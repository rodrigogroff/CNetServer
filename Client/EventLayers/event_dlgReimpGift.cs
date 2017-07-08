using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using SyCrafEngine;

//UserIncludes

using System.Drawing.Printing;

//UserIncludes END

namespace Client
{
	public class event_dlgReimpGift : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_val_TxtEmpresa = 5;
		public const int event_val_TxtCartao = 6;
		public const int event_Confirmar = 7;
		public const int event_BuscaDados = 8;
		public const int event_Print = 9;
		public const int event_BtnConfirmarClick = 10;
		#endregion

		public dlgReimpGift i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController 	ctrl_TxtEmpresa		= new numberTextController();
		numberTextController 	ctrl_TxtCartao  	= new numberTextController();
				
		Color 	colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgReimpGift ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgReimpGift ( this );
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
					
					ctrl_TxtEmpresa.AcquireTextBox 		( i_Form.TxtEmpresa, 	this, event_val_TxtEmpresa, 6 );
					ctrl_TxtCartao.AcquireTextBox 	( i_Form.TxtCartao, 	this, event_val_TxtCartao, 6 );
					
					if ( header.get_tg_user_type() == TipoUsuario.VendedorGift || 
					    header.get_tg_user_type() == TipoUsuario.AdminGift ||
					     header.get_tg_user_type() == TipoUsuario.Operador ||
					     header.get_tg_user_type() == TipoUsuario.Administrador )
					{
						ctrl_TxtEmpresa.SetTextBoxText  ( header.get_st_empresa() );
						i_Form.TxtEmpresa.ReadOnly 		= true ;
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
				
				#region - event_val_TxtCartao -
				
				case event_val_TxtCartao:
				{
					//InitEventCode event_val_TxtCartao
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtCartao.Text.Length > 0 )
							{
								i_Form.TxtCartao.BackColor     = Color.White;	
								ctrl_TxtCartao.IsUserValidated = true;
								ctrl_TxtCartao.CleanError();
								
								if ( ctrl_TxtCartao.GetEnterPressed() )
								{
									doEvent ( event_BuscaDados, null );
								}
							}
							else
							{
								i_Form.TxtCartao.BackColor     = colorInvalid;	
								ctrl_TxtCartao.IsUserValidated = false;
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
					
					PrintDocument 		pd      = new PrintDocument();
		            PrintDialog 		pDialog = new PrintDialog();
		            
		            pDialog.Document = pd;
		            
		            PrintPreviewDialog prevDialog = new PrintPreviewDialog();
		            prevDialog.Document = pd;
		            
		            pd.PrintPage += new PrintPageEventHandler ( i_Form.Inven_Report );
		            prevDialog.ShowDialog();
		
		            if (pDialog.ShowDialog() == DialogResult.OK)
		            {
		                pd.Print();
		            }
		            					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BuscaDados -
				
				case event_BuscaDados:
				{
					//InitEventCode event_BuscaDados
					
					if ( !ctrl_TxtEmpresa.IsUserValidated  && 
					    !ctrl_TxtCartao.IsUserValidated )
					{
						return false;
					}
					
					ArrayList lstCred = new ArrayList();
					ArrayList lstProd = new ArrayList();
					ArrayList lstComprov = new ArrayList();
					
					string nome = "";
					string disp = "";
					string sit  = "";
					
					if ( !var_exchange.fetch_consultaCartaoGift ( 	ctrl_TxtEmpresa.getTextBoxValue(),
							                                       	ctrl_TxtCartao.getTextBoxValue(),
							                                       	ref header,
							                                       	ref nome,
							                                       	ref disp,
							                                       	ref sit,
							                                       	ref lstCred,
							                                       	ref lstProd,
							                                        ref lstComprov ) )
					{
						return false;
					}
					
					i_Form.TxtNome.Text  = nome;
					i_Form.TxtSaldo.Text = new money().formatToMoney ( disp );
					i_Form.TxtSit.Text   = sit;
					
					for ( int t=0; t < lstComprov.Count; ++t )
					{
						DadosComprovGift dcg = new DadosComprovGift ( lstComprov[t] as DataPortable );
						
						string [] full_row = new string [] { dcg.get_dt_venda(), 
															 "R$ " + new money().formatToMoney ( dcg.get_vr_valor() ),
															 dcg.get_st_tipo() };
						
						i_Form.LstComprov.Items.Add ( var_util.GetListViewItem ( dcg.get_id_venda(), full_row ) );
					}
					
					if ( i_Form.LstComprov.Items.Count > 0 )
						i_Form.LstComprov.Items[0].Selected = true;
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Print -
				
				case event_Print:
				{
					//InitEventCode event_Print
					
					ArrayList lst = new ArrayList();
					
					string id_gift = var_util.getSelectedListViewItemTag ( i_Form.LstComprov );
					
					if ( id_gift == "" )
						return false;
					
					var_exchange.fetch_comprov_Gift ( id_gift, Context.TRUE, ref header, ref lst );
										
					PrintPageEventArgs e = arg as PrintPageEventArgs;
										
					Graphics g = e.Graphics;
		            int n = 0;
		            Font myFont = new Font("Courier New", 10);
		            
		            try
			        {
			            for (int t=0; t < lst.Count; ++t )
			            {
			            	DataPortable port = lst[t] as DataPortable;
			            	
				            g.DrawString ( port.getValue ( "linha" ), myFont, Brushes.Black, 10, 10 + (n * 20)); ++n;
			            }
		            	
			            myFont.Dispose();
		           	}
		            catch (Exception ex)
		            {
		                MessageBox.Show(ex.Message.ToString());
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
