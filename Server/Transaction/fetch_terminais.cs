using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_terminais : type_base
	{
		public string input_st_csvId = "";
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_terminais ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_terminais";
			constructor();
		}
		
		public fetch_terminais()
		{
			var_Alias = "fetch_terminais";
		
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
			Registry ( "setup fetch_terminais " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_TERMINAIS.st_csvId, ref input_st_csvId ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_TERMINAIS.st_csvId missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_TERMINAIS.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_TERMINAIS.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_terminais " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_terminais " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_terminais " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_terminais " ); 
		
			/// USER [ execute ]
			
			T_Terminal m_term = new T_Terminal(this);
			
			for ( int t=0; t < var_util.indexCSV ( input_st_csvId ); ++t )
			{
				if ( !m_term.selectIdentity ( var_util.getCSV ( t ) ) )
					return false;
				
				DadosTerminal dt = new DadosTerminal();
				
				dt.set_st_terminal  	( m_term.get_nu_terminal()		);
				dt.set_st_localizacao 	( m_term.get_st_localizacao() 	);
				
				output_array_generic_lst.Add ( dt );				
			}
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_terminais " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_terminais " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_terminais " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_TERMINAIS.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
