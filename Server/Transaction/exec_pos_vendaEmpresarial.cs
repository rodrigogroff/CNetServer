using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_pos_vendaEmpresarial : Transaction
	{
		public POS_Entrada input_cont_pe = new POS_Entrada();
		
		public string output_st_msg = "";
		
		public POS_Resposta output_cont_pr = new POS_Resposta();
		
		/// USER [ var_decl ]
		
		public string var_vr_total    	     	= "0";
		public string var_nu_parcelas 	  	 	= "0";
		public string var_operacaoCartao  	 	= "0";
		public string var_operacaoCartaoFail 	= "0";
		public string var_nu_nsuAtual     		= "0";
		public string var_nu_nsuOrig      		= "0";
		public string var_nu_nsuEntidade  		= "0";
		public string var_nu_nsuEntOrig   		= "0";
		public string var_codResp		  		= "0";
		
		public string var_nomeCliente	  		= "";
		
		public string var_dt_transacao = "";
		
		public T_Cartao 			cart;
		public T_Empresa 			emp;
		public T_Terminal 			term;
		public LOG_NSU 				l_nsu;
		public T_InfoAdicionais 	info; 
		public T_Proprietario 		prot; 
		public T_Loja 				loj; 
		
		long vr_dispMes, vr_dispTot, vr_valor;
		
		public bool IsDigitado = false;
		public string st_doc   = "";
		
		public ArrayList lstParcs = new ArrayList();
		
		/// USER [ var_decl ] END
		
		public exec_pos_vendaEmpresarial ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_pos_vendaEmpresarial";
			constructor();
		}
		
		public exec_pos_vendaEmpresarial()
		{
			var_Alias = "exec_pos_vendaEmpresarial";
		
			ut_max = 0;
			
			constructor();
		}
		
		public override void constructor()
		{
			/// USER [ constructor ]
			
			var_operacaoCartao     = OperacaoCartao.VENDA_EMPRESARIAL;
			var_operacaoCartaoFail = OperacaoCartao.FALHA_VENDA_EMPRESARIAL;
			
			/// USER [ constructor ] END
		}
		
		public override bool setup ( ) 
		{
			#region - SETUP TRANSACTION -
			Registry ( "setup exec_pos_vendaEmpresarial " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_EXEC_POS_VENDAEMPRESARIAL.pe, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_POS_VENDAEMPRESARIAL.pe missing! " ); 
				return false;
			}
			
			input_cont_pe.Import ( ct_0 );
			
			Registry ( "setup done exec_pos_vendaEmpresarial " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate exec_pos_vendaEmpresarial " ); 
		
			/// USER [ authenticate ]
			
			cart 	= new T_Cartao   		(this);
			emp 	= new T_Empresa  		(this);
			term 	= new T_Terminal 		(this);
			l_nsu   = new LOG_NSU    		(this);
			info 	= new T_InfoAdicionais 	(this);
			prot 	= new T_Proprietario 	(this);
			loj  	= new T_Loja 			(this);
			
			// Default é erro genérico
			var_codResp = "9999";

			// Normal
			var_nu_nsuAtual     = Context.NONE;
			var_nu_nsuEntidade  = Context.NONE;
			
			// Cancelamento
			var_nu_nsuOrig      = Context.NONE;
			var_nu_nsuEntOrig   = Context.NONE;
			
			// Valores básicos de comércio
			var_vr_total 		= input_cont_pe.get_vr_valor();
			var_nu_parcelas 	= input_cont_pe.get_nu_parcelas();
			
			var_codResp   		= "0606";

			#region - valida terminal - 
			
			// ## Busca terminal pelo seu código
			
            if ( !term.select_rows_terminal ( input_cont_pe.get_st_terminal() ) )
            {
            	output_st_msg = "Terminal inexistente";
            	var_codResp   = "0303";
            	return false;
            }
            
            if ( !term.fetch() )
            {
            	output_st_msg = "Erro aplicativo";
            	return false;
            }
            
            #endregion
            
            #region - valida empresa - 
                       
            // ## Busca empresa informada
            
            if ( !emp.select_rows_empresa ( input_cont_pe.get_st_empresa() ) )
            {
            	output_st_msg = "Empresa inexistente";
            	var_codResp   = "0303";
            	return false;
            }
            
            if ( !emp.fetch() )
            {
            	output_st_msg = "Erro de aplicativo";
            	return false;
            }
            
            // ## Caso empresa bloqueada, sair
            
            if ( emp.get_tg_bloq() == Context.TRUE )
            {
            	output_st_msg = "Empresa bloqueada";
            	var_codResp   = "0303";
            	return false;
            }
            
            #endregion
            
            #region - valida relação da Loja do Terminal com Empresa (Convênio)
            
            LINK_LojaEmpresa loj_emp = new LINK_LojaEmpresa (this);
            
            if ( !loj_emp.select_fk_empresa_loja ( emp.get_identity(), term.get_fk_loja() ) )
            {
            	output_st_msg = "Terminal não conveniado";
            	var_codResp   = "0303";            	
            	return false;
            }
            
            if ( !loj.selectIdentity  ( term.get_fk_loja() ) )
			{
            	output_st_msg = "Erro aplicativo";
            	return false;
            }
            
            if ( loj.get_tg_blocked() == Context.TRUE )
            {
            	output_st_msg = "Loja bloqueada";
            	var_codResp   = "0303";            	
            	return false;
            }
            
            if ( loj.get_tg_cancel() == Context.TRUE )
            {
            	output_st_msg = "Loja cancelada";
            	var_codResp   = "0303";            	
            	return false;
            }
            
            #endregion
            
            #region - valida cartão - 
            
            if ( !cart.select_rows_tudo ( input_cont_pe.get_st_empresa(),
     									 input_cont_pe.get_st_matricula(),
                                       	 input_cont_pe.get_st_titularidade() ) )
            {
            	output_st_msg = "Cartão inexistente";
            	var_codResp   = "0606";
            	return false;
            }
            
            if ( !cart.fetch() )
            {
            	output_st_msg = "Erro aplicativo";
            	return false;
            }
            
            // ## Verifica bloqueio 
            
			if ( cart.get_tg_status() == CartaoStatus.Bloqueado )
            {
            	output_st_msg = "Cartão inválido";
            	var_codResp   = "0505";
            	return false;
            }
			
			if ( cart.get_tg_emitido() != StatusExpedicao.Expedido )
            {
            	output_st_msg = "Cartão inválido";
            	var_codResp   = "0505";
            	return false;
            }
			
			if ( cart.get_tg_tipoCartao() == TipoCartao.educacional )
			{
				// ## No caso educacional, permitir somente venda 
				// ## em uma parcela
				
				if ( input_cont_pe.get_nu_parcelas().TrimStart ( '0' ) != "1" )
				{
					output_st_msg = "Somente uma parcela";
					var_codResp   = "0606";
	            	return false;
				}
			}
			
			// ## Conferir vencto do cartão
			/*
			if ( cart.get_tg_tipoCartao() == TipoCartao.empresarial )
			{
				int year  = 2000 + Convert.ToInt32 ( cart.get_st_venctoCartao().Substring ( 2,2 ) );
				int month = Convert.ToInt32 ( cart.get_st_venctoCartao().Substring ( 0,2 ) );
				int day   = 1;
				
	            DateTime tim_venc = new DateTime ( year, month, day );
				
	            if ( tim_venc < DateTime.Now )
				{
	            	output_st_msg     = "Cartão vencido";
	            	var_codResp       = "7676";
	            	return false;
				}
			}
			*/
			
			#endregion
			
			var_vr_total 		= input_cont_pe.get_vr_valor();
			var_nu_parcelas 	= input_cont_pe.get_nu_parcelas();
			
			SQL_LOGGING_ENABLE = false;
			
            #region - Verifica disponivel mensal nas parcelas - 

            T_Parcelas parc = new T_Parcelas (this);
            
            string myId = cart.get_identity();
            
            if ( cart.get_st_titularidade() != "01" )
            {
            	cart.select_rows_tudo ( cart.get_st_empresa(),
            	                       	cart.get_st_matricula(),
            	                       	"01" );
            	cart.fetch();
            }
            
            vr_dispMes = cart.get_int_vr_limiteMensal() + cart.get_int_vr_extraCota();
			vr_dispTot = cart.get_int_vr_limiteTotal() + cart.get_int_vr_extraCota();
				            
			vr_valor = Convert.ToInt64 ( input_cont_pe.get_vr_valor() );
			
			if ( cart.get_tg_tipoCartao() != TipoCartao.presente )
			{
				new ApplicationUtil().GetSaldoDisponivel ( ref cart, ref vr_dispMes, ref vr_dispTot );
				
				int tmp_nu_parc = Convert.ToInt32 ( input_cont_pe.get_nu_parcelas() );
				 
				if ( tmp_nu_parc > 1 )
				{
					if ( vr_valor > vr_dispTot )
					{
		        		output_st_msg = "limite excedido";
		        		var_codResp   = "2727" ;
		        		
		        		SQL_LOGGING_ENABLE = true;
		        		
		        		return false;
		        	}
					
					LOG_Transacoes  ltr 	 = new LOG_Transacoes 	( this );
					T_Parcelas 		parcTot  = new T_Parcelas 		( this );
					
					string tmp = input_cont_pe.get_st_valores();
					
					ArrayList lstCartoes = new ArrayList();
					
					T_Cartao c_t = new T_Cartao ( this );
					
					c_t.select_rows_empresa_matricula ( cart.get_st_empresa(), 
					                                    cart.get_st_matricula() );
					
					while ( c_t.fetch() )
						lstCartoes.Add ( c_t.get_identity() );
					
					for (int t=1, index_pos = 0; t <= tmp_nu_parc; ++t )
					{
						long valor_unit_parc = Convert.ToInt64 ( tmp.Substring ( index_pos, 12 ) );
						
						index_pos += 12;
					
						if ( valor_unit_parc > cart.get_int_vr_limiteMensal() )
						{
							output_st_msg = "limite excedido";
		        			var_codResp   = "2727" ;
		        			
		        			SQL_LOGGING_ENABLE = true;
		        			
		        			return false;
						}
						
						long dispMesParc = cart.get_int_vr_limiteMensal();
						
						// Verifica disponivel mensal nas parcelas
						if ( parcTot.select_rows_cartao_mensal ( ref lstCartoes, t.ToString() ) ) // este mês
			    		{
							while ( parcTot.fetch() )
							{
								if ( ltr.selectIdentity ( parcTot.get_fk_log_transacoes() ) ) // busca transação
								{
									if ( ltr.get_tg_confirmada() == TipoConfirmacao.Confirmada || 
							      		 ltr.get_tg_confirmada() == TipoConfirmacao.Pendente )
									{
										dispMesParc -= parcTot.get_int_vr_valor();
									}
								}
							}
						}
						
						if ( valor_unit_parc > dispMesParc )
						{
		    	    		output_st_msg = "limite excedido";
		        			var_codResp   = "2727" ;
		        			
		        			SQL_LOGGING_ENABLE = true;
		        			
		        			return false;
		        		}
					}					
				}
				else
				{
					if ( vr_valor > vr_dispMes || vr_valor > vr_dispTot )
					{
		        		output_st_msg = "limite excedido";
		        		var_codResp   = "2727" ;
		        		
		        		SQL_LOGGING_ENABLE = true;
		        		
		        		return false;
		        	}
				}
			}
			else
			{
				if ( vr_valor > cart.get_int_vr_limiteTotal() )
				{
	        		output_st_msg = "limite excedido";
	        		var_codResp   = "2727" ;
	        		
	        		SQL_LOGGING_ENABLE = true;
	        		
	        		return false;
	        	}
			}
			
			if ( myId != cart.get_identity() )
			{
				// restaurar cartão dep
				cart.selectIdentity ( myId );
			}
			
			#endregion
						
			SQL_LOGGING_ENABLE = true;
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_pos_vendaEmpresarial " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute exec_pos_vendaEmpresarial " ); 
		
			/// USER [ execute ]
			
            #region - atualizar senhas - 
            
			cart.ExclusiveAccess();
            	
        	if ( !cart.selectIdentity ( cart.get_identity() ) )
        	{
            	output_st_msg = "Erro aplicativo";
            	return false;
            }
        	       	
        	if ( !prot.selectIdentity ( cart.get_fk_dadosProprietario() ) )
			{
            	output_st_msg = "Erro aplicativo";
            	return false;
            }
    	
        	if ( cart.get_st_titularidade() != "01" )
        	{
        		T_Dependente dep = new T_Dependente (this);
        		
        		if ( !dep.select_rows_prop_tit (  cart.get_fk_dadosProprietario(), cart.get_st_titularidade() ) )
        		{
        			output_st_msg = "Erro aplicativo";
            		return false;
        		}
        		
        		if ( !dep.fetch() )
        		{
        			output_st_msg = "Erro aplicativo";
            		return false;
        		}
        		
        		var_nomeCliente = dep.get_st_nome();        		
        	}
        	else
        	{
	        	var_nomeCliente = prot.get_st_nome();
        	}
    	
        	if ( IsDigitado )
        	{
        		string cod_acesso = new ApplicationUtil().calculaCodigoAcesso (    cart.get_st_empresa(),
												                                   cart.get_st_matricula(),
												                                   cart.get_st_titularidade(),
												                                   cart.get_nu_viaCartao(),
												                                   prot.get_st_cpf() );
        		
        		Trace ( cod_acesso );
        		
        		if ( cod_acesso != input_cont_pe.get_st_senha() )
        		{
        			output_st_msg = "Senha inválida";
	            	var_codResp   = "4343";
					return false;
        		}
        	}
        	else
        	{
	            if ( cart.get_st_senha() != input_cont_pe.get_st_senha() )
	            {
		          	long senhasErradas = cart.get_int_nu_senhaErrada() + 1;
	            	
	            	cart.set_nu_senhaErrada ( senhasErradas.ToString() );
	            	
	            	if ( senhasErradas > 4 )
	            	{
	            		cart.set_tg_status 			( CartaoStatus.Bloqueado 		);
	            		cart.set_tg_motivoBloqueio 	( MotivoBloqueio.SENHA_ERRADA 	);
	            		cart.set_dt_bloqueio 		( GetDataBaseTime() 			);
	            	}
	            	
	            	if ( !cart.synchronize_T_Cartao() )
	        		{
	            		output_st_msg = "Erro aplicativo";
	            		return false;
	            	}
	            	
	            	output_st_msg = "Senha inválida";
	            	var_codResp   = "4343";
					return false;
	            }
	            else
	            {
	            	cart.set_nu_senhaErrada ( Context.NONE );
	            }
        	}
            
            if ( cart.get_tg_tipoCartao() == TipoCartao.presente )
            {
            	cart.set_vr_limiteTotal ( cart.get_int_vr_limiteTotal() - vr_valor );
            	
            	if ( !cart.synchronize_T_Cartao() )
	    		{
	        		output_st_msg = "Erro aplicativo";
	        		return false;
	        	}             
            }
            
            cart.ReleaseExclusive();
			
            #endregion
            
			#region - busca informações extras -
			            
			if ( !info.selectIdentity ( cart.get_fk_infoAdicionais() ) )
			{
				output_st_msg = "Erro aplicativo";
            	return false;
			}            
            
            #endregion
            
			#region - Faz efetivamente a venda -
						
			int 	tmp_nu_parc  = Convert.ToInt32 ( input_cont_pe.get_nu_parcelas() );
			int 	index_pos    = 0;
			
			string  tmp_variavel = input_cont_pe.get_st_valores();
			
			if ( tmp_variavel.Length < tmp_nu_parc * 12 )
			{
				output_st_msg = "formato incorreto";
				return false;				
			}
			
			if ( cart.get_tg_tipoCartao() != TipoCartao.presente )
			{
				if ( tmp_nu_parc > emp.get_int_nu_parcelas() )
				{
					output_st_msg = "excede max. parcelas";
					var_codResp   = "1212";
					return false;				
				}
			}
			
			#region - obtem nsu - 
						
			l_nsu.set_dt_log ( GetDataBaseTime() );
				
            if ( !l_nsu.create_LOG_NSU() )
            {
        		output_st_msg = "Erro aplicativo";
        		return false;
        	}
            
            #endregion
            
            var_nu_nsuAtual    = l_nsu.get_identity();
            var_nu_nsuEntidade = var_nu_nsuAtual;
			
			var_dt_transacao = GetDataBaseTime();
			
			// ## Criar parcelas
			
			for (int t=1; t <= tmp_nu_parc; ++t )
			{
				T_Parcelas parc = new T_Parcelas (this);
				
				string valor_unit_parc = tmp_variavel.Substring ( index_pos, 12 );
				
				index_pos += 12;
				
				#region - atribui valores e links à parcela - 
								
				parc.set_nu_nsu				( l_nsu.get_identity()		);
				parc.set_fk_empresa			( emp.get_identity()		);
				parc.set_fk_cartao			( cart.get_identity()		);
				parc.set_dt_inclusao		( var_dt_transacao			);
				parc.set_nu_parcela			( t.ToString()				);
				parc.set_vr_valor			( valor_unit_parc      	 	);
				parc.set_nu_indice			( t.ToString()				); 
				parc.set_tg_pago			( TipoParcela.EM_ABERTO		);
				parc.set_fk_loja			( loj.get_identity()		);
				parc.set_nu_tot_parcelas	( tmp_nu_parc.ToString() 	);
				parc.set_fk_terminal		( term.get_identity()		);
				
				#endregion
				
				if ( !parc.create_T_Parcelas() )
				{
					output_st_msg = "erro aplicativo";
					return false;				
				}
				
				lstParcs.Add ( parc.get_identity() );
			}
							
			#endregion
			
			var_codResp = "0000";
				
			/// USER [ execute ] END
		
			Registry ( "execute done exec_pos_vendaEmpresarial " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish exec_pos_vendaEmpresarial " ); 
		
			/// USER [ finish ]
			     
			if ( IsFail )
			{
				// ## Nsu não foi criado!
				l_nsu.set_dt_log ( GetDataBaseTime() );
				
	            if ( !l_nsu.create_LOG_NSU() )
	            {
	        		output_st_msg = "Erro aplicativo";
	        		return false;
	        	}
	            
	            var_nu_nsuAtual    = l_nsu.get_identity();
	            var_operacaoCartao = var_operacaoCartaoFail;
			}		

			// ## Copiar dados para saída
			
			output_cont_pr.set_st_codResp 		( var_codResp							);
			output_cont_pr.set_st_nsuRcb 		( var_nu_nsuAtual.PadLeft ( 6, '0' ) 	);
			
			output_cont_pr.set_st_nsuBanco 		( 	new StringBuilder().Append ( DateTime.Now.Year.ToString() 		)
										                               .Append ( DateTime.Now.Month.ToString("00")  )
										                               .Append ( DateTime.Now.Day.ToString("00") 	)
										                               .Append ( var_nu_nsuAtual.PadLeft ( 6, '0')  ).ToString() );
			
			output_cont_pr.set_st_PAN			( cart.get_st_empresa() + cart.get_st_matricula() );
			
			output_cont_pr.set_st_mesPri		( Context.EMPTY  				);
			output_cont_pr.set_st_loja 			( loj.get_st_loja() 			);
			output_cont_pr.set_st_nomeCliente 	( var_nomeCliente				);
			
			output_cont_pr.set_st_variavel 		( info.get_st_empresaAfiliada() );
			
			LOG_Transacoes l_tr = new LOG_Transacoes (this);
			
			#region - registra a transação - 
			
			l_tr.set_fk_terminal		( term.get_identity()				);
			l_tr.set_fk_empresa			( emp.get_identity()				);
			l_tr.set_fk_cartao			( cart.get_identity()				);
			l_tr.set_vr_total			( var_vr_total						);
			l_tr.set_nu_parcelas		( var_nu_parcelas					);
			l_tr.set_nu_nsu 			( var_nu_nsuAtual	 				);
			l_tr.set_dt_transacao		( GetDataBaseTime()					);
			l_tr.set_nu_cod_erro 		( output_cont_pr.get_st_codResp() 	);
			l_tr.set_nu_nsuOrig			( var_nu_nsuOrig 					);
			l_tr.set_en_operacao		( var_operacaoCartao				);
			l_tr.set_st_msg_transacao 	( output_st_msg 					);
			l_tr.set_fk_loja			( term.get_fk_loja()				);
			l_tr.set_st_doc				( st_doc 							);
			
			if ( IsFail )
			{
				l_tr.set_tg_confirmada	( TipoConfirmacao.Erro				);
				l_tr.set_tg_contabil 	( Context.FALSE 					);
			}
			else
			{
				l_tr.set_tg_confirmada	( TipoConfirmacao.Pendente			);
				l_tr.set_tg_contabil 	( Context.TRUE 						);
			}
			
			if ( cart.get_tg_tipoCartao() == TipoCartao.educacional )
			{
				l_tr.set_vr_saldo_disp		( cart.get_vr_disp_educacional()	);
				l_tr.set_vr_saldo_disp_tot	( cart.get_vr_educacional()			);
			}
			else
			{
				l_tr.set_vr_saldo_disp		( vr_dispMes.ToString()	);
				l_tr.set_vr_saldo_disp_tot	( vr_dispTot.ToString() 	);
			}
			
			#endregion
			
			l_tr.create_LOG_Transacoes();		
			
			#region - vincula parcelas com a transação - 
					
			T_Parcelas parc_upd = new T_Parcelas (this);
			
			// ## Como o registro da transação é feito depois,
			// ## vincular as parcelas com este mesmo registro.
			
			for ( int t=0; t < lstParcs.Count; ++t )
			{
				parc_upd.ExclusiveAccess();
				
				if ( parc_upd.selectIdentity ( lstParcs[t].ToString() ) )
				{
					parc_upd.set_fk_log_transacoes ( l_tr.get_identity() );
					
					parc_upd.synchronize_T_Parcelas();
				}
				
				parc_upd.ReleaseExclusive();
            }
			
			#endregion
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_pos_vendaEmpresarial " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_EXEC_POS_VENDAEMPRESARIAL.st_msg, output_st_msg ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			DataPortable dp_cont_1 = new DataPortable();
		
			dp_cont_1.MapTagContainer ( COMM_OUT_EXEC_POS_VENDAEMPRESARIAL.pr , output_cont_pr as DataPortable );
		
			var_Comm.AddExitPortable ( ref dp_cont_1 ); 
		
			return true;
		}
	}
}
