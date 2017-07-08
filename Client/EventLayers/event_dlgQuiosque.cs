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
	public class event_dlgQuiosque : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Remover = 5;
		public const int event_Adicionar = 6;
		public const int event_Liberar = 7;
		public const int event_Vincular = 8;
		public const int event_BuscaVendedores = 9;
		public const int event_val_TxtNovo = 10;
		public const int event_val_TxtEmpresa = 11;
		public const int event_Quiosque = 12;
		public const int event_LstQSelectedIndexChanged = 13;
		public const int event_BtnRemoverClick = 14;
		public const int event_BtnAdicionarClick = 15;
		public const int event_BtnLiberarClick = 16;
		public const int event_BtnVincularClick = 17;
		#endregion

		public dlgQuiosque i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController 	ctrl_TxtEmpresa	= new numberTextController();
		alphaTextController		ctrl_TxtNovo	= new alphaTextController();
		
		Color colorInvalid = Color.Lavender;
		
		ArrayList lstVinc = new ArrayList();
		ArrayList lstOutros = new ArrayList();		
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgQuiosque ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgQuiosque ( this );
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
					
					ctrl_TxtEmpresa.AcquireTextBox 	( i_Form.TxtEmpresa, 	this, event_val_TxtEmpresa, 	6  );
					ctrl_TxtNovo.AcquireTextBox 	( i_Form.TxtNovo, 		this, event_val_TxtNovo, 		20, alphaTextController.ENABLE_NUMBERS, alphaTextController.ENABLE_SYMBOLS	);
					
					if ( header.get_tg_user_type() == TipoUsuario.AdminGift )
					{
						ctrl_TxtEmpresa.SetTextBoxText ( header.get_st_empresa() );
						
						doEvent ( event_BuscaVendedores, null );
						
						i_Form.TxtEmpresa.ReadOnly = true;
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
				
				#region - event_Remover -
				
				case event_Remover:
				{
					//InitEventCode event_Remover
					
					if ( i_Form.TxtNomeEmp.Text.Length == 0 )
					{
						MessageBox.Show ( "Escolha uma empresa destino" , "Aviso" );
						return false;
					}
					
					if ( i_Form.LstQ.SelectedItems.Count == 0 )
						return false;
					
					var_exchange.del_quiosque ( ctrl_TxtEmpresa.getTextBoxValue(),
					                            i_Form.LstQ.SelectedItem.ToString(),
					                            ref header );
					
					ArrayList lstQ = new ArrayList();
										
					if ( var_exchange.fetch_quiosque ( ctrl_TxtEmpresa.getTextBoxValue(),
					                                  	ref header,
					                                  	ref lstQ ) )
					{
						i_Form.LstQ.Items.Clear();
						i_Form.LstTodos.Items.Clear();
						i_Form.LstVend.Items.Clear();
						
						for ( int t=0; t < lstQ.Count; ++t )
						{
							DadosQuiosque dq = new DadosQuiosque ( lstQ[t] as DataPortable );
							
							i_Form.LstQ.Items.Add ( dq.get_st_nome() );
						}
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Adicionar -
				
				case event_Adicionar:
				{
					//InitEventCode event_Adicionar
					
					if ( i_Form.TxtNomeEmp.Text.Length == 0 )
					{
						MessageBox.Show ( "Escolha uma empresa destino" , "Aviso" );
						return false;
					}
					
					var_exchange.ins_quiosque ( ctrl_TxtEmpresa.getTextBoxValue(),
					     						ctrl_TxtNovo.getTextBoxValue(),
					                            ref header );
					
					ArrayList lstQ = new ArrayList();
										
					if ( var_exchange.fetch_quiosque ( ctrl_TxtEmpresa.getTextBoxValue(),
					                                  	ref header,
					                                  	ref lstQ ) )
					{
						i_Form.LstQ.Items.Clear();
						i_Form.LstTodos.Items.Clear();
						i_Form.LstVend.Items.Clear();
						
						for ( int t=0; t < lstQ.Count; ++t )
						{
							DadosQuiosque dq = new DadosQuiosque ( lstQ[t] as DataPortable );
							
							i_Form.LstQ.Items.Add ( dq.get_st_nome() );
						}
					}
					
					doEvent ( event_Quiosque, null );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Liberar -
				
				case event_Liberar:
				{
					//InitEventCode event_Liberar
					
					if ( i_Form.TxtNomeEmp.Text.Length == 0 )
						return false;
					
					if ( i_Form.LstQ.SelectedItems.Count == 0 )
						return false;
					
					if ( i_Form.LstVend.SelectedItems.Count == 0 )
						return false;
					
					string id = "";
					
					for ( int t=0; t < lstVinc.Count; ++t )
					{
						DadosUsuario du = new DadosUsuario ( lstVinc[t] as DataPortable );
						
						if ( du.get_st_nome() == i_Form.LstVend.SelectedItem.ToString() )
							id = du.get_id_usuario();
					}
										
					if ( id == "" )
						return false;
					
					if ( var_exchange.exec_vincQuiosque ( 	i_Form.LstQ.SelectedItem.ToString(),
															ctrl_TxtEmpresa.getTextBoxValue(),
															id,
															Context.FALSE, 
															ref header ) )
					{
						ArrayList lstQ = new ArrayList();
										
						if ( var_exchange.fetch_quiosque ( ctrl_TxtEmpresa.getTextBoxValue(),
						                                  	ref header,
						                                  	ref lstQ ) )
						{
							i_Form.LstQ.Items.Clear();
							for ( int t=0; t < lstQ.Count; ++t )
							{
								DadosQuiosque dq = new DadosQuiosque ( lstQ[t] as DataPortable );
								
								i_Form.LstQ.Items.Add ( dq.get_st_nome() );
							}
						}
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Vincular -
				
				case event_Vincular:
				{
					//InitEventCode event_Vincular
					
					if ( i_Form.TxtNomeEmp.Text.Length == 0 )
						return false;
					
					if ( i_Form.LstQ.SelectedItems.Count == 0 )
						return false;
					
					if ( i_Form.LstTodos.SelectedItems.Count == 0 )
						return false;
					
					string id = "";
					
					for ( int t=0; t < lstOutros.Count; ++t )
					{
						DadosUsuario du = new DadosUsuario ( lstOutros[t] as DataPortable );
						
						if ( du.get_st_nome() == i_Form.LstTodos.SelectedItem.ToString() )
							id = du.get_id_usuario();
					}
										
					if ( id == "" )
						return false;
					
					if ( var_exchange.exec_vincQuiosque ( 	i_Form.LstQ.SelectedItem.ToString(),
															ctrl_TxtEmpresa.getTextBoxValue(),
															id,
															Context.TRUE, 
															ref header ) )
					{
						doEvent ( event_Quiosque, null );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BuscaVendedores -
				
				case event_BuscaVendedores:
				{
					//InitEventCode event_BuscaVendedores
					
					DadosEmpresa de = new DadosEmpresa();
					
					if ( var_exchange.fetch_dadosEmpresa ( 	ctrl_TxtEmpresa.getTextBoxValue(), ref header, ref de ) )
					{
						i_Form.TxtNomeEmp.Text = de.get_st_fantasia();
						
						ArrayList lstQ = new ArrayList();
						
						if ( var_exchange.fetch_quiosque ( ctrl_TxtEmpresa.getTextBoxValue(),
						                                  	ref header,
						                                  	ref lstQ ) )
						{
							i_Form.LstQ.Items.Clear();
							for ( int t=0; t < lstQ.Count; ++t )
							{
								DadosQuiosque dq = new DadosQuiosque ( lstQ[t] as DataPortable );
								
								i_Form.LstQ.Items.Add ( dq.get_st_nome() );
							}
						}
					}
	
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtNovo -
				
				case event_val_TxtNovo:
				{
					//InitEventCode event_val_TxtNovo
					
					if ( ctrl_TxtNovo.getTextBoxValue().Length > 0 )
					{
						i_Form.TxtNovo.BackColor     = Color.White;
						ctrl_TxtNovo.IsUserValidated = true;
						ctrl_TxtNovo.CleanError();
					}
					else
					{
						i_Form.TxtNovo.BackColor     = colorInvalid;
						ctrl_TxtNovo.IsUserValidated = false;
					}
					
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
									doEvent ( event_BuscaVendedores, null );
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
				
				#region - event_Quiosque -
				
				case event_Quiosque:
				{
					//InitEventCode event_Quiosque
					
					if ( i_Form.TxtNomeEmp.Text.Length == 0 )
						return false;
					
					if ( i_Form.LstQ.SelectedItems.Count == 0 )
						return false;
					
					lstVinc.Clear();
					lstOutros.Clear();
									
					if ( var_exchange.fetch_vendedorQuiosque ( 	ctrl_TxtEmpresa.getTextBoxValue(),
					                                          	i_Form.LstQ.SelectedItem.ToString(), 
					                                          	ref header,
					                                          	ref lstVinc,
					                                          	ref lstOutros ) )
					{
						i_Form.LstVend.Items.Clear();
						i_Form.LstTodos.Items.Clear();
						
						for ( int t=0; t < lstVinc.Count; ++t )
						{
							DadosUsuario du = new DadosUsuario ( lstVinc [ t ] as DataPortable );
							
							i_Form.LstVend.Items.Add ( du.get_st_nome() );
						}
						
						for ( int t=0; t < lstOutros.Count; ++t )
						{
							DadosUsuario du = new DadosUsuario ( lstOutros [ t ] as DataPortable );
														
							i_Form.LstTodos.Items.Add ( du.get_st_nome() );
						}
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_LstQSelectedIndexChanged -
				
				case event_LstQSelectedIndexChanged:
				{
					//InitEventCode event_LstQSelectedIndexChanged
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
				
				#region - event_BtnLiberarClick -
				
				case event_BtnLiberarClick:
				{
					//InitEventCode event_BtnLiberarClick
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
