using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_terminalLoja : type_base
	{
		public string input_st_cnpj_loja = "";
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
	
		T_Loja loj;
		T_Terminal term;
			
		/// USER [ var_decl ] END
		
		public fetch_terminalLoja ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_terminalLoja";
			constructor();
		}
		
		public fetch_terminalLoja()
		{
			var_Alias = "fetch_terminalLoja";
		
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
			Registry ( "setup fetch_terminalLoja " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_TERMINALLOJA.st_cnpj_loja, ref input_st_cnpj_loja ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_TERMINALLOJA.st_cnpj_loja missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_TERMINALLOJA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_TERMINALLOJA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_terminalLoja " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_terminalLoja " ); 
		
			/// USER [ authenticate ]
			
			loj = new T_Loja (this);
			
			if ( !loj.select_rows_loja ( input_st_cnpj_loja ) )
			{
				PublishError ( "Loja inexistente" );
				return false;
			}
			
			if ( !loj.fetch() )
				return false;
			
			term = new T_Terminal (this);
			
			if ( !term.select_fk_loja ( loj.get_identity() ) )
			{
				PublishError ( "Nenhum terminal cadastrado para esta loja" );
				return false;
			}
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_terminalLoja " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_terminalLoja " ); 
		
			/// USER [ execute ]
			
			while ( term.fetch() )
			{
				if ( term.get_fk_loja() == Context.NOT_SET )
					continue;
				
				DadosTerminal dt = new DadosTerminal ();
				
				dt.set_st_terminal 		( term.get_nu_terminal() 	);
				dt.set_st_localizacao 	( term.get_st_localizacao() );
				
				output_array_generic_lst.Add ( dt );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_terminalLoja " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_terminalLoja " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_terminalLoja " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_TERMINALLOJA.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
