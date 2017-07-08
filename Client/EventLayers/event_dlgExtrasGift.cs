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
	public class event_dlgExtrasGift : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_BuscaDados = 5;
		public const int event_Remover = 6;
		public const int event_Adicionar = 7;
		public const int event_val_TxtNome = 8;
		public const int event_val_TxtValor = 9;
		public const int event_Selecionar = 10;
		public const int event_val_TxtEmpresa = 11;
		public const int event_LstProdClick = 12;
		public const int event_BtnRemoverClick = 13;
		public const int event_BtnAdicionarClick = 14;
		#endregion

		public dlgExtrasGift i_Form;

		//UserVariables
		
		public CNetHeader header;
				
		numberTextController 	ctrl_TxtEmpresa = new numberTextController();
		alphaTextController 	ctrl_TxtNome 	= new alphaTextController();
		moneyTextController 	ctrl_TxtValor 	= new moneyTextController();
		
		Color colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgExtrasGift ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgExtrasGift ( this );
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
					
					ctrl_TxtValor.AcquireTextBox 	( i_Form.TxtValor, this, event_val_TxtValor,  	"R$", 8 								);
					ctrl_TxtNome.AcquireTextBox 	( i_Form.TxtNome,  this, event_val_TxtNome, 	40, alphaTextController.ENABLE_NUMBERS, alphaTextController.ENABLE_SYMBOLS 	);
					
					ctrl_TxtEmpresa.AcquireTextBox  ( i_Form.TxtEmpresa, this, event_val_TxtEmpresa,  6 );
					
					if ( header.get_tg_user_type() == TipoUsuario.AdminGift )
					{
						ctrl_TxtEmpresa.SetTextBoxText ( header.get_st_empresa() );
						i_Form.TxtEmpresa.ReadOnly = true;
						
						doEvent ( event_BuscaDados, null );
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
				
				#region - event_BuscaDados -
				
				case event_BuscaDados:
				{
					//InitEventCode event_BuscaDados
					
					ArrayList lst = new ArrayList();
					
					if ( header.get_tg_user_type() == TipoUsuario.SuperUser )
						header.set_st_empresa ( ctrl_TxtEmpresa.getTextBoxValue() );
					
					var_exchange.fetch_extraGift ( ref header, ref lst );
					
					if ( header.get_tg_user_type() == TipoUsuario.SuperUser )
						header.set_st_empresa ( "000000" );
					
					i_Form.LstProd.Items.Clear();
					for (int t=0; t  < lst.Count ; ++t )
					{
						DadosProdutoGift dpg = new DadosProdutoGift ( lst[t] as DataPortable );
						
						string [] full_row = new string [] { dpg.get_st_nome(), "R$ " + new money().formatToMoney ( dpg.get_vr_valor() ) };
							
						i_Form.LstProd.Items.Add ( var_util.GetListViewItem ( dpg.get_id_produto(), full_row ) );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Remover -
				
				case event_Remover:
				{
					//InitEventCode event_Remover
					
					if ( i_Form.LstProd.SelectedItems.Count == 0 )
						return false;
					
					if ( MessageBox.Show (	"Confirma remoção de produto ?",
				                    		"Aviso", 
				                    		MessageBoxButtons.YesNo, 
				                    		MessageBoxIcon.Question, 
				                    		MessageBoxDefaultButton.Button2 ) == DialogResult.No )
					{
						return false;
					}
					
					var_exchange.del_extraGift ( var_util.getSelectedListViewItemTag ( i_Form.LstProd ), ref header );
						
					doEvent ( event_BuscaDados, null );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Adicionar -
				
				case event_Adicionar:
				{
					//InitEventCode event_Adicionar
					
					if ( !ctrl_TxtValor.IsUserValidated && !ctrl_TxtNome.IsUserValidated )
						return false;
					
					DadosProdutoGift prod = new DadosProdutoGift();
					
					prod.set_st_nome  ( ctrl_TxtNome.getTextBoxValue() 				);
					prod.set_vr_valor ( ctrl_TxtValor.getTextBoxValue_NumberStr() 	);
					
					var_exchange.ins_extraGift ( ref prod, ref header );
					
					doEvent ( event_BuscaDados, null );
					
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
							if ( ctrl_TxtNome.getTextBoxValue().Length > 3 )
							{
								i_Form.TxtNome.BackColor = Color.White;
								ctrl_TxtNome.IsUserValidated = true;
								ctrl_TxtNome.CleanError();
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
				
				#region - event_val_TxtValor -
				
				case event_val_TxtValor:
				{
					//InitEventCode event_val_TxtValor
					
					if ( ctrl_TxtValor.getTextBoxValue_Long() == 0 )
					{
						i_Form.TxtValor.BackColor = colorInvalid;
						ctrl_TxtValor.IsUserValidated = false;
					}
					else
					{
						i_Form.TxtValor.BackColor = Color.White;
						ctrl_TxtValor.IsUserValidated = true;
						ctrl_TxtValor.CleanError();
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Selecionar -
				
				case event_Selecionar:
				{
					//InitEventCode event_Selecionar
					
					if ( i_Form.LstProd.SelectedItems.Count == 0 )
						return false;
					
					ctrl_TxtNome.SetTextBoxText 	( i_Form.LstProd.SelectedItems[0].SubItems[0].Text );
					ctrl_TxtValor.SetTextBoxLong 	( new money().getNumericValue ( i_Form.LstProd.SelectedItems[0].SubItems[1].Text.Replace ( "R$ ","" ) ) );
				
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
							if ( i_Form.TxtEmpresa.Text.Length > 0 )
							{
								i_Form.TxtEmpresa.BackColor     = Color.White;
								ctrl_TxtEmpresa.IsUserValidated = true;
								ctrl_TxtEmpresa.CleanError();
								
								if ( ctrl_TxtEmpresa.GetEnterPressed() )
								{
									doEvent ( event_BuscaDados, null );
								}
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
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_LstProdClick -
				
				case event_LstProdClick:
				{
					//InitEventCode event_LstProdClick
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
				
				#region - event_BtnAdicionarClick -
				
				case event_BtnAdicionarClick:
				{
					//InitEventCode event_BtnAdicionarClick
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
