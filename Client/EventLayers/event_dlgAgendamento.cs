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
	public class event_dlgAgendamento : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Adicionar = 5;
		public const int event_Remover = 6;
		public const int event_buscaDados = 7;
		public const int event_BtnAdicionarClick = 8;
		public const int event_BtnRemoverClick = 9;
		public const int event_DlgAgendamentoShown = 10;
		#endregion

		public dlgAgendamento i_Form;

		//UserVariables
		
		public CNetHeader header;
			
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgAgendamento ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgAgendamento ( this );
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
				
				#region - event_Adicionar -
				
				case event_Adicionar:
				{
					//InitEventCode event_Adicionar
					
					event_dlgCadastroAtividade ev_call = new event_dlgCadastroAtividade ( var_util, var_exchange );
					
					ev_call.header = header;
					
					ev_call.i_Form.ShowDialog();
					
					if ( ev_call.HouveCadastro )
						doEvent ( event_buscaDados, null );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Remover -
				
				case event_Remover:
				{
					//InitEventCode event_Remover
					
					string fk_agenda = var_util.getSelectedListViewItemTag ( i_Form.LstTrans );

					if ( fk_agenda != null )
					{
						var_exchange.del_agenda ( fk_agenda, ref header );
						
						doEvent ( event_buscaDados, null );
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_buscaDados -
				
				case event_buscaDados:
				{
					//InitEventCode event_buscaDados
					
					Application.DoEvents();
					
					string st_csv_id = "";
					
					i_Form.LstTrans.Items.Clear();
					
					ArrayList desc = new TipoAtividadeDesc().GetArray();
					
					if ( var_exchange.fetch_agenda ( ref header, 
					                                 ref st_csv_id ) )
					{
						ArrayList full_memory = new ArrayList();
							
						while ( st_csv_id != "" )
						{
							ArrayList tmp_memory  = new ArrayList();
							
							if ( var_exchange.fetch_memory ( st_csv_id, "400",  ref st_csv_id, ref tmp_memory ) )
								for ( int t=0; t < tmp_memory.Count; ++t )
									full_memory.Add ( tmp_memory[t] );
						}
				
						for ( int t=0; t < full_memory.Count; ++t )
						{
							DadosAgenda da = new DadosAgenda ( full_memory[t] as DataPortable );
							
							int index = Convert.ToInt32 ( da.get_en_atividade() ) - 1;
							
							string [] full_row = new string [] { 	da.get_st_empresa() + " - " + da.get_st_nome_empresa(),
																	desc [ index ].ToString(),
																	da.get_st_info()  };
							
							i_Form.LstTrans.Items.Add ( var_util.GetListViewItem( da.get_fk_agenda(), full_row ) );
						}
						
						Application.DoEvents();			
					}
					
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
				
				#region - event_BtnRemoverClick -
				
				case event_BtnRemoverClick:
				{
					//InitEventCode event_BtnRemoverClick
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_DlgAgendamentoShown -
				
				case event_DlgAgendamentoShown:
				{
					//InitEventCode event_DlgAgendamentoShown
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
