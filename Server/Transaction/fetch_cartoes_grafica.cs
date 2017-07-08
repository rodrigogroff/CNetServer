using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_cartoes_grafica : type_base
	{
		public string input_st_empresa = "";
		
		public string output_st_csv = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_cartoes_grafica ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_cartoes_grafica";
			constructor();
		}
		
		public fetch_cartoes_grafica()
		{
			var_Alias = "fetch_cartoes_grafica";
		
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
			Registry ( "setup fetch_cartoes_grafica " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CARTOES_GRAFICA.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CARTOES_GRAFICA.st_empresa missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_CARTOES_GRAFICA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CARTOES_GRAFICA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_cartoes_grafica " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_cartoes_grafica " ); 
		
			/// USER [ authenticate ]
			
			input_st_empresa =input_st_empresa.PadLeft ( 6, '0' );
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_cartoes_grafica " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_cartoes_grafica " ); 
		
			/// USER [ execute ]
			
			StringBuilder sb = new StringBuilder();
			
			T_Cartao 		cart     = new T_Cartao(this);
			T_Cartao 		cart_upd = new T_Cartao(this);
			T_Proprietario 	prot     = new T_Proprietario (this);
			T_Empresa 		emp      = new T_Empresa(this);
			
			ApplicationUtil util = new ApplicationUtil();
			
			// ## Busca empresa informada
			
			if ( !emp.select_rows_empresa ( input_st_empresa ) )
			{
				PublishError ( "Empresa inválida" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			string nome_empresa = emp.get_st_fantasia().PadRight ( 25, ' ' );
			
			// ## Busca todos cartões vinculados à empresa
			
			if ( cart.select_rows_empresa ( input_st_empresa ) )
			{
				while ( cart.fetch() )
				{
					// ## Se cartão não estiver expedido...
					
					if ( cart.get_tg_emitido() == StatusExpedicao.NaoExpedido )
					{
						DadosExpedicao port = new DadosExpedicao();
						
						string line = "+";
						
						string nome = "";
						
						if ( cart.get_tg_tipoCartao() == TipoCartao.presente )
						{
							nome = "";
						}
						else
						{
							if ( !prot.selectIdentity ( cart.get_fk_dadosProprietario() ) )
								return false;
							
							nome = prot.get_st_nome();
							
							T_Dependente dep_f = new T_Dependente(this);
				
							if ( dep_f.select_rows_prop_tit ( 	cart.get_fk_dadosProprietario(), 
							                                 	cart.get_st_titularidade() ) )
							{
								if ( dep_f.fetch() )
									nome = dep_f.get_st_nome();
							}
						}
						
						line += nome					    + ",";
						line += cart.get_st_empresa() 		+ ",";
						line += cart.get_st_matricula() 	+ ",";
						
						cart.set_st_venctoCartao ( cart.get_st_venctoCartao().PadLeft ( 4, '0' ) );
						
						line += cart.get_st_venctoCartao().Substring (0,2) + "/" + 
							    cart.get_st_venctoCartao().Substring (2,2) 	+ ",";
						
						if ( cart.get_tg_tipoCartao() == TipoCartao.presente )
						{
							line += util.calculaCodigoAcesso ( cart.get_st_empresa(),
							                                   cart.get_st_matricula(),
							                                   cart.get_st_venctoCartao() );
						}
						else
						{
							line += util.calculaCodigoAcesso ( cart.get_st_empresa(),
							                                   cart.get_st_matricula(),
							                                   cart.get_st_titularidade(),
							                                   cart.get_nu_viaCartao(),
							                                   prot.get_st_cpf() );
						}
							
						line += ",";
						line += nome + ",";
						
						// # Trilha
						
						line += "|";
						
						line += "826766" + 	cart.get_st_empresa() + 
											cart.get_st_matricula() + 
											cart.get_st_titularidade() + 
											cart.get_nu_viaCartao() + 
							     "65" + 	cart.get_st_venctoCartao();
							
						line += "|";
						
						port.set_st_line ( line );
						
						// ## Salva em memória
						
						DataPortable mem_port = port as DataPortable;
					
						sb.Append ( MemorySave ( ref mem_port ) );
						sb.Append ( ","   );
						
						// ## Atualiza estado do cartão para 'em expedição'
						
						cart_upd.ExclusiveAccess();
						
						if ( !cart_upd.selectIdentity ( cart.get_identity() ) )
							return false;
						
						cart_upd.set_tg_emitido ( StatusExpedicao.EmExpedicao );
						
						// ## Atualiza
						
						if ( !cart_upd.synchronize_T_Cartao() )
							return false;
						
						cart_upd.ReleaseExclusive();
					}
				}
			}
			
			// ## Gera bloco de linhas em um identificador
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
			
			if ( list_ids == "" )
			{
				PublishError ( "Nenhum cartão encontrado para ser expedido à grafica" );
				return false;
			}
									
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
			
			// ## Copia para saída
						  
			output_st_csv = MemorySave ( ref dp );
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_cartoes_grafica " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_cartoes_grafica " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.GeraArqGrafica       );
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( "" );
				
				aud.set_fk_generic  ( 0 );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_cartoes_grafica " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_CARTOES_GRAFICA.st_csv, output_st_csv ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
