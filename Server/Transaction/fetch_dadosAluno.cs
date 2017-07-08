using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_dadosAluno : type_base
	{
		public string input_st_cartao = "";
		
		public DadosCartaoEdu output_cont_dce = new DadosCartaoEdu();
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_dadosAluno ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_dadosAluno";
			constructor();
		}
		
		public fetch_dadosAluno()
		{
			var_Alias = "fetch_dadosAluno";
		
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
			Registry ( "setup fetch_dadosAluno " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_DADOSALUNO.st_cartao, ref input_st_cartao ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_DADOSALUNO.st_cartao missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_DADOSALUNO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_DADOSALUNO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_dadosAluno " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_dadosAluno " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_dadosAluno " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_dadosAluno " ); 
		
			/// USER [ execute ]
			
			input_st_cartao = input_st_cartao.PadLeft ( 14, '0' );
			
			T_Cartao cart = new T_Cartao (this);
			
			// ## Busca dados de cartão específico de aluno
			
			if ( !cart.select_rows_tudo ( input_st_cartao.Substring (  0,6 ),
			                              input_st_cartao.Substring (  6,6 ),
			                              input_st_cartao.Substring ( 12,2 ) ) )
          	{
				PublishError ( "Cartão inválido" );
				return false;
          	}
			
			if ( !cart.fetch() )
				return false;
			
			// ## Copia para saída
						
			output_cont_dce.set_st_aluno  ( cart.get_st_aluno() 			);
			output_cont_dce.set_vr_diario ( cart.get_vr_edu_diario() 		);
			output_cont_dce.set_vr_disp   ( cart.get_vr_disp_educacional() 	);
			output_cont_dce.set_vr_depot  ( cart.get_vr_educacional() 		);
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_dadosAluno " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_dadosAluno " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_dadosAluno " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_cont_1 = new DataPortable();
		
			dp_cont_1.MapTagContainer ( COMM_OUT_FETCH_DADOSALUNO.dce , output_cont_dce as DataPortable );
		
			var_Comm.AddExitPortable ( ref dp_cont_1 ); 
		
			return true;
		}
	}
}
