using System;
using System.Text;
using System.Collections;

/// USER [ using_decl ]

using System.IO;
using System.Threading;

/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class schedule_tst : schedule_base
	{
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public schedule_tst ( Transaction trans ) : base (trans)
		{
			var_Alias = "schedule_tst";
		}
		
		public schedule_tst()
		{
			var_Alias = "schedule_tst";
		
			dbProcedure = DB_PROCEDURE.on_demand;
		
			ut_max = 0;
			
			/// USER [ constructor ]
			/// USER [ constructor ] END
		}
		
		public override bool setup ( ) 
		{
			Registry ( "setup schedule_tst " ); 
		
			Registry ( "setup done schedule_tst " ); 
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate schedule_tst " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done schedule_tst " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute schedule_tst " ); 
		
			/// USER [ execute ]
					
			T_Usuario user = new T_Usuario (this);
			
			if ( user.selectAll() )
			{
				while ( user.fetch() )
				{
					Registry ( user.get_st_nome() );
				}
			}
				
			/// USER [ execute ] END
		
			Registry ( "execute done schedule_tst " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish schedule_tst " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done schedule_tst " ); 
		
			return true;
		}
	}
}
