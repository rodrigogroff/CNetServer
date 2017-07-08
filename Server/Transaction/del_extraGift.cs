using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class del_extraGift : type_base
	{
		public string input_id = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public del_extraGift ( Transaction trans ) : base (trans)
		{
			var_Alias = "del_extraGift";
			constructor();
		}
		
		public del_extraGift()
		{
			var_Alias = "del_extraGift";
		
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
			Registry ( "setup del_extraGift " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_DEL_EXTRAGIFT.id, ref input_id ) == false ) 
			{
				Trace ( "# COMM_IN_DEL_EXTRAGIFT.id missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_DEL_EXTRAGIFT.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_DEL_EXTRAGIFT.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done del_extraGift " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate del_extraGift " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done del_extraGift " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute del_extraGift " ); 
		
			/// USER [ execute ]
			
			T_ExtraGift gift = new T_ExtraGift (this);
			
			if ( !gift.selectIdentity ( input_id ) )
			{
				PublishError ( "Produto não disponível" );
				return false;
			}
			
			if ( !gift.delete() )
				return false;
				
			/// USER [ execute ] END
		
			Registry ( "execute done del_extraGift " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish del_extraGift " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.RemProdGift		);
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( "" );
				
				aud.set_fk_generic  ( 0 );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done del_extraGift " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
