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
	public class event_dlgDBF_Fechamento : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int robot_ShowDialog = 3;
		public const int robot_CloseDialog = 4;
		public const int event_Procurar = 5;
		public const int event_BtnProcurarClick = 6;
		#endregion

		public dlgDBF_Fechamento i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		public string mes = "";
		public string ano = "";
		public string st_cod_empresa = "";
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgDBF_Fechamento ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgDBF_Fechamento ( this );
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
					
					i_Form.LblText.Text += mes + "/" + ano + " - Empresa " + st_cod_empresa;
					
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
				
				#region - event_Procurar -
				
				case event_Procurar:
				{
					//InitEventCode event_Procurar
					
					i_Form.folderBrowserDialog1.ShowNewFolderButton = true;
					i_Form.folderBrowserDialog1.Description = "Selecione o diretório para o arquivo BDF:";
					i_Form.folderBrowserDialog1.ShowDialog();
					
					i_Form.TxtFile.Text = i_Form.folderBrowserDialog1.SelectedPath + "fechamen.dbf";
					
					if ( MessageBox.Show (	"Confirma geração de arquivo?",
			                    			"Aviso", 
			                    			MessageBoxButtons.YesNo, 
			                    			MessageBoxIcon.Question, 
			                    			MessageBoxDefaultButton.Button2 ) == DialogResult.No )
					{
						return false;
					}
					
					string st_empresa 				= "";
					string st_csv_cartao 			= "";
					string st_csv_loja 				= "";
					string st_csv_loja_content 		= "";
					string st_csv_subtotal_loja 	= ""; 
					string st_csv_subtotal_cartao 	= "";
					string st_csv_cartao_content 	= "";
					string st_total 				= "";
					
					dlgStatus stat = new dlgStatus ( "Relatório" );
					
					stat.LblActivity.Text = "Processando no servidor";
					stat.Show();
					Application.DoEvents();
					
					if ( !var_exchange.fetch_rel_3_fech (	"1",
							                                mes,
							                                ano,
							                                st_cod_empresa,
							                                "",
										                 	ref header,
										                 	ref st_empresa, 
										                 	ref st_csv_cartao,
										                 	ref st_csv_loja,
										                    ref st_csv_loja_content,
										                    ref st_csv_subtotal_loja,
										                    ref st_csv_subtotal_cartao,
										                    ref st_csv_cartao_content,
										                    ref st_total ) )
                 	{
						stat.Close();
						return false;                 		
                 	}
					
					DBfileGen dbf = new DBfileGen ( i_Form.folderBrowserDialog1.SelectedPath, 
					                                "fechamen", 
					                                "dbf" );
					
		            dbf.addCampo("data", "date");
		            dbf.addCampo("nsu", "varchar(6)");
		            dbf.addCampo("matricula", "varchar(6)");
		            dbf.addCampo("valor", "currency");
		            dbf.addCampo("parcela", "varchar(6)");
		            dbf.addCampo("cnpj", "varchar(14)");
					
					money 		money_helper = new money();
					Hashtable 	mem_Cartoes  = new Hashtable();
					
					stat.LblActivity.Text = "Obtendo resultados";
					
					Application.DoEvents();
					
					#region Busca todos os registros de todos os cartoes
					{
						ArrayList full_memory = new ArrayList();
						
						while ( st_csv_cartao_content != "" )
						{
							ArrayList tmp_memory  = new ArrayList();
							
							if ( var_exchange.fetch_memory ( st_csv_cartao_content, "400", ref st_csv_cartao_content, ref tmp_memory ) )
								for ( int t=0; t < tmp_memory.Count; ++t )
									full_memory.Add ( tmp_memory[t] );
						}
					
						for ( int t=0; t < full_memory.Count; ++t )
						{
							DadosFechamento df = new DadosFechamento ( full_memory[t] as DataPortable );
							
							string tmp_cartao = df.get_st_cartao();
							
							if ( mem_Cartoes [ tmp_cartao ] == null )
								mem_Cartoes [ tmp_cartao ] = new ArrayList();
							
							ArrayList memoryCart = mem_Cartoes [ tmp_cartao ] as ArrayList;
							
							memoryCart.Add ( df );
						}
					}
					
					#endregion
					
					stat.LblActivity.Text = "Escrevendo arquivo";
					
					Application.DoEvents();
					
					int tot_Cartoes = var_util.indexCSV ( st_csv_cartao );
					
					ApplicationUtil var_utilFooter = new ApplicationUtil();
						
					var_utilFooter.indexCSV ( st_csv_subtotal_cartao );
					
					for ( int h=0; h < tot_Cartoes; ++h )
					{
						string cart = var_util.getCSV (h);
						
						ArrayList memCartList = mem_Cartoes [ cart ] as ArrayList;
						
						if ( memCartList != null )
						{
							for ( int t=0; t < memCartList.Count; ++t )
							{
								DadosFechamento df = new DadosFechamento ( memCartList[t] as DataPortable );
								
								ArrayList lstLine = new ArrayList();
								
								lstLine.Add ( var_util.getDDMMYYYY_format ( df.get_dt_trans() ).Substring ( 0 , 10 ) );
            					lstLine.Add ( df.get_st_nsu().PadLeft ( 6, '0' )    );
            					lstLine.Add ( df.get_st_matricula() 				);
            					
            					string vr_val = df.get_vr_valor().PadLeft ( 3, '0' );
            					
            					vr_val = vr_val.Insert ( vr_val.Length -2, "." );
            					
            					lstLine.Add ( vr_val 				);
            					lstLine.Add ( df.get_nu_parcela() 	);
            					lstLine.Add ( df.get_st_cnpj()      );             					
            					            				
            					dbf.addReg ( lstLine );
							}
						}
					}
					
					dbf.save();
					
					stat.Close();
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnProcurarClick -
				
				case event_BtnProcurarClick:
				{
					//InitEventCode event_BtnProcurarClick
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
