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
	public class event_dlgEduCancelarCartao : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_val_TxtEmpresa = 5;
		public const int event_val_TxtCartao = 6;
		public const int event_Cancelar = 7;
		public const int event_val_TxtAluno = 8;
		public const int event_BtnCancelarClick = 9;
		#endregion

		public dlgEduCancelarCartao i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		alphaTextController 	ctrl_TxtAluno	= new alphaTextController();
				
		Color 	colorInvalid = Color.Lavender;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgEduCancelarCartao ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgEduCancelarCartao ( this );
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
					
					ctrl_TxtAluno.AcquireTextBox ( i_Form.TxtAluno, this, event_val_TxtAluno,  26  );
					
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
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtCartao -
				
				case event_val_TxtCartao:
				{
					//InitEventCode event_val_TxtCartao
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Cancelar -
				
				case event_Cancelar:
				{
					//InitEventCode event_Cancelar

					if ( i_Form.LstAlunos.SelectedIndex == -1 )
						return false;
					
					if ( MessageBox.Show (	"Confirma cancelamento de cartão?",
			                    			"Aviso", 
			                    			MessageBoxButtons.YesNo, 
			                    			MessageBoxIcon.Question, 
			                    			MessageBoxDefaultButton.Button2 ) == DialogResult.No )
					{
						return false;
					}
					
					string cart = i_Form.LstAlunos.SelectedItem.ToString().Substring ( 0, 14 );
				
					var_exchange.exec_edu_cancelaCartao (  cart, ref header );					
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtAluno -
				
				case event_val_TxtAluno:
				{
					//InitEventCode event_val_TxtAluno
					
					switch ( arg as string )
					{
						case alphaTextController.ALPHA_COMPLETE:
						case alphaTextController.ALPHA_INCOMPLETE:
						{
							if ( ctrl_TxtAluno.getTextBoxValue().Length > 1 )
							{
								i_Form.TxtAluno.BackColor = Color.White;
								ctrl_TxtAluno.IsUserValidated = true;
								ctrl_TxtAluno.CleanError();
								
								if ( ctrl_TxtAluno.GetEnterPressed() )
								{
									string st_csv = "";
									
									var_exchange.fetch_edu_nomeAluno ( 	ctrl_TxtAluno.getTextBoxValue(), 
									                                  	ref header, 
									                                  	ref st_csv );
									
									
									ArrayList full_memory = new ArrayList();
						
									while ( st_csv != "" )
									{
										ArrayList tmp_memory  = new ArrayList();
										
										if ( var_exchange.fetch_memory ( st_csv, "400", ref st_csv, ref tmp_memory ) )
											for ( int t=0; t < tmp_memory.Count; ++t )
												full_memory.Add ( tmp_memory[t] );
									}
									
									i_Form.LstAlunos.Items.Clear();
									
									ArrayList desc = new TipoConfirmacaoDesc().GetArray();
									ArrayList desc_op = new OperacaoCartaoDesc().GetArray();
								
									for ( int t=0; t < full_memory.Count; ++t )
									{
										DadosCartaoEdu aluno = new DadosCartaoEdu ( full_memory[t] as DataPortable );
										
										i_Form.LstAlunos.Items.Add ( aluno.get_st_cartao() + " " + aluno.get_st_aluno() );
									}
								}
							}
							else
							{
								i_Form.TxtAluno.BackColor = colorInvalid;
								ctrl_TxtAluno.IsUserValidated = false;
							}
							
							break;
						}
						
						default: break;
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnCancelarClick -
				
				case event_BtnCancelarClick:
				{
					//InitEventCode event_BtnCancelarClick
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
