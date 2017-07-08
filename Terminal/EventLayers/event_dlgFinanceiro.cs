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
	public class event_dlgFinanceiro : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int event_CalDateChanged = 3;
		public const int event_CalDateSelected = 4;
		#endregion

		public dlgFinanceiro i_Form;

		//UserVariables
		
		public CNetHeader header;
			
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgFinanceiro ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgFinanceiro ( this );
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
					
					doEvent ( event_CalDateChanged, null );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CalDateChanged -
				
				case event_CalDateChanged:
				{
					//InitEventCode event_CalDateChanged
					
					string oper   = "";
					string vendas = "";
					string canc   = "";
					
					var_exchange.fetch_financ_lojista ( var_util.GetDataBaseTimeFormat ( i_Form.cal.SelectionStart ),
					                                  	ref header,
					                                    ref oper, 
					                                    ref vendas, 
					                                    ref canc );
					
					i_Form.LblOper.Text 		= oper;
					i_Form.LblVendas.Text 		= "R$ " + new money().formatToMoney ( vendas );
					i_Form.LblVendasCanc.Text 	= "R$ " + new money().formatToMoney ( canc );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CalDateSelected -
				
				case event_CalDateSelected:
				{
					//InitEventCode event_CalDateSelected
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
