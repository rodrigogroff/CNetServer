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
	public class event_dlgConsultaLoja : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Consultar = 5;
		public const int event_Editar = 6;
		public const int event_Remover = 7;
		public const int event_val_TxtNome = 8;
		public const int event_val_TxtCidade = 9;
		public const int event_val_TxtEstado = 10;
		public const int event_val_TxtRamo = 11;
		public const int event_val_TxtQtdTerm = 12;
		public const int event_val_TxtEmpresa = 13;
		public const int event_val_TxtLoja = 14;
		public const int event_val_TxtCNPJ = 15;
		public const int event_Print = 16;
		public const int event_Report = 17;
		public const int event_BtnConsultarClick = 18;
		public const int event_LstLojasDoubleClick = 19;
		public const int event_BtnRelatorioClick = 20;
		#endregion

		public dlgConsultaLoja i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		ArrayList full_memory = new ArrayList();
		
		numberTextController		ctrl_TxtEmpresa			= new numberTextController();
		alphaTextController			ctrl_TxtNome			= new alphaTextController();
		alphaTextController			ctrl_TxtCidade			= new alphaTextController();
		alphaTextController			ctrl_TxtEstado			= new alphaTextController();
		numberTextController		ctrl_TxtQtdTerm			= new numberTextController();
		
		numberTextController		ctrl_TxtLoja			= new numberTextController();
		cnpjTextController			ctrl_TxtCNPJ			= new cnpjTextController();
				
		Color 	colorInvalid 	= Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgConsultaLoja ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgConsultaLoja ( this );
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
					
					ctrl_TxtEmpresa.AcquireTextBox	( i_Form.TxtEmpresa,	this, event_val_TxtEmpresa, 6  	);
					
					ctrl_TxtLoja.AcquireTextBox	( i_Form.TxtLoja,	this, event_val_TxtLoja, 6  	);
					ctrl_TxtCNPJ.AcquireTextBox	( i_Form.TxtCNPJ,	this, event_val_TxtCNPJ 	);
					
					ctrl_TxtNome.AcquireTextBox		( i_Form.TxtNome,		this, event_val_TxtNome, 	40  );
					ctrl_TxtCidade.AcquireTextBox	( i_Form.TxtCidade,		this, event_val_TxtCidade, 	20, false  );
					ctrl_TxtEstado.AcquireTextBox	( i_Form.TxtEstado,		this, event_val_TxtEstado,	2, false   );
										
					ctrl_TxtQtdTerm.AcquireTextBox	( i_Form.TxtQtdTerm,	this, event_val_TxtQtdTerm, 2  	);
					
					if ( header.get_tg_user_type() == TipoUsuario.Administrador || 
					     header.get_tg_user_type() == TipoUsuario.AdminGift )
					{
						i_Form.TxtEmpresa.Text = header.get_st_empresa();
						i_Form.TxtEmpresa.ReadOnly = true;
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
				
				#region - event_Consultar -
				
				case event_Consultar:
				{
					//InitEventCode event_Consultar
					
					i_Form.BtnConsultar.Enabled = false;
					
					DadosConsultaLoja dcl = new DadosConsultaLoja();
					
					dcl.set_st_empresa 	    ( ctrl_TxtEmpresa.getTextBoxValue()			);
					dcl.set_st_nome 		( ctrl_TxtNome.getTextBoxValue() 			);
					dcl.set_st_cidade 		( ctrl_TxtCidade.getTextBoxValue() 			);
					dcl.set_st_estado 		( ctrl_TxtEstado.getTextBoxValue() 			);
					dcl.set_nu_qtd_term 	( ctrl_TxtQtdTerm.getTextBoxValue() 		);
					dcl.set_st_loja			( ctrl_TxtLoja.getTextBoxValue() 			);
					dcl.set_st_cnpj			( ctrl_TxtCNPJ.getTextBoxValue() 			);
										
					string st_csv_id = "";

					i_Form.LstLojas.Items.Clear();
					
					i_Form.LblQtd.Text = "Processando...";
					
					Application.DoEvents();
					
					if ( var_exchange.fetch_consultaLoja ( 	ref dcl, 
					                                      	ref header, 
					                                      	ref st_csv_id ) )
					{
						full_memory.Clear();
						
						while ( st_csv_id != "" )
						{
							ArrayList tmp_memory  = new ArrayList();
							
							if ( var_exchange.fetch_memory ( st_csv_id, "400", ref st_csv_id, ref tmp_memory ) )
							{
								for ( int t=0; t < tmp_memory.Count; ++t )
									full_memory.Add ( tmp_memory[t] );
								
								i_Form.LblQtd.Text = "Buscando " + full_memory.ToString() + " registros";
								Application.DoEvents();
							}
						}
						
						for ( int t=0; t < full_memory.Count; ++t )
						{
							DadosLoja dl = new DadosLoja ( full_memory[t] as DataPortable );
							
							string [] full_row = new string [] { 	dl.get_st_loja(), 
																	dl.get_st_nome(),
																	dl.get_st_cidade(),
																	dl.get_st_estado(), 
																	dl.get_st_obs(),
																	dl.get_nu_CNPJ(),
																	dl.get_nu_diasRep(),
																	dl.get_nu_pctRep(),
																	dl.get_st_convenios() };
								
							i_Form.LstLojas.Items.Add ( var_util.GetListViewItem ( dl.get_nu_CNPJ(), full_row ) );
						}
						
						i_Form.LblQtd.Text = full_memory.Count.ToString() + " registros encontrados";
					}
					else
					{
						i_Form.LblQtd.Text = "";
					}
							
					i_Form.BtnConsultar.Enabled = true;
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Editar -
				
				case event_Editar:
				{
					//InitEventCode event_Editar
					
					if ( i_Form.LstLojas.SelectedItems.Count > 0 )
					{
						if ( 	header.get_tg_user_type() == TipoUsuario.SuperUser || 
						   		header.get_tg_user_type() == TipoUsuario.Administrador ||
						  		header.get_tg_user_type() == TipoUsuario.AdminGift 				)
						{
							event_dlgNovaLoja ev_call = new event_dlgNovaLoja ( var_util, var_exchange );
						
							ev_call.header 			= header;
							ev_call.IsMaintenance 	= true;
							ev_call.par_code 		= var_util.getSelectedListViewItemTag ( i_Form.LstLojas );
												
							ev_call.i_Form.ShowDialog();
						}
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Remover -
				
				case event_Remover:
				{
					//InitEventCode event_Remover
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtNome -
				
				case event_val_TxtNome:
				{
					//InitEventCode event_val_TxtNome
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtNome.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtNome.BackColor = Color.White;	
								ctrl_TxtNome.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtNome.BackColor = colorInvalid;	
								ctrl_TxtNome.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCidade -
				
				case event_val_TxtCidade:
				{
					//InitEventCode event_val_TxtCidade
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtCidade.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtCidade.BackColor = Color.White;	
								ctrl_TxtCidade.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtCidade.BackColor = colorInvalid;	
								ctrl_TxtCidade.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtEstado -
				
				case event_val_TxtEstado:
				{
					//InitEventCode event_val_TxtEstado
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtEstado.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtEstado.BackColor = Color.White;	
								ctrl_TxtEstado.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtEstado.BackColor = colorInvalid;	
								ctrl_TxtEstado.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtRamo -
				
				case event_val_TxtRamo:
				{
					//InitEventCode event_val_TxtRamo
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtQtdTerm -
				
				case event_val_TxtQtdTerm:
				{
					//InitEventCode event_val_TxtQtdTerm
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtQtdTerm.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtQtdTerm.BackColor = Color.White;	
								ctrl_TxtQtdTerm.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtQtdTerm.BackColor = colorInvalid;	
								ctrl_TxtQtdTerm.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtEmpresa -
				
				case event_val_TxtEmpresa:
				{
					//InitEventCode event_val_TxtEmpresa
					
					if ( header.get_tg_user_type() == TipoUsuario.Administrador || 
					     header.get_tg_user_type() == TipoUsuario.AdminGift )
						return false;
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtEmpresa.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtEmpresa.BackColor = Color.White;	
								ctrl_TxtEmpresa.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtEmpresa.BackColor = colorInvalid;	
								ctrl_TxtEmpresa.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
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
							}
							else
							{
								i_Form.TxtLoja.BackColor = colorInvalid;	
								ctrl_TxtLoja.IsUserValidated = false;
							}
							
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
							break;
						}
							
						case cnpjTextController.CNPJ_VALID:
						{
							i_Form.TxtCNPJ.BackColor     = Color.White;	
							ctrl_TxtCNPJ.IsUserValidated = true;
							ctrl_TxtCNPJ.CleanError();
							break;
						}
							
						default: break;
					}
					
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
				
				#region - event_Report -
				
				case event_Report:
				{
					//InitEventCode event_Report
					
					ArrayList lstReport = new ArrayList();
					
					lstReport.Add ( "RELATÓRIO COMPLETO DE LOJAS" );
					lstReport.Add ( "" );
					lstReport.Add ( "COD.     NOME                                                   CIDADE       CNPJ             DIAS REP.   PCT. REPASSE" );
					lstReport.Add ( "TELEFONE E ENDEREÇO" );
					lstReport.Add ( "CONVENIOS" );
					lstReport.Add ( "------------------------------------------------------------------------------------------------------------------------" );
					lstReport.Add ( "" );
		            	
	            	string line = "";
	            	
	            	for ( int t=0; t < i_Form.LstLojas.Items.Count; ++t )
	            	{
	            		line  = i_Form.LstLojas.Items[t].SubItems[0].Text.PadRight ( 8, ' ' ) + " ";
	            		line += i_Form.LstLojas.Items[t].SubItems[1].Text.PadRight ( 48, ' ' ).Substring (0,48) + " ";
	            		line += i_Form.LstLojas.Items[t].SubItems[2].Text.Trim().PadLeft ( 18, ' ' ) + " ";
	            		line += i_Form.LstLojas.Items[t].SubItems[5].Text.PadLeft ( 14, ' ' ) + " ";
	            		line += i_Form.LstLojas.Items[t].SubItems[6].Text.PadLeft ( 11, ' ' ) + " ";
	            		line += i_Form.LstLojas.Items[t].SubItems[7].Text.PadLeft ( 11, ' ' ) + " ";
	            		
	            		lstReport.Add (  line );
	            		
	            		for ( int h=0; h < full_memory.Count; ++h )
						{
							DadosLoja dl = new DadosLoja ( full_memory[h] as DataPortable );
							
							if ( dl.get_st_nome() != i_Form.LstLojas.Items[t].SubItems[1].Text )
								continue;
							
							lstReport.Add ( dl.get_st_endereco() );
							break;
	            		}
	            		
	            		lstReport.Add ( "Convênios: " + i_Form.LstLojas.Items[t].SubItems[8].Text );
	            		lstReport.Add ( "" );
	            	}
					
					new ConveyPrinter ( "Courier New", 7, 10, ref lstReport );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnConsultarClick -
				
				case event_BtnConsultarClick:
				{
					//InitEventCode event_BtnConsultarClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_LstLojasDoubleClick -
				
				case event_LstLojasDoubleClick:
				{
					//InitEventCode event_LstLojasDoubleClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnRelatorioClick -
				
				case event_BtnRelatorioClick:
				{
					//InitEventCode event_BtnRelatorioClick
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
