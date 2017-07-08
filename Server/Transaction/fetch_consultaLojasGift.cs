using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_consultaLojasGift : type_base
	{
		public string input_st_empresa = "";
		
		public string output_st_csv_id = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_consultaLojasGift ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_consultaLojasGift";
			constructor();
		}
		
		public fetch_consultaLojasGift()
		{
			var_Alias = "fetch_consultaLojasGift";
		
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
			Registry ( "setup fetch_consultaLojasGift " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CONSULTALOJASGIFT.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CONSULTALOJASGIFT.st_empresa missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_CONSULTALOJASGIFT.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CONSULTALOJASGIFT.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_consultaLojasGift " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_consultaLojasGift " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_consultaLojasGift " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_consultaLojasGift " ); 
		
			/// USER [ execute ]
			
			input_st_empresa = input_st_empresa.PadLeft ( 6, '0' );
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_st_empresa ) )
			{
				PublishError ( "Empresa não disponível" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			LINK_LojaEmpresa lje = new LINK_LojaEmpresa (this);
			T_Loja 			 loj = new T_Loja (this);
			T_Terminal		 term = new T_Terminal (this);
			
			StringBuilder sb = new StringBuilder();
			
			ArrayList lstSort = new ArrayList();
			
			if ( lje.select_fk_empresa_geral ( emp.get_identity() ) )
			{
				SQL_LOGGING_ENABLE = false;
				
				while ( lje.fetch() )
					if ( loj.selectIdentity ( lje.get_fk_loja() ) )
						lstSort.Add ( loj.get_st_nome() );
				
				lstSort.Sort();
				
				for ( int t=0; t < lstSort.Count; ++t )
				{
					string nome_loja = lstSort[t].ToString();
					
					if ( loj.select_rows_nome ( nome_loja ) )
					{
						if ( loj.fetch() )
						{
							if ( !term.select_fk_loja ( loj.get_identity() ) )
							return false;
						
							if ( !term.fetch() )
								return false;
						
							DadosLoja dl = new DadosLoja();
						
							dl.set_st_nome ( loj.get_st_nome() + " - " + loj.get_st_social() 	);
							dl.set_st_obs  ( term.get_nu_terminal() 							);
						
							DataPortable tmp = dl as DataPortable;
				
							// ## obtem indexador
						
							sb.Append ( MemorySave ( ref tmp ) 	);
							sb.Append ( "," 				 	);						
						}
					}
				}
				
				SQL_LOGGING_ENABLE = true;
			}
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
			
			if ( list_ids == "" )
			{
				PublishNote ( "Nenhum resultado foi encontrado" );
				return true;
			}
											
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
			
			// ## Obtem indexador geral
						  
			output_st_csv_id = MemorySave ( ref dp );
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_consultaLojasGift " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_consultaLojasGift " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_consultaLojasGift " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_CONSULTALOJASGIFT.st_csv_id, output_st_csv_id ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
