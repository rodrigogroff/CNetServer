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
	public class event_dlgEditaChamado : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Alterar = 5;
		public const int event_BuscaDados = 6;
		public const int event_BtnAlterarClick = 7;
		#endregion

		public dlgEditaChamado i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		public string id_chamado = "";
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgEditaChamado ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgEditaChamado ( this );
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
					
					ArrayList lst = new ArrayList();
					
					var_exchange.fetch_conveyUsuarios ( ref header, ref lst );
					
					i_Form.CboOpers.Items.Clear();
					
					for ( int t=0; t < lst.Count; ++t )
					{
						DadosUsuario us = new DadosUsuario ( lst[t] as DataPortable );
						
						i_Form.CboOpers.Items.Add ( us.get_st_nome() );
					}
					
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
				
				#region - event_Alterar -
				
				case event_Alterar:
				{
					//InitEventCode event_Alterar
					
					if ( i_Form.TxtNewSolution.Text.Trim().Length == 0 )
					{
						MessageBox.Show ( "Digite o andamento da solução", "Aviso" );
						return false;
					}
					
					if ( i_Form.CboSit.SelectedIndex == 1 )
					{
						if ( MessageBox.Show (	"Confirma fechamento de chamado?",
					                    		"Aviso", 
					                    		MessageBoxButtons.YesNo, 
					                    		MessageBoxIcon.Question, 
					                    		MessageBoxDefaultButton.Button2 ) == DialogResult.No )
						{
							return false;
						}
					}
					
					string 	st_new_desc = i_Form.TxtNewSolution.Text, 
							tg_fechado	= i_Form.CboSit.SelectedIndex.ToString(),
							st_operador = i_Form.CboOpers.SelectedItem.ToString();
					
					var_exchange.exec_alteraChamado ( id_chamado, st_new_desc, tg_fechado, st_operador, ref header );
					
					i_Form.BtnAlterar.Enabled 		= false;
					i_Form.TxtNewSolution.Enabled 	= false;
					i_Form.CboOpers.Enabled 		= false;
					i_Form.CboSit.Enabled 			= false;
					
					doEvent ( event_BuscaDados, null );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BuscaDados -
				
				case event_BuscaDados:
				{
					//InitEventCode event_BuscaDados
					
					ArrayList lst = new ArrayList();
					
					DadosChamado dc = new DadosChamado();
					
					if ( var_exchange.fetch_chamadoHist ( id_chamado, ref header, ref dc, ref lst ) )
					{
						i_Form.TxtLoja.Text = dc.get_st_cod_loja();
						i_Form.TxtNome.Text = dc.get_st_nome_loja();
						i_Form.TxtDesc.Text = dc.get_st_motivo();
						
						for ( int t=0; t < i_Form.CboOpers.Items.Count; ++t )
						{
							if ( i_Form.CboOpers.Items[t].ToString() == dc.get_st_oper() )
							{
								i_Form.CboOpers.SelectedIndex = t;
								break;
							}
						}
						
						i_Form.CboCateg.SelectedIndex   = Convert.ToInt32 ( dc.get_nu_categ() 	);
						i_Form.CboSit.SelectedIndex   	= Convert.ToInt32 ( dc.get_tg_fechado() );
						i_Form.TxtDtAbertura.Text 		= var_util.getDDMMYYYY_format ( dc.get_dt_ab() );
						
						if ( dc.get_tg_fechado() == Context.TRUE )
							i_Form.TxtDtFechamento.Text = var_util.getDDMMYYYY_format ( dc.get_dt_fech() );
												
						i_Form.TxtHist.Text = "";
						
						for ( int t=0; t < lst.Count; ++t )
						{
							DadosAlteracaoChamado dac = new DadosAlteracaoChamado ( lst[t] as DataPortable );
							
							i_Form.TxtHist.Text += "-= " + 
													var_util.getDDMMYYYY_format ( dac.get_dt_alt() ) +
													" (" + 
													dac.get_st_oper_alt() + 
													") =- \r\n";
							
							i_Form.TxtHist.Text += 	dac.get_st_desc_alt();
							i_Form.TxtHist.Text += 	"\r\n\r\n";
						}
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnAlterarClick -
				
				case event_BtnAlterarClick:
				{
					//InitEventCode event_BtnAlterarClick
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
