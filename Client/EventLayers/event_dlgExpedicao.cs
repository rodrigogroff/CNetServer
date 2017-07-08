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
	public class event_dlgExpedicao : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Confirmar = 5;
		public const int event_val_TxtEmpresa = 6;
		public const int event_ComboChanged = 7;
		public const int event_BtnDirClick = 8;
		public const int event_BtnConfirmarClick = 9;
		public const int event_CboEmpresaSelectedIndexChanged = 10;
		#endregion

		public dlgExpedicao i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		Color 	colorInvalid = Color.Lavender;
		
		Hashtable hshEmp = new Hashtable();
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgExpedicao ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgExpedicao ( this );
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
					
					doEvent ( event_val_TxtEmpresa, null );
					
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
					
					if ( i_Form.CboEmpresa.SelectedIndex == -1 )
					{
						MessageBox.Show ( "Nenhuma empresa disponível" );
						return false;
					}
					
					if ( i_Form.TxtFile.Text.Length == 0 )
					{
						MessageBox.Show ( "Escolha um arquivo de destino" );
						return false;
					}
					
					i_Form.BtnConfirmar.Enabled = false;
					
					string st_csv = "";
					
					if ( !var_exchange.fetch_cartoes_grafica ( i_Form.CboEmpresa.SelectedItem.ToString(), ref header, ref st_csv ) )
					{
						i_Form.BtnConfirmar.Enabled = true;
						return false;
					}
					
					ArrayList full_memory = new ArrayList();
						
					while ( st_csv != "" )
					{
						ArrayList tmp_memory  = new ArrayList();
						
						if ( var_exchange.fetch_memory ( st_csv, "400", ref st_csv, ref tmp_memory ) )
							for ( int t=0; t < tmp_memory.Count; ++t )
								full_memory.Add ( tmp_memory[t] );
					}
					
					ArrayList desc    = new TipoConfirmacaoDesc().GetArray();
					ArrayList desc_op = new OperacaoCartaoDesc().GetArray();
					
					StreamWriter sw = new StreamWriter ( i_Form.TxtFile.Text );
				
					for ( int t=0; t < full_memory.Count; ++t )
					{
						DadosExpedicao port = new DadosExpedicao ( full_memory[t] as DataPortable );
						
						sw.WriteLine ( port.get_st_line() );
					}
					
					sw.Close();		
					
					MessageBox.Show ( "Arquivo gerado sucesso", "Aviso" );
										
					i_Form.BtnConfirmar.Enabled = true;
					
					doEvent ( event_val_TxtEmpresa, null );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_val_TxtEmpresa -
				
				case event_val_TxtEmpresa:
				{
					//InitEventCode event_val_TxtEmpresa

					ArrayList lst = new ArrayList();
					
					dlgStatus st = new dlgStatus( "Empresas com novos cartões" );
					
					st.LblActivity.Text = "Buscando cartões";
					st.Show();
					
					Application.DoEvents();
					
					var_exchange.fetch_empresasGrafica ( ref header, ref lst );
					
					i_Form.TxtFile.Text = "";
					i_Form.CboEmpresa.Items.Clear();
					hshEmp.Clear();
					
					for ( int t=0; t < lst.Count; ++t )
					{
						DadosEmpresa de = new DadosEmpresa ( lst[t] as DataPortable );
						
						i_Form.CboEmpresa.Items.Add ( de.get_st_empresa() );
						
						hshEmp [ de.get_st_empresa() ] = de;
					}
					
					if ( lst.Count > 0 )
						i_Form.CboEmpresa.SelectedIndex = 0;
					
					st.Close();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_ComboChanged -
				
				case event_ComboChanged:
				{
					//InitEventCode event_ComboChanged
					
					DadosEmpresa de = hshEmp [ i_Form.CboEmpresa.SelectedItem.ToString() ] as DadosEmpresa;
					
					i_Form.TxtNome.Text = de.get_st_fantasia();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnDirClick -
				
				case event_BtnDirClick:
				{
					//InitEventCode event_BtnDirClick
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
				
				#region - event_CboEmpresaSelectedIndexChanged -
				
				case event_CboEmpresaSelectedIndexChanged:
				{
					//InitEventCode event_CboEmpresaSelectedIndexChanged
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
