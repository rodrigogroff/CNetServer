using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_memory : Transaction
	{
		public string input_st_block = "";
		public string input_st_bytes = "";
		
		public string output_st_new_block = "";
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_memory ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_memory";
			constructor();
		}
		
		public fetch_memory()
		{
			var_Alias = "fetch_memory";
		
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
			Registry ( "setup fetch_memory " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_MEMORY.st_block, ref input_st_block ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_MEMORY.st_block missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_MEMORY.st_bytes, ref input_st_bytes ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_MEMORY.st_bytes missing! " ); 
				return false;
			}
			
			Registry ( "setup done fetch_memory " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate fetch_memory " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_memory " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute fetch_memory " ); 
		
			/// USER [ execute ]
			
			StringBuilder   sb       = new StringBuilder();
			ApplicationUtil var_util = new ApplicationUtil();
						
			int memory = Convert.ToInt32 ( new InstallData().maxPacket ) / Convert.ToInt32 ( input_st_bytes );
						
			// ###
			// ###  Obtem todos os id´s que o relatório gerou
			// ###
			 			
			DataPortable dp_container = MemoryGet ( input_st_block );
			
			string ids   = dp_container.getValue ( "ids" );
			string final = "";
			
			
			
			int total_records = var_util.indexCSV ( ids );
			
			
			
			// ###
			// ###  Compila uma lista de id´s que cabem na memoria
			// ###
			 			
			bool Term = false;
			
			for ( int y=0; y < total_records; ++y )
			{
				
				
				sb.Append ( var_util.getCSV (y) );	
				sb.Append ( "," );

				if ( --memory == 0 || y == total_records - 1 )
				{
					
					
					final = sb.ToString();
			
					// se for ultimo registro
					if ( y == total_records - 1 )
					{
						Term  = true;
						
						
						final = final.TrimEnd ( ',' );
						
					}
					
					break;			
				}
			}
			
			if ( Term != true && final.Length > 0 )
			{
				
				
				// ###
				// ### Atualiza a lista com id´s que ainda nao foram devolvidos
				// ###
				
				string new_batch = ids.Replace ( final, "" );
				
				
				
				DataPortable dp_new_recs = new DataPortable();
				
				dp_new_recs.setValue ( "ids", new_batch );
				
				// ###
				// ### Obtem novo id da lista
				// ###
								
				output_st_new_block = MemorySave ( ref dp_new_recs );
			}
			
			// ###
			// ### Copia itens da memoria
			// ###
			 			
			final = final.TrimEnd ( ',' );

			var_util.clearPortable();
			
			total_records = var_util.indexCSV ( final );
			
			for ( int y=0; y < total_records; ++y )
			{
				output_array_generic_lst.Add ( MemoryGet ( var_util.getCSV (y) ) );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_memory " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish fetch_memory " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_memory " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_MEMORY.st_new_block, output_st_new_block ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_MEMORY.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
