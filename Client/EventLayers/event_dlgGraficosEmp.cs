using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using SyCrafEngine;

//UserIncludes

using ZedGraph;

//UserIncludes END

namespace Client
{
	public class event_dlgGraficosEmp : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_GeraGrafico = 5;
		public const int event_Adicionar = 6;
		public const int event_val_TxtDtIni = 7;
		public const int event_val_TxtDtFim = 8;
		public const int event_val_TxtCodLoja = 9;
		public const int event_val_TxtEmpresa = 10;
		public const int event_Remover = 11;
		public const int event_BuscaListaLojasTransacao = 12;
		public const int event_GeraGraficoTransacao = 13;
		public const int event_Ranking = 14;
		public const int event_BtnRemoverClick = 15;
		public const int event_BtnGraficoClick = 16;
		public const int event_BtnAdicionarClick = 17;
		public const int event_BtnBuscarListaClick = 18;
		public const int event_BtnGeraTransClick = 19;
		public const int event_BtnRankingClick = 20;
		#endregion

		public dlgGraficosEmp i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		dateTextController		ctrl_TxtDtIni   = new dateTextController();
		dateTextController		ctrl_TxtDtFim   = new dateTextController();
		
		numberTextController 	ctrl_TxtEmpresa	= new numberTextController();
		numberTextController 	ctrl_TxtCodLoja	= new numberTextController();
		
		Color 	colorInvalid = Color.Lavender;

		int length_cod_loja = 0;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgGraficosEmp ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgGraficosEmp ( this );
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
					
					ctrl_TxtDtIni.AcquireTextBox 		( i_Form.TxtDtIni,		this, event_val_TxtDtIni, dateTextController.FORMAT_DDMMYYYY );
					ctrl_TxtDtFim.AcquireTextBox 		( i_Form.TxtDtFim,		this, event_val_TxtDtFim, dateTextController.FORMAT_DDMMYYYY );
					ctrl_TxtEmpresa.AcquireTextBox 		( i_Form.TxtEmpresa, 	this, event_val_TxtEmpresa, 	6   );
					ctrl_TxtCodLoja.AcquireTextBox 		( i_Form.TxtCodLoja, 	this, event_val_TxtCodLoja, 	6   );
					
					ctrl_TxtDtFim.SetTextBoxText 	( 	DateTime.Now.Day.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) +
					                                	DateTime.Now.Year.ToString().PadLeft ( 2, '0' ) );
					
					ctrl_TxtDtIni.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false );
					ctrl_TxtDtFim.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtEmpresa.SetupErrorProvider 	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtCodLoja.SetupErrorProvider  ( ErrorIconAlignment.MiddleRight, false ); 
					
					if ( header.get_tg_user_type () ==  TipoUsuario.Administrador || 
					     header.get_tg_user_type () ==  TipoUsuario.AdminGift  )
					{
						ctrl_TxtEmpresa.SetTextBoxText ( header.get_st_empresa() );
						i_Form.TxtEmpresa.ReadOnly = true;
						
						i_Form.tabControl1.TabPages.RemoveAt ( 1 );
						i_Form.tabControl1.TabPages.RemoveAt ( 1 );
					}
					
					i_Form.CboTipo.SelectedIndex  = 0;
					i_Form.CboGraph.SelectedIndex = 0;
					
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
				
				#region - event_GeraGrafico -
				
				case event_GeraGrafico:
				{
					//InitEventCode event_GeraGrafico
					
					if ( i_Form.LstLines.Items.Count == 0 )
						return false;
					
					dlgGraph graph = new dlgGraph();
					
					graph.Text = "Gráficos ConveyNET para desempenho financeiro";
					
					GraphPane myPane = graph.zed.GraphPane;

					myPane.Title.Text          = "Performance financeira comparativa de lojas";
					
					myPane.XAxis.Title.Text    = "Período requerido";
					myPane.XAxis.Type          = AxisType.Date;
					//myPane.XAxis.Scale.Format  = "d";
					
					myPane.YAxis.Title.Text    = "Valores de compras nas lojas";
					myPane.YAxis.Scale.Format  = "c";
					
					myPane.CurveList.Clear();
					
					ArrayList lstInput = new ArrayList();
					
					for ( int t=0; t < i_Form.LstLines.Items.Count; ++t )
					{
						DadosGraficoFinanceiro dgf = new DadosGraficoFinanceiro();
						
						#region - format data - 
						
						dgf.set_st_empresa 	( i_Form.LstLines.Items[t].SubItems[0].Text );
						
						string dt_ini = i_Form.LstLines.Items[t].SubItems[1].Text;
						
						dt_ini = dt_ini.Substring ( 6, 4 ) + "-" + 
							     dt_ini.Substring ( 3, 2 ) + "-" +
							     dt_ini.Substring ( 0, 2 );
						
						string dt_fim = i_Form.LstLines.Items[t].SubItems[2].Text;
						
						dt_fim = dt_fim.Substring ( 6, 4 ) + "-" + 
							     dt_fim.Substring ( 3, 2 ) + "-" +
							     dt_fim.Substring ( 0, 2 );
						
						dgf.set_dt_ini 		( dt_ini );
						dgf.set_dt_fim 		( dt_fim );
						
						string loja = i_Form.LstLines.Items[t].SubItems[3].Text;
						
						if ( loja.StartsWith ( "L" ) )
							dgf.set_st_loja 	( loja.Substring ( 1, loja.IndexOf ( " " ) - 1 ).Trim() );
						
						dgf.set_nu_id 		( t.ToString() 										);
						
						#endregion
						
						lstInput.Add ( dgf );
					}
					
					string st_csv_contents = "";
					
					if ( !var_exchange.graph_financeiro ( i_Form.CboTipo.SelectedIndex.ToString(),
					                                      ref header, 
					                                      ref lstInput, 
					                                      ref st_csv_contents ) )
						return false;
					
					ArrayList full_memory = new ArrayList();
							
					while ( st_csv_contents != "" )
					{
						ArrayList tmp_memory  = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_csv_contents, "200", ref st_csv_contents, ref tmp_memory ) )
							for ( int t=0; t < tmp_memory.Count; ++t )
								full_memory.Add ( tmp_memory[t] );
					}
					
					Color col = Color.Green;
					
					for ( int t=0; t < lstInput.Count; ++t )
					{
						PointPairList list = new PointPairList();
						
						switch (t)
						{
							case 0:	col = Color.Green;	break;
							case 1:	col = Color.Red;	break;
							case 2:	col = Color.Blue;	break;
							case 3:	col = Color.Gray;	break;
							case 4:	col = Color.Orange;	break;
							case 5:	col = Color.Violet;	break;
							
							default: break;
						}
						
						string name_curve = "";
						string my_id      = t.ToString();
												
						for ( int g=0; g < full_memory.Count; ++g )
						{
							DadosGraficoFinanceiro dgf = new DadosGraficoFinanceiro ( full_memory[g] as DataPortable );
							
							if ( dgf.get_nu_id() != my_id )
								continue;
							
							if ( name_curve == "" )
								name_curve = dgf.get_st_loja();
							
							string line = dgf.get_dt_point();
					 
					 		XDate x = new XDate (  	Convert.ToInt32 ( line.Substring ( 0, 4 ) ), // ano
						                      		Convert.ToInt32 ( line.Substring ( 5, 2 ) ), // mes
						                      		Convert.ToInt32 ( line.Substring ( 8, 2 ) ), // dia
											  		Convert.ToInt32 ( line.Substring ( 11, 2 ) ), // hora
											  		Convert.ToInt32 ( line.Substring ( 14, 2 ) ), 
											  		0, 0 ); // minuto
							
							list.Add ( (double) x, Convert.ToDouble ( dgf.get_vr_point() ) / 100 );
						}

						if ( i_Form.CboGraph.SelectedIndex == 0 )
						{
						    myPane.AddBar   ( name_curve, (IPointList) list, col );
						}
						else
						{
							LineItem myCurve = myPane.AddCurve ( name_curve, list, col, SymbolType.None );
							myCurve.Line.Fill = new Fill( Color.White, Color.FromArgb( 60, col.R, col.G, col.B ), 90F );
						}
						
						name_curve = "";
					}
					
					myPane.Chart.Fill = new Fill( Color.White, Color.LightGoldenrodYellow, 45F );
					myPane.Fill       = new Fill( Color.White, Color.FromArgb( 220, 220, 255 ), 45F );
					
					graph.zed.AxisChange();
					
					graph.ShowDialog();						
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Adicionar -
				
				case event_Adicionar:
				{
					//InitEventCode event_Adicionar
					
					if ( !ctrl_TxtDtIni.IsUserValidated )
					{
						MessageBox.Show ( "Informe o período inicial", "Aviso" );
						return false;
					}
					
					if ( !ctrl_TxtDtFim.IsUserValidated )
					{
						MessageBox.Show ( "Informe o período final", "Aviso" );
						return false;
					}
					
					if ( !ctrl_TxtEmpresa.IsUserValidated )
					{
						MessageBox.Show ( "Informe a empresa", "Aviso" );
						return false;
					}
			
					if ( ctrl_TxtCodLoja.IsUserValidated )
					{
						if ( i_Form.TxtNome.Text == "" )
						{
							MessageBox.Show ( "Confirmar a loja pressionando enter no campo de código", "Aviso" );
							return false;
						}
					}
				
					if ( i_Form.LstLines.Items.Count >= 5 )
					{
						MessageBox.Show ( "Máximo de cinco items para gráfico", "Aviso" );
						return false;
					}
					
					string nome = "";
					
					if ( ctrl_TxtCodLoja.IsUserValidated )
					{
						nome = "L" + ctrl_TxtCodLoja.getTextBoxValue() + " - " + i_Form.TxtNome.Text;
					}
					else
					{
						if ( ctrl_TxtEmpresa.getTextBoxValue_Long() == 0 )
							nome = "ConveyNET";	
						else
							nome = "Todas as lojas";
					}
											
					string [] full_row = new string [] { ctrl_TxtEmpresa.getTextBoxValue(),
														 ctrl_TxtDtIni.getTextBoxValue(),
														 ctrl_TxtDtFim.getTextBoxValue(),
														 nome };
					
					i_Form.LstLines.Items.Add ( var_util.GetListViewItem ( null, full_row ) );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDtIni -
				
				case event_val_TxtDtIni:
				{
					//InitEventCode event_val_TxtDtIni
					
					switch ( arg as string )
					{
						case dateTextController.DATE_INVALID:
						{
							i_Form.TxtDtIni.BackColor = colorInvalid;	
							ctrl_TxtDtIni.IsUserValidated = false;
							break;
						}

						case dateTextController.DATE_VALID:
						{
							i_Form.TxtDtIni.BackColor = Color.White;	
							ctrl_TxtDtIni.IsUserValidated = true;
							ctrl_TxtDtIni.CleanError();
							break;
						}
								
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtDtFim -
				
				case event_val_TxtDtFim:
				{
					//InitEventCode event_val_TxtDtFim
					
					switch ( arg as string )
					{
						case dateTextController.DATE_INVALID:
						{
							i_Form.TxtDtFim.BackColor = colorInvalid;	
							ctrl_TxtDtFim.IsUserValidated = false;
							break;
						}

						case dateTextController.DATE_VALID:
						{
							i_Form.TxtDtFim.BackColor = Color.White;	
							ctrl_TxtDtFim.IsUserValidated = true;
							ctrl_TxtDtIni.CleanError();
							break;
						}
								
						default: break;
					}
					
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
							if ( i_Form.TxtCodLoja.Text.Length > 0 )
							{
								i_Form.TxtCodLoja.BackColor     = Color.White;	
								ctrl_TxtCodLoja.IsUserValidated = true;
								ctrl_TxtCodLoja.CleanError();
								
								if ( length_cod_loja > 0 )
								{
									if ( length_cod_loja != i_Form.TxtCodLoja.Text.Length )
									{
										i_Form.TxtNome.Text = "";
									}
								}
								
								length_cod_loja = i_Form.TxtCodLoja.Text.Length;
								
								if ( ctrl_TxtCodLoja.GetEnterPressed() )
								{
									DadosLoja dl = new DadosLoja();
									
									var_exchange.fetch_dadosLoja ( "", ctrl_TxtCodLoja.getTextBoxValue(), ref header, ref dl );
									
									i_Form.TxtNome.Text = dl.get_st_nome();
								}
							}
							else
							{
								i_Form.TxtCodLoja.BackColor     = colorInvalid;	
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
				
				#region - event_Remover -
				
				case event_Remover:
				{
					//InitEventCode event_Remover
					
					if ( i_Form.LstLines.SelectedItems.Count == 0 )
						return false;
					
					i_Form.LstLines.Items.RemoveAt ( i_Form.LstLines.SelectedIndices[0] );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BuscaListaLojasTransacao -
				
				case event_BuscaListaLojasTransacao:
				{
					//InitEventCode event_BuscaListaLojasTransacao
					
					if ( !ctrl_TxtDtIni.IsUserValidated )
					{
						MessageBox.Show ( "Informe a data inicial","Aviso" );
						return false;
					}
					
					if ( !ctrl_TxtDtFim.IsUserValidated )
					{
						MessageBox.Show ( "Informe a data final","Aviso" );
						return false;
					}
					
					i_Form.BtnBuscarLista.Enabled  = false;
					i_Form.LstTransLojas.Items.Clear();
					
					string st_csv_contents = "";
					
					var_exchange.fetch_listaTransacoesLojas (  var_util.GetDataBaseTimeFormat ( ctrl_TxtDtIni.getTextBoxValue_Date() ),
					                                           var_util.GetDataBaseTimeFormat ( ctrl_TxtDtFim.getTextBoxValue_Date() ),
					                                           ref header, 
					                                           ref st_csv_contents );
					
					ArrayList full_memory = new ArrayList();
							
					while ( st_csv_contents != "" )
					{
						ArrayList tmp_memory  = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_csv_contents, "200", ref st_csv_contents, ref tmp_memory ) )
							for ( int t=0; t < tmp_memory.Count; ++t )
								full_memory.Add ( tmp_memory[t] );
					}
					
					for ( int t=0; t < full_memory.Count; ++t )
					{
						DadosConsultaGraficoTransLojas dl = new DadosConsultaGraficoTransLojas ( full_memory[t] as DataPortable );
						
						string [] full_row = new string [] { dl.get_nu_trans(),
															 dl.get_nu_cod(),
															 dl.get_tg_tipo(),
															 dl.get_st_nome() };
					
						i_Form.LstTransLojas.Items.Add ( var_util.GetListViewItem ( null, full_row ) );
					}
					
					i_Form.BtnBuscarLista.Enabled  = true;
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_GeraGraficoTransacao -
				
				case event_GeraGraficoTransacao:
				{
					//InitEventCode event_GeraGraficoTransacao
					
					dlgGraph graph = new dlgGraph();
					
					graph.Text = "Gráficos ConveyNET para quantidade de transações";
					
					GraphPane myPane = graph.zed.GraphPane;

					myPane.Title.Text          = "Performance em transações de associações e lojas";
					
					myPane.XAxis.Title.Text    = "Período requerido";
					myPane.XAxis.Type          = AxisType.Date;
					
					myPane.YAxis.Title.Text    = "Quantidade de transações";
					
					myPane.CurveList.Clear();
					
					ArrayList lstInput = new ArrayList();
					
					for ( int t=0; t < i_Form.LstTransLojas.Items.Count; ++t )
					{
						if ( i_Form.LstTransLojas.Items[t].Checked )
						{
							DadosConsultaGraficoTransLojas dl = new DadosConsultaGraficoTransLojas();
							
							dl.set_nu_cod  ( i_Form.LstTransLojas.Items[t].SubItems[1].Text );
							dl.set_tg_tipo ( i_Form.LstTransLojas.Items[t].SubItems[2].Text );
							dl.set_st_nome ( i_Form.LstTransLojas.Items[t].SubItems[3].Text );
							
							lstInput.Add ( dl );
						}						
					}
					
					string st_csv_contents = "";
					
					if ( !var_exchange.graph_transacoes ( 	var_util.GetDataBaseTimeFormat ( ctrl_TxtDtIni.getTextBoxValue_Date() ),
		                                           			var_util.GetDataBaseTimeFormat ( ctrl_TxtDtFim.getTextBoxValue_Date() ),
		                                           			ref header, 
		                                           			ref lstInput,
		                                           			ref st_csv_contents ) )
					{
						return false;
					}
		                                           								
					ArrayList full_memory = new ArrayList();
							
					while ( st_csv_contents != "" )
					{
						ArrayList tmp_memory  = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_csv_contents, "200", ref st_csv_contents, ref tmp_memory ) )
							for ( int t=0; t < tmp_memory.Count; ++t )
								full_memory.Add ( tmp_memory[t] );
					}
					
					Color col = Color.Green;
					
					for ( int t=0; t < lstInput.Count; ++t )
					{
						DadosConsultaGraficoTransLojas dl = new DadosConsultaGraficoTransLojas( lstInput[t] as DataPortable );
						
						PointPairList list = new PointPairList();
						
						switch (t)
						{
							case 0:	col = Color.Green;	break;
							case 1:	col = Color.Red;	break;
							case 2:	col = Color.Blue;	break;
							case 3:	col = Color.Gray;	break;
							case 4:	col = Color.Orange;	break;
							case 5:	col = Color.Violet;	break;
							
							default: break;
						}
						
						string name_curve = dl.get_st_nome();
						string my_id      = t.ToString();
												
						for ( int g=0; g < full_memory.Count; ++g )
						{
							DadosConsultaGraficoTransLojas dgt = new DadosConsultaGraficoTransLojas ( full_memory[g] as DataPortable );
							
							if ( dgt.get_nu_id() != my_id )
								continue;
							
							string line = dgt.get_dt_trans();
					 
					 		XDate x = new XDate (  	Convert.ToInt32 ( line.Substring ( 0, 4 ) ), // ano
						                      		Convert.ToInt32 ( line.Substring ( 5, 2 ) ), // mes
						                      		Convert.ToInt32 ( line.Substring ( 8, 2 ) ), // dia
											  		Convert.ToInt32 ( line.Substring ( 11, 2 ) ), // hora
											  		Convert.ToInt32 ( line.Substring ( 14, 2 ) ), 
											  		0, 0 ); // minuto
							
							list.Add ( (double) x, Convert.ToDouble ( dgt.get_nu_trans() ) );
						}

						LineItem myCurve = myPane.AddCurve ( name_curve, list, col, SymbolType.None );
					}
					
					myPane.Chart.Fill = new Fill( Color.White, Color.LightGoldenrodYellow, 45F );
					myPane.Fill       = new Fill( Color.White, Color.FromArgb( 220, 220, 255 ), 45F );
					
					graph.zed.AxisChange();
					
					graph.ShowDialog();					
										     
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Ranking -
				
				case event_Ranking:
				{
					//InitEventCode event_Ranking
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
				
				#region - event_BtnGraficoClick -
				
				case event_BtnGraficoClick:
				{
					//InitEventCode event_BtnGraficoClick
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
				
				#region - event_BtnBuscarListaClick -
				
				case event_BtnBuscarListaClick:
				{
					//InitEventCode event_BtnBuscarListaClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnGeraTransClick -
				
				case event_BtnGeraTransClick:
				{
					//InitEventCode event_BtnGeraTransClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnRankingClick -
				
				case event_BtnRankingClick:
				{
					//InitEventCode event_BtnRankingClick
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
