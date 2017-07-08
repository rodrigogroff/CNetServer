using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_quiosque : type_base
	{
		public string input_st_empresa = "";
		
		public ArrayList output_array_generic_lstQ = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_quiosque ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_quiosque";
			constructor();
		}
		
		public fetch_quiosque()
		{
			var_Alias = "fetch_quiosque";
		
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
			Registry ( "setup fetch_quiosque " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_QUIOSQUE.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_QUIOSQUE.st_empresa missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_QUIOSQUE.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_QUIOSQUE.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_quiosque " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_quiosque " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_quiosque " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_quiosque " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_st_empresa.PadLeft ( 6, '0' ) ) )
			{
				PublishError ( "Empresa não disponível" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			T_Quiosque q = new T_Quiosque (this);
			
			if ( !q.select_fk_empresa ( emp.get_identity() ) )
			{
				PublishError ( "Nenhum quiosque encontrado" );
				return false;
			}
			
			while ( q.fetch() )
			{
				DadosQuiosque dq = new DadosQuiosque();
				
				dq.set_st_nome ( q.get_st_nome() );
				
				output_array_generic_lstQ.Add ( dq );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_quiosque " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_quiosque " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_quiosque " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_array_generic_lstQ = new DataPortable();
		
			dp_array_generic_lstQ.MapTagArray ( COMM_OUT_FETCH_QUIOSQUE.lstQ , ref output_array_generic_lstQ );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lstQ );
		
			return true;
		}
	}
}
