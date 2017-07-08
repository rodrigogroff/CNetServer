using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class ins_terminal : type_base
	{
		public string input_st_loja_cnpj = "";
		
		public DadosTerminal input_cont_dt = new DadosTerminal();
		
		/// USER [ var_decl ]
		
		T_Loja loj;
		T_Terminal term;

		int my_term = 0;
			
		/// USER [ var_decl ] END
		
		public ins_terminal ( Transaction trans ) : base (trans)
		{
			var_Alias = "ins_terminal";
			constructor();
		}
		
		public ins_terminal()
		{
			var_Alias = "ins_terminal";
		
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
			Registry ( "setup ins_terminal " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_TERMINAL.st_loja_cnpj, ref input_st_loja_cnpj ) == false ) 
			{
				Trace ( "# COMM_IN_INS_TERMINAL.st_loja_cnpj missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			DataPortable ct_2 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_INS_TERMINAL.dt, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_INS_TERMINAL.dt missing! " ); 
				return false;
			}
			if ( var_Comm.GetEntryPortableAtPosition(2).GetMapContainer ( COMM_IN_INS_TERMINAL.header, ref ct_2 ) == false )
			{
				Trace ( "# COMM_IN_INS_TERMINAL.header missing! " ); 
				return false;
			}
			
			input_cont_dt.Import ( ct_1 );
			input_cont_header.Import ( ct_2 );
			
			Registry ( "setup done ins_terminal " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate ins_terminal " ); 
		
			/// USER [ authenticate ]

			term = new T_Terminal (this);
			
			my_term = Convert.ToInt32 ( input_st_loja_cnpj );
			
			while ( term.select_rows_terminal ( my_term.ToString().PadLeft ( 8, '0' ) ) )
			{
				term.fetch();
				
				if ( term.get_fk_loja() == "0" )
					break;
				else
					my_term++;
			}

			loj = new T_Loja (this);
			
			if ( !loj.select_rows_loja ( input_st_loja_cnpj ) )
			{
				PublishError ( "Código de loja não encontrado" );
				return false;
			}
			
			if ( !loj.fetch() )
				return false;
									
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done ins_terminal " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute ins_terminal " ); 
		
			/// USER [ execute ]

			term.Reset();
			
			term.set_fk_loja 		( loj.get_identity() 					);
			term.set_nu_terminal 	( my_term.ToString().PadLeft ( 8, '0' )	);
			term.set_st_localizacao ( input_cont_dt.get_st_localizacao() 	);
			
			if ( !term.create_T_Terminal() )
				return false;
			
			PublishNote ( "Terminal criado com suceesso (" + my_term.ToString() + ")"  );
			
			/// USER [ execute ] END
		
			Registry ( "execute done ins_terminal " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish ins_terminal " ); 
		
			/// USER [ finish ]

			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.CadTerminal 				);
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				aud.set_st_observacao ( term.get_st_localizacao() );
				
				aud.set_fk_generic  ( term.get_identity() 					);
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done ins_terminal " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
