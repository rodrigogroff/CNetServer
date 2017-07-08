using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_proprietario : type_base
	{
		public string input_st_cpf = "";
		
		public DadosProprietario output_cont_dp = new DadosProprietario();
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_proprietario ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_proprietario";
			constructor();
		}
		
		public fetch_proprietario()
		{
			var_Alias = "fetch_proprietario";
		
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
			Registry ( "setup fetch_proprietario " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_PROPRIETARIO.st_cpf, ref input_st_cpf ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_PROPRIETARIO.st_cpf missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_PROPRIETARIO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_PROPRIETARIO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_proprietario " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_proprietario " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_proprietario " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_proprietario " ); 
		
			/// USER [ execute ]
			
			T_Proprietario prot = new T_Proprietario (this);
			
			// ## Busca de proprietário pelo cpf
			
			if ( prot.select_rows_cpf ( input_st_cpf ) )
			{
				// ## por todos os registros
				
				if ( prot.fetch() )
				{
					// ## Copia dados para saida
					
					output_cont_dp.set_tg_found ( Context.TRUE );
						
					output_cont_dp.set_st_nome 			( prot.get_st_nome()		);
					output_cont_dp.set_st_endereco 		( prot.get_st_endereco()	);
					output_cont_dp.set_st_numero 		( prot.get_st_numero()		);
					output_cont_dp.set_st_complemento 	( prot.get_st_complemento()	);
					output_cont_dp.set_st_bairro 		( prot.get_st_bairro() 		);
					output_cont_dp.set_st_cidade 		( prot.get_st_cidade()		);
					output_cont_dp.set_st_UF 			( prot.get_st_UF()			);
					output_cont_dp.set_st_CEP 			( prot.get_st_cep() 		);
					output_cont_dp.set_st_ddd 			( prot.get_st_ddd()			);
					output_cont_dp.set_st_telefone 		( prot.get_st_telefone()	);
					
					DateTime ti = Convert.ToDateTime ( prot.get_dt_nasc() );
										
					output_cont_dp.set_dt_nasc 			( 	ti.Day.ToString().PadLeft 	( 2, '0' ) +
					                               			ti.Month.ToString().PadLeft ( 2, '0' ) + 
					                               			ti.Year.ToString() 		);
					
					output_cont_dp.set_st_email 		( prot.get_st_email()		);
					output_cont_dp.set_vr_renda 		( prot.get_vr_renda()		);
					output_cont_dp.set_id_instrucao		( "0"						);
				}
			}
			
			// ## Não encontrou CPF
			
			else
			{
				output_cont_dp.set_tg_found ( Context.FALSE );	
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_proprietario " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_proprietario " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_proprietario " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_cont_1 = new DataPortable();
		
			dp_cont_1.MapTagContainer ( COMM_OUT_FETCH_PROPRIETARIO.dp , output_cont_dp as DataPortable );
		
			var_Comm.AddExitPortable ( ref dp_cont_1 ); 
		
			return true;
		}
	}
}
