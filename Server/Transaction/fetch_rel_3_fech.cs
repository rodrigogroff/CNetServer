using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_rel_3_fech : type_base
	{
		public string input_en_tipo = "";
		public string input_st_mes = "";
		public string input_st_ano = "";
		public string input_st_cod_empresa = "";
		public string input_st_afiliada = "";
		
		public string output_st_empresa = "";
		public string output_st_csv_cartao = "";
		public string output_st_csv_loja = "";
		public string output_st_csv_loja_content = "";
		public string output_st_csv_subtotal_loja = "";
		public string output_st_csv_subtotal_cartao = "";
		public string output_st_csv_cartao_content = "";
		public string output_st_total = "";
		
		/// USER [ var_decl ]

		T_Empresa emp;
		LOG_Fechamento log_fech;		
		
		/// USER [ var_decl ] END
		
		public fetch_rel_3_fech ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_rel_3_fech";
			constructor();
		}
		
		public fetch_rel_3_fech()
		{
			var_Alias = "fetch_rel_3_fech";
		
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
			Registry ( "setup fetch_rel_3_fech " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_3_FECH.en_tipo, ref input_en_tipo ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_3_FECH.en_tipo missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_3_FECH.st_mes, ref input_st_mes ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_3_FECH.st_mes missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_3_FECH.st_ano, ref input_st_ano ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_3_FECH.st_ano missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_3_FECH.st_cod_empresa, ref input_st_cod_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_3_FECH.st_cod_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_3_FECH.st_afiliada, ref input_st_afiliada ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_3_FECH.st_afiliada missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_REL_3_FECH.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_REL_3_FECH.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_rel_3_fech " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_rel_3_fech " ); 
		
			/// USER [ authenticate ]
			
			input_st_mes 		 = input_st_mes.PadLeft ( 2, '0' );
			input_st_cod_empresa = input_st_cod_empresa.PadLeft ( 6, '0' );
			
			// ## Busca empresa envolvida
			
			emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_st_cod_empresa ) )
			{
				PublishError ( "Empresa inválida" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			output_st_empresa = emp.get_st_fantasia();
			
			log_fech = new LOG_Fechamento(this);
			
			// ## Busca fechamento por período
			
			if ( !log_fech.select_rows_mes_ano ( input_st_mes, input_st_ano, emp.get_identity() ) )
			{
				PublishError ( "Nenhum registro encontrado" );
				return false;
			}
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_rel_3_fech " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_rel_3_fech " ); 
		
			/// USER [ execute ]
			
			// ## 
			// ## O seguinte trecho indexa as lojas possíveis
			// ## de retorno para uma determinada empresa.
			// ## 
			// ## E, no caso de a empresa original ser administradora
			// ## de empresas, indexar todas as lojas de todas empresas
			// ## desta rede.
			// ## 
			
			Hashtable hshLojas = new Hashtable();
			
			T_Loja 		loj  = new T_Loja 		(this);
			T_Parcelas 	parc = new T_Parcelas 	(this);
			T_Cartao 	cart = new T_Cartao 	(this);
			T_Terminal  term = new T_Terminal   (this);
			T_Proprietario prot = new T_Proprietario (this);
			LINK_LojaEmpresa loj_emp = new LINK_LojaEmpresa (this);
			
			string aff = "";
			
			switch ( input_en_tipo )
			{
				case "0":	// por Loja
				{
					#region Por Loja
					
					Hashtable 	hsh_loja           = new Hashtable();
					Hashtable 	hsh_sub_total_loja = new Hashtable();
					
					StringBuilder 	sb = new StringBuilder();
					
					long nu_total_empresa = 0;
					
					ArrayList lstLojas = new ArrayList();
										
					// ## Busca registros
					
					while ( log_fech.fetch() )
					{
						if ( aff == "" )
							aff = " - " + log_fech.get_st_afiliada();

						// ## Busca tabelas auxiliares
						
						if ( !loj.selectIdentity ( log_fech.get_fk_loja() ) )
							return false;
						
						if ( !cart.selectIdentity ( log_fech.get_fk_cartao() ) )
							return false;
						
						if ( !prot.selectIdentity ( cart.get_fk_dadosProprietario() ) )
							return false;
						
						if ( !parc.selectIdentity ( log_fech.get_fk_parcela() ) )
							return false;
						
						if ( !term.selectIdentity ( parc.get_fk_terminal() ) )
							return false;
						
						if ( input_st_afiliada != "" )
							if ( log_fech.get_st_afiliada() != input_st_afiliada )
								continue;
						
						string pct = "000";
						
						if ( loj_emp.select_fk_empresa_loja ( emp.get_identity(), loj.get_identity() ) )
						{
							if ( loj_emp.fetch() )
							{
								pct = loj_emp.get_tx_admin();
							}
						}
						
						double 	 tx   = loj_emp.get_int_tx_admin();
						
						pct = pct.PadLeft ( 3, '0' );
						pct = pct.Insert ( pct.Length -2, "." ) + "%";
						
						string st_loja = loj.get_st_nome() + " - Perc.: " + pct + "<br>" + loj.get_st_social() + " - CNPJ: " + loj.get_nu_CNPJ();
												
						// ## Guarda nomes de lojas
						
						if ( hsh_loja [ st_loja ] == null )
						{
							hsh_sub_total_loja [ st_loja ] = (long) 0;
							hsh_loja           [ st_loja ] = "*";
							
							lstLojas.Add ( st_loja );
						}
							
						long valor      = log_fech.get_int_vr_valor();
						long sub_loja   = (long) hsh_sub_total_loja [ st_loja ];
						
						nu_total_empresa += valor;
						
						hsh_sub_total_loja [ st_loja ] = sub_loja + valor;
						
						// ## Grava registro em memória
						
						DadosFechamento df = new DadosFechamento();
						
						df.set_st_cartao   ( 	cart.get_st_empresa() + "." +
						                    	cart.get_st_matricula() + "." +
						                    	cart.get_st_titularidade()  );
						
						df.set_st_terminal ( term.get_nu_terminal() 		);
						df.set_st_loja 	   ( st_loja 						);
						df.set_st_nsu 	   ( parc.get_nu_nsu() 				);
						df.set_dt_trans    ( parc.get_dt_inclusao() 		);
						df.set_vr_valor    ( log_fech.get_vr_valor() 		);
						
						df.set_st_nome     ( prot.get_st_nome() 			);
						
						long repasse = Convert.ToInt64 ( log_fech.get_int_vr_valor() - ( log_fech.get_int_vr_valor() * tx / 10000 ) );
						
						df.set_vr_repasse  ( repasse.ToString() );
						
						df.set_nu_parcela  ( 	parc.get_nu_indice() + 
						                    	"/" + 
						                    	parc.get_nu_tot_parcelas() );
												
						DataPortable mem_rlt = df as DataPortable;
				
						// ## Gera identificador
						
						sb.Append ( MemorySave ( ref mem_rlt ) );
						sb.Append ( ","   );			
					}
					
					output_st_total = nu_total_empresa.ToString();
										
					string list_ids = sb.ToString().TrimEnd ( ',' );
					
					if ( list_ids == "" )
					{
						PublishNote ( "Nenhum registro encontrado" );
						return false;
					}
									
					DataPortable dp = new DataPortable();
					
					dp.setValue ( "ids", list_ids );
								  
					// ## gera identificador de todos os registros
					
					output_st_csv_loja_content = MemorySave ( ref dp );
					
					lstLojas.Sort();
					
					for ( int t=0; t < lstLojas.Count; ++t )
					{
						string loja = lstLojas[t].ToString();
						
						long   sub_total = (long) hsh_sub_total_loja [ loja ];
						
						output_st_csv_subtotal_loja += sub_total.ToString() + ",";
						output_st_csv_loja          += loja + ",";
					}
					
					output_st_csv_loja          = output_st_csv_loja.TrimEnd ( ',' );
					output_st_csv_subtotal_loja = output_st_csv_subtotal_loja.TrimEnd ( ',' );
					
					#endregion
					
					break;
				}
					
				case "1": // por cartao
				{
					#region Por Cartao 
						
					Hashtable 		hsh_cartao           = new Hashtable();
					Hashtable 		hsh_sub_total_cartao = new Hashtable();
					
					StringBuilder 	sb = new StringBuilder();
					
					long nu_total_cartao = 0;
					
					ArrayList lstCart = new ArrayList();
						
					while ( log_fech.fetch() )
					{
						if ( aff == "" )
							if ( log_fech.get_st_afiliada().Trim().Length != 0 )
								aff = " - " + log_fech.get_st_afiliada();
						
						if ( !loj.selectIdentity ( log_fech.get_fk_loja() ) )
							return false;
						
						if ( !parc.selectIdentity ( log_fech.get_fk_parcela() ) )
							return false;
						
						if ( !cart.selectIdentity ( log_fech.get_fk_cartao() ) )
							return false;
												
						if ( !prot.selectIdentity ( cart.get_fk_dadosProprietario() ) )
						    return false;
						
						string cartao = prot.get_st_nome() 		+ "<br>CPF: " + 
										prot.get_st_cpf() 		+ " Cartão: " + 
										cart.get_st_empresa() 	+ "." + 
										cart.get_st_matricula() + "<br>";
							
						if ( hsh_cartao [ cartao ] == null )
						{
							hsh_sub_total_cartao [ cartao ] = (long) 0;
							hsh_cartao           [ cartao ] = "*";
							
							lstCart.Add ( cartao );
						}
						
						long valor      = log_fech.get_int_vr_valor();
						long sub_cartao = (long) hsh_sub_total_cartao [ cartao ];
						
						nu_total_cartao                 += valor;
						hsh_sub_total_cartao [ cartao ]  = sub_cartao + valor;	
						
						DadosFechamento df = new DadosFechamento();
						
						df.set_st_cartao   	( cartao	);
						
						df.set_st_loja 	   	( "(" + loj.get_st_loja() +") " + loj.get_st_nome()	);
						df.set_st_nsu 	  	( parc.get_nu_nsu() 								);
						df.set_dt_trans  	( parc.get_dt_inclusao() 							);
						df.set_vr_valor   	( log_fech.get_vr_valor() 							);
						df.set_st_cnpj    	( loj.get_nu_CNPJ()									);
						df.set_st_matricula ( cart.get_st_matricula() 							);
						
						df.set_nu_parcela ( parc.get_nu_indice() + 
						                   	"/" + 
						                   	parc.get_nu_tot_parcelas() );
												
						DataPortable mem_rlt = df as DataPortable;
				
						sb.Append ( MemorySave ( ref mem_rlt ) );
						sb.Append ( ","   );			
					}
					
					output_st_total = nu_total_cartao.ToString();
										
					string list_ids = sb.ToString().TrimEnd ( ',' );
									
					DataPortable dp = new DataPortable();
					
					dp.setValue ( "ids", list_ids );
								  
					output_st_csv_cartao_content = MemorySave ( ref dp );
				
					lstCart.Sort();
					
					for ( int t=0; t < lstCart.Count; ++t )
					{
						string st_cart = lstCart[t].ToString();
						
						long sub_total = (long) hsh_sub_total_cartao [ st_cart ];
						
						output_st_csv_subtotal_cartao += sub_total.ToString() + ",";
						output_st_csv_cartao          += st_cart + ",";
					}
					
					output_st_csv_subtotal_cartao = output_st_csv_subtotal_cartao.TrimEnd ( ',' );
					output_st_csv_cartao          = output_st_csv_cartao.TrimEnd ( ',' );
					
					#endregion
					
					break;
				}
			}
			
			output_st_empresa += aff;
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_rel_3_fech " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_rel_3_fech " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_rel_3_fech " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_3_FECH.st_empresa, output_st_empresa ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_3_FECH.st_csv_cartao, output_st_csv_cartao ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_3_FECH.st_csv_loja, output_st_csv_loja ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_3_FECH.st_csv_loja_content, output_st_csv_loja_content ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_3_FECH.st_csv_subtotal_loja, output_st_csv_subtotal_loja ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_3_FECH.st_csv_subtotal_cartao, output_st_csv_subtotal_cartao ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_3_FECH.st_csv_cartao_content, output_st_csv_cartao_content ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_3_FECH.st_total, output_st_total ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
