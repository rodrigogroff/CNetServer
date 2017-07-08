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
	public class event_dlgCustoChamado : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_FormIsClosing = 5;
		public const int event_Confirmar = 6;
		public const int event_val_TxtValor = 7;
		public const int event_BtnConfirmarClick = 8;
		#endregion

		public dlgCustoChamado i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		public string cod_loja = "";
		
		moneyTextController ctrl_TxtValor = new moneyTextController();
			
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgCustoChamado ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgCustoChamado ( this );
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
					
					ctrl_TxtValor.AcquireTextBox 	( i_Form.TxtValor, this, event_val_TxtValor, "R$", 6 );
					
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
				
				#region - event_FormIsClosing -
				
				case event_FormIsClosing:
				{
					//InitEventCode event_FormIsClosing
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Confirmar -
				
				case event_Confirmar:
				{
					//InitEventCode event_Confirmar
					
					var_exchange.ins_despesa (  ctrl_TxtValor.getTextBoxValue_NumberStr(),
					                          	cod_loja,
					                          	Context.FALSE,
					                          	"Chamado ConveyNET",
					                          	Context.FALSE,
					                          	ref header );
					
					i_Form.Close();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtValor -
				
				case event_val_TxtValor:
				{
					//InitEventCode event_val_TxtValor
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
