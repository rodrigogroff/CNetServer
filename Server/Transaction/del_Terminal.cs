using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class del_Terminal : type_base
	{
		public string input_st_loja_cnpj = "";
		public string input_st_terminal = "";
		
		/// USER [ var_decl ]
		
		T_Loja loj;
		T_Terminal term;
				
		/// USER [ var_decl ] END
		
		public del_Terminal ( Transaction trans ) : base (trans)
		{
			var_Alias = "del_Terminal";
			constructor();
		}
		
		public del_Terminal()
		{
			var_Alias = "del_Terminal";
		
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
			Registry ( "setup del_Terminal " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_DEL_TERMINAL.st_loja_cnpj, ref input_st_loja_cnpj ) == false ) 
			{
				Trace ( "# COMM_IN_DEL_TERMINAL.st_loja_cnpj missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_DEL_TERMINAL.st_terminal, ref input_st_terminal ) == false ) 
			{
				Trace ( "# COMM_IN_DEL_TERMINAL.st_terminal missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_DEL_TERMINAL.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_DEL_TERMINAL.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done del_Terminal " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate del_Terminal " ); 
		
			/// USER [ authenticate ]
			
			loj = new T_Loja (this);
			
			if ( !loj.select_rows_cnpj ( input_st_loja_cnpj ) )
			{
				PublishError ( "Loja não cadastrada" );
				return false;
			}
			
			if ( !loj.fetch() )
				return false;
			
			term = new T_Terminal (this);
			
			if ( !term.select_fk_loja ( loj.get_identity() ) )
				return false;
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done del_Terminal " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute del_Terminal " ); 
		
			/// USER [ execute ]
			
			input_st_terminal = input_st_terminal.PadLeft ( 8, '0' );
			
			T_Terminal term_upd = new T_Terminal (this);
			
			while ( term.fetch() )
			{
				if ( term.get_nu_terminal() == input_st_terminal )
				{
					term_upd.ExclusiveAccess();
					
					term_upd.selectIdentity ( term.get_identity() );
					
					term_upd.set_fk_loja ( Context.NONE );
					
					if ( !term_upd.synchronize_T_Terminal() )
						return false;
					
					term_upd.ReleaseExclusive();
					
					PublishNote ( "Terminal " + input_st_terminal + " removido com sucesso" );
					return true;
				}
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done del_Terminal " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish del_Terminal " ); 
		
			/// USER [ finish ]
			
			LOG_Audit aud = new LOG_Audit (this);
			
			aud.set_tg_operacao	( TipoOperacao.RemoverTerminal			);
			
			aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
			aud.set_dt_operacao ( GetDataBaseTime() 					);
			
			aud.set_st_observacao ( input_st_loja_cnpj );
			
			aud.set_fk_generic  ( term.get_identity() 					);
			
			if ( !aud.create_LOG_Audit() )
				return false;
			
			/// USER [ finish ] END
		
			Registry ( "finish done del_Terminal " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
