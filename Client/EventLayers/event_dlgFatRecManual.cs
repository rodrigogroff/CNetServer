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
	public class event_dlgFatRecManual : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_val_TxtCodigo = 5;
		public const int event_val_TxtVrPago = 6;
		public const int event_val_TxtJuros = 7;
		public const int event_val_TxtVrAbatimento = 8;
		public const int event_val_TxtMotivo = 9;
		public const int event_BtnConfirmar = 10;
		public const int event_CalcParcela = 11;
		public const int event_BtnConfirmarClick = 12;
		#endregion

		public dlgFatRecManual i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController 	ctrl_TxtCodigo 		 = new numberTextController();
		moneyTextController  	ctrl_TxtVrPago 		 = new moneyTextController();
		percentTextController 	ctrl_TxtJuros 		 = new percentTextController();
		moneyTextController  	ctrl_TxtVrAbatimento = new moneyTextController();
		alphaTextController 	ctrl_TxtMotivo 		 = new alphaTextController();
		
		long vr_total = 0;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgFatRecManual ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgFatRecManual ( this );
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
					
					ctrl_TxtVrAbatimento.AcquireTextBox ( i_Form.TxtVrAbatimento, 	this, event_val_TxtVrAbatimento, "R$", 12 );
					ctrl_TxtJuros.AcquireTextBox 		( i_Form.TxtJuros, 			this, event_val_TxtJuros, 	5, 2 );
					ctrl_TxtCodigo.AcquireTextBox 		( i_Form.TxtCodigo, 		this, event_val_TxtCodigo, 6 );
					ctrl_TxtVrPago.AcquireTextBox 		( i_Form.TxtVrPago, 		this, event_val_TxtVrPago, "R$", 12 );
					ctrl_TxtMotivo.AcquireTextBox 		( i_Form.TxtMotivo, 		this, event_val_TxtMotivo, 20 );
					
					ctrl_TxtVrAbatimento.SetTextBoxString ( "0" );
					ctrl_TxtJuros.SetTextBoxText ( "1000" );
					
					i_Form.TxtTotal.Text = "R$ " + new money().formatToMoney ( vr_total.ToString() );
					
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
				
				#region - event_val_TxtCodigo -
				
				case event_val_TxtCodigo:
				{
					//InitEventCode event_val_TxtCodigo
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtCodigo.Text.Length > 0 )
							{
								i_Form.TxtCodigo.BackColor     = Color.White;	
								ctrl_TxtCodigo.IsUserValidated = true;
								ctrl_TxtCodigo.CleanError();
								
								if ( ctrl_TxtCodigo.GetEnterPressed() )
								{
									if ( i_Form.CboTipo.SelectedIndex != -1 )
									{
										string msg 			= "";
										string tg_empresa 	= Context.FALSE;
										string vr_valor 	= "";
										
										if ( i_Form.CboTipo.SelectedIndex == 0 )
											tg_empresa = Context.TRUE;
										
										if ( var_exchange.fetch_dadosFaturamento ( 	tg_empresa,
										                                      		ctrl_TxtCodigo.getTextBoxValue(), 
										                                      		ref header, 
										                                      		ref msg, 
										                                      		ref vr_valor ) )
										{
											vr_total  = Convert.ToInt64 ( vr_valor );
											
											doEvent ( event_CalcParcela, null );
										}
									}
								}
							}
							break;
						}
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtVrPago -
				
				case event_val_TxtVrPago:
				{
					//InitEventCode event_val_TxtVrPago
					
					doEvent ( event_CalcParcela, null );
											
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtJuros -
				
				case event_val_TxtJuros:
				{
					//InitEventCode event_val_TxtJuros
					
					doEvent ( event_CalcParcela, null );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtVrAbatimento -
				
				case event_val_TxtVrAbatimento:
				{
					//InitEventCode event_val_TxtVrAbatimento
					
					doEvent ( event_CalcParcela, null );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtMotivo -
				
				case event_val_TxtMotivo:
				{
					//InitEventCode event_val_TxtMotivo
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnConfirmar -
				
				case event_BtnConfirmar:
				{
					//InitEventCode event_BtnConfirmar
					
					if ( ctrl_TxtCodigo.getTextBoxValue().Length == 0 )
						return false;
					
					if ( i_Form.TxtMotivo.Text.Length == 0 )
					{
						MessageBox.Show ( "Informe o motivo corretamente", "Aviso" );
						return false;
					}
					
					if ( MessageBox.Show (	"Confirma o valor de despesa " + i_Form.TxtVrDevido.Text + "?",
				                    		"Aviso", 
				                    		MessageBoxButtons.YesNo, 
				                    		MessageBoxIcon.Question, 
				                    		MessageBoxDefaultButton.Button2 ) == DialogResult.No )
					{
						return false;
					}
					
					string st_val_juro = i_Form.TxtVrDevido.Text.Replace ( "R$ ","" );
					
					long   valor_juro  = new money().getNumericValue ( st_val_juro );
					long   valor_pago  = ctrl_TxtVrPago.getTextBoxValue_Long();
									
					string emp      = Context.FALSE;
					string desconto = Context.FALSE;
					
					if ( i_Form.CboTipo.SelectedIndex == 0 )
						emp = Context.TRUE;	
					
					if ( !var_exchange.exec_fat_recManual ( emp,
						                                  	ctrl_TxtCodigo.getTextBoxValue(),
						                                  	valor_pago.ToString(),
						                                  	ref header ) )
					{
						return false;
					}
						
					if ( valor_juro > 0 )
					{
						var_exchange.ins_despesa (  valor_juro.ToString(),
						                          	ctrl_TxtCodigo.getTextBoxValue(),
						                          	emp,
						                          	i_Form.TxtMotivo.Text,
						                          	desconto,
						                          	ref header );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CalcParcela -
				
				case event_CalcParcela:
				{
					//InitEventCode event_CalcParcela
					
					if ( i_Form.TxtVrPago.Text.Length == 0 )
						return false;
					
					if ( i_Form.TxtJuros.Text.Length == 0 )
						return false;
					
					if ( i_Form.TxtVrAbatimento.Text.Length == 0 )
						return false;
					
					i_Form.TxtTotal.Text = "R$ " + new money().formatToMoney ( vr_total.ToString() );
					
					long desc = vr_total - ctrl_TxtVrPago.getTextBoxValue_Long();
					
					i_Form.TxtVrDesc.Text = "R$ " + new money().formatToMoney ( desc.ToString() );
										
					long jur  = (long) ctrl_TxtJuros.getTextBoxValue_Double() * vr_total / 100;
					long abat = ctrl_TxtVrAbatimento.getTextBoxValue_Long();
					
					i_Form.TxtVrDevido.Text = "R$ " + new money().formatToMoney ( ( desc + jur - abat ).ToString() );					
					
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
