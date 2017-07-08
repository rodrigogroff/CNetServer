using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_edu_segundaVia : type_base
	{
		public string input_st_cartao = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_edu_segundaVia ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_edu_segundaVia";
			constructor();
		}
		
		public exec_edu_segundaVia()
		{
			var_Alias = "exec_edu_segundaVia";
		
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
			Registry ( "setup exec_edu_segundaVia " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_EDU_SEGUNDAVIA.st_cartao, ref input_st_cartao ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_EDU_SEGUNDAVIA.st_cartao missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_EDU_SEGUNDAVIA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_EDU_SEGUNDAVIA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_edu_segundaVia " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_edu_segundaVia " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_edu_segundaVia " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_edu_segundaVia " ); 
		
			/// USER [ execute ]
			
			// ## Busca cartão específico 
			
			T_Cartao cart = new T_Cartao (this);
			
			cart.ExclusiveAccess();
			
			if ( !cart.select_rows_tudo ( 	input_st_cartao.Substring (0,6), 
			                             	input_st_cartao.Substring (6,6), 
			                             	input_st_cartao.Substring (12,2) ) )
			{
				PublishError ( "Cartão inválido" );
				return false;
			}
			
			if ( !cart.fetch() )
				return false;
			
			// ## incrementa via de cartão e seta como não expedido,
			// ## ou seja, precisa vir da gráfica e ser testado
			
			cart.set_nu_viaCartao ( ( cart.get_int_nu_viaCartao() + 1 ).ToString() 	);
			cart.set_tg_emitido   ( StatusExpedicao.NaoExpedido 					);
			
			cart.set_st_venctoCartao ( 	DateTime.Now.AddYears(5).Month.ToString().PadLeft (2,'0' ) + 
			                          DateTime.Now.AddYears(5).Year.ToString().Substring (2,2) );
			
			// ## Atualiza
			
			if ( !cart.synchronize_T_Cartao() )
				return false;
			
			PublishNote ( "Segunda via requerida ao cartao " + input_st_cartao + "." );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_edu_segundaVia " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_edu_segundaVia " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_edu_segundaVia " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
