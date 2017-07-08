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
	public class event_dlgConfGiftCard : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtCarga = 6;
		public const int event_CalcTotal = 7;
		public const int event_FormIsClosing = 8;
		public const int event_val_TxtCodAcesso = 9;
		public const int event_BtnConfirmarClick = 10;
		public const int event_LstProdItemChecked = 11;
		public const int event_DlgConfGiftCardFormClosing = 12;
		#endregion

		public dlgConfGiftCard i_Form;

		//UserVariables
		
		public CNetHeader 			header;
		
		public DadosProprietario 	dp;
		public DadosCartao 			dc;
		public DadosAdicionais 		da;
		
		public long total = 0;
		
		moneyTextController 	ctrl_TxtCarga = new moneyTextController();
		numberTextController 	ctrl_TxtCodAcesso = new numberTextController();
		
		public bool recarga = false;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgConfGiftCard ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgConfGiftCard ( this );
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
					
					ctrl_TxtCodAcesso.AcquireTextBox 	( i_Form.TxtCodAcesso, this, event_val_TxtCodAcesso, 4 );
					ctrl_TxtCarga.AcquireTextBox 		( i_Form.TxtCarga, this, event_val_TxtCarga, "R$", 6 );
					
					i_Form.LstDados.Items.Add ( "-Nome " 				);
					i_Form.LstDados.Items.Add ( dp.get_st_nome() 		);
					i_Form.LstDados.Items.Add ( "-Cpf "   				);
					i_Form.LstDados.Items.Add ( dp.get_st_cpf() 		);
					i_Form.LstDados.Items.Add ( "-Telefone "  			);
					i_Form.LstDados.Items.Add ( dp.get_st_telefone() 	);
					i_Form.LstDados.Items.Add ( "-Endereço " 			);
					i_Form.LstDados.Items.Add ( dp.get_st_endereco() 	);
										
					ArrayList lst = new ArrayList();
					
					var_exchange.fetch_extraGift ( ref header, ref lst );
					
					i_Form.LstProd.Items.Clear();
					for (int t=0; t  < lst.Count ; ++t )
					{
						DadosProdutoGift dpg = new DadosProdutoGift ( lst[t] as DataPortable );
						
						string [] full_row = new string [] { dpg.get_st_nome(), "R$ " + new money().formatToMoney ( dpg.get_vr_valor() ) };
							
						i_Form.LstProd.Items.Add ( var_util.GetListViewItem ( dpg.get_id_produto(), full_row ) );
						
						if ( recarga )
						{
							if ( t == 1 )
								i_Form.LstProd.Items[t].Checked = true;
						}
						else
						{
							if ( t == 0 )
								i_Form.LstProd.Items[t].Checked = true;
						}
					}
					
					if ( recarga )
					{
						i_Form.Text = "Confirmação para recarga de cartão Gift";
					}
					
					doEvent ( event_CalcTotal, null );
					
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
					
					if ( ctrl_TxtCarga.getTextBoxValue_Long() == 0 )
					{
						MessageBox.Show ( "Informe o valor de carga", "Aviso" );
						return false;
					}
					
					string tg_recarga = Context.FALSE;
					
					if ( recarga )
						tg_recarga = Context.TRUE;
					
					if ( !var_exchange.exec_validGift ( ctrl_TxtCodAcesso.getTextBoxValue(),
						                             	dc.get_st_empresa(),
						                             	dc.get_st_matricula(),
						                             	tg_recarga,
						                             	ref header	) )
					{
						return false;
					}
					
					event_dlgFinalGift ev_call = new event_dlgFinalGift ( var_util, var_exchange );
					
					ev_call.header 	= header;
					ev_call.da 		= da;
					ev_call.dp 		= dp;
					ev_call.dc 		= dc;
					ev_call.total 	= total;
					ev_call.carga   = ctrl_TxtCarga.getTextBoxValue_Long();
					ev_call.recarga = recarga;
					
					for ( int t=0; t < i_Form.LstProd.Items.Count; ++t )
					{
						if ( i_Form.LstProd.Items[t].Checked == true )
						{
							ev_call.lstProdsNome.Add ( i_Form.LstProd.Items[t].SubItems[0].Text );
							ev_call.lstProdsValor.Add ( new money().getNumericValue ( i_Form.LstProd.Items[t].SubItems[1].Text.Replace ( "R$","" ) ).ToString() );
						}
					}
					
					ev_call.i_Form.ShowDialog();
					
					i_Form.IsTerm = ev_call.IsTerm;
					i_Form.Close();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCarga -
				
				case event_val_TxtCarga:
				{
					//InitEventCode event_val_TxtCarga
					
					doEvent ( event_CalcTotal, null );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_CalcTotal -
				
				case event_CalcTotal:
				{
					//InitEventCode event_CalcTotal
					
					total = ctrl_TxtCarga.getTextBoxValue_Long();
					
					for ( int t=0; t < i_Form.LstProd.Items.Count; ++t )
					{
						if ( recarga )
						{
							if ( t == 1 )
							{
								if ( i_Form.LstProd.Items[t].Checked == false )
								{
									i_Form.LstProd.Items[t].Checked = true;
									return false;
								}
							}
						}
						else
						{
							if ( t == 0 )
							{
								if ( i_Form.LstProd.Items[t].Checked == false )
								{
									i_Form.LstProd.Items[t].Checked = true;
									return false;
								}
							}
						}
						
						if ( i_Form.LstProd.Items[t].Checked == true )
						{
							total += new money().getNumericValue ( i_Form.LstProd.Items[t].SubItems[1].Text.Replace ( "R$","" ) );
						}						
					}
					
					i_Form.LblTotal.Text = "Total: R$ " + new money().formatToMoney ( total.ToString() );
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_FormIsClosing -
				
				case event_FormIsClosing:
				{
					//InitEventCode event_FormIsClosing
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCodAcesso -
				
				case event_val_TxtCodAcesso:
				{
					//InitEventCode event_val_TxtCodAcesso
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
				
				#region - event_LstProdItemChecked -
				
				case event_LstProdItemChecked:
				{
					//InitEventCode event_LstProdItemChecked
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_DlgConfGiftCardFormClosing -
				
				case event_DlgConfGiftCardFormClosing:
				{
					//InitEventCode event_DlgConfGiftCardFormClosing
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
