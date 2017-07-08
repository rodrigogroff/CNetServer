using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_nomeLoja : type_base
	{
		public string input_st_nomeLoja = "";
		public string input_st_cod_empresa = "";
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		
		T_Empresa emp;
		
		/// USER [ var_decl ] END
		
		public fetch_nomeLoja ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_nomeLoja";
			constructor();
		}
		
		public fetch_nomeLoja()
		{
			var_Alias = "fetch_nomeLoja";
		
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
			Registry ( "setup fetch_nomeLoja " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_NOMELOJA.st_nomeLoja, ref input_st_nomeLoja ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_NOMELOJA.st_nomeLoja missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_NOMELOJA.st_cod_empresa, ref input_st_cod_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_NOMELOJA.st_cod_empresa missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_NOMELOJA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_NOMELOJA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_nomeLoja " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_nomeLoja " ); 
		
			/// USER [ authenticate ]
			
			emp = new T_Empresa (this);
			
			input_st_cod_empresa = input_st_cod_empresa.PadLeft ( 6, '0' );
			
			// ## Busca dados de empresa
			
			if ( !emp.select_rows_empresa ( input_st_cod_empresa ) )
			{
				PublishError ( "Código inválido de empresa" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
						
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_nomeLoja " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_nomeLoja " ); 
		
			/// USER [ execute ]
			
			LINK_LojaEmpresa lojEmp = new LINK_LojaEmpresa (this);
			
			if ( !lojEmp.select_fk_empresa_geral ( emp.get_identity() ) )
			{
				PublishError ( "Nenhuma loja conveniada à empresa" );
				return false;
			}
			
			T_Loja loj = new T_Loja (this);
			
			// ## Busca registros de relacionamento
			
			while ( lojEmp.fetch() )
			{
				if ( !loj.selectIdentity ( lojEmp.get_fk_loja() ) )
					return false;
			
				// ## Se nome de loja bate
				
				if ( loj.get_st_nome().Contains ( input_st_nomeLoja ) )
				{
					// ## Copia dados para memória
					
					DadosLoja dl = new DadosLoja();
					
					dl.set_st_nome ( loj.get_st_nome() );
					dl.set_st_loja ( loj.get_st_loja() );
					
					output_array_generic_lst.Add ( dl );
				}
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_nomeLoja " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_nomeLoja " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_nomeLoja " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_NOMELOJA.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
