using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_pf_telefoneLojista : type_base
	{
		public string input_st_loja = "";
		
		public string output_st_telefone = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_pf_telefoneLojista ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_pf_telefoneLojista";
			constructor();
		}
		
		public fetch_pf_telefoneLojista()
		{
			var_Alias = "fetch_pf_telefoneLojista";
		
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
			Registry ( "setup fetch_pf_telefoneLojista " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_PF_TELEFONELOJISTA.st_loja, ref input_st_loja ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_PF_TELEFONELOJISTA.st_loja missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_PF_TELEFONELOJISTA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_PF_TELEFONELOJISTA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_pf_telefoneLojista " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_pf_telefoneLojista " ); 
		
			/// USER [ authenticate ]
			
			input_st_loja = input_st_loja.PadLeft ( 6, '0' );
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_pf_telefoneLojista " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_pf_telefoneLojista " ); 
		
			/// USER [ execute ]
			
			// ## Obtem loja por código
			
			T_Loja loj = new T_Loja ( this );
			
			if ( loj.select_rows_loja ( input_st_loja ) )
			{
				if ( !loj.fetch() )
					return false;
				
				// ## Obtem terminais vinculados
				
				T_Terminal term = new T_Terminal (this);
				
				if ( term.select_fk_loja ( loj.get_identity() ) )
				{
					T_PayFone pf = new T_PayFone ( this );
					
					// ## Para todos os terminais
					
					while ( term.fetch() )
					{
						// ## busca payfone
						
						if ( pf.select_fk_term ( term.get_identity() ) )
						{
							// ## para todos os registros
							
							while ( pf.fetch() )
							{
								// ## somente lojista
								
								if ( pf.get_tg_tipoCelular() == TipoCelular.LOJA )
								{
									// ## Achou telefone
									
									output_st_telefone = pf.get_st_telefone();
									return true;
								}
							}
						}
					}
				}
			}
			
			/// 
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_pf_telefoneLojista " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_pf_telefoneLojista " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_pf_telefoneLojista " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_PF_TELEFONELOJISTA.st_telefone, output_st_telefone ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
