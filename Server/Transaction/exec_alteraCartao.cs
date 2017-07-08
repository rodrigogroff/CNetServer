using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_alteraCartao : type_base
	{
		public DadosCartao input_cont_dc = new DadosCartao();
		
		/// USER [ var_decl ]
		
		T_Cartao cart;
		
		/// USER [ var_decl ] END
		
		public exec_alteraCartao ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_alteraCartao";
			constructor();
		}
		
		public exec_alteraCartao()
		{
			var_Alias = "exec_alteraCartao";
		
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
			Registry ( "setup exec_alteraCartao " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_EXEC_ALTERACARTAO.dc, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_ALTERACARTAO.dc missing! " ); 
				return false;
			}
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_ALTERACARTAO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_ALTERACARTAO.header missing! " ); 
				return false;
			}
			
			input_cont_dc.Import ( ct_0 );
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_alteraCartao " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_alteraCartao " ); 
		
			/// USER [ authenticate ]
			
			cart = new T_Cartao (this);
			
			cart.ExclusiveAccess();
			
			// ## Busca cartão específico
			
			if ( !cart.select_rows_empresa_matricula ( input_cont_dc.get_st_empresa(),
			                                          input_cont_dc.get_st_matricula() ) )
			{
				PublishError ( "Cartão inválido" );
				return false;
			}
			
			if ( !cart.fetch() )
				return false;
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_alteraCartao " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_alteraCartao " ); 
		
			/// USER [ execute ]
			
			// ## Altera limites
			
			cart.set_vr_limiteTotal 	( input_cont_dc.get_vr_limiteTotal() 	);
			cart.set_vr_limiteMensal 	( input_cont_dc.get_vr_limiteMensal() 	);
			cart.set_vr_limiteRotativo 	( input_cont_dc.get_vr_limiteRotativo() );
			cart.set_vr_extraCota 		( input_cont_dc.get_vr_extraCota() 		);
			
			// ## Atualiza
			
			if ( !cart.synchronize_T_Cartao() )
				return false;
			
			PublishNote ( "Cartão alterado com sucesso" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_alteraCartao " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_alteraCartao " ); 
		
			/// USER [ finish ]
			
			// ## Grava em registro de auditoria 
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	  ( TipoOperacao.AlterCartao 				);
				aud.set_fk_usuario	  ( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao   ( GetDataBaseTime() 					);
				aud.set_st_observacao ( input_cont_dc.get_st_empresa() + input_cont_dc.get_st_matricula() );
				
				aud.set_fk_generic  ( user.get_identity() 					);
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_alteraCartao " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
