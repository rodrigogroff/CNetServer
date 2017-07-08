using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_dadosAdministradora : type_base
	{
		public string input_st_empresa = "";
		
		public string output_st_in_csv = "";
		public string output_st_out_csv = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_dadosAdministradora ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_dadosAdministradora";
			constructor();
		}
		
		public fetch_dadosAdministradora()
		{
			var_Alias = "fetch_dadosAdministradora";
		
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
			Registry ( "setup fetch_dadosAdministradora " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_DADOSADMINISTRADORA.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_DADOSADMINISTRADORA.st_empresa missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_DADOSADMINISTRADORA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_DADOSADMINISTRADORA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_dadosAdministradora " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_dadosAdministradora " ); 
		
			/// USER [ authenticate ]
			
			input_st_empresa = input_st_empresa.PadLeft ( 6, '0' );
				
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_dadosAdministradora " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_dadosAdministradora " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa (this);
			
			// ## Busca empresa
			
			if ( !emp.select_rows_empresa ( input_st_empresa ) )
			{
				PublishError ( "Empresa inválida" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			// ## Obtem chave da empresa principal
			
			string fk_admin = emp.get_identity();
			
			// ## Busca todas as empresas
			
			if ( !emp.selectAll() )
			{
				PublishError ( "Nenhuma empresa cadastrada" );
				return false;
			}
			
			// ## Dois grupos, um das empresas vinculadas
			// ## e outro de não vinculadas
			
			StringBuilder sb_in = new StringBuilder();
			StringBuilder sb_out = new StringBuilder();
			
			// ## Busca registros
			
			while ( emp.fetch() )
			{
				// ## Empresa admin deve ser filtrada
				
				if ( emp.get_identity() == fk_admin )
					continue;
				
				// ## Copia para memória
				
				DadosEmpresa de = new DadosEmpresa();
				
				de.set_st_fantasia ( emp.get_st_fantasia() );
				de.set_st_empresa  ( emp.get_st_empresa()  );
				
				DataPortable port = de as DataPortable;
				
				// ## Caso link para admin bater com admin
				// ## esta empresa é vinculada
				
				if ( emp.get_fk_admin() == fk_admin )
				{
					// ## obtem indexador
					
					sb_in.Append ( MemorySave ( ref port ) );
					sb_in.Append ( "," );
				}				
				else
				{
					// ## obtem indexador
					
					sb_out.Append ( MemorySave ( ref port ) );
					sb_out.Append ( "," );
				}
			}	
			
			// in
			{
				string list_ids = sb_in.ToString().TrimEnd ( ',' );
										
				DataPortable dp = new DataPortable();
				
				dp.setValue ( "ids", list_ids );
					
				// ## obtem indexador de grupo
				
				output_st_in_csv = MemorySave ( ref dp );
			}
			
			// out
			{
				string list_ids = sb_out.ToString().TrimEnd ( ',' );
										
				DataPortable dp = new DataPortable();
				
				dp.setValue ( "ids", list_ids );
				
				// ## obtem indexador de grupo
							  
				output_st_out_csv = MemorySave ( ref dp );
			}
					
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_dadosAdministradora " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_dadosAdministradora " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_dadosAdministradora " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_DADOSADMINISTRADORA.st_in_csv, output_st_in_csv ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_DADOSADMINISTRADORA.st_out_csv, output_st_out_csv ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
