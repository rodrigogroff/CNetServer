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
	public class event_dlgVendaParcelada : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Redefinir = 5;
		public const int event_Confirmar = 6;
		public const int event_val_TxtValor = 7;
		public const int event_LstClick = 8;
		public const int event_LstParcsClick = 9;
		public const int event_BtnConfirmarClick = 10;
		#endregion

		public dlgVendaParcelada i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		public long tot_parcs = 0;
		public long tot_valor = 0;
		
		long vr_diff = 0;
		
		public ArrayList lstPar;
		
		moneyTextController ctrl_TxtValor = new moneyTextController();
		
		Color 	colorInvalid 	= Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgVendaParcelada ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgVendaParcelada ( this );
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
					
					ctrl_TxtValor.AcquireTextBox ( i_Form.TxtValor, this, event_val_TxtValor, "R$", 9 );
					
					i_Form.LblParc.Text  += tot_parcs.ToString();
					
					i_Form.LblVrTot.Text = "Valor Total: R$ " + new money().setMoneyFormat ( tot_valor );
					i_Form.LblDiff.Text  = "Diferença: R$ 0,00";
					
					long parc = tot_valor / tot_parcs;
					
					if ( lstPar.Count == 0 )
					{
						for ( int t=0; t < tot_parcs; ++t )
						{
							i_Form.LstParcs.Items.Add ( new money().setMoneyFormat ( parc ) );
						}
					}
					else
					{
						for ( int t=0; t < lstPar.Count; ++t )
						{
							i_Form.LstParcs.Items.Add ( new money().formatToMoney ( lstPar[t].ToString() ) );
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
				
				#region - event_Redefinir -
				
				case event_Redefinir:
				{
					//InitEventCode event_Redefinir
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Confirmar -
				
				case event_Confirmar:
				{
					//InitEventCode event_Confirmar
					
					if ( vr_diff != 0 )
					{
						MessageBox.Show ( "Corrigir a diferença nas parcelas","Aviso" );
					}
					else
					{
						lstPar.Clear();
						
						for (int t=0; t < i_Form.LstParcs.Items.Count; ++t )
						{
							lstPar.Add ( i_Form.LstParcs.Items [ t ].ToString().Replace ( ",","" ).Replace ( ".","" ) );
						}	
						
						i_Form.Close();
					}
					    
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtValor -
				
				case event_val_TxtValor:
				{
					//InitEventCode event_val_TxtValor
					
					if ( ctrl_TxtValor.GetEnterPressed() )
					{
						if ( i_Form.LstParcs.SelectedIndex >= 0 )
						{
							vr_diff = 0;
							
							i_Form.LstParcs.Items [ i_Form.LstParcs.SelectedIndex ] = ctrl_TxtValor.getTextBoxValue();
							
							for (int t=0; t < i_Form.LstParcs.Items.Count; ++t )
							{
								vr_diff += new money().getNumericValue ( i_Form.LstParcs.Items [ t ].ToString() );
							}							
							
							vr_diff = tot_valor - vr_diff;
							
							i_Form.LblDiff.Text  = "Diferença: R$ " + new money().setMoneyFormat ( vr_diff );
						}
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_LstClick -
				
				case event_LstClick:
				{
					//InitEventCode event_LstClick
					
					if ( i_Form.LstParcs.SelectedIndex >= 0 )
					{
						ctrl_TxtValor.SetTextBoxString ( i_Form.LstParcs.SelectedItem.ToString() );
					}
				
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_LstParcsClick -
				
				case event_LstParcsClick:
				{
					//InitEventCode event_LstParcsClick
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
