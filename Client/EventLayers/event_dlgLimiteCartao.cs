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
	public class event_dlgLimiteCartao : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtCpf = 6;
		public const int event_val_TxtLimTotal = 7;
		public const int event_val_TxtLimMensal = 8;
		public const int event_val_TxtLimRotativo = 9;
		public const int event_val_TxtCotaExtra = 10;
		public const int event_Click = 11;
		public const int event_LstCartoesClick = 12;
		public const int event_BtnConfirmarClick = 13;
		#endregion

		public dlgLimiteCartao i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController			ctrl_TxtCpf			= new numberTextController();
		
		moneyTextController  	   	ctrl_TxtLimTotal 	= new moneyTextController();
		moneyTextController  	   	ctrl_TxtLimMensal	= new moneyTextController();
		moneyTextController  	   	ctrl_TxtLimRotativo	= new moneyTextController();
		moneyTextController  	   	ctrl_TxtCotaExtra	= new moneyTextController();
		
		Color colorInvalid = Color.Lavender;

		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgLimiteCartao ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgLimiteCartao ( this );
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
					
					ctrl_TxtLimMensal.AcquireTextBox 	( i_Form.TxtLimMensal, 		this, event_val_TxtLimMensal,  	"R$", 8 );
					ctrl_TxtLimTotal.AcquireTextBox 	( i_Form.TxtLimTotal, 		this, event_val_TxtLimTotal,  	"R$", 8 );
					ctrl_TxtLimRotativo.AcquireTextBox 	( i_Form.TxtLimRotativo, 	this, event_val_TxtLimRotativo, "R$", 8 );
					ctrl_TxtCotaExtra.AcquireTextBox 	( i_Form.TxtCotaExtra, 		this, event_val_TxtCotaExtra, 	"R$", 8 );
					
					ctrl_TxtCpf.AcquireTextBox 			( i_Form.TxtCpf, 			this, event_val_TxtCpf, 11 );
					
					ctrl_TxtLimMensal.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtLimTotal.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtLimRotativo.SetupErrorProvider   	( ErrorIconAlignment.MiddleRight, false ); 
					ctrl_TxtCotaExtra.SetupErrorProvider   		( ErrorIconAlignment.MiddleRight, false ); 
					
					ctrl_TxtLimTotal.IsUserValidated 		= false;
					ctrl_TxtLimMensal.IsUserValidated		= false;
					ctrl_TxtLimRotativo.IsUserValidated		= false;
					ctrl_TxtCotaExtra.IsUserValidated 		= false;
					
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
					
					if ( i_Form.LstCartoes.SelectedItems.Count > 0 )
					{
						bool IsDone = true;
					
						if ( !ctrl_TxtLimTotal.IsUserValidated )	{	ctrl_TxtLimTotal.SetErrorMessage 		( "Valor deve estar preenchido" );	IsDone = false;	}
						if ( !ctrl_TxtLimMensal.IsUserValidated )	{	ctrl_TxtLimMensal.SetErrorMessage 		( "Valor deve estar preenchido" );	IsDone = false;	}
						if ( !ctrl_TxtLimRotativo.IsUserValidated )	{	ctrl_TxtLimRotativo.SetErrorMessage 	( "Valor deve estar preenchido" );	IsDone = false;	}
						if ( !ctrl_TxtCotaExtra.IsUserValidated )	{	ctrl_TxtCotaExtra.SetErrorMessage 		( "Valor deve estar preenchido" );	IsDone = false;	}
						
						if ( !IsDone ) 
							return false;
						
						if ( ctrl_TxtLimMensal.getTextBoxValue_Long() > ctrl_TxtLimTotal.getTextBoxValue_Long() )
						{
							ctrl_TxtLimMensal.SetErrorMessage ( "Valor mensal deve ser menor que o valor total" );	
							return false;
						}
					
						string 			tag = var_util.getSelectedListViewItemTag ( i_Form.LstCartoes );
						DataPortable 	tmp = var_util.retrievePortable ( tag );
						
						DadosCartao dc = new DadosCartao ( tmp );
						
						dc.set_vr_limiteTotal		( ctrl_TxtLimTotal.getTextBoxValue_NumberStr() 		);
						dc.set_vr_limiteMensal		( ctrl_TxtLimMensal.getTextBoxValue_NumberStr() 	);
						dc.set_vr_limiteRotativo	( ctrl_TxtLimRotativo.getTextBoxValue_NumberStr() 	);
						dc.set_vr_extraCota			( ctrl_TxtCotaExtra.getTextBoxValue_NumberStr() 	);
						
						var_exchange.exec_alteraCartao ( ref dc, ref header );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCpf -
				
				case event_val_TxtCpf:
				{
					//InitEventCode event_val_TxtCpf
					
					if ( ctrl_TxtCpf.getTextBoxValue().Length < 11 )
					{
						i_Form.TxtCpf.BackColor = colorInvalid;	
						ctrl_TxtCpf.IsUserValidated = false;
						
						i_Form.LstCartoes.Items.Clear();
						i_Form.LblNome.Text = "";
					}
					else	
					{
						i_Form.TxtCpf.BackColor = Color.White;	
												
						if ( ctrl_TxtCpf.IsUserValidated == false )
						{
							string st_csv_id = "";
							
							i_Form.LstCartoes.Items.Clear();
							
							if ( var_exchange.fetch_limitesCartao ( ctrl_TxtCpf.getTextBoxValue(), 
							                                       	ref header, 
							                                       	ref st_csv_id ) )
							{
								ArrayList full_memory = new ArrayList();
					
								while ( st_csv_id != "" )
								{
									ArrayList tmp_memory  = new ArrayList();
									
									if ( var_exchange.fetch_memory ( st_csv_id, "400", ref st_csv_id, ref tmp_memory ) )
										for ( int t=0; t < tmp_memory.Count; ++t )
											full_memory.Add ( tmp_memory[t] );
								}
								
								ArrayList desc = new CartaoStatusDesc().GetArray();
										
								for ( int t=0; t < full_memory.Count; ++t )
								{
									DadosCartao dc = new DadosCartao ( full_memory[t] as DataPortable );

									string nu_cartao 	= dc.get_st_empresa() + dc.get_st_matricula();
									
									int index = Convert.ToInt32 ( dc.get_tg_status() );
									
									string status 		= desc [ index ].ToString();
									string venc   		= dc.get_st_vencimento().Substring (0,2) + 
															"/" + 
															dc.get_st_vencimento().Substring (2,2);
									
									string [] full_row = new string [] { 	nu_cartao,
																			status,
																			venc	};
									
									var_util.savePortable ( nu_cartao, dc );
									
									i_Form.LstCartoes.Items.Add ( var_util.GetListViewItem ( nu_cartao, full_row ) );
									
									i_Form.LblNome.Text = dc.get_st_proprietario();
								}
								
								if (  full_memory.Count > 0 )
								{
									i_Form.LstCartoes.Items[ 0 ].Selected = true;
									doEvent( event_Click , null );
								}
							}
						}
						
						ctrl_TxtCpf.IsUserValidated = true;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtLimTotal -
				
				case event_val_TxtLimTotal:
				{
					//InitEventCode event_val_TxtLimTotal
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtLimMensal -
				
				case event_val_TxtLimMensal:
				{
					//InitEventCode event_val_TxtLimMensal
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtLimRotativo -
				
				case event_val_TxtLimRotativo:
				{
					//InitEventCode event_val_TxtLimRotativo
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCotaExtra -
				
				case event_val_TxtCotaExtra:
				{
					//InitEventCode event_val_TxtCotaExtra
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Click -
				
				case event_Click:
				{
					//InitEventCode event_Click
					
					if ( i_Form.LstCartoes.SelectedItems.Count > 0 )
					{
						string 			tag = var_util.getSelectedListViewItemTag ( i_Form.LstCartoes );
						DataPortable 	tmp = var_util.retrievePortable ( tag );
						
						DadosCartao dc = new DadosCartao ( tmp );
						
						ctrl_TxtLimTotal.SetTextBoxString 		( dc.get_vr_limiteTotal() 		);
						ctrl_TxtLimMensal.SetTextBoxString 		( dc.get_vr_limiteMensal() 		);
						ctrl_TxtLimRotativo.SetTextBoxString 	( dc.get_vr_limiteRotativo() 	);
						ctrl_TxtCotaExtra.SetTextBoxString 		( dc.get_vr_extraCota() 		);
						
						ctrl_TxtLimTotal.IsUserValidated 		= true;
						ctrl_TxtLimMensal.IsUserValidated		= true;
						ctrl_TxtLimRotativo.IsUserValidated		= true;
						ctrl_TxtCotaExtra.IsUserValidated 		= true;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_LstCartoesClick -
				
				case event_LstCartoesClick:
				{
					//InitEventCode event_LstCartoesClick
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
