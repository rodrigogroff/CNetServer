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
	public class event_dlgLojista : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Vincular = 5;
		public const int event_val_TxtCodLoja = 6;
		public const int event_BtnVincularClick = 7;
		#endregion

		public dlgLojista i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController ctrl_TxtCodLoja = new numberTextController();
		
		Color 	colorInvalid 	= Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgLojista ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgLojista ( this );
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
					
					ctrl_TxtCodLoja.AcquireTextBox		( i_Form.TxtCodLoja,	 this, event_val_TxtCodLoja, 		8 	);
					
					// carregar list box com usuarios logistas sem vinculo
					
					ArrayList lst = new ArrayList();
					
					var_exchange.fetch_user_lojista ( ref header, ref lst );
					
					for ( int t=0; t < lst.Count; ++t )
					{
						DadosUsuario du = new DadosUsuario ( lst [t] as DataPortable );
						
						i_Form.LstUsers.Items.Add ( du.get_id_usuario() + " - " + 
						                            du.get_st_nome() );
					}
					
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
				
				#region - event_Vincular -
				
				case event_Vincular:
				{
					//InitEventCode event_Vincular
					
					if ( i_Form.LstUsers.SelectedIndex == -1 )
					{
						MessageBox.Show ( "Selecione o usuário", "Aviso" );
						return false;
					}
					
					if ( i_Form.TxtNomeLoja.Text.Length == 0 )
					{
						MessageBox.Show ( "Selecione o código da loja", "Aviso" );
						return false;
					}
					
					string id_user = i_Form.LstUsers.SelectedItem.ToString();
					
					id_user = id_user.Substring (0, id_user.IndexOf ( " " ) );
					
					var_exchange.exec_vincula_lojista ( ctrl_TxtCodLoja.getTextBoxValue(),
					                                    id_user,
					                                    ref header );
					
					i_Form.Close();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCodLoja -
				
				case event_val_TxtCodLoja:
				{
					//InitEventCode event_val_TxtCodLoja
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtCodLoja.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtCodLoja.BackColor = Color.White;	
								ctrl_TxtCodLoja.IsUserValidated = true;
								
								if ( ctrl_TxtCodLoja.GetEnterPressed() )
								{
									DadosLoja dl = new DadosLoja();
									
									var_exchange.fetch_dadosLoja ( "",
									                              ctrl_TxtCodLoja.getTextBoxValue(),
									                              ref header,
									                              ref dl );
									
									i_Form.TxtNomeLoja.Text = dl.get_st_nome();
								}
							}
							else
							{
								i_Form.TxtCodLoja.BackColor = colorInvalid;	
								ctrl_TxtCodLoja.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
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
