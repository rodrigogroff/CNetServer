using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_listaUsuarios : type_base
	{
		public string output_st_csv_id = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_listaUsuarios ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_listaUsuarios";
			constructor();
		}
		
		public fetch_listaUsuarios()
		{
			var_Alias = "fetch_listaUsuarios";
		
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
			Registry ( "setup fetch_listaUsuarios " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_FETCH_LISTAUSUARIOS.header, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_LISTAUSUARIOS.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_0 );
			
			Registry ( "setup done fetch_listaUsuarios " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_listaUsuarios " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_listaUsuarios " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_listaUsuarios " ); 
		
			/// USER [ execute ]
			
			T_Usuario m_user = new T_Usuario(this);
			
			// ## Busca usuários da empresa
			
			if ( input_cont_header.get_st_empresa() == "000000" )
			{
				// ## Todos, ordenados por empresa
				
				m_user.select_rows_empresa_super();
			}
			else 
			{
				// ## Somente vinculados a uma empresa
				
				m_user.select_rows_empresa ( input_cont_header.get_st_empresa() );
			}
				
			int max = m_user.RowCount();
			
			StringBuilder 	sb = new StringBuilder();
			
			while ( m_user.fetch() )
			{
				// ## Copia dados
				
				if ( m_user.get_tg_bloqueio() == "2" )
					continue;
					
				DadosUsuario info = new DadosUsuario ();
				
				info.set_id_usuario  ( m_user.get_identity() 	);
				info.set_st_nome     ( m_user.get_st_nome() 	);
				info.set_tg_bloqueio ( m_user.get_tg_bloqueio() );
				info.set_tg_nivel  	 ( m_user.get_tg_nivel() 	);
				info.set_st_empresa	 ( m_user.get_st_empresa()	);
				
				DataPortable tmp = info as DataPortable;
				
				// ## Obtem identificador para registro
					
				sb.Append ( MemorySave ( ref tmp ) );
				sb.Append ( "," 				   );
			}
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
			
			if ( list_ids == "" )
			{
				PublishNote ( "Nenhum resultado foi encontrado" );
				return true;
			}
											
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
			
			// ## Obtem identificador geral
						  
			output_st_csv_id = MemorySave ( ref dp );
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_listaUsuarios " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_listaUsuarios " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_listaUsuarios " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_LISTAUSUARIOS.st_csv_id, output_st_csv_id ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
