using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class web_fetch_edu_inicial : Transaction
	{
		public string input_st_cpf = "";
		public string input_st_cartao = "";
		public string input_st_senha = "";
		public string input_st_ip = "";
		
		public string output_tg_resp = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public web_fetch_edu_inicial ( Transaction trans ) : base (trans)
		{
			var_Alias = "web_fetch_edu_inicial";
			constructor();
		}
		
		public web_fetch_edu_inicial()
		{
			var_Alias = "web_fetch_edu_inicial";
		
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
			Registry ( "setup web_fetch_edu_inicial " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_FETCH_EDU_INICIAL.st_cpf, ref input_st_cpf ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_FETCH_EDU_INICIAL.st_cpf missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_FETCH_EDU_INICIAL.st_cartao, ref input_st_cartao ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_FETCH_EDU_INICIAL.st_cartao missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_FETCH_EDU_INICIAL.st_senha, ref input_st_senha ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_FETCH_EDU_INICIAL.st_senha missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_WEB_FETCH_EDU_INICIAL.st_ip, ref input_st_ip ) == false ) 
			{
				Trace ( "# COMM_IN_WEB_FETCH_EDU_INICIAL.st_ip missing! " ); 
				return false;
			}
			
			Registry ( "setup done web_fetch_edu_inicial " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate web_fetch_edu_inicial " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done web_fetch_edu_inicial " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute web_fetch_edu_inicial " ); 
		
			/// USER [ execute ]
			
			output_tg_resp = Context.FALSE;
			
			if  ( input_st_cpf.Length > 0 )
			{
				T_Proprietario prot = new T_Proprietario(this);
				
				if ( !prot.select_rows_cpf ( input_st_cpf ) )
				{
					PublishError ( "CPF inválido" );
					return false;
				}
				
				if ( !prot.fetch () )
					return false;
				
				if ( prot.get_st_senhaEdu() != input_st_senha )
				{
					PublishError ( "Senha de responsável inválida" );
					return false;
				}
				
				output_tg_resp = Context.TRUE;
				
				LINK_ProprietarioCartao prop_cart = new LINK_ProprietarioCartao (this);
				
				if ( !prop_cart.select_fk_proprietario ( prot.get_identity() ) )
				{
					PublishError ( "Nenhum cartão educacional cadastrado" );
					return false;
				}
				
				T_Cartao cart = new T_Cartao (this);
				
				bool found = false;
				
				while ( prop_cart.fetch() )
				{
					if ( !cart.selectIdentity ( prop_cart.get_fk_cartao() ) )
						return false;
					
					if ( cart.get_tg_tipoCartao() == TipoCartao.educacional )
					{
						found = true;
						break;
					}
					
					Trace ( input_st_senha 	);
				}
				
				if ( !found )
				{
					PublishError ( "Nenhum cartão educacional encontrado" );
					return false;
				}
			}
			else if ( input_st_cartao.Length > 0 )
			{
				input_st_cartao = input_st_cartao.PadLeft ( 14, '0' );
				
				T_Cartao cart = new T_Cartao (this);
				
				cart.ExclusiveAccess();
				
				if ( !cart.select_rows_tudo ( input_st_cartao.Substring (  0,6 ),
				                             input_st_cartao.Substring (  6,6 ),
				                             input_st_cartao.Substring ( 12,2 ) ) )
				{
					PublishError ( "Cartão inválido" );
					return false;
				}
				
				if ( !cart.fetch() )
					return false;
								
				T_WebBlock ip_block = new T_WebBlock(this);
				
				if ( ip_block.select_rows_ip ( input_st_ip, GetDataBaseTime(), cart.get_identity() ) )
				{
					PublishError ( "Senha de aluno inválida" );
					return false;					
				}
			
				if ( cart.get_st_senha() != input_st_senha )
				{
					long senhas_erradas = cart.get_int_nu_webSenhaErrada() + 1;
					
					if ( senhas_erradas >= 4 )
					{
						ip_block.set_dt_expire ( GetDataBaseTime ( DateTime.Now.AddDays(1) ) );
						ip_block.set_st_ip     ( input_st_ip );
						ip_block.set_fk_cartao ( cart.get_identity() );
						
						if ( !ip_block.create_T_WebBlock() )
							return false;
					}
										
					cart.set_nu_webSenhaErrada ( senhas_erradas.ToString() );
					
					if ( !cart.synchronize_T_Cartao() )
						return false;
					
					PublishError ( "Senha de aluno inválida" );
					return false;
				}
				
				cart.set_nu_webSenhaErrada ( "0" );
				
				if ( !cart.synchronize_T_Cartao() )
					return false;
				
				output_tg_resp = Context.FALSE;
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done web_fetch_edu_inicial " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish web_fetch_edu_inicial " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done web_fetch_edu_inicial " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_WEB_FETCH_EDU_INICIAL.tg_resp, output_tg_resp ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
