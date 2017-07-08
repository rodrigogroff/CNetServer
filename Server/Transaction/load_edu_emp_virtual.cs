using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class load_edu_emp_virtual : type_load
	{
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public load_edu_emp_virtual ( Transaction trans ) : base (trans)
		{
			var_Alias = "load_edu_emp_virtual";
			constructor();
		}
		
		public load_edu_emp_virtual()
		{
			var_Alias = "load_edu_emp_virtual";
		
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
			Registry ( "setup load_edu_emp_virtual " ); 
		
			Registry ( "setup done load_edu_emp_virtual " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate load_edu_emp_virtual " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done load_edu_emp_virtual " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute load_edu_emp_virtual " ); 
		
			/// USER [ execute ]
			
			StreamReader reader = new StreamReader ( archive );
			
			T_Edu_EmpresaVirtual emp_virtual = new T_Edu_EmpresaVirtual(this);
			
			try
			{
				while ( !reader.EndOfStream )
				{
					string line = reader.ReadLine().Replace ( "'", "" );
					
					if ( line == "" )
						continue;
					
					var_util.indexCSV ( line );
					
					emp_virtual.set_st_nome   ( var_util.getCSV ( 0 ) );
					emp_virtual.set_st_codigo ( var_util.getCSV ( 1 ) );
					emp_virtual.set_vr_valorAcao ( 10000 );
					
					emp_virtual.create_T_Edu_EmpresaVirtual();
				}
			}
			catch ( System.Exception ex )
			{
				Registry ( ex.ToString() );
				reader.Close();	
				
				return false;
			}
			
			reader.Close();
			
			/// USER [ execute ] END
		
			Registry ( "execute done load_edu_emp_virtual " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish load_edu_emp_virtual " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done load_edu_emp_virtual " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
