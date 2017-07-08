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
	public class event_dlgVendaEmpresarial : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtEmpresa = 6;
		public const int event_val_TxtMatricula = 7;
		public const int event_val_TxtTitularidade = 8;
		public const int event_val_TxtValor = 9;
		public const int event_BuscaDados = 10;
		public const int event_Print = 11;
		public const int event_val_TxtCodAcesso = 12;
		public const int event_BtnConfirmarClick = 13;
		#endregion

		public dlgVendaEmpresarial i_Form;

		//UserVariables

		ArrayList lst_val = new ArrayList();
		
		public CNetHeader header;
		
		numberTextController        ctrl_TxtCodAcesso 	    = new numberTextController();
		numberTextController 		ctrl_TxtEmpresa			= new numberTextController();
		numberTextController 		ctrl_TxtMatricula		= new numberTextController();
		numberTextController 		ctrl_TxtTitularidade	= new numberTextController();
		moneyTextController 		ctrl_TxtValor			= new moneyTextController();
		
		Color colorInvalid = Color.Lavender;
		
		ArrayList lstLojas = new ArrayList();
		
		string nsu_venda = "";
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgVendaEmpresarial ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgVendaEmpresarial ( this );
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
					
					ctrl_TxtEmpresa.AcquireTextBox 		( i_Form.TxtEmpresa, 		this, event_val_TxtEmpresa, 		6  );
					ctrl_TxtMatricula.AcquireTextBox 	( i_Form.TxtMatricula, 		this, event_val_TxtMatricula, 		6  );
					ctrl_TxtTitularidade.AcquireTextBox ( i_Form.TxtTitularidade, 	this, event_val_TxtTitularidade, 	4  );
					ctrl_TxtValor.AcquireTextBox		( i_Form.TxtValor, 			this, event_val_TxtValor,	  		"R$", 9 );
					
					ctrl_TxtCodAcesso.AcquireTextBox ( i_Form.TxtCodAcesso, 	this, event_val_TxtCodAcesso, 	4  );
					
					ctrl_TxtEmpresa.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtMatricula.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtTitularidade.SetupErrorProvider ( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtValor.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false ); 
										
					if ( header.get_tg_user_type() == TipoUsuario.VendedorGift || 
					     header.get_tg_user_type() == TipoUsuario.AdminGift ||
					     header.get_tg_user_type() == TipoUsuario.Operador ||
					     header.get_tg_user_type() == TipoUsuario.Administrador )
					{
						ctrl_TxtEmpresa.SetTextBoxText  ( header.get_st_empresa() );
						i_Form.TxtEmpresa.ReadOnly 		= true ;
					}		
					
					DadosConsultaLoja dcl = new DadosConsultaLoja();
					
					dcl.set_st_empresa ( header.get_st_empresa() );
					
					string st_csv_id = "";
					
					if ( var_exchange.fetch_consultaLojasGift ( header.get_st_empresa(),
					                                 			ref header,
					                                 			ref st_csv_id ) )
					{
						ArrayList tmp_memory = new ArrayList();
						
						while ( st_csv_id != "" )
						{
							if ( var_exchange.fetch_memory ( st_csv_id, "120", ref st_csv_id, ref tmp_memory ) )
							{
								for ( int t=0; t < tmp_memory.Count; ++t )
									lstLojas.Add ( tmp_memory[t] );
							}
						}
						
						for ( int t=0; t < lstLojas.Count; ++t )
						{
							DadosLoja dl = new DadosLoja ( lstLojas[t] as DataPortable );
							
							i_Form.LstLojas.Items.Add ( dl.get_st_nome() );
						}
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
				
				#region - event_Confirmar -
				
				case event_Confirmar:
				{
					//InitEventCode event_Confirmar
					
					bool IsDone = true;
					
					if ( !ctrl_TxtEmpresa.IsUserValidated )			{	ctrl_TxtEmpresa.SetErrorMessage 		( "O código da empresa deve ser informado" 		);	IsDone = false;	}
					if ( !ctrl_TxtMatricula.IsUserValidated )		{	ctrl_TxtMatricula.SetErrorMessage 		( "O código da matricula deve ser informado" 	);	IsDone = false;	}
					if ( !ctrl_TxtTitularidade.IsUserValidated )	{	ctrl_TxtTitularidade.SetErrorMessage 	( "A titularidade do cartão deve ser informada" );	IsDone = false;	}
					if ( !ctrl_TxtValor.IsUserValidated )			{	ctrl_TxtValor.SetErrorMessage	 		( "O valor da venda deve ser informado" 		);	IsDone = false;	}
					if ( !ctrl_TxtCodAcesso.IsUserValidated )			{	ctrl_TxtValor.SetErrorMessage	 	( "O código de acesso deve ser informado" 		);	IsDone = false;	}
		
					if ( i_Form.LstLojas.SelectedIndex == -1 )
					{
						MessageBox.Show ( "Selecione a loja" );
						return false;
					}
					
					if ( !IsDone )
						return false;
					
					if ( MessageBox.Show (	"Confirma venda no valor de R$ " + 
					                      	ctrl_TxtValor.getTextBoxValue() + 
					                      	" para " + 
					                      	i_Form.LstLojas.SelectedItem.ToString() + 
					                      	" ?",
				                    		"Aviso", 
				                    		MessageBoxButtons.YesNo, 
				                    		MessageBoxIcon.Question, 
				                    		MessageBoxDefaultButton.Button2 ) == DialogResult.No )
					{
						return false;
					}
					
					string cript_senha = new ApplicationUtil().DESCript ( "9999".PadLeft ( 8, '*' ), "12345678" );
					
					DadosLoja dl = new DadosLoja ( lstLojas [ i_Form.LstLojas.SelectedIndex ] as DataPortable );
					
					POS_Entrada  pe = new POS_Entrada();
			
					pe.set_st_senha    		( cript_senha 													);
		            pe.set_st_empresa   	( ctrl_TxtEmpresa.getTextBoxValue().PadLeft 	 ( 6, '0' ) 	);
		            pe.set_st_matricula 	( ctrl_TxtMatricula.getTextBoxValue().PadLeft 	 ( 6, '0' ) 	);
		            pe.set_st_titularidade 	( "01" 															);
					pe.set_vr_valor			( ctrl_TxtValor.getTextBoxValue_NumberStr().PadLeft ( 12, '0' ) );
					pe.set_st_terminal		( dl.get_st_obs() 												);
					pe.set_nu_parcelas		( "1" 															);
					pe.set_st_valores		( ctrl_TxtValor.getTextBoxValue_NumberStr().PadLeft ( 12, '0' ) );
		            
		            POS_Resposta resp = new POS_Resposta();
		            
		            string msg  = "";
		            
		            var_exchange.m_Client.QuietMode = true;
		            
		            
		            string codAc = var_util.calculaCodigoAcesso ( ctrl_TxtEmpresa.getTextBoxValue().PadLeft 	 ( 6, '0' ),
						                                           ctrl_TxtMatricula.getTextBoxValue().PadLeft 	 ( 6, '0' ),
						                                           ctrl_TxtTitularidade.getTextBoxValue() );
		            
		            if ( codAc != ctrl_TxtCodAcesso.getTextBoxValue() )
		            {
		            	MessageBox.Show ( "Cartão inválido", "Aviso" );
		            	return false;
		            }
		            
		            if ( var_exchange.exec_pos_vendaEmpresarial ( ref pe, 
		                                                          ref msg, 
		                                                          ref resp ) )
		            {
			            nsu_venda = resp.get_st_nsuRcb();
			            
			            if ( var_exchange.exec_pos_confirmaVendaEmpresarial ( nsu_venda, 
			                                                                  ref pe, 
			                                                                  ref msg, 
			                                                                  ref resp ) )
			            {
			            	var_exchange.m_Client.QuietMode = false;
			            	
			            	MessageBox.Show ( "NSU: " + nsu_venda, "Transação confirmada" );	
			            	
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
			            }
			            else
			            {
			            	MessageBox.Show ( msg, "Erro na transação" );	
			            }
		            }
		            else
		            {
		            	MessageBox.Show ( msg, "Erro na transação" );
		            }
		            
		            var_exchange.m_Client.QuietMode = false;
					
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
					
					if ( ctrl_TxtEmpresa.GetEnterPressed() )
					{
						doEvent ( event_BuscaDados, null );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtMatricula -
				
				case event_val_TxtMatricula:
				{
					//InitEventCode event_val_TxtMatricula
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtMatricula.Text.Length > 0 )
							{
								i_Form.TxtMatricula.BackColor     = Color.White;	
								ctrl_TxtMatricula.IsUserValidated = true;
								ctrl_TxtMatricula.CleanError();
							}
							else
							{
								i_Form.TxtMatricula.BackColor     = colorInvalid;	
								ctrl_TxtMatricula.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					if ( ctrl_TxtMatricula.GetEnterPressed() )
					{
						doEvent ( event_BuscaDados, null );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtTitularidade -
				
				case event_val_TxtTitularidade:
				{
					//InitEventCode event_val_TxtTitularidade
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtTitularidade.Text.Length == 4 )
							{
								i_Form.TxtTitularidade.BackColor     = Color.White;	
								ctrl_TxtTitularidade.IsUserValidated = true;
								ctrl_TxtTitularidade.CleanError();
							}
							else
							{
								i_Form.TxtTitularidade.BackColor     = colorInvalid;	
								ctrl_TxtTitularidade.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					if ( ctrl_TxtTitularidade.GetEnterPressed() )
					{
						doEvent ( event_BuscaDados, null );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtValor -
				
				case event_val_TxtValor:
				{
					//InitEventCode event_val_TxtValor
					
					if ( arg as string == moneyTextController.MONEY_ZERO )
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
				
				#region - event_BuscaDados -
				
				case event_BuscaDados:
				{
					//InitEventCode event_BuscaDados
					
					string st_nu_maxParcelas = "";
					string st_vr_dispMes     = "";
					string st_vr_dispTotal   = "";
					string st_nome			 = "";
					
					if ( var_exchange.fetch_dadosCartao ( 	ctrl_TxtEmpresa.getTextBoxValue(),
					                                     	ctrl_TxtMatricula.getTextBoxValue(),
					                                     	"01",
					                                     	ref header,
					                                     	ref st_nu_maxParcelas,
					                                     	ref st_vr_dispMes,
					                                     	ref st_vr_dispTotal,
					                                     	ref st_nome ) )
                 	{
 						i_Form.TxtVrDispTotal.Text = new money().formatToMoney ( st_vr_dispTotal );
                     	i_Form.TxtNome.Text        = st_nome;
					}
					else
					{
 						i_Form.TxtVrDispTotal.Text = "";
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Print -
				
				case event_Print:
				{
					//InitEventCode event_Print
					
					ArrayList lst = new ArrayList();
					
					var_exchange.fetch_reciboVendaGift ( nsu_venda, ref header, ref lst );
					
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
				
				#region - event_val_TxtCodAcesso -
				
				case event_val_TxtCodAcesso:
				{
					//InitEventCode event_val_TxtCodAcesso
					
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtCodAcesso.Text.Length == 4 )
							{
								i_Form.TxtCodAcesso.BackColor     = Color.White;	
								ctrl_TxtCodAcesso.IsUserValidated = true;
								ctrl_TxtCodAcesso.CleanError();
							}
							else
							{
								i_Form.TxtCodAcesso.BackColor     = colorInvalid;	
								ctrl_TxtCodAcesso.IsUserValidated = false;
							}
							
							break;
						}
							
						default: break;
					}
					
					if ( ctrl_TxtCodAcesso.GetEnterPressed() )
					{
						doEvent ( event_BuscaDados, null );
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
