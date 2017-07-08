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
	public class event_MainForm : EventLayer
	{
		#region - EVENTS -
		public const int event_Start = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int event_FormIsClosing = 3;
		public const int event_MainFormFormClosing = 4;
		public const int event_BtnVendaOnlineClick = 5;
		public const int event_BtnVendaDigitadaClick = 6;
		public const int event_BtnPendenciasClick = 7;
		public const int event_Login = 8;
		public const int event_Logoff = 9;
		public const int event_BtnCancelamentoClick = 10;
		public const int event_BtnFinanceiroClick = 11;
		#endregion

		public MainForm i_Form;

		//UserVariables
		
		public CNetHeader header = new CNetHeader();
				
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_MainForm ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new MainForm ( this );
		}
		
		public override bool doEvent ( int event_number, object arg )
		{
			switch ( event_number )
			{
				#region - event_Start -
				
				case event_Start:
				{
					//InitEventCode event_Start
					
					doEvent ( event_Translate, 			null );
					doEvent ( event_FormIsOpening, 		null );
					
					if ( !var_util.offline )
					{
						if ( !doEvent ( event_Login, 		null ) )
						{
							var_exchange.m_Client.ExitSession();
							Application.ExitThread();						
							return false;
						}
					}
					else
					{
						i_Form.BtnVendaOnline.Enabled = false; 
						
						i_Form.ShowDialog();
					}
				
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
					
					i_Form.LblVersion.Text = new InstallData().st_version;					
														
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_FormIsClosing -
				
				case event_FormIsClosing:
				{
					//InitEventCode event_FormIsClosing
					
					if ( !var_util.offline )
					{
						doEvent ( event_Logoff, null );
						
						var_exchange.m_Client.ExitSession();
					}
					
					Application.ExitThread();
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_MainFormFormClosing -
				
				case event_MainFormFormClosing:
				{
					//InitEventCode event_MainFormFormClosing
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnVendaOnlineClick -
				
				case event_BtnVendaOnlineClick:
				{
					//InitEventCode event_BtnVendaOnlineClick
					
					event_dlgVendaOnline ev_call = new event_dlgVendaOnline ( var_util, var_exchange );
					
					ev_call.header = header;
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnVendaDigitadaClick -
				
				case event_BtnVendaDigitadaClick:
				{
					//InitEventCode event_BtnVendaDigitadaClick
					
					event_dlgVendaOffline ev_call = new event_dlgVendaOffline ( var_util, var_exchange );
					
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnPendenciasClick -
				
				case event_BtnPendenciasClick:
				{
					//InitEventCode event_BtnPendenciasClick
					
					event_dlgPend ev_call = new event_dlgPend ( var_util, var_exchange );
					
					ev_call.header = header;
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Login -
				
				case event_Login:
				{
					//InitEventCode event_Login
					
					event_dlgLogin 	ev_call  = new event_dlgLogin ( var_util, var_exchange );
					
					ev_call.header = header;
					ev_call.i_Form.ShowDialog();
					
					if ( ev_call.var_IsCanceled )
						return false;
					
					i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Logoff -
				
				case event_Logoff:
				{
					//InitEventCode event_Logoff
					
					var_exchange.exec_logoff ( ref header );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnCancelamentoClick -
				
				case event_BtnCancelamentoClick:
				{
					//InitEventCode event_BtnCancelamentoClick
					
					event_dlgCancelamento ev_call = new event_dlgCancelamento ( var_util, var_exchange );
					
					ev_call.header = header;
					ev_call.i_Form.ShowDialog();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnFinanceiroClick -
				
				case event_BtnFinanceiroClick:
				{
					//InitEventCode event_BtnFinanceiroClick
					
					event_dlgFinanceiro ev_call = new event_dlgFinanceiro ( var_util, var_exchange );
					
					ev_call.header = header;
					ev_call.i_Form.ShowDialog();
					
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
