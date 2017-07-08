using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_rel_repEfetivo : type_base
	{
		public string input_st_empresa = "";
		public string input_dt_ini = "";
		public string input_dt_fim = "";
		public string input_st_loja = "";
		
		public string output_st_csv_contents = "";
		public string output_st_csv_pagto = "";
		public string output_st_nome_empresa = "";
		public string output_st_csv_lojas = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_rel_repEfetivo ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_rel_repEfetivo";
			constructor();
		}
		
		public fetch_rel_repEfetivo()
		{
			var_Alias = "fetch_rel_repEfetivo";
		
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
			Registry ( "setup fetch_rel_repEfetivo " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_REPEFETIVO.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_REPEFETIVO.st_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_REPEFETIVO.dt_ini, ref input_dt_ini ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_REPEFETIVO.dt_ini missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_REPEFETIVO.dt_fim, ref input_dt_fim ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_REPEFETIVO.dt_fim missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_REPEFETIVO.st_loja, ref input_st_loja ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_REPEFETIVO.st_loja missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_REL_REPEFETIVO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_REL_REPEFETIVO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_rel_repEfetivo " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_rel_repEfetivo " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_rel_repEfetivo " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_rel_repEfetivo " ); 
		
			/// USER [ execute ]
		
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_st_empresa ) )
			{
				PublishError ( "Empresa não disponível" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			output_st_nome_empresa = emp.get_st_fantasia();
			
			T_RepasseLoja repLoja = new T_RepasseLoja (this);
			
			if ( !repLoja.select_rows_dt ( input_dt_ini, input_dt_fim ) )
			{
				PublishError ( "Nenhum repasse encontrado" );
				return false;
			}
			
			LINK_RepasseParcela lrp 	= new LINK_RepasseParcela 	(this);
			LINK_LojaEmpresa 	loj_emp = new LINK_LojaEmpresa 		(this);
			T_Loja 				loj  	= new T_Loja 				(this);
			T_Parcelas 			parc	= new T_Parcelas 			(this);
			T_Cartao 			cart 	= new T_Cartao 				(this);
			
			StringBuilder sb_lojas 			= new StringBuilder ();
			StringBuilder sb_content 		= new StringBuilder ();
			StringBuilder sb_contentPagto 	= new StringBuilder ();
			
			string 	id_rep_loja  = "";
			
			while ( repLoja.fetch() )
			{
				if ( !loj.selectIdentity ( repLoja.get_fk_loja() ) )
					return false;
				
				if ( input_st_loja.Length > 0 )
					if ( loj.get_st_loja() != input_st_loja )
						continue;
				
				if ( !loj_emp.select_fk_empresa_loja ( emp.get_identity(), loj.get_identity() ) )
					return false;
				
				if ( !loj_emp.fetch() )
					return false;
				
				// obtenho identificação geral deste pagto
				id_rep_loja = loj.get_st_nome() + " [" + loj.get_st_loja() + "] Perc.: " + ( (double) loj_emp.get_int_tx_admin()/100 ).ToString().Replace (",", "." ) + "% <br>Data Repasse: " + repLoja.get_dt_efetiva();
				
				sb_lojas.Append ( id_rep_loja 		);
				sb_lojas.Append ( "," 				);
				
				double tx = loj_emp.get_int_tx_admin();
				
				DadosPagtoRepasse dpr = new DadosPagtoRepasse();
				
				dpr.set_st_loja	 ( id_rep_loja 				);
				dpr.set_vr_valor ( repLoja.get_vr_valor() 	);
				dpr.set_tg_opcao ( repLoja.get_tg_opcao() 	);
				dpr.set_dt_pagto ( repLoja.get_dt_efetiva() );
								
				if ( repLoja.get_tg_opcao() != TipoPagamento.Cheque && 
				     repLoja.get_tg_opcao() != TipoPagamento.Dinheiro )
				{
					// valor em depósito
					dpr.set_st_extra ( "Banco (" 		+ loj_emp.get_st_banco() + 
					                   ") Agência (" 	+ loj_emp.get_st_ag() 	 + 
					                   ") Conta (" 		+ loj_emp.get_st_conta() + ")" );
				}
				else
				{
					dpr.set_st_extra ( repLoja.get_st_ident() );	
				}
				
				// index em memoria, retrieve depois
				{
					DataPortable port = dpr;
					
					sb_contentPagto.Append ( MemorySave ( ref port ) );
					sb_contentPagto.Append ( "," 				);
				}				
				
				// busco detalhes
				
				if ( !lrp.select_fk_rep ( repLoja.get_identity() ) )
					return false;
				
				while ( lrp.fetch() )
				{
					if ( !parc.selectIdentity ( lrp.get_fk_parcela() ) )
						return false;
					
					if ( !cart.selectIdentity ( parc.get_fk_cartao() ) )
						return false;
					
					DadosRepasse dr = new DadosRepasse();
					
					dr.set_st_loja	 (  id_rep_loja );
					
					dr.set_st_nsu    ( parc.get_nu_nsu() 		);
					dr.set_dt_trans  ( parc.get_dt_inclusao()  	);
					dr.set_st_cartao ( cart.get_st_empresa()   + "." +
					                   cart.get_st_matricula() + "." + 
					                   cart.get_st_titularidade() );
					
					long det_tot = Convert.ToInt64 ( parc.get_int_vr_valor() - ( parc.get_int_vr_valor() * tx / 10000 ) );
					
					dr.set_vr_repasse ( det_tot.ToString() );
					dr.set_vr_total   ( parc.get_vr_valor() );
					
					// index em memoria, retrieve depois
					{
						DataPortable port = dr;
						
						sb_content.Append ( MemorySave ( ref port ) );
						sb_content.Append ( "," 				);
					}
				}
			}
			
			output_st_csv_lojas = sb_lojas.ToString().TrimEnd ( ',' );
			
			// indexa todos os items
			{
				string list_ids = sb_content.ToString().TrimEnd ( ',' );
			
				if ( list_ids == "" )
				{
					PublishNote ( "Nenhum registro encontrado" );
					return false;
				}
										
				DataPortable dp = new DataPortable();
				
				dp.setValue ( "ids", list_ids );
				
				// ## Guarda indexador de grupo
							  
				output_st_csv_contents = MemorySave ( ref dp );
			}
			
			// indexa todos os pagamentos
			{
				string list_ids = sb_contentPagto.ToString().TrimEnd ( ',' );
			
				if ( list_ids == "" )
				{
					PublishNote ( "Nenhum registro encontrado" );
					return false;
				}
										
				DataPortable dp = new DataPortable();
				
				dp.setValue ( "ids", list_ids );
				
				// ## Guarda indexador de grupo
							  
				output_st_csv_pagto = MemorySave ( ref dp );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_rel_repEfetivo " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_rel_repEfetivo " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_rel_repEfetivo " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_REPEFETIVO.st_csv_contents, output_st_csv_contents ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_REPEFETIVO.st_csv_pagto, output_st_csv_pagto ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_REPEFETIVO.st_nome_empresa, output_st_nome_empresa ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_REPEFETIVO.st_csv_lojas, output_st_csv_lojas ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
