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
	public class event_dlgMensagensEdu : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_val_TxtDt_Ini = 5;
		public const int event_val_TxtDt_Fim = 6;
		public const int event_BuscaDados = 7;
		public const int event_LstMsgDoubleClick = 8;
		public const int event_BtnNovoClick = 9;
		public const int event_BtnAtualizarClick = 10;
		public const int event_BtnRemoverClick = 11;
		#endregion

		public dlgMensagensEdu i_Form;

		//UserVariables
		dateTextController  	   	ctrl_TxtDt_Ini = new dateTextController();
		dateTextController  	   	ctrl_TxtDt_Fim = new dateTextController();
		
		public CNetHeader header;
		public string id = "";
				
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgMensagensEdu ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgMensagensEdu ( this );
		}
		
		public override bool doEvent ( int event_number, object arg )
		{
			switch ( event_number )
			{
				#region - event_Load -
				
				case event_Load:
				{
					//InitEventCode event_Load
					doEvent ( event_Translate, 			null );
					doEvent ( event_FormIsOpening, 		null );
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
					ctrl_TxtDt_Ini.AcquireTextBox 	( i_Form.TxtDt_Ini, this, event_val_TxtDt_Ini, dateTextController.FORMAT_DDMMYYYY );
					ctrl_TxtDt_Fim.AcquireTextBox 	( i_Form.TxtDt_Fim, this, event_val_TxtDt_Fim, dateTextController.FORMAT_DDMMYYYY );
					ctrl_TxtDt_Ini.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtDt_Fim.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false ); 
					
					doEvent ( event_BuscaDados, null );
									
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
				
				#region - event_val_TxtDt_Ini -
				
				case event_val_TxtDt_Ini:
				{
					//InitEventCode event_val_TxtDt_Ini
					
					switch ( arg as string )
					{
						case dateTextController.DATE_INVALID:
						{
							i_Form.TxtDt_Ini.BackColor = Color.Lavender;;
							ctrl_TxtDt_Ini.IsUserValidated = false;
							break;
						}
					
						case dateTextController.DATE_VALID:
						{
							i_Form.TxtDt_Ini.BackColor = Color.White;
							ctrl_TxtDt_Ini.IsUserValidated = true;
							ctrl_TxtDt_Ini.CleanError();
							break;
						}
					
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDt_Fim -
				
				case event_val_TxtDt_Fim:
				{
					//InitEventCode event_val_TxtDt_Fim
					
					switch ( arg as string )
					{
						case dateTextController.DATE_INVALID:
						{
							i_Form.TxtDt_Fim.BackColor = Color.Lavender;;
							ctrl_TxtDt_Fim.IsUserValidated = false;
							break;
						}
					
						case dateTextController.DATE_VALID:
						{
							i_Form.TxtDt_Fim.BackColor = Color.White;
							ctrl_TxtDt_Fim.IsUserValidated = true;
							ctrl_TxtDt_Fim.CleanError();
							break;
						}
					
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BuscaDados -
				
				case event_BuscaDados:
				{
					//InitEventCode event_BuscaDados
					
					i_Form.LstMsg.Items.Clear();
					var_util.clearPortable();
					
					string st_csv_content = "";
					
					if ( !var_exchange.fetch_edu_messages ( ref header, 
					                                        ref st_csv_content ) )
						return false;
					
					ArrayList full_memory = new ArrayList();
					
					while ( st_csv_content != "" )
					{
						ArrayList tmp_memory = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_csv_content, "1000", 
						                                 ref st_csv_content, 
						                                 ref tmp_memory ) )
						{
							for ( int t=0; t < tmp_memory.Count; ++t )
							{
								full_memory.Add ( tmp_memory[t] as DataPortable );
							}
						}
					}
										
					for ( int t=0; t < full_memory.Count; ++t )
					{
						DadosEduMessage dem = new DadosEduMessage ( full_memory[t] as DataPortable );
						
						string time = var_util.getDDMMYYYY_format ( dem.get_dt_start() ).Replace ( " 00:00:00","" ) + " - " +
									  var_util.getDDMMYYYY_format ( dem.get_dt_end() ).Replace ( " 23:59:59","" );
						
						string [] full_row = new string [] { dem.get_st_msg(), time };
						
						var_util.savePortable ( dem.get_id_mem(), dem );
							
						i_Form.LstMsg.Items.Add ( var_util.GetListViewItem ( dem.get_id_mem(), full_row ) );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_LstMsgDoubleClick -
				
				case event_LstMsgDoubleClick:
				{
					//InitEventCode event_LstMsgDoubleClick
					
					id = var_util.getSelectedListViewItemTag ( i_Form.LstMsg );
					
					DadosEduMessage dem = new DadosEduMessage ( var_util.retrievePortable ( id ) as DataPortable );

					i_Form.txtMsg.Text = dem.get_st_msg();
					
					DateTime tim = Convert.ToDateTime ( dem.get_dt_start() );
					
					ctrl_TxtDt_Ini.SetTextBoxText ( tim.Day.ToString().PadLeft ( 2, '0' ) + 
					                               tim.Month.ToString().PadLeft ( 2, '0' ) + 
					                               tim.Year.ToString() );
						
					DateTime tim2 = Convert.ToDateTime ( dem.get_dt_end() );
					
					ctrl_TxtDt_Fim.SetTextBoxText ( tim2.Day.ToString().PadLeft ( 2, '0' ) + 
					                               tim2.Month.ToString().PadLeft ( 2, '0' ) + 
					                               tim2.Year.ToString() );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnNovoClick -
				
				case event_BtnNovoClick:
				{
					//InitEventCode event_BtnNovoClick
					
					dlgAutorizacao autor = new dlgAutorizacao();
					
					autor.ShowDialog();
					
					Application.DoEvents();
					
					if ( autor.IsConfirmed )
					{
						DadosEduMessage dem = new DadosEduMessage();
						
						dem.set_dt_start ( var_util.GetDataBaseTimeFormat ( ctrl_TxtDt_Ini.getTextBoxValue_Date() ) );
						dem.set_dt_end   ( var_util.GetDataBaseTimeFormat ( ctrl_TxtDt_Fim.getTextBoxValue_Date().AddHours(23).AddMinutes(59).AddSeconds(59) ) );
						dem.set_st_msg   ( i_Form.txtMsg.Text 				);
						
						var_exchange.ins_edu_msg ( ref dem, ref header );
						
						doEvent ( event_BuscaDados, null );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnAtualizarClick -
				
				case event_BtnAtualizarClick:
				{
					//InitEventCode event_BtnAtualizarClick
					
					dlgAutorizacao autor = new dlgAutorizacao();
					
					autor.ShowDialog();
					
					Application.DoEvents();
					
					if ( autor.IsConfirmed )
					{
						DadosEduMessage dem = new DadosEduMessage();
						
						dem.set_dt_start ( var_util.GetDataBaseTimeFormat ( ctrl_TxtDt_Ini.getTextBoxValue_Date() ) );
						dem.set_dt_end   ( var_util.GetDataBaseTimeFormat ( ctrl_TxtDt_Fim.getTextBoxValue_Date().AddHours(23).AddMinutes(59).AddSeconds(59) ) );
						dem.set_st_msg   ( i_Form.txtMsg.Text 	);
						dem.set_id_mem   ( id 					);
						
						var_exchange.exec_change_edu_msg ( ref dem, ref header );
						
						doEvent ( event_BuscaDados, null );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnRemoverClick -
				
				case event_BtnRemoverClick:
				{
					//InitEventCode event_BtnRemoverClick
					
					if ( MessageBox.Show (	"Remover mensagem?",
			                    			"Aviso", 
			                    			MessageBoxButtons.YesNo, 
			                    			MessageBoxIcon.Question, 
			                    			MessageBoxDefaultButton.Button2 ) == DialogResult.No )
					{
						return false;
					}
					
					string 			tag = var_util.getSelectedListViewItemTag ( i_Form.LstMsg );
					DataPortable 	tmp = var_util.retrievePortable ( tag );
					
					id = "";
					
					DadosEduMessage dem = new DadosEduMessage ( tmp );
					
					var_exchange.del_edu_msg ( dem.get_id_mem(), ref header );
					
					doEvent ( event_BuscaDados, null );
					
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
