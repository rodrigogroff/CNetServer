using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_dadosFaturamento : type_base
	{
		public string input_tg_empresa = "";
		public string input_st_codigo = "";
		
		public string output_st_msg = "";
		public string output_vr_valor = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_dadosFaturamento ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_dadosFaturamento";
			constructor();
		}
		
		public fetch_dadosFaturamento()
		{
			var_Alias = "fetch_dadosFaturamento";
		
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
			Registry ( "setup fetch_dadosFaturamento " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_DADOSFATURAMENTO.tg_empresa, ref input_tg_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_DADOSFATURAMENTO.tg_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_DADOSFATURAMENTO.st_codigo, ref input_st_codigo ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_DADOSFATURAMENTO.st_codigo missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_DADOSFATURAMENTO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_DADOSFATURAMENTO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_dadosFaturamento " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_dadosFaturamento " ); 
		
			/// USER [ authenticate ]
			
			T_Faturamento 			fat 	= new T_Faturamento (this);
			T_FaturamentoDetalhes 	fat_det = new T_FaturamentoDetalhes (this);

			T_Empresa 	emp = new T_Empresa (this);
			T_Loja 		loj = new T_Loja 	(this);
			
			money mon = new money();
			
			string ident = "";
						
			if ( input_tg_empresa == Context.TRUE )
			{
				if ( !emp.select_rows_empresa ( input_st_codigo.PadLeft ( 6, '0' ) ) )
				{
					PublishError ( "Empresa não existente" );
					return false;
				}
				
				if ( !emp.fetch() )
					return false;
				
				output_st_msg += emp.get_st_social()   + "@";
				output_st_msg += emp.get_st_fantasia() + "@";
				output_st_msg += emp.get_nu_CNPJ()     + "@";
				output_st_msg += emp.get_nu_telefone() + "@";
				
				output_st_msg += "@Faturamento pendente: @@";
				
				fat.SetReversedFetch();
				
				if ( !fat.select_rows_emp ( emp.get_identity() ) )
				{
					PublishError ( "Nenhum faturamento encontrado" );
					return false;
				}
				
				ident = emp.get_st_fantasia();
			}
			else
			{
				if ( !loj.select_rows_loja ( input_st_codigo ) )
				{
					PublishError ( "Loja não existente" );
					return false;
				}
				
				if ( !loj.fetch() )
					return false;
				
				output_st_msg += loj.get_st_nome()     + "@";
				output_st_msg += loj.get_st_social()   + "@";
				output_st_msg += loj.get_nu_CNPJ()     + "@";
				output_st_msg += loj.get_nu_telefone();
										
				//fat.SetReversedFetch();
				
				if ( !fat.select_rows_loj ( loj.get_identity() ) )
				{
					PublishError ( "Nenhum faturamento encontrado" );
					return false;
				}
			}
			
			bool Found = false;
			
			long tot_cob = 0;

			while ( fat.fetch() )
			{
				if ( fat.get_tg_situacao() == TipoSitFat.Pendente )
				{
					output_st_msg += "@@Faturamento pendente: ";
					Found = true;
				}
				else if ( fat.get_tg_situacao() == TipoSitFat.EmCobrança )
				{
					output_st_msg += "@@Faturamento em cobrança: ";
					Found = true;
				}
				else
					continue;
				
				output_st_msg += var_util.getDDMMYYYY_format ( fat.get_dt_vencimento() ).Substring ( 0, 10) + "@";
				output_st_msg += "@Total: R$ " + mon.formatToMoney ( fat.get_vr_cobranca() ) + "@";
				
				tot_cob += fat.get_int_vr_cobranca();
				
				if ( !fat_det.select_fk_fat ( fat.get_identity() ) )
				{
					PublishNote ( "Nenhum faturamento encontrado" );
				}
				
				output_st_msg += "@------ Detalhes ------- @";
				
				while ( fat_det.fetch() )
				{
					switch ( fat_det.get_tg_tipoFat() )
					{
						case TipoFat.TBM:
						{
							output_st_msg += "@Tarifa básica mensal: ".PadRight ( 33, ' ' ) + "R$ " + mon.formatToMoney ( fat_det.get_vr_cobranca() ).PadLeft ( 7, ' ' );
							break;
						}
						case TipoFat.CartaoAtiv:
						{
							output_st_msg += "@Tarifa por cartões ativos: ".PadRight ( 33, ' ' ) + "R$ " + mon.formatToMoney ( fat_det.get_vr_cobranca() ).PadLeft ( 7, ' ' );
							break;
						}
						case TipoFat.FixoTrans:
						{
							output_st_msg += "@Valor sobre Transações: ".PadRight ( 33, ' ' ) + "R$ " + mon.formatToMoney ( fat_det.get_vr_cobranca() ).PadLeft ( 7, ' ' );
							break;
						}
						case TipoFat.Percent:
						{
							output_st_msg += "@Percentual sobre Transações: ".PadRight ( 33, ' ' ) + "R$ " + mon.formatToMoney ( fat_det.get_vr_cobranca() ).PadLeft ( 7, ' ' );
							break;
						}
					}
				}
				
				if ( !fat_det.select_fk_fat ( fat.get_identity() ) )
				{
					PublishError ( "Nenhum faturamento encontrado" );
					return false;
				}
				
				while ( fat_det.fetch() )
				{
					switch ( fat_det.get_tg_tipoFat() )
					{
						case TipoFat.Extras:
						{
							output_st_msg += "@@------ Extras ------- @";
							
							output_st_msg += "@" + fat_det.get_st_extras().PadRight ( 32, ' ' ) + "R$ " + mon.formatToMoney ( fat_det.get_vr_cobranca() ).PadLeft ( 7, ' ' );
							
							break;
						}
					}
				}
			}
			
			if ( !Found )
			{
				output_st_msg += "@ - Nenhum débito pendente ou em cobrança - @";
			}
			else
			{
				output_st_msg += "@@@# Valor completo devido: R$ " + new money().setMoneyFormat ( tot_cob ) + "@";
			}
								
			output_vr_valor = tot_cob.ToString();
			
			if ( input_tg_empresa == Context.TRUE )
			{
				fat_det.select_rows_emp ( emp.get_identity(), TipoFat.Extras );
			}
			else
			{
				fat_det.select_rows_loja ( loj.get_identity(), TipoFat.Extras );								
			}
			
			if ( fat_det.RowCount() > 0 )
			{
				output_st_msg += "@@------ Lançamentos futuros ------- @";
			
				while ( fat_det.fetch() )
				{
					output_st_msg += "@" + fat_det.get_st_extras().PadRight ( 32, ' ' ) + "R$ " + mon.formatToMoney ( fat_det.get_vr_cobranca() ).PadLeft ( 7, ' ' );
				}
				
				if ( Found )
					output_st_msg += "@@";			
			}
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_dadosFaturamento " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_dadosFaturamento " ); 
		
			/// USER [ execute ]
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_dadosFaturamento " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_dadosFaturamento " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_dadosFaturamento " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_DADOSFATURAMENTO.st_msg, output_st_msg ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_DADOSFATURAMENTO.vr_valor, output_vr_valor ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
