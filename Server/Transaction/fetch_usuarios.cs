using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_usuarios : type_base
	{
		public string input_st_csv_list = "";
		
		public string output_st_csv = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_usuarios ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_usuarios";
			constructor();
		}
		
		public fetch_usuarios()
		{
			var_Alias = "fetch_usuarios";
		
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
			Registry ( "setup fetch_usuarios " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_USUARIOS.st_csv_list, ref input_st_csv_list ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_USUARIOS.st_csv_list missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_USUARIOS.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_USUARIOS.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_usuarios " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_usuarios " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_usuarios " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_usuarios " ); 
		
			/// USER [ execute ]
			
			T_Usuario m_user = new T_Usuario(this);
			
			StringBuilder sb = new StringBuilder();
			
			for ( int t=0; t < var_util.indexCSV ( input_st_csv_list ); ++t )
			{
				if ( !m_user.selectIdentity ( var_util.getCSV ( t ) ) )
					return false;
				
				if ( m_user.get_tg_bloqueio() == "2" )
					continue;
				
				DadosUsuario du = new DadosUsuario();
				
				du.set_id_usuario 	( m_user.get_identity() 	);
				du.set_st_empresa 	( m_user.get_st_empresa() 	);
				du.set_st_nome    	( m_user.get_st_nome()		);
				du.set_tg_bloqueio 	( m_user.get_tg_bloqueio() 	);
				du.set_tg_nivel		( m_user.get_tg_nivel() 	);
				
				DataPortable mem_rtc = du as DataPortable;
				
				// ## obtem indice
				
				sb.Append ( MemorySave ( ref mem_rtc ) );
				sb.Append ( ","   );			
			}
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
									
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
				
			// ## obtem indice geral
			
			output_st_csv = MemorySave ( ref dp );
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_usuarios " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_usuarios " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_usuarios " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_USUARIOS.st_csv, output_st_csv ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
