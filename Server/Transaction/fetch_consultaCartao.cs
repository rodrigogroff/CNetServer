using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_consultaCartao : type_base
	{
		public DadosConsultaCartoes input_cont_dcc = new DadosConsultaCartoes();
		
		public string output_st_csv_cartao = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_consultaCartao ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_consultaCartao";
			constructor();
		}
		
		public fetch_consultaCartao()
		{
			var_Alias = "fetch_consultaCartao";
		
			ut_max = 0;
			
			constructor();
		}
		
		public override void constructor()
		{
			/// USER [ constructor ]
			/// USER [ constructor ] END
		}
		
		public override bool setup ( ) 
		{
			#region - SETUP TRANSACTION -
			Registry ( "setup fetch_consultaCartao " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_FETCH_CONSULTACARTAO.dcc, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CONSULTACARTAO.dcc missing! " ); 
				return false;
			}
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_CONSULTACARTAO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CONSULTACARTAO.header missing! " ); 
				return false;
			}
			
			input_cont_dcc.Import ( ct_0 );
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_consultaCartao " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_consultaCartao " ); 
		
			/// USER [ authenticate ]
			
			input_cont_dcc.set_st_empresa ( input_cont_dcc.get_st_empresa().PadLeft ( 6, '0' ) );
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_consultaCartao " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_consultaCartao " ); 
		
			/// USER [ execute ]
			
			// ## Filtro para busca de cartões
			
			StringBuilder 	sb   = new StringBuilder();
			
			T_Cartao 		cart = new T_Cartao (this);
			T_Proprietario 	prot = new T_Proprietario (this);
			T_Parcelas 		parc = new T_Parcelas (this);
			
			ApplicationUtil util = new ApplicationUtil();
			
			string st_cart = input_cont_dcc.get_st_cartao();
			string st_cpf  = input_cont_dcc.get_st_cpf();
			
			// ## Se for cartão especifico
			
			if ( st_cart.Length > 0 )
			{
				// admin ou oper
				if ( input_cont_dcc.get_st_empresa().Length > 0 )
				{
					if ( !cart.select_rows_empresa_matricula ( input_cont_dcc.get_st_empresa(),
					                                          st_cart.PadLeft ( 6, '0' ) ) )
						return true;
					
					
				}
				else // root
				{
					if ( !cart.select_rows_mat ( st_cart.PadLeft ( 6, '0' ) ) )
						return true;
				}
			}
			
			// ## Se cpf ou cnpj for informado
			
			else if ( st_cpf.Length > 0 )
			{
				if ( prot.select_rows_cpf ( st_cpf ) )
				{
					prot.fetch();
				
					if ( !cart.select_rows_prop ( prot.get_identity() ) )
						return true;
				}
			}
			
			// ## Se for de código de empresa específica
			
			else if ( input_cont_dcc.get_st_empresa().Length > 0 )
			{
				if ( !cart.select_rows_empresa ( input_cont_dcc.get_st_empresa() ) )
					return true;
			}
			
			// ## Busca todos registros
			
			else 
			{
				if ( !cart.selectAll() )
					return true;
			}
			
			bool 	nome      = false,
					total     = false,
					mensal    = false,
					cotaExtra = false,
					cidade    = false,
					estado    = false;
			
			string 	st_nome   = input_cont_dcc.get_st_nome().ToUpper(),
					st_cidade = input_cont_dcc.get_st_cidade(),
					st_estado = input_cont_dcc.get_st_estado(),
					expedido  = input_cont_dcc.get_tg_expedido();
			
			int i_total = 0, 
				i_mensal = 0, 
				i_cota = 0;
					
			// ## Prepara flags de filtro
			
			if ( st_nome.Length 							> 0 )	nome = true;
			if ( input_cont_dcc.get_vr_limTotal().Length 	> 0 )	total = true;
			if ( input_cont_dcc.get_vr_limMensal().Length	> 0 )	mensal = true;
			if ( input_cont_dcc.get_vr_cotaExtra().Length 	> 0 )	cotaExtra = true;
			if ( st_cidade.Length 							> 0 )	cidade = true;
			if ( st_estado.Length 							> 0 )	estado = true;
			
			// ## Obtem valores rápidos para comparação
			
			if ( total ) 		i_total  = Convert.ToInt32 ( input_cont_dcc.get_vr_limTotal() );
			if ( mensal ) 		i_mensal = Convert.ToInt32 ( input_cont_dcc.get_vr_limMensal() );
			if ( cotaExtra ) 	i_cota 	 = Convert.ToInt32 ( input_cont_dcc.get_vr_cotaExtra() );
			
			// ## Busca todos os registros selecionados
			
			bool todos     = false;
			bool hab       = false;
			bool bloq      = false;
			bool canc      = false;
			bool adminGift = false;
			
			if ( input_cont_dcc.get_tg_bloqueado() == "3" ) // todos
			{
				todos = true;
			}
			else
			{
				if ( input_cont_dcc.get_tg_bloqueado() == Context.FALSE ) // 0
					hab = true;
				else if ( input_cont_dcc.get_tg_bloqueado() == Context.TRUE ) // 1
					bloq = true;
				else 
					canc = true; // 2
			}	
			
			if ( input_cont_header.get_tg_user_type() == TipoUsuario.AdminGift )
				adminGift = false;
			
			T_Dependente dep_f = new T_Dependente(this);
			T_Cartao  cart_prop = new T_Cartao (this);
			
			while ( cart.fetch() )
			{
				string dep = "";
				
				if ( cart.get_tg_emitido() != expedido )
					continue;
				
				if ( adminGift )
					if ( cart.get_fk_dadosProprietario() == "0" )
						continue;
				
				if ( !todos )
				{
					if ( bloq )
					{
						if ( cart.get_tg_status() != CartaoStatus.Bloqueado )
						{
							continue;
						}
					}
					else if ( canc )
					{
						if ( cart.get_tg_status() != CartaoStatus.Bloqueado )
							continue;
						
						if ( cart.get_tg_status() == CartaoStatus.Bloqueado && 
						     cart.get_tg_motivoBloqueio() != MotivoBloqueio.CANCELAMENTO )
						{
							continue;
						}
					}
					else if ( hab )
					{
						if ( cart.get_tg_status() != CartaoStatus.Habilitado )
						{
							continue;
						}
					}
				}
				
				if ( total )
					if ( cart.get_int_vr_limiteTotal() < i_total )
						continue;
				
				if ( mensal )
					if ( cart.get_int_vr_limiteMensal() < i_mensal )
						continue;
				
				if ( cotaExtra )
					if ( cart.get_int_vr_extraCota() < i_cota )
						continue;
				
				if ( cart.get_fk_dadosProprietario() != Context.NONE )
					if ( !prot.selectIdentity ( cart.get_fk_dadosProprietario() ) )
						return false;
				
				if ( cidade )
					if ( !prot.get_st_cidade().Contains ( st_cidade ) )
						continue;
				
				if ( estado )
					if ( !prot.get_st_UF().Contains ( st_estado ) )
						continue;
				
				if ( cart.get_st_titularidade() != "01" )
				{
					if ( !dep_f.select_rows_prop_tit ( 	cart.get_fk_dadosProprietario(), cart.get_st_titularidade() ) )
						continue;
					
					if ( !dep_f.fetch() )
						continue;
						
					dep = dep_f.get_st_nome().ToUpper();
								
					// Dependente
					if ( nome )
						if ( !dep.Contains ( st_nome ) )
							continue;
				}
				else
				{
					if ( nome )
						if ( !prot.get_st_nome().ToUpper().Contains ( st_nome ) )
							continue;
				}

				DadosCartao dc = new DadosCartao ();
							
				dc.set_st_empresa		( cart.get_st_empresa() 		);
				dc.set_st_matricula		( cart.get_st_matricula() 		);
				
				dc.set_st_titularidade	( cart.get_st_titularidade() + ":" + 
				                          cart.get_nu_viaCartao()   	);
				
				if ( cart.get_fk_dadosProprietario() != Context.NONE )
				{
					if ( dep.Length > 0 )
						dc.set_st_proprietario	( dep );
					else
						dc.set_st_proprietario	( prot.get_st_nome() 			);
					
					dc.set_st_cpf 			( prot.get_st_cpf()				);
				}
				
				dc.set_tg_status ( cart.get_tg_status() );
				
				if ( cart.get_tg_tipoCartao() == TipoCartao.presente )
				{
					dc.set_vr_limiteTotal	( "0" );
					dc.set_vr_limiteMensal	( "0" );
					dc.set_vr_extraCota		( "0" );
					dc.set_vr_dispMes		( "0" );
					dc.set_vr_dispTotal		( cart.get_vr_limiteTotal() 	);
				}
				else
				{
					long dispMensal = 0,
						 dispTotal  = 0;
						 
					if ( cart.get_st_titularidade() != "01" )
					{
						if ( !cart_prop.select_rows_tudo ( 	cart.get_st_empresa(),
						                            		cart.get_st_matricula(),
						                            		"01" ) )
						{
							continue;
						}
						
						if ( !cart_prop.fetch() )
							continue;
						
						dc.set_vr_limiteTotal	( cart_prop.get_vr_limiteTotal() 	);
						dc.set_vr_limiteMensal	( cart_prop.get_vr_limiteMensal() 	);
						dc.set_vr_extraCota		( cart_prop.get_vr_extraCota() 		);
						
						dispMensal = cart_prop.get_int_vr_limiteMensal() + cart_prop.get_int_vr_extraCota();
						dispTotal  = cart_prop.get_int_vr_limiteTotal() + cart_prop.get_int_vr_extraCota();
					}
					else
					{
						dc.set_vr_limiteTotal	( cart.get_vr_limiteTotal() 	);
						dc.set_vr_limiteMensal	( cart.get_vr_limiteMensal() 	);
						dc.set_vr_extraCota		( cart.get_vr_extraCota() 		);
						
						dispMensal = cart.get_int_vr_limiteMensal() + cart.get_int_vr_extraCota();
						dispTotal  = cart.get_int_vr_limiteTotal() + cart.get_int_vr_extraCota();
					}
					
					// ## Obtem saldo disponível
						 
					util.GetSaldoDisponivel ( ref cart, ref dispMensal, ref dispTotal );
					
					dc.set_vr_dispMes		( dispMensal.ToString() );
					dc.set_vr_dispTotal		( dispTotal.ToString()  );
				}
				
				DataPortable tmp = dc as DataPortable;
				
				// ## obtem identificador
				
				sb.Append ( MemorySave ( ref tmp ) );
				sb.Append ( "," 				 	  );
			}
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
			
			if ( list_ids == "" )
			{
				PublishNote ( "Nenhum resultado foi encontrado" );
				return true;
			}
											
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
			
			// ## Copia para saida um identificador de bloco
						  
			output_st_csv_cartao = MemorySave ( ref dp );
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_consultaCartao " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_consultaCartao " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_consultaCartao " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_CONSULTACARTAO.st_csv_cartao, output_st_csv_cartao ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
