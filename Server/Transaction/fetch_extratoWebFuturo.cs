using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_extratoWebFuturo : Transaction
	{
		public string input_st_cartao = "";
		public string input_st_senha = "";
		
		public string output_st_content = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_extratoWebFuturo ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_extratoWebFuturo";
			constructor();
		}
		
		public fetch_extratoWebFuturo()
		{
			var_Alias = "fetch_extratoWebFuturo";
		
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
			Registry ( "setup fetch_extratoWebFuturo " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_EXTRATOWEBFUTURO.st_cartao, ref input_st_cartao ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_EXTRATOWEBFUTURO.st_cartao missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_EXTRATOWEBFUTURO.st_senha, ref input_st_senha ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_EXTRATOWEBFUTURO.st_senha missing! " ); 
				return false;
			}
			
			Registry ( "setup done fetch_extratoWebFuturo " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate fetch_extratoWebFuturo " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_extratoWebFuturo " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute fetch_extratoWebFuturo " ); 
		
			/// USER [ execute ]
			
			T_Cartao cart          = new T_Cartao (this);
			T_Cartao cart_parc_dep = new T_Cartao (this);
			
			if ( !cart.select_rows_tudo ( 	input_st_cartao.Substring (0,6), 
			                             	input_st_cartao.Substring (6,6), 
			                             	input_st_cartao.Substring (12,2) ) )
			{
				PublishError ( "Matrícula não disponível" );
				return false;
			}
			
			if ( !cart.fetch() )
				return false;
			
			if ( cart.get_st_senha() != input_st_senha )
			{
				PublishError ( "Senha inválida" );
				return false;
			}
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( cart.get_st_empresa() ) )
			{
				PublishError ( "Empresa inválida" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			T_Parcelas parc = new T_Parcelas (this);
			
			ArrayList  lstDeps = new ArrayList();
			
			if ( cart_parc_dep.select_rows_empresa_matricula ( 	cart.get_st_empresa(),
					                                            cart.get_st_matricula() ) )
			{
				while ( cart_parc_dep.fetch() )
				{
					lstDeps.Add ( cart_parc_dep.get_identity() );
				}
			}
			
			T_Terminal 		term = new T_Terminal(this);
			T_Loja     		loj  = new T_Loja (this);
			LOG_Transacoes 	l_tr = new LOG_Transacoes (this);
			
			StringBuilder sb_parcs = new StringBuilder();
			
			for ( int t=2; t <= emp.get_int_nu_parcelas(); ++t )
			{
				if ( parc.select_rows_relat_parc ( t.ToString(), ref lstDeps ) )
				{
					while ( parc.fetch() )
					{
						if ( !term.selectIdentity ( parc.get_fk_terminal() ) )
							continue;
						
						if ( !loj.selectIdentity ( term.get_fk_loja() ) )
							continue;
						
						if ( l_tr.selectIdentity ( parc.get_fk_log_transacoes() ) )
							if ( l_tr.get_tg_confirmada() != TipoConfirmacao.Confirmada )
								continue;
						
						Rel_RTC rtc = new Rel_RTC();
			
						rtc.set_st_loja 	 		( loj.get_st_nome() 			);
						rtc.set_vr_total	 		( parc.get_vr_valor() 			);
						rtc.set_nu_parc 	 		( parc.get_nu_tot_parcelas()	);
						rtc.set_st_indice_parcela 	( parc.get_nu_indice() 			);
										
						DataPortable mem_rtc = rtc as DataPortable;
						
						// ## obtem indice
						
						sb_parcs.Append ( MemorySave ( ref mem_rtc ) );
						sb_parcs.Append ( ","   );
					}
				}
			}
			
			string list_ids_parc = sb_parcs.ToString().TrimEnd ( ',' );
									
			DataPortable dp_parcs = new DataPortable();
	
			dp_parcs.setValue ( "ids", list_ids_parc );
			
			output_st_content = MemorySave ( ref dp_parcs );
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_extratoWebFuturo " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish fetch_extratoWebFuturo " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_extratoWebFuturo " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_EXTRATOWEBFUTURO.st_content, output_st_content ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
