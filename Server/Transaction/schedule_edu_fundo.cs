using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]

using System.Net;
using System.Threading;

/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class schedule_edu_fundo : schedule_base
	{
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public schedule_edu_fundo ( Transaction trans ) : base (trans)
		{
			var_Alias = "schedule_edu_fundo";
			constructor();
		}
		
		public schedule_edu_fundo()
		{
			var_Alias = "schedule_edu_fundo";
		
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
			Registry ( "setup schedule_edu_fundo " ); 
		
			Registry ( "setup done schedule_edu_fundo " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate schedule_edu_fundo " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done schedule_edu_fundo " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute schedule_edu_fundo " ); 
		
			/// USER [ execute ]
			
			if ( DateTime.Now.DayOfWeek == DayOfWeek.Saturday ||
			     DateTime.Now.DayOfWeek == DayOfWeek.Sunday )
			{
				return true;
			}
			
			T_Edu_EmpresaVirtual virt = new T_Edu_EmpresaVirtual (this);
			T_Edu_EmpresaVirtual virt_upd = new T_Edu_EmpresaVirtual (this);
			
			string dt_time =  DateTime.Now.Year.ToString()                     + "-" + 
                     		  DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + "-" +
                     		  DateTime.Now.Day.ToString().PadLeft   ( 2, '0' ) + " 00:00:00";
			
			LOG_Edu_RendimentoEmpresa rend = new LOG_Edu_RendimentoEmpresa (this);
				
			if ( virt.selectAll() )
			{
				while ( virt.fetch() )
				{
					bool web_Ok = false;
					
					while ( !web_Ok )
					{
						try
						{
							#region - busca valor de oscilação - 
							
							int index = 0;
							string osc_web = "";
												
							WebClient client = new WebClient ();
				
							string web = client.DownloadString ( 	"http://www.bovespa.com.br/Cotacoes2000/formCotacoesMobile.asp?codsocemi=" + 
							                                    	virt.get_st_codigo() + 
							                                    	"3" );
							
							client.Dispose();
							
							Trace ( web );
							
							if ( web.IndexOf ( "NUMERO_DO_ERRO" ) == -1 )
							{
								index   = web.IndexOf ( "OSCILACAO=" ) + 11;
								osc_web = web.Substring ( index, 15 );
								osc_web = osc_web.Substring ( 0, osc_web.IndexOf ( " " ) - 1 );
							}
							else
							{
								osc_web = "0,0000";
							}
							
							if ( osc_web.IndexOf ( "," ) == -1 )
								osc_web += ",0000";
							
							index = osc_web.IndexOf ( "," ) + 1;
							
							int diff  = osc_web.Length - index;
							
							// força 4 casas após a virgula
							if ( diff < 4 )
								osc_web = osc_web.PadRight ( 4 - diff, '0' );
							
							#endregion
							
							// pega valor inteiro, acrescenta 4 casas
							double oscilacao = Convert.ToDouble ( osc_web ) * 10000;
							// converte para string
							string osc_rend  = Convert.ToInt64 ( oscilacao ).ToString();
							
							if ( osc_web.IndexOf ( "-" ) >= 0 )
								rend.set_tg_neg ( Context.TRUE );
							else
								rend.set_tg_neg ( Context.FALSE );
							
							rend.set_vr_pct	 			( osc_rend.Replace ( "-", "" ) 	);
							rend.set_fk_empresaVirtual 	( virt.get_identity() 			);
							rend.set_dt_rend 			( dt_time 						);
							
							rend.create_LOG_Edu_RendimentoEmpresa();		
							
							oscilacao /= 10000;
							oscilacao /= 100;
							
							virt_upd.selectIdentity ( virt.get_identity() );
							
							long final_fundo = virt_upd.get_int_vr_valorAcao() + Convert.ToInt64 ( virt_upd.get_int_vr_valorAcao() * oscilacao );
							
							virt_upd.set_vr_valorAcao ( final_fundo.ToString() );
							
							virt_upd.synchronize_T_Edu_EmpresaVirtual();						
							
							web_Ok = true;
						}
						catch ( System.Exception ex )
						{
							Registry ( ex.ToString() );
							
							Thread.Sleep ( 250 );
							
							Registry ( "Trying again" );
						}						
					}
				}				
			}
			
			// descobre o rank
			T_Cartao cart_rank = new T_Cartao (this);
			T_Cartao cart_upd  = new T_Cartao (this);
			
			LINK_Edu_FundoEmpresa 	lnk = new LINK_Edu_FundoEmpresa (this);
			T_Edu_EmpresaVirtual	emp = new T_Edu_EmpresaVirtual (this);
			
			if ( cart_rank.select_rows_tipo ( TipoCartao.educacional ) )
			{
				Hashtable hshVal = new Hashtable();
				ArrayList lstVal = new ArrayList();
				
				while ( cart_rank.fetch() )
				{
					long invest_virtual = 0;
					
					if ( lnk.select_fk_cart ( cart_rank.get_identity() ) )
					{
						while ( lnk.fetch() )
						{
							if ( !emp.selectIdentity ( lnk.get_fk_empresa() ) )
								return false;
							
							invest_virtual += lnk.get_int_vr_fundo() * emp.get_int_vr_valorAcao();
						}
					}
					
					if ( invest_virtual > 0 )
					{
						invest_virtual += cart_rank.get_int_vr_edu_disp_virtual();
							
						lstVal.Add ( invest_virtual );
						
						if ( hshVal [ invest_virtual ] == null ) 
							hshVal [ invest_virtual ] = new ArrayList();
						
						ArrayList tmp = hshVal [ invest_virtual ] as ArrayList;
						
						tmp.Add ( cart_rank.get_identity() );
					}
				}
				
				lstVal.Sort();
				
				for ( int t= lstVal.Count -1, rank = 1; t >=0 ; --t, ++rank )
				{
					ArrayList tmp = hshVal [ (long) lstVal[t]  ] as ArrayList;
					
					for (int y=0; y < tmp.Count; ++y )
					{
						string ident = tmp [y].ToString();
						
						cart_upd.ExclusiveAccess();
						cart_upd.selectIdentity ( ident );
							
						cart_upd.set_nu_rankVirtual ( rank.ToString() );
						cart_upd.set_vr_edu_total_ranking ( lstVal[t].ToString() );
						
						cart_upd.synchronize_T_Cartao();
						cart_upd.ReleaseExclusive();
					}
				}
			}
												
			/// USER [ execute ] END
		
			Registry ( "execute done schedule_edu_fundo " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish schedule_edu_fundo " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done schedule_edu_fundo " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
