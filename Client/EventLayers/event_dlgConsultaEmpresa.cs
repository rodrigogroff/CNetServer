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
	public class event_dlgConsultaEmpresa : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_val_TxtNome = 5;
		public const int event_val_TxtCidade = 6;
		public const int event_val_TxtEstado = 7;
		public const int event_val_TxtQtdCartoes = 8;
		public const int event_val_TxtQtdParc = 9;
		public const int event_val_TxtVrMin = 10;
		public const int event_val_TxtVrMax = 11;
		public const int event_Consultar = 12;
		public const int event_Editar = 13;
		public const int event_val_TxtQtdLojas = 14;
		public const int event_Cancelar = 15;
		public const int event_BtnConsultarClick = 16;
		public const int event_LstEmpresasDoubleClick = 17;
		public const int event_BtnCancelarClick = 18;
		#endregion

		public dlgConsultaEmpresa i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		alphaTextController			ctrl_TxtNome			= new alphaTextController();
		alphaTextController			ctrl_TxtCidade			= new alphaTextController();
		alphaTextController			ctrl_TxtEstado			= new alphaTextController();
		numberTextController		ctrl_TxtQtdCartoes		= new numberTextController();
		numberTextController		ctrl_TxtQtdParc			= new numberTextController();
		numberTextController		ctrl_TxtQtdLojas		= new numberTextController();
		
		moneyTextController			ctrl_TxtVrMin			= new moneyTextController();
		moneyTextController			ctrl_TxtVrMax			= new moneyTextController();
				
		Color 	colorInvalid 	= Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgConsultaEmpresa ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgConsultaEmpresa ( this );
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
					
					ctrl_TxtNome.AcquireTextBox			( i_Form.TxtNome,		this, event_val_TxtNome, 		40  );
					ctrl_TxtCidade.AcquireTextBox		( i_Form.TxtCidade,		this, event_val_TxtCidade, 		20, false  );
					ctrl_TxtEstado.AcquireTextBox		( i_Form.TxtEstado,		this, event_val_TxtEstado,		2, false  	);
					ctrl_TxtQtdCartoes.AcquireTextBox	( i_Form.TxtQtdCartoes,	this, event_val_TxtQtdCartoes, 	6  	);
					ctrl_TxtQtdParc.AcquireTextBox		( i_Form.TxtQtdParc,	this, event_val_TxtQtdParc, 	6  	);
					ctrl_TxtQtdLojas.AcquireTextBox		( i_Form.TxtQtdLojas,	this, event_val_TxtQtdLojas, 	6  	);
										
					ctrl_TxtVrMin.AcquireTextBox		( i_Form.TxtVrMin,		this, event_val_TxtVrMin, 	"R$" , 6  	);
					ctrl_TxtVrMax.AcquireTextBox		( i_Form.TxtVrMax,		this, event_val_TxtVrMax, 	"R$" , 6  	);
					
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
				
				#region - event_val_TxtQtdCartoes -
				
				case event_val_TxtQtdCartoes:
				{
					//InitEventCode event_val_TxtQtdCartoes
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtQtdCartoes.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtQtdCartoes.BackColor = Color.White;	
								ctrl_TxtQtdCartoes.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtQtdCartoes.BackColor = colorInvalid;	
								ctrl_TxtQtdCartoes.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtQtdParc -
				
				case event_val_TxtQtdParc:
				{
					//InitEventCode event_val_TxtQtdParc
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtQtdParc.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtQtdParc.BackColor = Color.White;	
								ctrl_TxtQtdParc.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtQtdParc.BackColor = colorInvalid;	
								ctrl_TxtQtdParc.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtVrMin -
				
				case event_val_TxtVrMin:
				{
					//InitEventCode event_val_TxtVrMin
					
					if ( ctrl_TxtVrMin.getTextBoxValue_Long() > 0 )
					{
						i_Form.TxtVrMin.BackColor = Color.White;	
						ctrl_TxtVrMin.IsUserValidated = true;
					}
					else
					{
						i_Form.TxtVrMin.BackColor = colorInvalid;	
						ctrl_TxtVrMin.IsUserValidated = false;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtVrMax -
				
				case event_val_TxtVrMax:
				{
					//InitEventCode event_val_TxtVrMax
					
					if ( ctrl_TxtVrMax.getTextBoxValue_Long() > 0 )
					{
						i_Form.TxtVrMax.BackColor = Color.White;	
						ctrl_TxtVrMax.IsUserValidated = true;
					}
					else
					{
						i_Form.TxtVrMax.BackColor = colorInvalid;	
						ctrl_TxtVrMax.IsUserValidated = false;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Consultar -
				
				case event_Consultar:
				{
					//InitEventCode event_Consultar
					
					i_Form.BtnConsultar.Enabled = false;
					
					DadosConsultaEmpresa dce = new DadosConsultaEmpresa();
					
					dce.set_st_nome 		( ctrl_TxtNome.getTextBoxValue() 			);
					dce.set_st_cidade 		( ctrl_TxtCidade.getTextBoxValue() 			);
					dce.set_st_estado 		( ctrl_TxtEstado.getTextBoxValue() 			);
					dce.set_nu_cartoes 		( ctrl_TxtQtdCartoes.getTextBoxValue() 		);
					dce.set_nu_parcelas 	( ctrl_TxtQtdParc.getTextBoxValue() 		);
					dce.set_vr_taxa_min  	( ctrl_TxtVrMin.getTextBoxValue_NumberStr() );
					dce.set_vr_taxa_max	 	( ctrl_TxtVrMax.getTextBoxValue_NumberStr() );
					dce.set_nu_lojas		( ctrl_TxtQtdLojas.getTextBoxValue()		);
					
					string st_csv_id = "";

					i_Form.LstEmpresas.Items.Clear();
					Application.DoEvents();
					
					if ( var_exchange.fetch_consultaEmpresa ( 	ref dce, 
					                                      		ref header, 
					                                      		ref st_csv_id ) )
					{
						ArrayList full_memory = new ArrayList();
						
						while ( st_csv_id != "" )
						{
							ArrayList tmp_memory  = new ArrayList();
							
							if ( var_exchange.fetch_memory ( st_csv_id, "400",  ref st_csv_id, ref tmp_memory ) )
								for ( int t=0; t < tmp_memory.Count; ++t )
									full_memory.Add ( tmp_memory[t] );
						}
		
						for ( int t=0; t < full_memory.Count; ++t )
						{
							DadosEmpresa de = new DadosEmpresa ( full_memory[t] as DataPortable );
							
							string [] full_row = new string [] { 	de.get_st_empresa(), 
																	de.get_st_fantasia(),
																	de.get_st_cidade(),
																	de.get_st_estado(), 
																	de.get_nu_cartoes(), 
																	de.get_nu_parcelas(), 
																	"R$ " + new money().formatToMoney ( de.get_vr_mensalidade() ),
																	de.get_nu_lojas(),
																	de.get_nu_CNPJ() };
								
							i_Form.LstEmpresas.Items.Add ( var_util.GetListViewItem ( de.get_st_empresa(), full_row ) );
						}
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
					
					if ( i_Form.LstEmpresas.SelectedItems.Count > 0 )
					{
						event_dlgNovaEmpresa ev_call = new event_dlgNovaEmpresa ( var_util, var_exchange );
						
						ev_call.header 			= header;
						ev_call.IsMaintenance 	= true;
						ev_call.par_code 		= var_util.getSelectedListViewItemTag ( i_Form.LstEmpresas );
											
						ev_call.i_Form.ShowDialog();
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtQtdLojas -
				
				case event_val_TxtQtdLojas:
				{
					//InitEventCode event_val_TxtQtdLojas
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtQtdLojas.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtQtdLojas.BackColor = Color.White;	
								ctrl_TxtQtdLojas.IsUserValidated = true;
							}
							else
							{
								i_Form.TxtQtdLojas.BackColor = colorInvalid;	
								ctrl_TxtQtdLojas.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Cancelar -
				
				case event_Cancelar:
				{
					//InitEventCode event_Cancelar
					
					if ( i_Form.LstEmpresas.SelectedItems.Count > 0 )
					{
						dlgAutorizacao autor = new dlgAutorizacao();
						
						autor.ShowDialog();
						
						Application.DoEvents();
						
						var_exchange.exec_cancelaEmpresa (  var_util.getMd5Hash ( autor.senha ),						
															new ApplicationUtil().getSelectedListViewItemTag ( i_Form.LstEmpresas ),
															ref header );
					}
					
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
				
				#region - event_LstEmpresasDoubleClick -
				
				case event_LstEmpresasDoubleClick:
				{
					//InitEventCode event_LstEmpresasDoubleClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnCancelarClick -
				
				case event_BtnCancelarClick:
				{
					//InitEventCode event_BtnCancelarClick
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
