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
	public class event_dlgCancelaDespesa : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_val_TxtCodigo = 5;
		public const int event_Cancelar = 6;
		public const int event_buscaDados = 7;
		public const int event_BtnCancelarClick = 8;
		#endregion

		public dlgCancelaDespesa i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController ctrl_TxtCodigo	= new numberTextController();
				
		Color 	colorInvalid 	= Color.Lavender;		
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgCancelaDespesa ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgCancelaDespesa ( this );
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
					
					ctrl_TxtCodigo.AcquireTextBox   ( i_Form.TxtCodigo, 	this, event_val_TxtCodigo,   		6 );
					
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
									doEvent ( event_buscaDados, null );
								}
							}
							else
							{
								i_Form.TxtCodigo.BackColor     = colorInvalid;	
								ctrl_TxtCodigo.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Cancelar -
				
				case event_Cancelar:
				{
					//InitEventCode event_Cancelar
										
					var_exchange.exec_cancelaDespesa ( var_util.getSelectedListViewItemTag ( i_Form.LstDespesas ), 
					                                   ref header );
					
					doEvent ( event_buscaDados, null );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_buscaDados -
				
				case event_buscaDados:
				{
					//InitEventCode event_buscaDados
					
					if ( i_Form.CboTipo.SelectedIndex != -1 )
					{
						ArrayList list = new ArrayList();
						
						string nome   = "";
						string tg_emp = Context.FALSE;
						
						if ( i_Form.CboTipo.SelectedIndex == 0 )
							tg_emp = Context.TRUE;
						
						var_exchange.fetch_dadosDespesas ( 	tg_emp,
							                                ctrl_TxtCodigo.getTextBoxValue(),
							                                ref header, 
							                                ref nome,
							                                ref list );
							
						i_Form.TxtNome.Text = nome;
						
						i_Form.LstDespesas.Items.Clear();
						
						for (int t=0; t < list.Count; ++t )
						{
							DadosDespesas dd = new DadosDespesas ( list [t] as DataPortable );
							
							string [] full_row = new string [] { dd.get_st_info(), 
																 new money().formatToMoney ( dd.get_vr_cobrança() ) };
			
							i_Form.LstDespesas.Items.Add ( var_util.GetListViewItem( dd.get_fk_faturadet(), full_row ) );
						}
						
						Application.DoEvents();
					}
	
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnCancelarClick -
				
				case event_BtnCancelarClick:
				{
					//InitEventCode event_BtnCancelarClick
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
