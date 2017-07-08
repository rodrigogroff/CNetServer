using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_desbloq_empresa : type_base
	{
		public string input_emp = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_desbloq_empresa ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_desbloq_empresa";
			constructor();
		}
		
		public exec_desbloq_empresa()
		{
			var_Alias = "exec_desbloq_empresa";
		
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
			Registry ( "setup exec_desbloq_empresa " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_DESBLOQ_EMPRESA.emp, ref input_emp ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_DESBLOQ_EMPRESA.emp missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_DESBLOQ_EMPRESA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_DESBLOQ_EMPRESA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_desbloq_empresa " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_desbloq_empresa " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_desbloq_empresa " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_desbloq_empresa " ); 
		
			/// USER [ execute ]

			T_Empresa emp = new T_Empresa ( this );
			
			emp.ExclusiveAccess();
			
			if ( !emp.select_rows_empresa ( input_emp.PadLeft ( 6, '0' ) ) )
				return false;

			if ( !emp.fetch() )
				return false;
			
			emp.set_tg_bloq ( Context.FALSE );
			
			emp.synchronize_T_Empresa();
			
			PublishNote ( "Empresa desbloqueada com sucesso!" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_desbloq_empresa " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_desbloq_empresa " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_desbloq_empresa " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
