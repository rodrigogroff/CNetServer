using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_empresasGrafica : type_base
	{
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_empresasGrafica ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_empresasGrafica";
			constructor();
		}
		
		public fetch_empresasGrafica()
		{
			var_Alias = "fetch_empresasGrafica";
		
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
			Registry ( "setup fetch_empresasGrafica " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_FETCH_EMPRESASGRAFICA.header, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_EMPRESASGRAFICA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_0 );
			
			Registry ( "setup done fetch_empresasGrafica " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_empresasGrafica " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_empresasGrafica " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_empresasGrafica " ); 
		
			/// USER [ execute ]
			
			T_Cartao 	cart = new T_Cartao 	(this);
			T_Empresa 	emp  = new T_Empresa 	(this);
			
			if ( emp.selectAll() )
			{
				while ( emp.fetch() )
				{
					bool Found = false;
					
					if ( cart.select_rows_empresa ( emp.get_st_empresa() ) )
					{
						while ( cart.fetch() )
						{
							if ( cart.get_tg_emitido() == StatusExpedicao.NaoExpedido )
							{
								Found = true;
								break;
							}
						}
					}
					
					if ( Found )
					{
						DadosEmpresa de = new DadosEmpresa();
						
						de.set_st_empresa ( emp.get_st_empresa() );
						de.set_st_fantasia ( emp.get_st_fantasia() );
						
						output_array_generic_lst.Add ( de );
					}
				}
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_empresasGrafica " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_empresasGrafica " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_empresasGrafica " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_EMPRESASGRAFICA.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
