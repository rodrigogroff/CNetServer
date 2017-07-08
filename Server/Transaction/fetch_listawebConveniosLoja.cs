using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_listawebConveniosLoja : Transaction
	{
		public string input_st_loja = "";
		public string input_st_senha = "";
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_listawebConveniosLoja ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_listawebConveniosLoja";
			constructor();
		}
		
		public fetch_listawebConveniosLoja()
		{
			var_Alias = "fetch_listawebConveniosLoja";
		
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
			Registry ( "setup fetch_listawebConveniosLoja " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_LISTAWEBCONVENIOSLOJA.st_loja, ref input_st_loja ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_LISTAWEBCONVENIOSLOJA.st_loja missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_LISTAWEBCONVENIOSLOJA.st_senha, ref input_st_senha ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_LISTAWEBCONVENIOSLOJA.st_senha missing! " ); 
				return false;
			}
			
			Registry ( "setup done fetch_listawebConveniosLoja " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate fetch_listawebConveniosLoja " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_listawebConveniosLoja " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute fetch_listawebConveniosLoja " ); 
		
			/// USER [ execute ]
			
			T_Loja loj = new T_Loja (this);
			
			if ( !loj.select_rows_loja ( input_st_loja ) )
			{
				PublishError ( "Cnpj não disponível" );
				return false;
			}
			
			if ( !loj.fetch() )
				return false;
			
			if ( loj.get_st_senha() != input_st_senha )
			{
				PublishError ( "Senha inválida" );
				return false;
			}
			
			LINK_LojaEmpresa lnk = new LINK_LojaEmpresa (this);
			T_Empresa emp = new T_Empresa (this);
			
			if ( lnk.select_fk_loja ( loj.get_identity() ) )
			{
				while ( lnk.fetch() )
				{
					if ( !emp.selectIdentity ( lnk.get_fk_empresa() ) )
						continue;
					
					DadosEmpresa de = new DadosEmpresa();
					
					de.set_st_empresa ( emp.get_st_empresa() );
					
					output_array_generic_lst.Add ( de );
				}
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_listawebConveniosLoja " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish fetch_listawebConveniosLoja " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_listawebConveniosLoja " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_LISTAWEBCONVENIOSLOJA.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
