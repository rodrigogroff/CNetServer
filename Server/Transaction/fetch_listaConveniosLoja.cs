using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_listaConveniosLoja : type_base
	{
		public string input_st_loja = "";
		
		public string output_st_cnpj = "";
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		
		T_Loja loj;
		
		/// USER [ var_decl ] END
		
		public fetch_listaConveniosLoja ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_listaConveniosLoja";
			constructor();
		}
		
		public fetch_listaConveniosLoja()
		{
			var_Alias = "fetch_listaConveniosLoja";
		
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
			Registry ( "setup fetch_listaConveniosLoja " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_LISTACONVENIOSLOJA.st_loja, ref input_st_loja ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_LISTACONVENIOSLOJA.st_loja missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_LISTACONVENIOSLOJA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_LISTACONVENIOSLOJA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_listaConveniosLoja " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_listaConveniosLoja " ); 
		
			/// USER [ authenticate ]
			
			// ## Obtem loja
			
			loj = new T_Loja (this);
			
			if ( !loj.select_rows_loja ( input_st_loja ) )
			{
				PublishError ( "Código de loja inválido" );
				return false;
			}
			
			if ( !loj.fetch() )
				return false;					
			
			output_st_cnpj = loj.get_nu_CNPJ();
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_listaConveniosLoja " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_listaConveniosLoja " ); 
		
			/// USER [ execute ]
			
			// ## Obtem empresas vinculadas à loja
			
			LINK_LojaEmpresa loj_emp = new LINK_LojaEmpresa (this);
			
			if ( loj_emp.select_fk_loja ( loj.get_identity() ) )
			{
				T_Empresa emp = new T_Empresa (this);
				
				while ( loj_emp.fetch() )
				{
					// ## Busca empresa
					
					if ( !emp.selectIdentity ( loj_emp.get_fk_empresa() ) )
						return false;
					
					// ## Copiar dados
					
					DadosEmpresa de = new DadosEmpresa();
					
					de.set_st_empresa		( emp.get_st_empresa() 			);
					de.set_st_fantasia		( emp.get_st_fantasia() 		);
					de.set_tx_convenio		( loj_emp.get_tx_admin() 		);
					de.set_nu_dias_convenio	( loj_emp.get_nu_dias_repasse() );
					de.set_st_ag			( loj_emp.get_st_ag() 			);
					de.set_st_banco			( loj_emp.get_st_banco() 		);
					de.set_st_conta			( loj_emp.get_st_conta() 		);
					
					output_array_generic_lst.Add ( de );
				}
			}
			
			if ( output_array_generic_lst.Count == 0 )
			{
				PublishNote ( "Nenhum convênio disponível" );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_listaConveniosLoja " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_listaConveniosLoja " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_listaConveniosLoja " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_LISTACONVENIOSLOJA.st_cnpj, output_st_cnpj ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_LISTACONVENIOSLOJA.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
