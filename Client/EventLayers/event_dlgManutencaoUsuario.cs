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
	public class event_dlgManutencaoUsuario : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_Detalhes = 6;
		public const int event_val_TxtEmpresa = 7;
		public const int event_BuscaDados = 8;
		public const int event_BtnConfirmarClick = 9;
		#endregion

		public dlgManutencaoUsuario i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		numberTextController 	ctrl_TxtEmpresa	= new numberTextController();
		
		Color 	colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgManutencaoUsuario ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgManutencaoUsuario ( this );
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
					
					ctrl_TxtEmpresa.AcquireTextBox 	( i_Form.TxtEmpresa, this, event_val_TxtEmpresa, 	6  	);
					
					if ( header.get_tg_user_type() == TipoUsuario.Administrador || 
					    header.get_tg_user_type() == TipoUsuario.AdminGift )
					{
						ctrl_TxtEmpresa.SetTextBoxText  ( header.get_st_empresa() 								);
						i_Form.TxtEmpresa.ReadOnly = true;
							
						doEvent ( event_BuscaDados, ctrl_TxtEmpresa.getTextBoxValue() );							
					}
					else // root
					{
						ctrl_TxtEmpresa.SetTextBoxText ( "0" );
						
						doEvent ( event_BuscaDados, null );
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
					
					if ( i_Form.CboAcao.SelectedItem != null )
					{
						if ( i_Form.LstUsuarios.SelectedItems.Count > 0 )
						{
							var_exchange.exec_alteraUsuario ( 	i_Form.CboAcao.SelectedIndex.ToString(), 
							                                 	var_util.getSelectedListViewItemTag ( i_Form.LstUsuarios ), 
							                                 	ref header );
							
							doEvent ( event_BuscaDados, ctrl_TxtEmpresa.getTextBoxValue() );
						}
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Detalhes -
				
				case event_Detalhes:
				{
					//InitEventCode event_Detalhes
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
									doEvent ( event_BuscaDados, ctrl_TxtEmpresa.getTextBoxValue() );
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
				
				#region - event_BuscaDados -
				
				case event_BuscaDados:
				{
					//InitEventCode event_BuscaDados
					
					i_Form.LstUsuarios.Items.Clear();
					
					ArrayList list = new ArrayList();
					
					string st_csv_id 		= "";
					
					var_util.clearPortable();

					// customiza header!
					CNetHeader head = new CNetHeader ( header as DataPortable );
					
					head.set_st_empresa ( arg as string );
					
					i_Form.LstUsuarios.Items.Clear();
					
					if ( var_exchange.fetch_listaUsuarios ( ref head, ref st_csv_id ) )
					{
						ArrayList full_memory = new ArrayList();
						
						while ( st_csv_id != "" )
						{
							ArrayList tmp_memory  = new ArrayList();
							
							if ( var_exchange.fetch_memory ( st_csv_id, "200", ref st_csv_id, ref tmp_memory ) )
								for ( int t=0; t < tmp_memory.Count; ++t )
									full_memory.Add ( tmp_memory[t] );
						}

						ArrayList desc = new TipoUsuarioDesc().GetArray();
						
						for (int t=0; t < full_memory.Count; ++t )
						{
							DadosUsuario info = new DadosUsuario ( full_memory[t] as DataPortable );
							
							string id      = info.get_id_usuario();
							string nome    = info.get_st_nome();
							string bloq    = info.get_tg_bloqueio();
							string nivel   = desc [ Convert.ToInt32 ( info.get_tg_nivel() ) ].ToString();
							string empresa = info.get_st_empresa();
							
							if ( bloq == Context.TRUE )	
								bloq = "Sim";
							else
								bloq = "Não";
							
							if ( empresa == "000000" )
								empresa = "";
							
							switch ( nivel )
							{
								case TipoUsuario.SuperUser:		nivel = "Super Usuário";	break;
								case TipoUsuario.Administrador:	nivel = "Administrador";	break;
								case TipoUsuario.Operador:		nivel = "Operador";			break;
								
								default: break;
							}
							
							string [] full_row = new string [] { nome, bloq, nivel, empresa };
							
							i_Form.LstUsuarios.Items.Add ( var_util.GetListViewItem ( id, full_row ) );
						}
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
