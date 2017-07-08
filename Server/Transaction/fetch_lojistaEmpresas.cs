using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_lojistaEmpresas : type_base
	{
		public string input_st_loja = "";
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_lojistaEmpresas ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_lojistaEmpresas";
			constructor();
		}
		
		public fetch_lojistaEmpresas()
		{
			var_Alias = "fetch_lojistaEmpresas";
		
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
			Registry ( "setup fetch_lojistaEmpresas " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_LOJISTAEMPRESAS.st_loja, ref input_st_loja ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_LOJISTAEMPRESAS.st_loja missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_LOJISTAEMPRESAS.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_LOJISTAEMPRESAS.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_lojistaEmpresas " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_lojistaEmpresas " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_lojistaEmpresas " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_lojistaEmpresas " ); 
		
			/// USER [ execute ]
			
			T_Loja loj = new T_Loja (this);
			
			if ( !loj.select_rows_loja ( input_st_loja ) )
			{
				PublishError ( "Loja não encontrada" );
				return false;
			}
			
			if ( !loj.fetch() )
				return false;
			
			T_Empresa emp = new T_Empresa (this);
			
			LINK_LojaEmpresa loj_emp = new LINK_LojaEmpresa (this);
			
			if ( loj_emp.select_fk_loja ( loj.get_identity() ) )
			{
				while ( loj_emp.fetch() )
				{
					if ( !emp.selectIdentity ( loj_emp.get_fk_empresa() ) )
						return false;
					
					DadosEmpresa de = new DadosEmpresa();
					
					de.set_st_empresa  ( emp.get_st_empresa()  );
					de.set_st_fantasia ( emp.get_st_fantasia() );
					
					output_array_generic_lst.Add ( de );
				}
			}
				
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_lojistaEmpresas " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_lojistaEmpresas " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_lojistaEmpresas " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_LOJISTAEMPRESAS.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
