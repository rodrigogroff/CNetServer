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
	public class event_dlgConfirmarRepasse : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_DetalheCheck = 6;
		public const int event_val_TxtDataIni = 7;
		public const int event_SelecionaLoja = 8;
		public const int event_BuscaDados = 9;
		public const int event_LstLojasClick = 10;
		public const int event_BtnConfirmarClick = 11;
		public const int event_ListView1ItemChecked = 12;
		#endregion

		public dlgConfirmarRepasse i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		Color 	colorInvalid = Color.Lavender;
		
		dateTextController		ctrl_TxtDataIni     = new dateTextController();
				
		Hashtable hshLojas = new Hashtable();
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgConfirmarRepasse ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgConfirmarRepasse ( this );
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
					
					ctrl_TxtDataIni.AcquireTextBox 		( i_Form.TxtDataIni,	this, event_val_TxtDataIni, dateTextController.FORMAT_DDMMYYYY );
					
					ctrl_TxtDataIni.SetTextBoxText ( 	DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Year.ToString().PadLeft ( 2, '0' ) );
					
					doEvent ( event_BuscaDados, null );
					
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
					
					if ( i_Form.LstLojas.SelectedItems.Count == 0 )
						return false;
					
					event_dlgConfFinalRepasse ev_call = new event_dlgConfFinalRepasse ( var_util, var_exchange );
					
					ev_call.header  = header;
					
					ev_call.st_codLoja 	= var_util.getSelectedListViewItemTag ( i_Form.LstLojas );
					ev_call.st_loja 	= i_Form.LstLojas.SelectedItems[0].SubItems[0].Text;
					ev_call.vr_valor 	= i_Form.LstLojas.SelectedItems[0].SubItems[1].Text.Replace ( ",", "" );
					ev_call.lstParcelas = hshLojas [ ev_call.st_codLoja ] as ArrayList;					
					
					ev_call.i_Form.ShowDialog();
					
					doEvent ( event_BuscaDados, null );
						
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_DetalheCheck -
				
				case event_DetalheCheck:
				{
					//InitEventCode event_DetalheCheck
					
					if ( i_Form.LstLojas.SelectedItems.Count == 0 )
						return false;
					
					string st_loja = var_util.getSelectedListViewItemTag ( i_Form.LstLojas );
					
					ArrayList lstDets = hshLojas [ st_loja ] as ArrayList;
					
					long tot_detalhes = 0;
					
					for ( int t=0; t < i_Form.LstDetalhes.Items.Count; ++t )
					{
						DadosRepasse dr = lstDets [ t ] as DadosRepasse;
						
						if ( i_Form.LstDetalhes.Items[t].Checked )
						{
							tot_detalhes += Convert.ToInt64 ( dr.get_vr_repasse() );
							
							dr.set_tg_confirmado ( Context.TRUE );
						}
						else
						{
							dr.set_tg_confirmado ( Context.FALSE );
						}						
					}				
					
					i_Form.LstLojas.SelectedItems[0].SubItems[1].Text = new money().formatToMoney ( tot_detalhes.ToString() );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDataIni -
				
				case event_val_TxtDataIni:
				{
					//InitEventCode event_val_TxtDataIni
					
					switch ( arg as string )
					{
						case dateTextController.DATE_INVALID:
						{
							i_Form.TxtDataIni.BackColor = colorInvalid;	
							ctrl_TxtDataIni.IsUserValidated = false;
							break;
						}

						case dateTextController.DATE_VALID:
						{
							i_Form.TxtDataIni.BackColor = Color.White;	
							ctrl_TxtDataIni.IsUserValidated = true;
						
							if ( ctrl_TxtDataIni.GetEnterPressed() )
							{
								doEvent ( event_BuscaDados, null );
							}
							break;
						}
								
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_SelecionaLoja -
				
				case event_SelecionaLoja:
				{
					//InitEventCode event_SelecionaLoja
					
					if ( i_Form.LstLojas.SelectedItems.Count == 0 )
						return false;
					
					string st_loja = var_util.getSelectedListViewItemTag ( i_Form.LstLojas );
					
					ArrayList lstDets = hshLojas [ st_loja ] as ArrayList;
					
					i_Form.LstDetalhes.Items.Clear();
					
					for ( int t=0; t < lstDets.Count; ++t )
					{
						DadosRepasse dr = new DadosRepasse ( lstDets [ t ] as DataPortable );
						
						DateTime tim_repasse = Convert.ToDateTime ( dr.get_dt_repasse() );
						
						string dt_rep = var_util.getDDMMYYYY_format ( dr.get_dt_repasse() ).Substring (0,10);
						
						if ( dt_rep == ctrl_TxtDataIni.getTextBoxValue() )
							dt_rep += " [hoje]";
						else if ( tim_repasse > ctrl_TxtDataIni.getTextBoxValue_Date() )
							dt_rep += " [futuro]";
						
						string [] full_row = new string [] {  new money().formatToMoney ( dr.get_vr_repasse() ),
															  dr.get_st_cartao(),
															  dr.get_st_nsu(),
															  var_util.getDDMMYYYY_format ( dr.get_dt_trans() ),
															  dt_rep };
						
						
						
						if ( dt_rep.IndexOf ( "futuro" ) >= 0 || dt_rep.IndexOf ( "hoje" ) >= 0 )
						{
							i_Form.LstDetalhes.Items.Add ( var_util.GetListViewItem ( dr.get_st_nsu(), 
							                                                          full_row, 
							                                                          Color.Black, 
							                                                          Color.Bisque ) );
						}
						else
						{
							i_Form.LstDetalhes.Items.Add ( var_util.GetListViewItem ( dr.get_st_nsu(), 
							                                                          full_row ) );
						}
						
						i_Form.LstDetalhes.Items[t].Checked = false;
						
						if ( dr.get_tg_confirmado() == Context.TRUE )
							i_Form.LstDetalhes.Items[t].Checked = true;						
					}				
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BuscaDados -
				
				case event_BuscaDados:
				{
					//InitEventCode event_BuscaDados
					
					string block_detalhe_loja = "";
					string block_sumario_loja = "";
					
					i_Form.LstLojas.Items.Clear();
					i_Form.LstDetalhes.Items.Clear();
					
					hshLojas.Clear();
					
					Application.DoEvents();
					
					var_exchange.fetch_repasseData ( 	ctrl_TxtDataIni.getTextBoxValue(), 
					                                	ref header, 
					                                	ref block_detalhe_loja, 
					                                	ref block_sumario_loja  );
					
					while ( block_detalhe_loja != "" )
					{
						ArrayList tmp_memory  = new ArrayList();
						
						if ( var_exchange.fetch_memory ( block_detalhe_loja , "400", ref block_detalhe_loja , ref tmp_memory ) )
						{
							for ( int t=0; t < tmp_memory.Count; ++t )
							{
								DadosRepasse dr = new DadosRepasse ( tmp_memory[t] as DataPortable );
								
								string cod = dr.get_st_loja();
								
								if ( hshLojas [ cod ] == null )	
									hshLojas [ cod ] = new ArrayList();
								
								ArrayList tmp_list = hshLojas [ cod ] as ArrayList;
								
								string dt_rep = var_util.getDDMMYYYY_format ( dr.get_dt_repasse() ).Substring (0,10);
						
								DateTime tim_repasse = Convert.ToDateTime ( dr.get_dt_repasse() );
								
								if ( dt_rep == ctrl_TxtDataIni.getTextBoxValue() )
									dr.set_tg_confirmado ( Context.FALSE );
								else if ( tim_repasse > ctrl_TxtDataIni.getTextBoxValue_Date() )
									dr.set_tg_confirmado ( Context.FALSE );
									
								tmp_list.Add ( dr );
							}
						}
					}	
					
					long vr_repasse = 0;
					
					ArrayList full_memory  = new ArrayList();
					
					while ( block_sumario_loja != "" )
					{
						ArrayList tmp_memory  = new ArrayList();
						
						if ( var_exchange.fetch_memory ( block_sumario_loja , "200", ref block_sumario_loja , ref tmp_memory ) )
						{
							for ( int t=0; t < tmp_memory.Count; ++t )
							{
								full_memory.Add ( tmp_memory[t] );
							}
						}
					}
					
					ArrayList sorted_memory = new ArrayList();
					
					for (int t=0; t < full_memory.Count; ++t )
					{
						DadosSumarioRepasse dsr = new DadosSumarioRepasse ( full_memory[t] as DataPortable );
						
						sorted_memory.Add ( dsr.get_vr_valor().PadLeft ( 20, '0' ) + dsr.get_st_codLoja().PadRight ( 20, ' ' ) );
					}
					
					sorted_memory.Sort();
										
					for (int g=sorted_memory.Count - 1; g >= 0; --g )
					{
						string tag = sorted_memory[g].ToString().Substring ( 20,20 ).Trim();
						
						for (int t=0; t < full_memory.Count; ++t )	
						{
							DadosSumarioRepasse dsr = new DadosSumarioRepasse ( full_memory[t] as DataPortable );
						
							if ( dsr.get_st_codLoja() == tag )
							{
								vr_repasse += Convert.ToInt64 ( dsr.get_vr_valor() );
								
								string [] full_row = new string [] { dsr.get_st_loja(),
																	 new money().formatToMoney ( dsr.get_vr_valor() ) };
							
								i_Form.LstLojas.Items.Add ( var_util.GetListViewItem ( dsr.get_st_codLoja(), full_row ) );
							}
						}
					}
					
					i_Form.TxtRepasse.Text = "R$ " +new money().formatToMoney ( vr_repasse.ToString() );
					
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
				
				#region - event_BtnConfirmarClick -
				
				case event_BtnConfirmarClick:
				{
					//InitEventCode event_BtnConfirmarClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ListView1ItemChecked -
				
				case event_ListView1ItemChecked:
				{
					//InitEventCode event_ListView1ItemChecked
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
