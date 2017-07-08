using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_extraGift : type_base
	{
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_extraGift ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_extraGift";
			constructor();
		}
		
		public fetch_extraGift()
		{
			var_Alias = "fetch_extraGift";
		
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
			Registry ( "setup fetch_extraGift " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_FETCH_EXTRAGIFT.header, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_EXTRAGIFT.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_0 );
			
			Registry ( "setup done fetch_extraGift " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_extraGift " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_extraGift " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_extraGift " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_cont_header.get_st_empresa() ) )
				return false;
			
			if ( !emp.fetch() )
				return false;
			
			T_ExtraGift gift = new T_ExtraGift (this);
			
			if ( gift.select_fk_emp ( emp.get_identity() ) )
			{
				while ( gift.fetch() )
				{
					DadosProdutoGift dpg = new DadosProdutoGift();
				
					dpg.set_id_produto ( gift.get_identity() 	);
					dpg.set_st_nome    ( gift.get_st_nome()		);
					dpg.set_vr_valor   ( gift.get_vr_valor()    );
					
					output_array_generic_lst.Add ( dpg );
				}
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_extraGift " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_extraGift " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_extraGift " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_EXTRAGIFT.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
