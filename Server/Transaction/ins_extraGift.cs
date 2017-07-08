using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class ins_extraGift : type_base
	{
		public DadosProdutoGift input_cont_prod = new DadosProdutoGift();
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public ins_extraGift ( Transaction trans ) : base (trans)
		{
			var_Alias = "ins_extraGift";
			constructor();
		}
		
		public ins_extraGift()
		{
			var_Alias = "ins_extraGift";
		
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
			Registry ( "setup ins_extraGift " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_INS_EXTRAGIFT.prod, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_INS_EXTRAGIFT.prod missing! " ); 
				return false;
			}
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_INS_EXTRAGIFT.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_INS_EXTRAGIFT.header missing! " ); 
				return false;
			}
			
			input_cont_prod.Import ( ct_0 );
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done ins_extraGift " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate ins_extraGift " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done ins_extraGift " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute ins_extraGift " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_cont_header.get_st_empresa() ) )
				return false;
			
			if ( !emp.fetch() )
				return false;
			
			T_ExtraGift gift = new T_ExtraGift (this);
			
			if ( !gift.select_rows_nome_emp ( input_cont_prod.get_st_nome(), emp.get_identity() ) )
			{
				gift.set_fk_empresa ( emp.get_identity() 				);
				gift.set_st_nome  	( input_cont_prod.get_st_nome() 	);
				gift.set_vr_valor  	( input_cont_prod.get_vr_valor() 	);
				
				if ( !gift.create_T_ExtraGift() )
					return false;
				
				PublishNote ( "Item cadastrado com sucesso" );
			}
			else
			{
				if (!gift.fetch() )
					return false;
				
				gift.set_vr_valor ( input_cont_prod.get_vr_valor() );
				
				if ( !gift.synchronize_T_ExtraGift() )
					return false;
				
				PublishNote ( "Valor alterado com sucesso" );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done ins_extraGift " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish ins_extraGift " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.CadProdExtraGift     );
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( "" );
				
				aud.set_fk_generic  ( 0 );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done ins_extraGift " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
