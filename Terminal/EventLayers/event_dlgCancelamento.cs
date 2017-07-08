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
	public class event_dlgCancelamento : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int event_BtnCancelarClick = 3;
		#endregion

		public dlgCancelamento i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		public DadosNSU dn = new DadosNSU();
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgCancelamento ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgCancelamento ( this );
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

					string st_content = "";
					
					if ( var_exchange.fetch_canc_dia_lojista ( ref header, ref st_content ) )
					{
						while ( st_content != "" )
						{
							ArrayList tmp_memory = new ArrayList();
							
							if ( var_exchange.fetch_memory ( st_content, "200", 
							                                 ref st_content, 
							                                 ref tmp_memory ) )
							{
								for ( int t=0; t < tmp_memory.Count; ++t )
								{
									DadosConsultaTransacao  dct = new DadosConsultaTransacao ( tmp_memory [t] as DataPortable );
									
									string [] full_row = new string [] { 	dct.get_st_cartao(), 
																			"R$ " + new money().formatToMoney ( dct.get_vr_valor() ),
																			var_util.getDDMMYYYY_format ( dct.get_dt_transacao() ),
																			dct.get_st_nsu()  };
									
									i_Form.LstVendas.Items.Add ( var_util.GetListViewItem ( null, full_row ) );
								}
							}
						}
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnCancelarClick -
				
				case event_BtnCancelarClick:
				{
					//InitEventCode event_BtnCancelarClick
					
					if ( i_Form.LstVendas.SelectedItems.Count == 0 )
						return false;
					
					string dtax = i_Form.LstVendas.SelectedItems[0].SubItems[2].Text;
					string nsu = i_Form.LstVendas.SelectedItems[0].SubItems[3].Text;
					
					string dta = var_util.GetDataBaseTimeFormat ( 
																new DateTime (  Convert.ToInt32 ( dtax.Substring ( 6,4 ) ),
					                                            				Convert.ToInt32 ( dtax.Substring ( 3,2 ) ),
																				Convert.ToInt32 ( dtax.Substring ( 0,2 ) ) ) );
					
					if ( !var_exchange.fetch_dadosNSU ( 	nsu, 
					                                   		dta,
					                                  		TipoConfirmacao.Confirmada,
					                                  		ref header, 
					                                  		ref dn ) )
					{
						return false;
					}
					
					POS_Entrada pe = new POS_Entrada();
					POS_Resposta pr = new POS_Resposta();
					
					pe.set_st_terminal 		( dn.get_st_terminal() 		);
					pe.set_st_empresa  		( dn.get_st_empresa()		);
					pe.set_st_matricula 	( dn.get_st_matricula() 	);
					pe.set_st_titularidade 	( dn.get_st_titularidade() 	);
					pe.set_nu_parcelas		( "0" 						);
					
					string st_msg = "";
					
					var_exchange.m_Client.QuietMode = true;
					
					if ( var_exchange.exec_pos_cancelaVendaEmpresarial ( 	nsu,
					                                                    	dta,
					                                                    	header.get_st_user_id(),
						                                               		ref pe,
						                                               		ref st_msg,
						                                               		ref pr ) )
					{
						MessageBox.Show ( "Sucesso no cancelamento", "Aviso" );
					}
					else
					{
						MessageBox.Show ( st_msg, "Erro" );
					}
					
					var_exchange.m_Client.QuietMode = false;
					
					doEvent ( event_FormIsOpening, null );
					
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
