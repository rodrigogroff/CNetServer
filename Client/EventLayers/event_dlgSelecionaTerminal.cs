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
	public class event_dlgSelecionaTerminal : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_val_TxtNome = 5;
		public const int event_Confirmar = 6;
		public const int event_LojaClick = 7;
		public const int event_TermClick = 8;
		public const int event_LstLojasClick = 9;
		public const int event_LstTermClick = 10;
		public const int event_BtnConfirmarClick = 11;
		#endregion

		public dlgSelecionaTerminal i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		public string st_cod_terminal = "";
		public string st_cod_empresa  = "";
		public string st_nome_loja    = "";
		
		alphaTextController	ctrl_TxtNome = new alphaTextController();
		
		Color colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgSelecionaTerminal ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgSelecionaTerminal ( this );
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
					
					ctrl_TxtNome.AcquireTextBox 		( i_Form.TxtNome, 			this, event_val_TxtNome, 		20, "" 		);
					
					ctrl_TxtNome.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false );
					
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
				
				#region - event_val_TxtNome -
				
				case event_val_TxtNome:
				{
					//InitEventCode event_val_TxtNome
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtNome.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtNome.BackColor = Color.White;	
								ctrl_TxtNome.IsUserValidated = true;
								ctrl_TxtNome.CleanError();
								
								if ( ctrl_TxtNome.GetEnterPressed() )
								{
									ArrayList lst = new ArrayList();
									
									if ( var_exchange.fetch_nomeLoja (  ctrl_TxtNome.getTextBoxValue(), 
									                              		st_cod_empresa, 
									                              		ref header, 
									                              		ref lst ) )
									{
										i_Form.LstLojas.Items.Clear();
										for ( int t=0; t < lst.Count; ++t )
										{
											DadosLoja dl = new DadosLoja ( lst[t] as DataPortable );
											
											string [] full_row = new string [] { dl.get_st_nome(), dl.get_st_loja() };
										
											i_Form.LstLojas.Items.Add ( var_util.GetListViewItem ( dl.get_st_loja(), full_row ) );
										}
									}
								}
							}
							else
							{
								i_Form.TxtNome.BackColor = colorInvalid;	
								ctrl_TxtNome.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Confirmar -
				
				case event_Confirmar:
				{
					//InitEventCode event_Confirmar
					
					i_Form.Close();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_LojaClick -
				
				case event_LojaClick:
				{
					//InitEventCode event_LojaClick
					
					if ( i_Form.LstLojas.SelectedItems.Count > 0 )
					{
						string st_cod_loja = new ApplicationUtil().getSelectedListViewItemTag ( i_Form.LstLojas );
						
						ArrayList lst = new ArrayList();
						
						if ( var_exchange.fetch_termLoja ( st_cod_loja, ref header, ref lst ) )
						{
							for ( int t=0; t < lst.Count; ++t )
							{
								DadosTerminal dt = new DadosTerminal ( lst [ t ] as DataPortable );
								
								string [] full_row = new string [] { dt.get_st_terminal(), dt.get_st_localizacao() };
										
								i_Form.LstTerm.Items.Add ( var_util.GetListViewItem ( dt.get_st_terminal(), full_row ) );
							}
						}
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_TermClick -
				
				case event_TermClick:
				{
					//InitEventCode event_TermClick
					
					if ( i_Form.LstTerm.SelectedItems.Count > 0 && 
					     i_Form.LstLojas.SelectedItems.Count > 0 )
					{
						st_cod_terminal = var_util.getSelectedListViewItemTag ( i_Form.LstTerm );
						st_nome_loja    = i_Form.LstLojas.SelectedItems[0].SubItems[0].Text;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_LstLojasClick -
				
				case event_LstLojasClick:
				{
					//InitEventCode event_LstLojasClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_LstTermClick -
				
				case event_LstTermClick:
				{
					//InitEventCode event_LstTermClick
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
