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
	public class event_dlgCotaExtra : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int event_val_TxtNu_Empresa = 3;
		public const int event_val_TxtMoney_Vlr = 4;
		public const int event_BtnAplicClick = 5;
		public const int event_BtnRemoveClick = 6;
		public const int event_BtnConfClick = 7;
		public const int event_buscaDados = 8;
		public const int event_ChkAlfaCheckedChanged = 9;
		#endregion

		public dlgCotaExtra i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController  	   	ctrl_TxtNu_Empresa = new numberTextController();
		moneyTextController  	   	ctrl_TxtMoney_Vlr = new moneyTextController();
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgCotaExtra ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgCotaExtra ( this );
		}
		
		public override bool doEvent ( int event_number, object arg )
		{
			switch ( event_number )
			{
				#region - event_Load -
				
				case event_Load:
				{
					//InitEventCode event_Load
					
					doEvent ( event_Translate, 			null );
					doEvent ( event_FormIsOpening, 		null );
					
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
					ctrl_TxtNu_Empresa.AcquireTextBox 	( i_Form.TxtNu_Empresa, this, event_val_TxtNu_Empresa, 6 );
					ctrl_TxtMoney_Vlr.AcquireTextBox 	( i_Form.TxtMoney_Vlr, this, event_val_TxtMoney_Vlr, "R$", 8 );
					ctrl_TxtNu_Empresa.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtMoney_Vlr.SetupErrorProvider   ( ErrorIconAlignment.MiddleRight, false ); 
					
					if ( header.get_tg_user_type() == TipoUsuario.Administrador )
					{
						ctrl_TxtNu_Empresa.SetTextBoxText ( header.get_st_empresa() );
						i_Form.TxtNu_Empresa.ReadOnly = true;
						
						doEvent ( event_buscaDados, null );
					}				
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtNu_Empresa -
				
				case event_val_TxtNu_Empresa:
				{
					//InitEventCode event_val_TxtNu_Empresa
					switch ( arg as string )
					{
						case numberTextController.NUMBER_INCOMPLETE:
						case numberTextController.NUMBER_COMPLETE:
						{
							if ( i_Form.TxtNu_Empresa.Text.Length > 0 )
							{
								i_Form.TxtNu_Empresa.BackColor = Color.White;
								ctrl_TxtNu_Empresa.IsUserValidated = true;
								ctrl_TxtNu_Empresa.CleanError();
								
								if ( ctrl_TxtNu_Empresa.GetEnterPressed() )
								{
									doEvent ( event_buscaDados, null );
								}
							}
							else
							{
								i_Form.TxtNu_Empresa.BackColor = Color.Lavender;
								ctrl_TxtNu_Empresa.IsUserValidated = false;
								ctrl_TxtNu_Empresa.CleanError();
							}
							
							break;
						}
						
						default: break;
					}
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtMoney_Vlr -
				
				case event_val_TxtMoney_Vlr:
				{
					//InitEventCode event_val_TxtMoney_Vlr
					string myValEv = arg as string;
					
					if ( myValEv == moneyTextController.MONEY_ZERO )
					{
						i_Form.TxtMoney_Vlr.BackColor = Color.Lavender;
						ctrl_TxtMoney_Vlr.IsUserValidated = false;
						ctrl_TxtMoney_Vlr.CleanError();
					}
					else
					{
						i_Form.TxtMoney_Vlr.BackColor = Color.White;
						ctrl_TxtMoney_Vlr.IsUserValidated = true;
						ctrl_TxtMoney_Vlr.CleanError();
					}
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnAplicClick -
				
				case event_BtnAplicClick:
				{
					//InitEventCode event_BtnAplicClick
					
					for (int t=0; t < i_Form.LstCart.Items.Count; ++t )
					{
						i_Form.LstCart.Items[t].SubItems[2].Text = "SIM";
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnRemoveClick -
				
				case event_BtnRemoveClick:
				{
					//InitEventCode event_BtnRemoveClick
					
					if ( i_Form.LstCart.SelectedItems.Count == 0 )
						return false;
					
					i_Form.LstCart.Items[i_Form.LstCart.SelectedIndices[0]].SubItems[2].Text = "NAO";
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnConfClick -
				
				case event_BtnConfClick:
				{
					//InitEventCode event_BtnConfClick
					
					string csv_block = "";
					
					for (int t=0; t < i_Form.LstCart.Items.Count; ++t )
						if ( i_Form.LstCart.Items[t].SubItems[2].Text == "NAO" )
							csv_block += i_Form.LstCart.Items[t].SubItems[0].Text;
					
					var_exchange.exec_cotaExtraEmpresa ( ctrl_TxtNu_Empresa.getTextBoxValue(), ctrl_TxtMoney_Vlr.getTextBoxValue_NumberStr(), csv_block, ref header );					
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_buscaDados -
				
				case event_buscaDados:
				{
					//InitEventCode event_buscaDados
					
					string st_csv_block = "";
					
					var_exchange.fetch_cotaExtra_carts ( ctrl_TxtNu_Empresa.getTextBoxValue(), ref header, ref st_csv_block );
					
					ArrayList full_memory  = new ArrayList();
					
					while ( st_csv_block != "" )
					{
						ArrayList tmp_memory  = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_csv_block, "400",  ref st_csv_block, ref tmp_memory ) )
							for ( int t=0; t < tmp_memory.Count; ++t )
								full_memory.Add ( tmp_memory[t] );
					}
					
					i_Form.LstCart.Items.Clear();
					
					if ( i_Form.ChkAlfa.Checked )
					{
						ArrayList lst_sort = new ArrayList();
						Hashtable hsh_sort = new Hashtable();
					
						for ( int t=0; t < full_memory.Count; ++t )
						{
							DadosCartao dc = new DadosCartao ( full_memory[t] as DataPortable );
						
							lst_sort.Add ( dc.get_st_proprietario() );
							hsh_sort [ dc.get_st_proprietario() ] = dc;
						}
						
						lst_sort.Sort();
						
						for ( int t=0; t < lst_sort.Count; ++t )
						{
							DadosCartao dc = hsh_sort [ lst_sort[t] ] as DadosCartao;
							
							string [] full_row = new string [] { 	dc.get_st_matricula(),
																	dc.get_st_proprietario(),																	
																	"NÃO" };
							
							i_Form.LstCart.Items.Add ( var_util.GetListViewItem ( dc.get_st_cpf(), full_row ) );
						}
					}
					else
					{
						for ( int t=0; t < full_memory.Count; ++t )
						{
							DadosCartao dc = new DadosCartao ( full_memory[t] as DataPortable );
							
							string [] full_row = new string [] { 	dc.get_st_matricula(),
																	dc.get_st_proprietario(),																	
																	"NÃO" };
								
							i_Form.LstCart.Items.Add ( var_util.GetListViewItem ( dc.get_st_cpf(), full_row ) );
						}
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ChkAlfaCheckedChanged -
				
				case event_ChkAlfaCheckedChanged:
				{
					//InitEventCode event_ChkAlfaCheckedChanged
					
					doEvent ( event_buscaDados, null );
					
					
					
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
