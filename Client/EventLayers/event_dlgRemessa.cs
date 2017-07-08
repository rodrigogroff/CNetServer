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
	public class event_dlgRemessa : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Processar = 5;
		public const int event_val_TxtCodEmpresa = 6;
		public const int event_BtnBuscarClick = 7;
		public const int event_BtnProcClick = 8;
		#endregion

		public dlgRemessa i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController 		ctrl_TxtCodEmpresa	= new numberTextController();
		
		Color 	colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgRemessa ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgRemessa ( this );
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
					
					ctrl_TxtCodEmpresa.AcquireTextBox 	( i_Form.TxtCodEmpresa, 	this, event_val_TxtCodEmpresa, 	6  );
					
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
				
				#region - event_Processar -
				
				case event_Processar:
				{
					//InitEventCode event_Processar
					
					if ( !ctrl_TxtCodEmpresa.IsUserValidated )
						return false;
					
					if ( i_Form.TxtFile.Text == "" )
						return false;
					
					i_Form.BtnProc.Enabled = false;
					
					ArrayList 	lstLines 	= new ArrayList();
					
					string 		id_archive 	= "";
					
					long 		sizeInfo 	= 100;
					long 		max 		= Convert.ToInt64 ( new InstallData().maxPacket ) / sizeInfo;
					long 		index 		= 0;
					
					StreamReader file = new StreamReader ( i_Form.TxtFile.Text );
					
					while ( !file.EndOfStream )
					{
						DataPortable port = new DataPortable();
						
						port.setValue ( "line", file.ReadLine() );
						
						lstLines.Add ( port );
						
						if ( ++index == max )
						{
							var_exchange.upload_archive ( id_archive, 
							                              ref header,
							                              ref lstLines,
							                              ref id_archive );
							index = 0;
							lstLines.Clear();
						}
					}
					
					if ( index > 0 )
					{
						var_exchange.upload_archive ( 	id_archive,
							                          	ref header,
														ref lstLines,
							                            ref id_archive );
					}
					
					file.Close();			
					
					if ( var_exchange.exec_processaArqConvenio ( id_archive, ctrl_TxtCodEmpresa.getTextBoxValue(), ref header ) )
					{
						MessageBox.Show ( "Arquivo processado" );
					}
					
					i_Form.BtnProc.Enabled = true;	
					    
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCodEmpresa -
				
				case event_val_TxtCodEmpresa:
				{
					//InitEventCode event_val_TxtCodEmpresa
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtCodEmpresa.Text.Length > 0 )
							{
								i_Form.TxtCodEmpresa.BackColor     = Color.White;	
								ctrl_TxtCodEmpresa.IsUserValidated = true;
								ctrl_TxtCodEmpresa.CleanError();
							}
							else
							{
								i_Form.TxtCodEmpresa.BackColor     = colorInvalid;	
								ctrl_TxtCodEmpresa.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnBuscarClick -
				
				case event_BtnBuscarClick:
				{
					//InitEventCode event_BtnBuscarClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnProcClick -
				
				case event_BtnProcClick:
				{
					//InitEventCode event_BtnProcClick
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
