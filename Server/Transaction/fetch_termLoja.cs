using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_termLoja : type_base
	{
		public string input_st_cod_loja = "";
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		
		T_Loja loj;
		
		/// USER [ var_decl ] END
		
		public fetch_termLoja ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_termLoja";
			constructor();
		}
		
		public fetch_termLoja()
		{
			var_Alias = "fetch_termLoja";
		
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
			Registry ( "setup fetch_termLoja " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_TERMLOJA.st_cod_loja, ref input_st_cod_loja ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_TERMLOJA.st_cod_loja missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_TERMLOJA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_TERMLOJA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_termLoja " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_termLoja " ); 
		
			/// USER [ authenticate ]
			
			loj = new T_Loja (this);
			
			input_st_cod_loja =input_st_cod_loja.PadLeft ( 6, '0' );
			
			if ( !loj.select_rows_loja ( input_st_cod_loja ) )
			{
				PublishError ( "Código de loja inválido" );
				return false;
			}
			
			if ( !loj.fetch() )
			    return false;
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_termLoja " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_termLoja " ); 
		
			/// USER [ execute ]
			
			T_Terminal term = new T_Terminal (this);
			
			if ( !term.select_fk_loja ( loj.get_identity() ) )
			{
				PublishError ( "Nenhum terminal cadastrado para a loja" );
				return false;
			}
			
			while ( term.fetch() )
			{
				DadosTerminal dt = new DadosTerminal();
				
				dt.set_st_terminal 	  ( term.get_nu_terminal() 	  );
				dt.set_st_localizacao ( term.get_st_localizacao() );
				
				output_array_generic_lst.Add ( dt );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_termLoja " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_termLoja " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_termLoja " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_TERMLOJA.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
