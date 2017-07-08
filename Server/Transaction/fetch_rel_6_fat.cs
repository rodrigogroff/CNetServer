using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_rel_6_fat : type_base
	{
		public string input_st_dt_ini = "";
		public string input_st_dt_fim = "";
		
		public string output_st_total = "";
		public string output_st_total_desconto = "";
		public string output_st_csv_subtotal = "";
		public string output_st_csv_subtotal_desconto = "";
		public string output_st_content_block = "";
		public string output_st_emp_loj_block = "";
		public string output_CartaoAtiv = "";
		public string output_Extras = "";
		public string output_FixoTrans = "";
		public string output_Percent = "";
		public string output_TBM = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_rel_6_fat ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_rel_6_fat";
			constructor();
		}
		
		public fetch_rel_6_fat()
		{
			var_Alias = "fetch_rel_6_fat";
		
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
			Registry ( "setup fetch_rel_6_fat " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_6_FAT.st_dt_ini, ref input_st_dt_ini ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_6_FAT.st_dt_ini missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_6_FAT.st_dt_fim, ref input_st_dt_fim ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_6_FAT.st_dt_fim missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_REL_6_FAT.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_REL_6_FAT.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_rel_6_fat " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_rel_6_fat " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_rel_6_fat " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_rel_6_fat " ); 
		
			/// USER [ execute ]
			
			T_Faturamento fat = new T_Faturamento (this);
			
			if ( !fat.select_rows_dt_venc ( input_st_dt_ini, 
			                                input_st_dt_fim,
			                                TipoSitFat.Pendente ) )
			{
				PublishError ( "Nenhum registro encontrado" );
				return false;
			}
			
			T_Empresa 				emp     = new T_Empresa 			(this);
			T_Loja 					loj     = new T_Loja 				(this);
			T_FaturamentoDetalhes 	fat_det = new T_FaturamentoDetalhes (this);
			
			StringBuilder sb_content = new StringBuilder();
			StringBuilder sb_entity  = new StringBuilder();
			
			long 	total 			= 0,
					total_desconto 	= 0,			
					CartaoAtiv 		= 0,
					Extras 			= 0,
					FixoTrans 		= 0,
					Percent 		= 0,
					TBM 			= 0;
			
			while ( fat.fetch() )
			{
				Entidade ent = new Entidade ();
				
				ent.set_fk_fatura 	( fat.get_identity()	);
				
				long desconto = 0;
				
				if ( fat.get_fk_empresa() != Context.NONE )
				{
					if ( !emp.selectIdentity ( fat.get_fk_empresa() ) )
						return false;
					
					if ( emp.get_tg_isentoFat() == Context.TRUE )
						continue;
					
					ent.set_st_nome ( "Associação (" + emp.get_st_empresa() + ") " + emp.get_st_fantasia() + " - CNPJ: " + emp.get_nu_CNPJ()  );
				}
				else
				{
					if ( !loj.selectIdentity ( fat.get_fk_loja() ) )
						return false;
					
					if ( loj.get_tg_isentoFat() == Context.TRUE )
						continue;
					
					ent.set_st_nome ( "Loja (" + loj.get_st_loja() + ") " + loj.get_st_nome() + " - CNPJ: " + loj.get_nu_CNPJ()	);
				}
				
				DataPortable tmp = ent as DataPortable;
					
				sb_entity.Append ( MemorySave ( ref tmp ) );
				sb_entity.Append ( "," 						 );
				
				fat_det.Reset();
				
				if ( fat_det.select_fk_fat ( fat.get_identity() ) )
				{
					while ( fat_det.fetch() )
					{
						Rel_FAT r_f = new Rel_FAT();
						
						if ( fat_det.get_tg_desconto() == Context.TRUE )
							desconto += fat_det.get_int_vr_cobranca();
						
						r_f.set_st_extra 	( fat_det.get_st_extras() 	);
						r_f.set_vr_cob   	( fat_det.get_vr_cobranca() );
						r_f.set_tg_tipoFat 	( fat_det.get_tg_tipoFat() 	);
						r_f.set_tg_desconto ( fat_det.get_tg_desconto() );
						
						switch ( fat_det.get_tg_tipoFat() )
						{
							case TipoFat.CartaoAtiv:	CartaoAtiv += fat_det.get_int_vr_cobranca();	break;
							case TipoFat.Extras:		Extras     += fat_det.get_int_vr_cobranca();	break;
							case TipoFat.FixoTrans:		FixoTrans  += fat_det.get_int_vr_cobranca();	break;
							case TipoFat.Percent:		Percent    += fat_det.get_int_vr_cobranca();	break;
							case TipoFat.TBM:			TBM 	   += fat_det.get_int_vr_cobranca();	break;
						}
						
						r_f.set_fk_fatura 	( fat_det.get_fk_fatura() );
						
						DataPortable tmp2 = r_f as DataPortable;
					
						sb_content.Append ( MemorySave ( ref tmp2 ) );
						sb_content.Append ( "," 					   );
					}
				}
				
				total          					+= fat.get_int_vr_cobranca();
				total_desconto 					+= desconto;
				
				output_st_csv_subtotal 	    	+= fat.get_vr_cobranca() + ",";
				output_st_csv_subtotal_desconto += desconto.ToString() + ",";
			}
			
			// content
			{
				string list_ids = sb_content.ToString().TrimEnd ( ',' );
									
				DataPortable dp = new DataPortable();
				
				dp.setValue ( "ids", list_ids );
							  
				output_st_content_block = MemorySave ( ref dp );
			}
			
			// entidades
			{
				string list_ids = sb_entity.ToString().TrimEnd ( ',' );
									
				DataPortable dp = new DataPortable();
				
				dp.setValue ( "ids", list_ids );
							  
				output_st_emp_loj_block = MemorySave ( ref dp );
			}
						
			output_st_csv_subtotal          = output_st_csv_subtotal.TrimEnd ( ',' );
			output_st_csv_subtotal_desconto = output_st_csv_subtotal_desconto.TrimEnd ( ',' );
			
			output_st_total 		        = total.ToString();
			output_st_total_desconto        = total_desconto.ToString();
			output_CartaoAtiv 				= CartaoAtiv.ToString();
			output_Extras 					= Extras.ToString();
			output_FixoTrans 				= FixoTrans.ToString();
			output_Percent 					= Percent.ToString();
			output_TBM 						= TBM.ToString();
					
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_rel_6_fat " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_rel_6_fat " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_rel_6_fat " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_6_FAT.st_total, output_st_total ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_6_FAT.st_total_desconto, output_st_total_desconto ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_6_FAT.st_csv_subtotal, output_st_csv_subtotal ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_6_FAT.st_csv_subtotal_desconto, output_st_csv_subtotal_desconto ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_6_FAT.st_content_block, output_st_content_block ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_6_FAT.st_emp_loj_block, output_st_emp_loj_block ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_6_FAT.CartaoAtiv, output_CartaoAtiv ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_6_FAT.Extras, output_Extras ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_6_FAT.FixoTrans, output_FixoTrans ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_6_FAT.Percent, output_Percent ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_6_FAT.TBM, output_TBM ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
