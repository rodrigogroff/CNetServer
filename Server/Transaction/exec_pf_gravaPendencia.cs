using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_pf_gravaPendencia : type_pf_base
	{
		public string input_st_telefoneLoja = "";
		public string input_vr_valor = "";
		
		public string output_st_nsu = "";
		
		/// USER [ var_decl ]
			
		T_PayFone pf_lojista;
			
		/// USER [ var_decl ] END
		
		public exec_pf_gravaPendencia ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_pf_gravaPendencia";
			constructor();
		}
		
		public exec_pf_gravaPendencia()
		{
			var_Alias = "exec_pf_gravaPendencia";
		
			ut_max = 0;
			
			constructor();
		}
		
		public override void constructor()
		{
			/// USER [ constructor ]
			
			GravaNSU = true;
			
			var_operacaoCartao 		= OperacaoCartao.PAY_FONE_GRAVA_PEND;
			var_operacaoCartaoFail 	= OperacaoCartao.FALHA_PAY_FONE_GRAVA_PEND;
						
			/// USER [ constructor ] END
		}
		
		public override bool setup ( ) 
		{
			#region - SETUP TRANSACTION -
			Registry ( "setup exec_pf_gravaPendencia " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_PF_GRAVAPENDENCIA.st_telefoneLoja, ref input_st_telefoneLoja ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_PF_GRAVAPENDENCIA.st_telefoneLoja missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_PF_GRAVAPENDENCIA.vr_valor, ref input_vr_valor ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_PF_GRAVAPENDENCIA.vr_valor missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_PF_GRAVAPENDENCIA.st_telefone, ref input_st_telefone ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_PF_GRAVAPENDENCIA.st_telefone missing! " ); 
				return false;
			}
			
			Registry ( "setup done exec_pf_gravaPendencia " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_pf_gravaPendencia " ); 
		
			/// USER [ authenticate ]
			
			var_valorTotal = input_vr_valor;
			
			// ## Busca payfone do lojista pelo tel informado
							
			pf_lojista = new T_PayFone (this);
			
			if ( !pf_lojista.select_rows_telefone ( input_st_telefoneLoja ) )
			{
				output_st_codResp = "98"; 
				output_st_msg 	  = "Telefone inválido";
				return false;
			}
			
			if ( !pf_lojista.fetch() )
			{
				output_st_codResp = "80"; 
				output_st_msg     = "Erro de aplicativo";
				return false;
			}
			
			// ## Busca terminal pelo payfone do lojista
			
			if ( !term.selectIdentity ( pf_lojista.get_fk_terminal() ) )
			{
				output_st_codResp = "87"; 
				output_st_msg 	  = "Terminal invalido";
				return false;
			}
			
			T_Loja loj = new T_Loja (this);
			
			if ( !loj.selectIdentity ( term.get_fk_loja() ) )
			{
				output_st_codResp = "87"; 
				output_st_msg 	  = "Terminal invalido";
				return false;
			}
			
			if ( loj.get_tg_blocked() == Context.TRUE )
			{
				output_st_codResp = "87"; 
				output_st_msg 	  = "Terminal invalido";
				return false;
			}
						
			// ## Busca empresa
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( cart.get_st_empresa() ) )
			{
				output_st_codResp = "80"; 
				output_st_msg     = "Erro de aplicativo";
				return false;
			}
			
			if ( !emp.fetch() )
			{
				output_st_codResp = "80"; 
				output_st_msg     = "Erro de aplicativo";
				return false;
			}
			
			// ## Se empresa estiver bloqueada, sair
			
			if ( emp.get_tg_blocked() == Context.TRUE )
			{
				output_st_codResp = "65"; 
				output_st_msg     = "Empresa bloqueada";
				return false;
			}
					
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_pf_gravaPendencia " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_pf_gravaPendencia " ); 
		
			/// USER [ execute ]
			
			// ## Criar pendência para payfone de usuário
			
			T_PendPayFone pendPayFone = new T_PendPayFone (this);
            
            pendPayFone.set_dt_inclusao ( GetDataBaseTime() 			);
            pendPayFone.set_fk_cartao   ( pf_usuario.get_fk_cartao() 	);
            pendPayFone.set_fk_terminal ( pf_lojista.get_fk_terminal()  );
            pendPayFone.set_fk_empresa  ( emp.get_identity()			);
            pendPayFone.set_nu_nsu      ( var_nsu						);
            pendPayFone.set_vr_valor    ( var_valorTotal				);
            pendPayFone.set_fk_loja     ( term.get_fk_loja() 			);
            pendPayFone.set_en_situacao ( TipoPendPayFone.PENDENTE 		);
            
            if ( !pendPayFone.create_T_PendPayFone() )
            {
				output_st_codResp = "70"; 
				output_st_msg 	  = "Erro de aplicativo";
				return false;
			}	
            
            output_st_codResp  = "00";
            output_st_nsu      = var_nsu;
            output_st_msg 	   = "";
                       	            
			/// USER [ execute ] END
		
			Registry ( "execute done exec_pf_gravaPendencia " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_pf_gravaPendencia " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_pf_gravaPendencia " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_GRAVAPENDENCIA.st_nsu, output_st_nsu ); 
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_GRAVAPENDENCIA.st_codResp, output_st_codResp ); 
			dp_out.MapTagValue ( COMM_OUT_EXEC_PF_GRAVAPENDENCIA.st_msg, output_st_msg ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
