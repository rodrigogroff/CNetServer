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
	public class event_dlgAdminEmpresas : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_val_TxtEmpresa = 5;
		public const int event_Remover = 6;
		public const int event_Adicionar = 7;
		public const int event_BuscaDados = 8;
		public const int event_BtnRemoverClick = 9;
		public const int event_BtnVincularClick = 10;
		#endregion

		public dlgAdminEmpresas i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController 	ctrl_TxtEmpresa	= new numberTextController();
		
		Color 	colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgAdminEmpresas ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgAdminEmpresas ( this );
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
					
					ctrl_TxtEmpresa.AcquireTextBox 	( i_Form.TxtEmpresa, this, event_val_TxtEmpresa,  6  );
										
					ctrl_TxtEmpresa.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false );
					
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
				
				#region - event_val_TxtEmpresa -
				
				case event_val_TxtEmpresa:
				{
					//InitEventCode event_val_TxtEmpresa
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtEmpresa.Text.Length == 6 )
							{
								i_Form.TxtEmpresa.BackColor     = Color.White;	
								ctrl_TxtEmpresa.IsUserValidated = true;
								ctrl_TxtEmpresa.CleanError();
							}
							else
							{
								i_Form.TxtEmpresa.BackColor     = colorInvalid;	
								ctrl_TxtEmpresa.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					if ( ctrl_TxtEmpresa.GetEnterPressed() )
					{
						doEvent ( event_BuscaDados, null );
						
						ctrl_TxtEmpresa.SetTextBoxText ( ctrl_TxtEmpresa.getTextBoxValue().PadLeft ( 6, '0' ) );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Remover -
				
				case event_Remover:
				{
					//InitEventCode event_Remover
					
					if ( i_Form.LstEmp.SelectedItem == null )
						return false;
					
					if ( !ctrl_TxtEmpresa.IsUserValidated )
						return false;
					
					var_exchange.exec_alteraAdminEmpresa ( 	ctrl_TxtEmpresa.getTextBoxValue(), 
					                                      	Context.TRUE,
					                                      	i_Form.LstEmp.SelectedItem.ToString().Substring ( 0, 6 ),
					                                      	ref header );
					
					doEvent ( event_BuscaDados, null );

					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Adicionar -
				
				case event_Adicionar:
				{
					//InitEventCode event_Adicionar
					
					if ( i_Form.LstEmpDisp.SelectedItem == null )
						return false;
					
					if ( !ctrl_TxtEmpresa.IsUserValidated )
						return false;
					
					var_exchange.exec_alteraAdminEmpresa ( 	ctrl_TxtEmpresa.getTextBoxValue(), 
					                                      	Context.FALSE,
					                                      	i_Form.LstEmpDisp.SelectedItem.ToString().Substring ( 0, 6 ),
					                                      	ref header );
					
					doEvent ( event_BuscaDados, null );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BuscaDados -
				
				case event_BuscaDados:
				{
					//InitEventCode event_BuscaDados
					
					DadosEmpresa de = new DadosEmpresa();
					
					i_Form.LstEmp.Items.Clear();
					i_Form.LstEmpDisp.Items.Clear();
						
					if ( var_exchange.fetch_dadosEmpresa ( 	ctrl_TxtEmpresa.getTextBoxValue(),
					                                 		ref header,
					                                 		ref de ) )
					{
						i_Form.TxtNome.Text = de.get_st_fantasia();
					
						string st_csv_in  = "";
						string st_csv_out = "";
						
						if ( var_exchange.fetch_dadosAdministradora ( 	ctrl_TxtEmpresa.getTextBoxValue(),
						                                 				ref header,
						                                 				ref st_csv_in,
						                                 				ref st_csv_out ) )
						{
							// obtem in
							{
								ArrayList full_memory = new ArrayList();
							
								while ( st_csv_in != "" )
								{
									ArrayList tmp_memory  = new ArrayList();
									
									if ( var_exchange.fetch_memory ( st_csv_in, "400", ref st_csv_in, ref tmp_memory ) )
										for ( int t=0; t < tmp_memory.Count; ++t )
											full_memory.Add ( tmp_memory[t] );
								}
								
								for ( int t=0; t < full_memory.Count; ++t )
								{
									DadosEmpresa dex = new DadosEmpresa ( full_memory[t] as DataPortable );
									
									i_Form.LstEmp.Items.Add ( dex.get_st_empresa() + " - " + dex.get_st_fantasia() );
								}
							}
							
							// obtem out
							{
								ArrayList full_memory = new ArrayList();
							
								while ( st_csv_out != "" )
								{
									ArrayList tmp_memory  = new ArrayList();
									
									if ( var_exchange.fetch_memory ( st_csv_out, "400", ref st_csv_out, ref tmp_memory ) )
										for ( int t=0; t < tmp_memory.Count; ++t )
											full_memory.Add ( tmp_memory[t] );
								}
								
								for ( int t=0; t < full_memory.Count; ++t )
								{
									DadosEmpresa dex = new DadosEmpresa ( full_memory[t] as DataPortable );
									
									i_Form.LstEmpDisp.Items.Add ( dex.get_st_empresa() + " - " + dex.get_st_fantasia() );
								}
							}
						}
					}
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnRemoverClick -
				
				case event_BtnRemoverClick:
				{
					//InitEventCode event_BtnRemoverClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnVincularClick -
				
				case event_BtnVincularClick:
				{
					//InitEventCode event_BtnVincularClick
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
