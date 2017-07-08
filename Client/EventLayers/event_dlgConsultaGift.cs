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
	public class event_dlgConsultaGift : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_val_TxtEmpresa = 5;
		public const int event_val_TxtMatricula = 6;
		public const int event_val_TxtCartao = 7;
		#endregion

		public dlgConsultaGift i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController 	ctrl_TxtEmpresa		= new numberTextController();
		numberTextController 	ctrl_TxtMatricula	= new numberTextController();
				
		Color 	colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgConsultaGift ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgConsultaGift ( this );
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
					ctrl_TxtMatricula.AcquireTextBox 	( i_Form.TxtMatricula, 	this, event_val_TxtMatricula, 6 );
					
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
									doEvent ( event_val_TxtCartao, null );
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
								
								if ( ctrl_TxtMatricula.GetEnterPressed() )
								{
									doEvent ( event_val_TxtCartao, null );
								}
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
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCartao -
				
				case event_val_TxtCartao:
				{
					//InitEventCode event_val_TxtCartao
					
					if ( !ctrl_TxtEmpresa.IsUserValidated  && 
					    !ctrl_TxtMatricula.IsUserValidated )
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
							                                       	ctrl_TxtMatricula.getTextBoxValue(),
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
					
					i_Form.LstCred.Items.Clear();
					i_Form.LstProd.Items.Clear();
					
					for (int t=0; t < lstCred.Count; ++t )
					{
						DadosConsultaGift dcg = new DadosConsultaGift ( lstCred[t] as DataPortable );
						
						string [] full_row = new string [] { dcg.get_st_nome(),
															 "R$ " + new money().formatToMoney ( dcg.get_vr_valor() ),
															 var_util.getDDMMYYYY_format ( dcg.get_dt_data() ) };
							
						i_Form.LstCred.Items.Add ( var_util.GetListViewItem ( "", full_row ) );
					}
					
					for (int t=0; t < lstProd.Count; ++t )
					{
						DadosConsultaGift dcg = new DadosConsultaGift ( lstProd[t] as DataPortable );
						
						string [] full_row = new string [] { dcg.get_st_nome(), 
															 "R$ " + new money().formatToMoney ( dcg.get_vr_valor() )	};
							
						i_Form.LstProd.Items.Add ( var_util.GetListViewItem ( "", full_row ) );
					}						
					
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
