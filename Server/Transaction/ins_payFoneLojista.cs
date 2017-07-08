using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class ins_payFoneLojista : type_base
	{
		public string input_st_pf_empresa = "";
		public string input_st_pf_term = "";
		public string input_st_pf_telefone = "";
		
		/// USER [ var_decl ]
		
		T_Terminal term;
		T_PayFone pf;
		
		/// USER [ var_decl ] END
		
		public ins_payFoneLojista ( Transaction trans ) : base (trans)
		{
			var_Alias = "ins_payFoneLojista";
			constructor();
		}
		
		public ins_payFoneLojista()
		{
			var_Alias = "ins_payFoneLojista";
		
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
			Registry ( "setup ins_payFoneLojista " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_PAYFONELOJISTA.st_pf_empresa, ref input_st_pf_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_INS_PAYFONELOJISTA.st_pf_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_PAYFONELOJISTA.st_pf_term, ref input_st_pf_term ) == false ) 
			{
				Trace ( "# COMM_IN_INS_PAYFONELOJISTA.st_pf_term missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_PAYFONELOJISTA.st_pf_telefone, ref input_st_pf_telefone ) == false ) 
			{
				Trace ( "# COMM_IN_INS_PAYFONELOJISTA.st_pf_telefone missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_INS_PAYFONELOJISTA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_INS_PAYFONELOJISTA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done ins_payFoneLojista " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate ins_payFoneLojista " ); 
		
			/// USER [ authenticate ]
			
			input_st_pf_term = input_st_pf_term.PadLeft ( 8, '0' );
			
			term = new T_Terminal (this);
			
			if ( !term.select_rows_terminal ( input_st_pf_term ) )
			{
				PublishError ( "Terminal inválido" );
				return false;
			}
			
			if ( !term.fetch() )
				return false;
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done ins_payFoneLojista " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute ins_payFoneLojista " ); 
		
			/// USER [ execute ]
			
			pf = new T_PayFone (this);
			
			if ( pf.select_rows_telefone ( input_st_pf_telefone ) )
			{
				PublishError ( "Telefone já utilizado" );
				return false;
			}
			
			pf.Reset();
			
			pf.set_fk_cartao 		( Context.NOT_SET 		);
			pf.set_fk_terminal		( term.get_identity()	);
			pf.set_st_telefone 		( input_st_pf_telefone 	);
			pf.set_tg_tipoCelular 	( TipoCelular.LOJA 		);
			
			if ( !pf.create_T_PayFone() )
				return false;
			
			string m_sSessionSeed = "abcdefghijklmnopqrstuvxywz0123456789";
			string st_cod_ativ = "";
			
			Random randObj = new Random();
			
       		int iLen = m_sSessionSeed.Length;
       		for (int t=0; t < 8; ++t)
				st_cod_ativ += m_sSessionSeed[ randObj.Next( 0, iLen ) ].ToString();
       		
			LINK_PFAtivacao l_pfativa = new LINK_PFAtivacao (this);
			
			l_pfativa.set_fk_payfone 	( pf.get_identity() );
			l_pfativa.set_dt_ativacao 	( GetDataBaseTime() );
			l_pfativa.set_st_ativacao 	( st_cod_ativ 		);
			l_pfativa.set_tg_status 	( Context.OPEN		);
			
			if ( !l_pfativa.create_LINK_PFAtivacao() )
				return false;
		
			PublishNote ( "Sucesso na criação de PayFone. Código: " + st_cod_ativ );
			
			/// USER [ execute ] END
		
			Registry ( "execute done ins_payFoneLojista " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish ins_payFoneLojista " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.CadPayFoneLojista		);
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( pf.get_st_telefone() );
				
				aud.set_fk_generic  ( pf.get_identity() 					);
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}

			/// USER [ finish ] END
		
			Registry ( "finish done ins_payFoneLojista " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
