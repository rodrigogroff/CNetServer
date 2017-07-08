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
	public class event_dlgConvenios : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_val_TxtEmpresa = 5;
		public const int event_val_TxtFantasia = 6;
		public const int event_Adicionar = 7;
		public const int event_Remover = 8;
		public const int event_Confirmar = 9;
		public const int event_val_TxtTaxa = 10;
		public const int event_val_TxtRepasse = 11;
		public const int event_val_TxtCNPJ = 12;
		public const int event_Convenio = 13;
		public const int event_val_TxtBanco = 14;
		public const int event_val_TxtAg = 15;
		public const int event_val_TxtConta = 16;
		public const int event_val_TxtLoja = 17;
		public const int event_LstConveniosClick = 18;
		public const int event_BtnRemoverClick = 19;
		public const int event_BtnAdicionarClick = 20;
		public const int event_BtnConfirmarClick = 21;
		#endregion

		public dlgConvenios i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		string cnpj = "";

		numberTextController		ctrl_TxtLoja		= new numberTextController();
		numberTextController		ctrl_TxtEmpresa		= new numberTextController();
		alphaTextController			ctrl_TxtFantasia	= new alphaTextController();
		percentTextController		ctrl_TxtTaxa        = new percentTextController();
		numberTextController		ctrl_TxtRepasse		= new numberTextController();
		
		numberTextController		ctrl_TxtBanco		= new numberTextController();
		alphaTextController			ctrl_TxtAg		= new alphaTextController();
		numberTextController		ctrl_TxtConta		= new numberTextController();
		
		Color colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgConvenios ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgConvenios ( this );
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
					
					ctrl_TxtLoja.AcquireTextBox 		( i_Form.TxtLoja,	 		this, event_val_TxtLoja, 		6  	);
					ctrl_TxtEmpresa.AcquireTextBox 		( i_Form.TxtEmpresa,	 	this, event_val_TxtEmpresa, 		6  	);
					ctrl_TxtFantasia.AcquireTextBox 	( i_Form.TxtFantasia,	 	this, event_val_TxtFantasia, 		40, alphaTextController.ENABLE_NUMBERS  );
					ctrl_TxtTaxa.AcquireTextBox 		( i_Form.TxtTaxa, 			this, event_val_TxtTaxa, 			4, 2 );
					ctrl_TxtRepasse.AcquireTextBox 		( i_Form.TxtRepasse,	 	this, event_val_TxtRepasse, 		3  );
					
					ctrl_TxtEmpresa.SetupErrorProvider   	 ( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtRepasse.SetupErrorProvider   	 ( ErrorIconAlignment.MiddleRight, false ); 
					
					ctrl_TxtBanco.AcquireTextBox 		( i_Form.TxtBanco,	 	this, event_val_TxtBanco, 		3  );
					ctrl_TxtAg.AcquireTextBox 			( i_Form.TxtAg,	 		this, event_val_TxtAg, 			5, alphaTextController.ENABLE_NUMBERS  );
					ctrl_TxtConta.AcquireTextBox 		( i_Form.TxtConta,	 	this, event_val_TxtBanco, 	   11  );
					
					ctrl_TxtBanco.SetTextBoxText 	( "0" );
					ctrl_TxtAg.SetTextBoxText 		( "0" );
					ctrl_TxtConta.SetTextBoxText	( "0" );
					ctrl_TxtRepasse.SetTextBoxText 	( "0" );
					
					ctrl_TxtTaxa.IsUserValidated = true;
									
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
								if ( i_Form.TxtEmpresa.Text.Length < 6 )
								{
									i_Form.TxtEmpresa.BackColor     = colorInvalid;	
									ctrl_TxtEmpresa.IsUserValidated = false;
								}
								else
								{
									i_Form.TxtEmpresa.BackColor     = Color.White;	
								}
								
								ctrl_TxtEmpresa.IsUserValidated = true;
								ctrl_TxtEmpresa.CleanError();
								
								if ( ctrl_TxtEmpresa.GetEnterPressed() )
								{
									string st_nome = "";
									string st_empresa = ctrl_TxtEmpresa.getTextBoxValue().PadLeft ( 6, '0' );
									
									if ( var_exchange.fetch_validaEmpresa ( st_empresa,
									                                       	ref header, 
									                                       	ref st_nome ) )
									{
										ctrl_TxtEmpresa.SetTextBoxText  ( st_empresa 	);
										ctrl_TxtFantasia.SetTextBoxText ( st_nome 		);
										
										i_Form.TxtFantasia.BackColor = Color.White;	
										i_Form.TxtEmpresa.BackColor = Color.White;	
										ctrl_TxtFantasia.IsUserValidated = true;
										ctrl_TxtEmpresa.IsUserValidated = true;
									}
									else
									{
										i_Form.TxtEmpresa.BackColor     = colorInvalid;	
										i_Form.TxtFantasia.BackColor 	= colorInvalid;	
										ctrl_TxtFantasia.IsUserValidated 	= false;
										ctrl_TxtEmpresa.IsUserValidated 	= false;
									}
								}
							}
							else
							{
								i_Form.TxtEmpresa.BackColor     = colorInvalid;	
								ctrl_TxtEmpresa.IsUserValidated = false;
								
								if ( ctrl_TxtEmpresa.GetEnterPressed() )
								{
									event_dlgConsultaLoja ev_call = new event_dlgConsultaLoja ( var_util, var_exchange );
										
									ev_call.header = header;
									
									ev_call.i_Form.ShowDialog();
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
				
				#region - event_val_TxtFantasia -
				
				case event_val_TxtFantasia:
				{
					//InitEventCode event_val_TxtFantasia
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtFantasia.getTextBoxValue().Length > 3 )
							{
								ctrl_TxtFantasia.CleanError();
								
								if ( ctrl_TxtFantasia.GetEnterPressed() )
								{
									ArrayList lst = new ArrayList();
									
									if ( var_exchange.fetch_nomeEmpresa ( ctrl_TxtFantasia.getTextBoxValue(),
									                                     	ref header,
									                                     	ref lst ) )
									{
										event_dlgSelecionaEmpresa ev_call = new event_dlgSelecionaEmpresa ( var_util, var_exchange );
					
										ev_call.header = header;
										ev_call.lst    = lst;
															
										ev_call.i_Form.ShowDialog();
										
										if ( ev_call.var_empresa  != "" && ev_call.var_fantasia != "" )
										{
											ctrl_TxtEmpresa.SetTextBoxText 	( ev_call.var_empresa 	);
											ctrl_TxtFantasia.SetTextBoxText ( ev_call.var_fantasia 	);
											
											i_Form.TxtFantasia.BackColor 		= Color.White;	
											i_Form.TxtEmpresa.BackColor 		= Color.White;	
											ctrl_TxtFantasia.IsUserValidated 	= true;
											ctrl_TxtEmpresa.IsUserValidated 	= true;
										}
										else
										{
											ctrl_TxtEmpresa.SetTextBoxText 	( "" );
											ctrl_TxtFantasia.SetTextBoxText ( "" );
											
											i_Form.TxtEmpresa.BackColor     	= colorInvalid;	
											i_Form.TxtFantasia.BackColor 		= colorInvalid;	
											ctrl_TxtFantasia.IsUserValidated 	= false;
											ctrl_TxtEmpresa.IsUserValidated 	= false;
										}
									}
								}
							}
							else
							{
								i_Form.TxtFantasia.BackColor = colorInvalid;	
								ctrl_TxtFantasia.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Adicionar -
				
				case event_Adicionar:
				{
					//InitEventCode event_Adicionar
					
					bool IsDone = true;
					
					if ( !ctrl_TxtEmpresa.IsUserValidated )		{	ctrl_TxtEmpresa.SetErrorMessage 	( "O código da empresa deve ser informado" );	IsDone = false;	}
					if ( !ctrl_TxtRepasse.IsUserValidated )		{	ctrl_TxtRepasse.SetErrorMessage 	( "O número de dias para repasse deve ser informado" );	IsDone = false;	}
					
					if ( !IsDone )
						return false;
					    
					int max = i_Form.LstConvenios.Items.Count;
					
					for ( int t=0; t < max; ++t )
					{
						if ( i_Form.LstConvenios.Items[t].SubItems[0].Text == ctrl_TxtEmpresa.getTextBoxValue() )
						{
							i_Form.LstConvenios.Items[t].SubItems [2].Text = ctrl_TxtTaxa.getTextBoxValue().PadLeft ( 4, '0').Insert ( 2, "," ) + " %";
							i_Form.LstConvenios.Items[t].SubItems [3].Text = ctrl_TxtRepasse.getTextBoxValue();
							i_Form.LstConvenios.Items[t].SubItems [4].Text = i_Form.TxtBanco.Text;
							i_Form.LstConvenios.Items[t].SubItems [5].Text = i_Form.TxtAg.Text;
							i_Form.LstConvenios.Items[t].SubItems [6].Text = i_Form.TxtConta.Text;							
							return false;
						}
					}
					
					string [] full_row = new string [] { 	ctrl_TxtEmpresa.getTextBoxValue(), 
															ctrl_TxtFantasia.getTextBoxValue(),
															ctrl_TxtTaxa.getTextBoxValue().PadLeft ( 4, '0').Insert ( 2, "," ) + " %",
															ctrl_TxtRepasse.getTextBoxValue(),
															ctrl_TxtBanco.getTextBoxValue(),
															ctrl_TxtAg.getTextBoxValue(),
															ctrl_TxtConta.getTextBoxValue() };
								
					string emp = ctrl_TxtEmpresa.getTextBoxValue();
					
					i_Form.LstConvenios.Items.Add ( var_util.GetListViewItem ( emp, full_row ) );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Remover -
				
				case event_Remover:
				{
					//InitEventCode event_Remover
					
					if ( i_Form.LstConvenios.SelectedItems.Count > 0 )
					{
						string emp = i_Form.LstConvenios.SelectedItems[0].Text;
						
						i_Form.LstConvenios.Items.Remove ( i_Form.LstConvenios.SelectedItems[0] );	
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Confirmar -
				
				case event_Confirmar:
				{
					//InitEventCode event_Confirmar
					
					int max = i_Form.LstConvenios.Items.Count;
					
					string st_csv_empresas = "";
					string st_csv_taxas = "";
					string st_csv_dias_repasse = "";
					
					string st_csv_banco_repasse = "";
					string st_csv_ag_repasse = "";
					string st_csv_conta_repasse = "";
					
					for ( int t=0; t < max; ++t )
					{
						string emp = i_Form.LstConvenios.Items[t].SubItems[0].Text;
						
						st_csv_empresas     += emp;
						st_csv_taxas        += i_Form.LstConvenios.Items[t].SubItems[2].Text.Replace ( ",","" ).Replace( " %", "" );
						st_csv_dias_repasse += i_Form.LstConvenios.Items[t].SubItems[3].Text;
						
						st_csv_banco_repasse += i_Form.LstConvenios.Items[t].SubItems[4].Text;
						st_csv_ag_repasse 	 += i_Form.LstConvenios.Items[t].SubItems[5].Text;
						st_csv_conta_repasse += i_Form.LstConvenios.Items[t].SubItems[6].Text;
						
						if ( t < max -1 )
						{
							st_csv_empresas      += ",";
							st_csv_taxas         += ",";
							st_csv_dias_repasse  += ",";
							st_csv_banco_repasse += ",";
							st_csv_ag_repasse 	 += ",";
							st_csv_conta_repasse += ",";
						}
					}
					
					DadosLoja dl = new DadosLoja();
					
					dl.set_nu_CNPJ ( cnpj );
					
					var_exchange.exec_alteraLoja ( st_csv_empresas, 
					                               st_csv_taxas, 
					                               st_csv_dias_repasse, 
					                               st_csv_banco_repasse,
					                               st_csv_ag_repasse,
					                               st_csv_conta_repasse,
					                               ref dl, 
					                               ref header );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtTaxa -
				
				case event_val_TxtTaxa:
				{
					//InitEventCode event_val_TxtTaxa
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtRepasse -
				
				case event_val_TxtRepasse:
				{
					//InitEventCode event_val_TxtRepasse
					
					if ( i_Form.TxtRepasse.Text.Length == 0 )
					{
						i_Form.TxtRepasse.BackColor     = colorInvalid;	
						ctrl_TxtRepasse.IsUserValidated = false;						
					}
					else
					{
						i_Form.TxtRepasse.BackColor     = Color.White;	
						ctrl_TxtRepasse.IsUserValidated = true;
						ctrl_TxtRepasse.CleanError();
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCNPJ -
				
				case event_val_TxtCNPJ:
				{
					//InitEventCode event_val_TxtCNPJ
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Convenio -
				
				case event_Convenio:
				{
					//InitEventCode event_Convenio
					
					if ( i_Form.LstConvenios.SelectedItems.Count == 0 )
						return false;
					
					int index = i_Form.LstConvenios.SelectedIndices[0];
					
					string emp = i_Form.LstConvenios.Items [ index ].SubItems[0].Text;
					string ft  = i_Form.LstConvenios.Items [ index ].SubItems[1].Text;
					string tx  = i_Form.LstConvenios.Items [ index ].SubItems[2].Text;
					string rp  = i_Form.LstConvenios.Items [ index ].SubItems[3].Text;
					string banco = i_Form.LstConvenios.Items [ index ].SubItems[4].Text;
					string ag = i_Form.LstConvenios.Items [ index ].SubItems[5].Text;
					string conta = i_Form.LstConvenios.Items [ index ].SubItems[6].Text;
					
					ctrl_TxtEmpresa.SetTextBoxText 	( emp 	);	i_Form.TxtEmpresa.BackColor     = Color.White;	
					ctrl_TxtFantasia.SetTextBoxText ( ft	);	i_Form.TxtFantasia.BackColor    = Color.White;	
					ctrl_TxtTaxa.SetTextBoxText 	( tx 	);	i_Form.TxtTaxa.BackColor     	= Color.White;	
					ctrl_TxtRepasse.SetTextBoxText 	( rp 	);	i_Form.TxtRepasse.BackColor		= Color.White;	
					
					ctrl_TxtBanco.SetTextBoxText 	( banco.PadLeft ( 1, '0' ) 		);
					ctrl_TxtAg.SetTextBoxText 		( ag.PadLeft ( 1, '0' ) 		);	
					ctrl_TxtConta.SetTextBoxText 	( conta.PadLeft ( 1, '0' ) 		);	
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtBanco -
				
				case event_val_TxtBanco:
				{
					//InitEventCode event_val_TxtBanco
					
					if ( i_Form.TxtBanco.Text.Length == 0 )
					{
						i_Form.TxtBanco.BackColor     = colorInvalid;	
						ctrl_TxtBanco.IsUserValidated = false;						
					}
					else
					{
						i_Form.TxtBanco.BackColor     = Color.White;	
						ctrl_TxtBanco.IsUserValidated = true;
						ctrl_TxtBanco.CleanError();
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtAg -
				
				case event_val_TxtAg:
				{
					//InitEventCode event_val_TxtAg
					
					if ( ctrl_TxtAg.getTextBoxValue().Length == 0 )
					{
						i_Form.TxtAg.BackColor     = colorInvalid;	
						ctrl_TxtAg.IsUserValidated = false;						
					}
					else
					{
						i_Form.TxtAg.BackColor     = Color.White;	
						ctrl_TxtAg.IsUserValidated = true;
						ctrl_TxtAg.CleanError();
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtConta -
				
				case event_val_TxtConta:
				{
					//InitEventCode event_val_TxtConta
					
					if ( ctrl_TxtConta.getTextBoxValue_Long() == 0 )
					{
						i_Form.TxtConta.BackColor     = colorInvalid;	
						ctrl_TxtConta.IsUserValidated = false;						
					}
					else
					{
						i_Form.TxtConta.BackColor     = Color.White;	
						ctrl_TxtConta.IsUserValidated = true;
						ctrl_TxtConta.CleanError();
					}
					
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
							if ( i_Form.TxtLoja.Text.Length > 0 )
							{
								i_Form.TxtLoja.BackColor     = Color.White;	
								ctrl_TxtLoja.IsUserValidated = true;
								ctrl_TxtLoja.CleanError();
						
								if ( ctrl_TxtLoja.GetEnterPressed() )
								{
									ArrayList list =  new ArrayList();
						
									var_exchange.fetch_listaConveniosLoja ( ctrl_TxtLoja.getTextBoxValue(), 
									                                        ref header, 
									                                        ref cnpj,
									                                        ref list );
									
									i_Form.LstConvenios.Items.Clear();
									
									for ( int t=0; t < list.Count; ++t )
									{
										DadosEmpresa de = new DadosEmpresa ( list[t] as DataPortable );
										
										string emp = de.get_st_empresa();
										
										string [] full_row = new string [] { 	emp,
																				de.get_st_fantasia(),
																				de.get_tx_convenio().PadLeft ( 4, '0').Insert ( 2, "," ) + " %",
																				de.get_nu_dias_convenio(),
																				de.get_st_banco(),
																				de.get_st_ag(),
																				de.get_st_conta()	};
													
										i_Form.LstConvenios.Items.Add ( var_util.GetListViewItem ( emp, full_row ) );
									}
								}				
							}
							else
							{
								i_Form.TxtLoja.BackColor     = colorInvalid;	
								ctrl_TxtLoja.IsUserValidated = false;						
							}
							break;
						}
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_LstConveniosClick -
				
				case event_LstConveniosClick:
				{
					//InitEventCode event_LstConveniosClick
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
