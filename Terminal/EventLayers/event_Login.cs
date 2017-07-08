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
	public class event_Login : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		#endregion

		public Login i_Form;

		//UserVariables
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_Login ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new Login ( this );
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
