using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_alteraAdminEmpresa : type_base
	{
		public string input_st_empresa_admin = "";
		public string input_tg_remover = "";
		public string input_st_empresa_destino = "";
		
		/// USER [ var_decl ]
		
		T_Empresa emp_admin;
		T_Empresa emp_dest;
		
		/// USER [ var_decl ] END
		
		public exec_alteraAdminEmpresa ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_alteraAdminEmpresa";
			constructor();
		}
		
		public exec_alteraAdminEmpresa()
		{
			var_Alias = "exec_alteraAdminEmpresa";
		
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
			Registry ( "setup exec_alteraAdminEmpresa " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERAADMINEMPRESA.st_empresa_admin, ref input_st_empresa_admin ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERAADMINEMPRESA.st_empresa_admin missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERAADMINEMPRESA.tg_remover, ref input_tg_remover ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERAADMINEMPRESA.tg_remover missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_ALTERAADMINEMPRESA.st_empresa_destino, ref input_st_empresa_destino ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_ALTERAADMINEMPRESA.st_empresa_destino missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_ALTERAADMINEMPRESA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_ALTERAADMINEMPRESA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_alteraAdminEmpresa " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_alteraAdminEmpresa " ); 
		
			/// USER [ authenticate ]
			
			input_st_empresa_admin = input_st_empresa_admin.PadLeft ( 6, '0' );
			input_st_empresa_destino = input_st_empresa_destino.PadLeft ( 6, '0' );
			
			emp_admin = new T_Empresa (this);
			
			// ## Busca empresa administradora
			
			if ( !emp_admin.select_rows_empresa ( input_st_empresa_admin ) )
			{
				PublishError ( "Empresa administradora inválida" );
				return false;
			}
			
			if ( !emp_admin.fetch() )
				return false;
			
			// ## Busca empresa destino
			
			emp_dest  = new T_Empresa (this);
			
			emp_dest.ExclusiveAccess();
			
			if ( !emp_dest.select_rows_empresa ( input_st_empresa_destino ) )
			{
				PublishError ( "Empresa destino inválida" );
				return false;
			}
			
			if ( !emp_dest.fetch() )
				return false;
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_alteraAdminEmpresa " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_alteraAdminEmpresa " ); 
		
			/// USER [ execute ]
			
			// ## efetua ação
			
			if ( input_tg_remover == Context.TRUE )
				emp_dest.set_fk_admin ( Context.NONE );
			else
				emp_dest.set_fk_admin ( emp_admin.get_identity() );
			
			// ## atualiza tabela
			
			if ( !emp_dest.synchronize_T_Empresa() )
				return false;
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_alteraAdminEmpresa " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_alteraAdminEmpresa " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_alteraAdminEmpresa " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
