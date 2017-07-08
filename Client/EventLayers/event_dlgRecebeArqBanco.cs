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
	public class event_dlgRecebeArqBanco : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Processar = 5;
		public const int event_BtnProcurarClick = 6;
		public const int event_BtnProcessarClick = 7;
		#endregion

		public dlgRecebeArqBanco i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgRecebeArqBanco ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgRecebeArqBanco ( this );
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
					
					if ( i_Form.TxtFile.Text == "" )
						return false;
					
					i_Form.BtnProcessar.Enabled = false;
					
					ArrayList 	lstLines 	= new ArrayList();
					string 		id_archive 	= "";
					string 		line		= "";
					string 		line_final	= "";
					long 		sizeInfo 	= 100;
					long 		max 		= Convert.ToInt64 ( new InstallData().maxPacket ) / sizeInfo;
					long 		index 		= 0;
					
					StreamReader file = new StreamReader ( i_Form.TxtFile.Text );
					
					line = file.ReadLine();
					
					bool debitoConta = false;
					
					if ( line [0] == '1' ) 
						debitoConta = true;
					
					while ( !file.EndOfStream )
					{
						line = file.ReadLine();
						
						if ( debitoConta ) // deb em conta
						{
							if ( line [0] == 'Z' ) 
								break;
							
							line_final = line.Substring ( 1,25 ) + 
										 line.Substring ( 67,2 ) + 
										 " ".PadLeft ( 42, '0' ) +
										 line.Substring ( 54,13 );						
						}
						else // doc
						{
							if ( line [0] == '9' ) 
								break;
							
							line_final = line.Substring ( 37,25 ) + 
										 line.Substring ( 108,2 ) + 
										 line.Substring ( 110,42 ) +
										 line.Substring ( 253,13 );
						}
									
						// substring
						
						DataPortable port = new DataPortable();
						
						port.setValue ( "line", line_final );
						
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
					
					var_exchange.exec_processaArqBancario ( id_archive, ref header );
					
					MessageBox.Show ( "Arquivo processado" );
					
					i_Form.BtnProcessar.Enabled = true;	
					
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
				
				#region - event_BtnProcessarClick -
				
				case event_BtnProcessarClick:
				{
					//InitEventCode event_BtnProcessarClick
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
