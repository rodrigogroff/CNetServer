using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using SyCrafEngine;

//UserIncludes

using System.Drawing.Printing;

//UserIncludes END

namespace Client
{
	public class event_dlgPesquisaChamado : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Procurar = 5;
		public const int event_val_TxtLoja = 6;
		public const int event_val_TxtDtAbIni = 7;
		public const int event_val_TxtDtAbFim = 8;
		public const int event_val_TxtDtFechIni = 9;
		public const int event_val_TxtDtFechFim = 10;
		public const int event_val_TxtCNPJ = 11;
		public const int event_Editar = 12;
		public const int event_Relatorio = 13;
		public const int event_Print = 14;
		public const int event_LstChamadosDoubleClick = 15;
		public const int event_BtnProcurarClick = 16;
		public const int event_BtnReportClick = 17;
		#endregion

		public dlgPesquisaChamado i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController	ctrl_TxtLoja        = new numberTextController();
		cnpjTextController	  	ctrl_TxtCNPJ     	= new cnpjTextController();
		
		dateTextController		ctrl_TxtDtAbIni     = new dateTextController();
		dateTextController		ctrl_TxtDtAbFim     = new dateTextController();
		dateTextController		ctrl_TxtDtFechIni   = new dateTextController();
		dateTextController		ctrl_TxtDtFechFim   = new dateTextController();
		
		Color colorInvalid = Color.Lavender;
			
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgPesquisaChamado ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgPesquisaChamado ( this );
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
					
					ctrl_TxtLoja.AcquireTextBox	( i_Form.TxtLoja,   this, event_val_TxtLoja, 	6	);
					ctrl_TxtCNPJ.AcquireTextBox	( i_Form.TxtCNPJ, 	this, event_val_TxtCNPJ			);
					
					ctrl_TxtDtAbIni.AcquireTextBox 		( i_Form.TxtDtAbIni,	this, event_val_TxtDtAbIni, dateTextController.FORMAT_DDMMYYYY );
					ctrl_TxtDtAbFim.AcquireTextBox 		( i_Form.TxtDtAbFim,	this, event_val_TxtDtAbFim, dateTextController.FORMAT_DDMMYYYY );
					
					ctrl_TxtDtFechIni.AcquireTextBox 	( i_Form.TxtDtFechIni,	this, event_val_TxtDtFechIni, dateTextController.FORMAT_DDMMYYYY );
					ctrl_TxtDtFechFim.AcquireTextBox 	( i_Form.TxtDtFechFim,	this, event_val_TxtDtFechFim, dateTextController.FORMAT_DDMMYYYY );
					
					ctrl_TxtDtAbIni.SetTextBoxText ( 	DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Year.ToString().PadLeft ( 2, '0' ) );
					
					ctrl_TxtDtAbFim.SetTextBoxText ( 	DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Year.ToString().PadLeft ( 2, '0' ) );
					
					ArrayList lst = new ArrayList();
					
					var_exchange.fetch_conveyUsuarios ( ref header, ref lst );
					
					i_Form.CboOpers.Items.Clear();
					i_Form.CboOpers.Items.Add ( "(Todos)" );
					i_Form.CboResp.Items.Add ( "(Todos)" );
					
					for ( int t=0; t < lst.Count; ++t )
					{
						DadosUsuario us = new DadosUsuario ( lst[t] as DataPortable );
						
						i_Form.CboOpers.Items.Add	( us.get_st_nome() 	);
						i_Form.CboResp.Items.Add 	( us.get_st_nome() 	);
					}
					
					i_Form.CboOpers.SelectedIndex = 0;
					i_Form.CboResp.SelectedIndex = 0;
					i_Form.CboCateg.SelectedIndex = 0;
					i_Form.CboPrioridade.SelectedIndex = 0;
					i_Form.CboSit.SelectedIndex = 0;
					
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
				
				#region - event_Procurar -
				
				case event_Procurar:
				{
					//InitEventCode event_Procurar
					
					string nu_categ			= (i_Form.CboCateg.SelectedIndex-1).ToString();
					string nu_prioridade	= (i_Form.CboPrioridade.SelectedIndex-1).ToString();
					string st_operador		= "";
					string st_resp			= "";
					string tg_closed		= i_Form.CboSit.SelectedIndex.ToString();
					string dt_ini_ab		= "";
					string dt_fim_ab		= "";
					string dt_ini_fech		= "";
					string dt_fim_fech		= "";
					string tg_tecnico		= Context.FALSE;
					string st_loja			= "";
					
					if ( i_Form.CboOpers.SelectedIndex > 0 )
						st_operador	= i_Form.CboOpers.SelectedItem.ToString();
					
					if ( i_Form.CboResp.SelectedIndex > 0 )
						st_resp	= i_Form.CboResp.SelectedItem.ToString();
					
					if ( ctrl_TxtLoja.IsUserValidated )
						st_loja = ctrl_TxtLoja.getTextBoxValue();
					
					if ( i_Form.ChkTecnico.Checked )
						tg_tecnico = Context.TRUE;
					
					if ( ctrl_TxtDtAbIni.IsUserValidated )
						dt_ini_ab	= var_util.GetDataBaseTimeFormat ( ctrl_TxtDtAbIni.getTextBoxValue_Date() );
					
					if ( ctrl_TxtDtAbFim.IsUserValidated )
						dt_fim_ab	= var_util.GetDataBaseTimeFormat ( ctrl_TxtDtAbFim.getTextBoxValue_Date().AddDays(1) );
					
					if ( ctrl_TxtDtFechIni.IsUserValidated )
						dt_ini_fech	= var_util.GetDataBaseTimeFormat ( ctrl_TxtDtFechIni.getTextBoxValue_Date() );
					
					if ( ctrl_TxtDtFechFim.IsUserValidated )
						dt_fim_fech	= var_util.GetDataBaseTimeFormat ( ctrl_TxtDtFechFim.getTextBoxValue_Date().AddDays (1) );
					
					string st_block  = "";
											
					var_exchange.fetch_chamados ( 	nu_categ,
													nu_prioridade, 
													st_operador, 
													tg_closed,
													dt_ini_ab,
													dt_fim_ab,
													dt_ini_fech,
													dt_fim_fech,
													tg_tecnico, 
													st_loja,
													st_resp,
													ref header,
													ref st_block );
					
					ArrayList full_memory = new ArrayList();
						
					while ( st_block != "" )
					{
						ArrayList tmp_memory  = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_block, "400", ref st_block, ref tmp_memory ) )
							for ( int t=0; t < tmp_memory.Count; ++t )
								full_memory.Add ( tmp_memory[t] );
					}
					
					i_Form.LstChamados.Items.Clear();
					
					for ( int t=0; t < full_memory.Count; ++t )
					{
						DadosChamado dc = new DadosChamado ( full_memory[t] as DataPortable );
						
						string dt_ab   = var_util.getDDMMYYYY_format ( dc.get_dt_ab() );
						string dt_fech = dc.get_dt_fech();
						
						if ( dt_fech.Length > 0 )
							dt_fech = var_util.getDDMMYYYY_format ( dt_fech );
						
						string [] full_row = new string [] { dt_ab,
															 dt_fech,
															 dc.get_st_oper() + " (" + dc.get_st_resp() + ")",
															 dc.get_st_motivo() };
									
						i_Form.LstChamados.Items.Add ( var_util.GetListViewItem ( dc.get_id_chamado(), full_row ) );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtLoja -
				
				case event_val_TxtLoja:
				{
					//InitEventCode event_val_TxtLoja
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtLoja.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtLoja.BackColor = Color.White;	
								ctrl_TxtLoja.IsUserValidated = true;
								
								if ( ctrl_TxtLoja.GetEnterPressed() )
								{
									DadosLoja dl = new DadosLoja();
									
									var_exchange.fetch_dadosLoja ( "", ctrl_TxtLoja.getTextBoxValue(), ref header, ref dl );
									
									i_Form.TxtNome.Text = dl.get_st_nome();
									ctrl_TxtCNPJ.SetTextBoxText ( dl.get_nu_CNPJ() );
								}
							}
							else
							{
								i_Form.TxtLoja.BackColor = colorInvalid;	
								ctrl_TxtLoja.IsUserValidated = false;
								
								if ( ctrl_TxtLoja.GetEnterPressed() )
								{
									event_dlgConsultaLoja ev_call = new event_dlgConsultaLoja ( var_util, var_exchange );
									
									ev_call.header = header;
									
									ev_call.i_Form.Show();
								}
							}
							
							break;
						}
							
						default: break;
					}					
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDtAbIni -
				
				case event_val_TxtDtAbIni:
				{
					//InitEventCode event_val_TxtDtAbIni
					
					switch ( arg as string )
					{
						case dateTextController.DATE_INVALID:
						{
							i_Form.TxtDtAbIni.BackColor = colorInvalid;	
							ctrl_TxtDtAbIni.IsUserValidated = false;
							break;
						}

						case dateTextController.DATE_VALID:
						{
							i_Form.TxtDtAbIni.BackColor = Color.White;	
							ctrl_TxtDtAbIni.IsUserValidated = true;
							break;
						}
								
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDtAbFim -
				
				case event_val_TxtDtAbFim:
				{
					//InitEventCode event_val_TxtDtAbFim
					
					switch ( arg as string )
					{
						case dateTextController.DATE_INVALID:
						{
							i_Form.TxtDtAbFim.BackColor = colorInvalid;	
							ctrl_TxtDtAbFim.IsUserValidated = false;
							break;
						}

						case dateTextController.DATE_VALID:
						{
							i_Form.TxtDtAbFim.BackColor = Color.White;	
							ctrl_TxtDtAbFim.IsUserValidated = true;
							break;
						}
								
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDtFechIni -
				
				case event_val_TxtDtFechIni:
				{
					//InitEventCode event_val_TxtDtFechIni
					
					switch ( arg as string )
					{
						case dateTextController.DATE_INVALID:
						{
							i_Form.TxtDtFechIni.BackColor = colorInvalid;	
							ctrl_TxtDtFechIni.IsUserValidated = false;
							break;
						}

						case dateTextController.DATE_VALID:
						{
							i_Form.TxtDtFechIni.BackColor = Color.White;	
							ctrl_TxtDtFechIni.IsUserValidated = true;
							break;
						}
								
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDtFechFim -
				
				case event_val_TxtDtFechFim:
				{
					//InitEventCode event_val_TxtDtFechFim
					
					switch ( arg as string )
					{
						case dateTextController.DATE_INVALID:
						{
							i_Form.TxtDtFechFim.BackColor = colorInvalid;	
							ctrl_TxtDtFechFim.IsUserValidated = false;
							break;
						}

						case dateTextController.DATE_VALID:
						{
							i_Form.TxtDtFechFim.BackColor = Color.White;	
							ctrl_TxtDtFechFim.IsUserValidated = true;
							break;
						}
								
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCNPJ -
				
				case event_val_TxtCNPJ:
				{
					//InitEventCode event_val_TxtCNPJ
					
					switch ( arg as string )
					{
						case cnpjTextController.CNPJ_INCOMPLETE:
						case cnpjTextController.CNPJ_INVALID:
						{
							i_Form.TxtCNPJ.BackColor     = colorInvalid;	
							ctrl_TxtCNPJ.IsUserValidated = false;
							
							if ( ctrl_TxtCNPJ.GetEnterPressed() )
							{
								event_dlgConsultaLoja ev_call = new event_dlgConsultaLoja ( var_util, var_exchange );
								
								ev_call.header = header;
								
								ev_call.i_Form.Show();
							}
							
							break;
						}
							
						case cnpjTextController.CNPJ_VALID:
						{
							i_Form.TxtCNPJ.BackColor     = Color.White;	
							ctrl_TxtCNPJ.IsUserValidated = true;
							ctrl_TxtCNPJ.CleanError();
							
							if ( ctrl_TxtLoja.GetEnterPressed() )
							{
								DadosLoja dl = new DadosLoja();
								
								var_exchange.fetch_dadosLoja ( ctrl_TxtCNPJ.getTextBoxValue(), "", ref header, ref dl );
								
								ctrl_TxtLoja.SetTextBoxText ( dl.get_st_loja() );
								
								i_Form.TxtNome.Text = dl.get_st_nome();
							}
						
							break;
						}
							
						default: break;
					}
										
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Editar -
				
				case event_Editar:
				{
					//InitEventCode event_Editar
					
					if ( i_Form.LstChamados.SelectedItems.Count > 0 )
					{
						event_dlgEditaChamado ev_call = new event_dlgEditaChamado ( var_util, var_exchange );
						
						ev_call.header     = header;
						ev_call.id_chamado = var_util.getSelectedListViewItemTag ( i_Form.LstChamados );
						
						ev_call.i_Form.ShowDialog();						
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Relatorio -
				
				case event_Relatorio:
				{
					//InitEventCode event_Relatorio
					
					ArrayList lstReport = new ArrayList();
					
					lstReport.Add ( "RELATÓRIO DE CHAMADOS" );
					lstReport.Add ( "" 						);
					lstReport.Add ( "DT. ABERTURA                  DT. FECHAMENTO                OPER (RESP)" 									);
					lstReport.Add ( "DESCRIÇÃO" 																								);
					lstReport.Add ( "-------------------------------------------------------------------------------------------------------" 	);
					lstReport.Add ( "" 						);
					
					string line = "";
		            	
	            	for ( int t=0; t < i_Form.LstChamados.Items.Count; ++t )
	            	{
	            		line  = i_Form.LstChamados.Items[t].SubItems[0].Text.PadRight ( 29, ' ' ) + " ";
	            		line += i_Form.LstChamados.Items[t].SubItems[1].Text.PadRight ( 29, ' ' ) + " ";
	            		line += i_Form.LstChamados.Items[t].SubItems[2].Text.PadRight ( 32, ' ' ) + " ";
	            		
	            		lstReport.Add ( line 	);
	            		
	            		line = i_Form.LstChamados.Items[t].SubItems[3].Text.PadRight ( 100, ' ' ).Substring ( 0, 100 );
	            		
	            		lstReport.Add ( line 	);
	            		lstReport.Add ( "" 		);
	            	}
	            	
	            	new ConveyPrinter ( "Courier New", 7, 10, ref lstReport );
		            
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Print -
				
				case event_Print:
				{
					//InitEventCode event_Print
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_LstChamadosDoubleClick -
				
				case event_LstChamadosDoubleClick:
				{
					//InitEventCode event_LstChamadosDoubleClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnProcurarClick -
				
				case event_BtnProcurarClick:
				{
					//InitEventCode event_BtnProcurarClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnReportClick -
				
				case event_BtnReportClick:
				{
					//InitEventCode event_BtnReportClick
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
