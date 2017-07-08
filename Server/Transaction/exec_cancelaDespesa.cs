using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_cancelaDespesa : type_base
	{
		public string input_fk_faturamentoDetalhe = "";
		
		/// USER [ var_decl ]
		
		T_FaturamentoDetalhes fat_det;
			
		/// USER [ var_decl ] END
		
		public exec_cancelaDespesa ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_cancelaDespesa";
			constructor();
		}
		
		public exec_cancelaDespesa()
		{
			var_Alias = "exec_cancelaDespesa";
		
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
			Registry ( "setup exec_cancelaDespesa " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_CANCELADESPESA.fk_faturamentoDetalhe, ref input_fk_faturamentoDetalhe ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_CANCELADESPESA.fk_faturamentoDetalhe missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_CANCELADESPESA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_CANCELADESPESA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_cancelaDespesa " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_cancelaDespesa " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_cancelaDespesa " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_cancelaDespesa " ); 
		
			/// USER [ execute ]
			
			fat_det = new T_FaturamentoDetalhes (this);
			
			if ( !fat_det.selectIdentity ( input_fk_faturamentoDetalhe ) )
			{
				PublishError ( "Despensa não encontrada" );
				return false;
			}
			
			if ( !fat_det.delete() )
				return false;
			
			PublishNote ( "Despesa removida com sucesso" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_cancelaDespesa " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_cancelaDespesa " ); 
		
			/// USER [ finish ]
						
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.RemDespesa				);
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( fat_det.get_st_extras() );
				
				aud.set_fk_generic  ( input_fk_faturamentoDetalhe  );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
				
			/// USER [ finish ] END
		
			Registry ( "finish done exec_cancelaDespesa " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
