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
	public class event_dlgManutencaoTerminal : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_BuscaDados = 5;
		public const int event_val_TxtCNPJ = 6;
		public const int event_Remover = 7;
		public const int event_Alterar = 8;
		public const int event_BtnAlterarClick = 9;
		#endregion

		public dlgManutencaoTerminal i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController			ctrl_TxtCNPJ			= new numberTextController();
		
		Color colorInvalid = Color.Lavender;		
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgManutencaoTerminal ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgManutencaoTerminal ( this );
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
					
					ctrl_TxtCNPJ.AcquireTextBox 		( i_Form.TxtCNPJ, 			this, event_val_TxtCNPJ, 			8  );
					
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
				
				#region - event_BuscaDados -
				
				case event_BuscaDados:
				{
					//InitEventCode event_BuscaDados
					
					i_Form.LstTerminais.Items.Clear();
					
					ArrayList list = new ArrayList();
					
					if ( var_exchange.fetch_terminalLoja ( 	ctrl_TxtCNPJ.getTextBoxValue(), 
					                                      	ref header, 
					                                      	ref list ) )
					{
						for (int t=0; t < list.Count; ++t )
						{
							DadosTerminal dt = new DadosTerminal ( list[t] as DataPortable );	
							
							string [] full_row = new string [] { 	dt.get_st_terminal(), 
																	dt.get_st_localizacao() };
									
							i_Form.LstTerminais.Items.Add ( var_util.GetListViewItem ( dt.get_st_terminal(), full_row ) );
						}
					}
					else
					{
						i_Form.LstTerminais.Items.Clear();
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
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtCNPJ.Text.Length > 0 )
							{
								i_Form.TxtCNPJ.BackColor     = Color.White;	
								ctrl_TxtCNPJ.IsUserValidated = true;
								ctrl_TxtCNPJ.CleanError();
								
								if ( ctrl_TxtCNPJ.GetEnterPressed() )
								{
									doEvent ( event_BuscaDados,null );
								}
							}
							else
							{
								i_Form.TxtCNPJ.BackColor     = colorInvalid;	
								ctrl_TxtCNPJ.IsUserValidated = false;
							}
							break;
						}
							
						default: break;
					}									
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Remover -
				
				case event_Remover:
				{
					//InitEventCode event_Remover
					
					if ( i_Form.LstTerminais.SelectedItems.Count > 0 )
					{
						var_exchange.del_Terminal ( ctrl_TxtCNPJ.getTextBoxValue(), 
						                           	i_Form.LstTerminais.SelectedItems[0].SubItems[0].Text,
						                           	ref header );
						
						doEvent ( event_BuscaDados, null );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Alterar -
				
				case event_Alterar:
				{
					//InitEventCode event_Alterar
					
					if ( i_Form.LstTerminais.SelectedItems.Count > 0 ) 
					{
						event_dlgLocalizacao ev_call = new event_dlgLocalizacao ( var_util, var_exchange );
						
						ev_call.header = header;
						ev_call.var_TxtTerminal = i_Form.LstTerminais.SelectedItems[0].SubItems[0].Text;
						ev_call.var_TxtLocalizacao = i_Form.LstTerminais.SelectedItems[0].SubItems[1].Text;
											
						ev_call.i_Form.ShowDialog();
						
						doEvent ( event_BuscaDados, null );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnAlterarClick -
				
				case event_BtnAlterarClick:
				{
					//InitEventCode event_BtnAlterarClick
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
