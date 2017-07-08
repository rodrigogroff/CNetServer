using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_excluiCart : type_base
	{
		public string input_emp = "";
		public string input_mat = "";
		public string input_tit = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_excluiCart ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_excluiCart";
			constructor();
		}
		
		public exec_excluiCart()
		{
			var_Alias = "exec_excluiCart";
		
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
			Registry ( "setup exec_excluiCart " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_EXCLUICART.emp, ref input_emp ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_EXCLUICART.emp missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_EXCLUICART.mat, ref input_mat ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_EXCLUICART.mat missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_EXCLUICART.tit, ref input_tit ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_EXCLUICART.tit missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_EXCLUICART.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_EXCLUICART.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_excluiCart " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_excluiCart " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_excluiCart " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_excluiCart " ); 
		
			/// USER [ execute ]
			
			T_Cartao cart = new T_Cartao ( this );
			
			if ( !cart.select_rows_tudo ( input_emp, input_mat, input_tit ) )
			{
				PublishError ( "Cartão não disponivel" );
				return false;
			}
			
			if ( !cart.fetch() )
				return false;
			
			if ( cart.get_tg_emitido() == StatusExpedicao.Expedido )
			{
				PublishError ( "Cartão não pode ser excluido - status expedido" );
				return false;
			}
			
			LOG_Transacoes ltr = new LOG_Transacoes ( this );
			
			if ( ltr.select_fk_cartao ( cart.get_identity() ) )
			{
				PublishError ( "Cartão não pode ser excluido - já possui movimentação" );
				return false;
			}
			
			if ( cart.get_st_titularidade() == "01" )
			{
				T_Proprietario prot = new T_Proprietario ( this );
				
				prot.selectIdentity ( cart.get_fk_dadosProprietario() );
				prot.delete();
			}
			else
			{
				T_Dependente dep = new T_Dependente ( this );
				
				if ( dep.select_rows_prop_tit ( cart.get_fk_dadosProprietario(), cart.get_st_titularidade() ) )
				{
					dep.fetch();
					dep.delete();
				}
			}
			
			cart.delete();
			
			PublishNote ( "Cartão removido do sistema" );			
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_excluiCart " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_excluiCart " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_excluiCart " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
