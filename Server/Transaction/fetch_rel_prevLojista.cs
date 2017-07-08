using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_rel_prevLojista : type_base
	{
		public string input_st_empresa = "";
		
		public string output_st_csv = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_rel_prevLojista ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_rel_prevLojista";
			constructor();
		}
		
		public fetch_rel_prevLojista()
		{
			var_Alias = "fetch_rel_prevLojista";
		
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
			Registry ( "setup fetch_rel_prevLojista " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_PREVLOJISTA.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_PREVLOJISTA.st_empresa missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_REL_PREVLOJISTA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_REL_PREVLOJISTA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_rel_prevLojista " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_rel_prevLojista " ); 
		
			/// USER [ authenticate ]
			
			if ( input_cont_header.get_tg_user_type() != TipoUsuario.Lojista )
			{
				return false;
			}
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_rel_prevLojista " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_rel_prevLojista " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_st_empresa ) ) 
			{
				PublishError ( "Empresa não disponível" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			T_Loja loj = new T_Loja (this);
			
			if ( !loj.select_rows_loja  ( input_cont_header.get_st_empresa().TrimStart ( '0' ) ) )
				return false;
			
			if ( !loj.fetch() )
				return false;
			
			LINK_LojaEmpresa loj_emp = new LINK_LojaEmpresa (this);
			
			if ( !loj_emp.select_fk_empresa_loja (	 emp.get_identity(),
			                                      loj.get_identity() ) )
			{
				PublishError ( "Loja não conveniada com empresa" );
				return false;
			}
			
			if ( !loj_emp.fetch() )
				return false;
			    
			double 	tx = loj_emp.get_int_tx_admin();
			
			T_Parcelas 	parc = new T_Parcelas 	(this);
			T_Cartao 	cart = new T_Cartao 	(this);
			LOG_Transacoes ltr = new LOG_Transacoes(this);
			
			if ( parc.select_rows_lojista_emp ( loj.get_identity(), 
			                                    emp.get_identity(), 
			                                    "1" ) )
			{
				SQL_LOGGING_ENABLE = false;
				
				StringBuilder sb = new StringBuilder();
				
				while ( parc.fetch() )
				{
					if ( parc.get_tg_pago() == Context.TRUE )
						continue;
					
					if ( !ltr.selectIdentity ( parc.get_fk_log_transacoes() ) )
						continue;
					
					if ( ltr.get_tg_confirmada() != TipoConfirmacao.Confirmada )
						continue;
					
					if ( !cart.selectIdentity ( parc.get_fk_cartao() ) )
						continue;
					
					if ( cart.get_st_empresa() != emp.get_st_empresa() )
						continue;
					
					DadosRepasse dr = new DadosRepasse();
					
					dr.set_st_cartao 	( 	cart.get_st_empresa() + "." + 
											cart.get_st_matricula() + "." + 
											cart.get_st_titularidade() );
					
					dr.set_st_nsu	 	( parc.get_nu_nsu() 		);
					dr.set_dt_trans	 	( parc.get_dt_inclusao() 	);
					dr.set_id_parcela 	( parc.get_nu_indice() 		);
					dr.set_vr_total		( parc.get_vr_valor()		);
					
					//DateTime t_rep = Convert.ToDateTime ( p
					
					//dr.set_dt_repasse   ( 
					
					long repasse = Convert.ToInt64 ( parc.get_int_vr_valor() - ( parc.get_int_vr_valor() * tx / 10000 ) );
					
					dr.set_vr_repasse	( repasse.ToString() );
					
					DataPortable mem_rtc = dr as DataPortable;
				
					// ## obtem indice
					
					sb.Append ( MemorySave ( ref mem_rtc ) );
					sb.Append ( ","   );
				}
				
				string list_ids = sb.ToString().TrimEnd ( ',' );
									
				DataPortable dp = new DataPortable();
				
				dp.setValue ( "ids", list_ids );
					
				// ## obtem indice geral
				
				output_st_csv = MemorySave ( ref dp );
				
				SQL_LOGGING_ENABLE = true;
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_rel_prevLojista " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_rel_prevLojista " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_rel_prevLojista " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_PREVLOJISTA.st_csv, output_st_csv ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
