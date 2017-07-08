using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_vincQuiosque : type_base
	{
		public string input_st_quiosque = "";
		public string input_st_empresa = "";
		public string input_id_user = "";
		public string input_tg_remover = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_vincQuiosque ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_vincQuiosque";
			constructor();
		}
		
		public exec_vincQuiosque()
		{
			var_Alias = "exec_vincQuiosque";
		
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
			Registry ( "setup exec_vincQuiosque " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_VINCQUIOSQUE.st_quiosque, ref input_st_quiosque ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_VINCQUIOSQUE.st_quiosque missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_VINCQUIOSQUE.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_VINCQUIOSQUE.st_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_VINCQUIOSQUE.id_user, ref input_id_user ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_VINCQUIOSQUE.id_user missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_VINCQUIOSQUE.tg_remover, ref input_tg_remover ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_VINCQUIOSQUE.tg_remover missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_VINCQUIOSQUE.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_VINCQUIOSQUE.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_vincQuiosque " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_vincQuiosque " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_vincQuiosque " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_vincQuiosque " ); 
		
			/// USER [ execute ]
		
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_st_empresa.PadLeft ( 6, '0' ) ) )
			{
				PublishError ( "Empresa não disponível" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			T_Quiosque q = new T_Quiosque (this);
			
			if ( !q.select_fk_empresa ( emp.get_identity() ) )
			{
				PublishError ( "Nenhum quiosque encontrado" );
				return false;
			}
			
			bool Found = false;
			
			while ( q.fetch() )
			{
				if ( q.get_st_nome() == input_st_quiosque )
				{
					Found = true;
					break;
				}
			}
			
			if ( !Found )
			{
				PublishError ( "Nenhum quiosque encontrado" );
				return false;
			}
			
			T_Usuario usrVend = new T_Usuario (this);
			
			usrVend.ExclusiveAccess();
			
			if ( usrVend.selectIdentity ( input_id_user ) )
			{
				if ( input_tg_remover == Context.TRUE )
				{
					usrVend.set_fk_quiosque ( q.get_identity() );
				}
				else
				{
					usrVend.set_fk_quiosque ( Context.NONE );
				}
					
				if ( !usrVend.synchronize_T_Usuario() )
					return false;
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_vincQuiosque " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_vincQuiosque " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.VincVendQuiosque  );
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( "" );
				
				aud.set_fk_generic  ( 0 );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_vincQuiosque " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
