using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class ins_payFone : type_base
	{
		public string input_st_pf_empresa = "";
		public string input_st_pf_mat = "";
		public string input_st_pf_telefone = "";
		
		/// USER [ var_decl ]
				
		T_Cartao cart;
		T_PayFone pf;
		
		/// USER [ var_decl ] END
		
		public ins_payFone ( Transaction trans ) : base (trans)
		{
			var_Alias = "ins_payFone";
			constructor();
		}
		
		public ins_payFone()
		{
			var_Alias = "ins_payFone";
		
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
			Registry ( "setup ins_payFone " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_PAYFONE.st_pf_empresa, ref input_st_pf_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_INS_PAYFONE.st_pf_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_PAYFONE.st_pf_mat, ref input_st_pf_mat ) == false ) 
			{
				Trace ( "# COMM_IN_INS_PAYFONE.st_pf_mat missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_PAYFONE.st_pf_telefone, ref input_st_pf_telefone ) == false ) 
			{
				Trace ( "# COMM_IN_INS_PAYFONE.st_pf_telefone missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_INS_PAYFONE.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_INS_PAYFONE.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done ins_payFone " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate ins_payFone " ); 
		
			/// USER [ authenticate ]
			
			input_st_pf_empresa = input_st_pf_empresa.PadLeft ( 6 , '0' );
			input_st_pf_mat     = input_st_pf_mat.PadLeft ( 6 , '0' );
			
			cart = new T_Cartao (this);
			
			if ( !cart.select_rows_empresa_matricula ( input_st_pf_empresa, input_st_pf_mat ) )
			{
				PublishError ( "Cartão inválido" );
				return false;
			}
			
			if ( !cart.fetch() )
				return false;
			
			if ( cart.get_tg_tipoCartao() == TipoCartao.presente )
			{
				PublishError ( "Cartão de presente não faz operações em Pay Fone" );
				return false;
			}
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done ins_payFone " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute ins_payFone " ); 
		
			/// USER [ execute ]
			
			pf = new T_PayFone (this);
			
			if ( pf.select_rows_telefone ( input_st_pf_telefone ) )
			{
				PublishError ( "Telefone já utilizado" );
				return false;
			}
			
			pf.Reset();
			
			pf.set_fk_cartao 		( cart.get_identity() 	);
			pf.set_fk_terminal		( Context.NOT_SET 		);
			pf.set_st_telefone 		( input_st_pf_telefone 	);
			pf.set_tg_tipoCelular 	( TipoCelular.CLIENTE 	);
			
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
		
			Registry ( "execute done ins_payFone " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish ins_payFone " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.CadPayFoneCliente		);
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( pf.get_st_telefone() );
				
				aud.set_fk_generic  ( pf.get_identity() 					);
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done ins_payFone " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
