using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using SyCrafEngine;

//UserIncludes
//UserIncludes END

namespace Client
{
	public class event_dlgPrevLojista : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_BtnConfirmarClick = 6;
		#endregion

		public dlgPrevLojista i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgPrevLojista ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgPrevLojista ( this );
		}
		
		public override bool doEvent ( int event_number, object arg )
		{
			switch ( event_number )
			{
				#region - event_Load -
				
				case event_Load:
				{
					//InitEventCode event_Load
					
					#if ROBOT
					var_util.execDefinedRobot ( this, var_alias );	
					#else
					
					doEvent ( event_Translate, 			null );
					doEvent ( event_FormIsOpening, 		null );
					
					#endif
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Translate -
				
				case event_Translate:
				{
					//InitEventCode event_Translate
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_FormIsOpening -
				
				case event_FormIsOpening:
				{
					//InitEventCode event_FormIsOpening

					if ( header.get_tg_user_type () ==  TipoUsuario.Lojista )
					{
						ArrayList lst = new ArrayList();
					
						var_exchange.fetch_lojistaEmpresas ( header.get_st_empresa(), ref header, ref lst );
						
						for ( int t=0; t < lst.Count; ++t )
						{
							DadosEmpresa de = new DadosEmpresa ( lst[t] as DataPortable );
							
							i_Form.LstEmp.Items.Add ( de.get_st_empresa() + " " + de.get_st_fantasia() );
						}
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - robot_ShowDialog -
				
				case robot_ShowDialog:
				{
					//InitEventCode robot_ShowDialog
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - robot_CloseDialog -
				
				case robot_CloseDialog:
				{
					//InitEventCode robot_CloseDialog
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Confirmar -
				
				case event_Confirmar:
				{
					//InitEventCode event_Confirmar
					
					if ( i_Form.LstEmp.SelectedIndex == -1 )
						return false;
					
					string st_empresa = i_Form.LstEmp.SelectedItem.ToString();
						
					st_empresa = st_empresa.Substring (0, st_empresa.IndexOf ( " " ) );
					
					// ##############################
					// # SETUP LISTS ################
					// ##############################
					
					ArrayList lstHeader 	= new ArrayList();
					ArrayList lstContent 	= new ArrayList();
					ArrayList lstTableSizes = new ArrayList();
					ArrayList lstFooter 	= new ArrayList();
					ArrayList lstMessages 	= new ArrayList();
					ArrayList lstFilters 	= new ArrayList();
					
					// ##############################
					// # CUSTOMIZE
					// ##############################
					
					string st_csv_contents	= "";
										
					dlgStatus stat = new dlgStatus ( "Relatório" );
					
					stat.LblActivity.Text = "Processando relatório no servidor";
					stat.Show();
					Application.DoEvents();
					
					if ( !var_exchange.fetch_rel_prevLojista ( 	st_empresa,
							                                    ref header,
							                                    ref st_csv_contents ) )
					{
						stat.Close();
						return false;
					}
					                       
					ArrayList full_memory = new ArrayList();
						
					stat.LblActivity.Text = "Buscando detalhes...";
					Application.DoEvents();
				
					while ( st_csv_contents != "" )
					{
						ArrayList tmp_memory  = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_csv_contents, "400", ref st_csv_contents, ref tmp_memory ) )
							for ( int t=0; t < tmp_memory.Count; ++t )
								full_memory.Add ( tmp_memory[t] );
					}
					
					money money_helper = new money();
					
					stat.LblActivity.Text = "Gerando relatório para web";
					Application.DoEvents();
					
					lstMessages.Add   ( "Transações confirmadas para a loja: " + header.get_st_empresa() );

					lstTableSizes.Add ( 650 			);
						
					ArrayList lst_sub_tbl_head = new ArrayList();
					
					lst_sub_tbl_head.Add ( "Cartão" 			);
					lst_sub_tbl_head.Add ( "NSU" 				);
					lst_sub_tbl_head.Add ( "Data e Hora" 		);
					lst_sub_tbl_head.Add ( "Parcela" 			);
					lst_sub_tbl_head.Add ( "Valor R$" 			);
					lst_sub_tbl_head.Add ( "Valor Repasse R$" 	);					
											
					lstHeader.Add ( lst_sub_tbl_head );
					
					long tot_repasse = 0;
							
					ArrayList my_line_container = new ArrayList();
					
					for (int t=0; t < full_memory.Count; ++t )
					{
						DadosRepasse dr = new DadosRepasse ( full_memory[t] as DataPortable );
						
						ArrayList lst_line_content = new ArrayList();

						lst_line_content.Add ( dr.get_st_cartao() );
						lst_line_content.Add ( dr.get_st_nsu() );
						lst_line_content.Add ( var_util.getDDMMYYYY_format ( dr.get_dt_trans() ) );
						lst_line_content.Add ( dr.get_id_parcela() );
						lst_line_content.Add ( money_helper.formatToMoney ( dr.get_vr_total() ) );
						lst_line_content.Add ( money_helper.formatToMoney ( dr.get_vr_repasse() ) );
						
						tot_repasse += Convert.ToInt64 ( dr.get_vr_repasse() );
													
						my_line_container.Add ( lst_line_content );
					}			
					
					lstContent.Add ( my_line_container );
						
					ArrayList lst_sub_foot = new ArrayList();
					
					lst_sub_foot.Add ( "Total de repasse: "+ money_helper.formatToMoney ( tot_repasse.ToString() ) );
						
					lstFooter.Add ( lst_sub_foot );			
					
					stat.Close();
					
					SyCrafReport rel = new SyCrafReport ( 	"Relatório de previsão de repasse ao lojista",
					                               		  	"RPR", 
					                               		  	i_Form.LstEmp.SelectedItem.ToString(),
					                               		  	var_util.getDDMMYYYY_format ( DateTime.Now.ToString() ),
					                               		  	"",
					                               			ref lstHeader,
					                               			ref lstContent,
					                                		ref lstTableSizes,
					                                		ref lstFooter,
					                                		ref lstMessages,
					                                		ref lstFilters );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnConfirmarClick -
				
				case event_BtnConfirmarClick:
				{
					//InitEventCode event_BtnConfirmarClick
					//EndEventCode
					return true;
				}
				
				#endregion
		
				default: break;
			}
		
			return false;
		}
	}
}
