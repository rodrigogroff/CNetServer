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
	public class event_dlgNovoChamado : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtLoja = 6;
		public const int event_BtnConfirmarClick = 7;
		#endregion

		public dlgNovoChamado i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController ctrl_TxtLoja = new numberTextController();
		
		Color colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgNovoChamado ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgNovoChamado ( this );
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
					
					ctrl_TxtLoja.AcquireTextBox	( i_Form.TxtLoja,   this, event_val_TxtLoja, 	6	);
					
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
				
				#region - event_Confirmar -
				
				case event_Confirmar:
				{
					//InitEventCode event_Confirmar
					
					if ( !ctrl_TxtLoja.IsUserValidated )
					{
						MessageBox.Show ( "Favor informar o código de loja", "Aviso" );
						return false;
					}
					
					if ( i_Form.CboCateg.SelectedIndex == -1 )
					{
						MessageBox.Show ( "Favor informar a categoria", "Aviso" );
						return false;
					}
					
					if ( i_Form.CboPrioridade.SelectedIndex == -1 )
					{
						MessageBox.Show ( "Favor informar a prioridade", "Aviso" );
						return false;
					}
					
					DadosChamado dc = new DadosChamado();
					
					dc.set_nu_categ 		( i_Form.CboCateg.SelectedIndex.ToString() 		);
					dc.set_nu_prioridade 	( i_Form.CboPrioridade.SelectedIndex.ToString() );
					dc.set_st_cod_loja		( ctrl_TxtLoja.getTextBoxValue() 				);
					dc.set_st_motivo		( i_Form.TxtDesc.Text 							);
					
					if ( i_Form.ChkTecnico.Checked )
						dc.set_tg_tecnico ( Context.TRUE );
					else
						dc.set_tg_tecnico ( Context.FALSE );
					
					var_exchange.ins_chamado ( ref dc, ref header );
					
					if ( i_Form.ChkTecnico.Checked )
					{
						event_dlgCustoChamado ev_call = new event_dlgCustoChamado ( var_util, var_exchange );
						
						ev_call.header = header;
						ev_call.cod_loja = ctrl_TxtLoja.getTextBoxValue();
						
						ev_call.i_Form.ShowDialog();
					}
					
					i_Form.Close();
				
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtLoja -
				
				case event_val_TxtLoja:
				{
					//InitEventCode event_val_TxtLoja
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( ctrl_TxtLoja.getTextBoxValue().Length > 0 )
							{
								i_Form.TxtLoja.BackColor = Color.White;	
								ctrl_TxtLoja.IsUserValidated = true;
								
								if ( ctrl_TxtLoja.GetEnterPressed() )
								{
									DadosLoja dl = new DadosLoja();
									
									var_exchange.fetch_dadosLoja ( "", ctrl_TxtLoja.getTextBoxValue(), ref header, ref dl );
									
									i_Form.TxtNome.Text = dl.get_st_nome();
								}
							}
							else
							{
								i_Form.TxtLoja.BackColor = colorInvalid;	
								ctrl_TxtLoja.IsUserValidated = false;
								
								if ( ctrl_TxtLoja.GetEnterPressed() )
								{
									event_dlgConsultaLoja ev_call = new event_dlgConsultaLoja ( var_util, var_exchange );
									
									ev_call.header = header;
									
									ev_call.i_Form.Show();
								}
							}
							
							break;
						}
							
						default: break;
					}				
					
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
