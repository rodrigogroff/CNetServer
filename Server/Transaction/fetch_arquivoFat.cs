using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_arquivoFat : type_base
	{
		public string input_dia_venc_ini = "";
		public string input_dia_venc_fim = "";
		public string input_tg_debito = "";
		
		public string output_st_msg = "";
		public string output_nu_nsFat = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_arquivoFat ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_arquivoFat";
			constructor();
		}
		
		public fetch_arquivoFat()
		{
			var_Alias = "fetch_arquivoFat";
		
			ut_max = 0;
			
			constructor();
		}
		
		public override void constructor()
		{
			/// USER [ constructor ]
			/// USER [ constructor ] END
		}
		
		public override bool setup ( ) 
		{
			#region - SETUP TRANSACTION -
			Registry ( "setup fetch_arquivoFat " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_ARQUIVOFAT.dia_venc_ini, ref input_dia_venc_ini ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_ARQUIVOFAT.dia_venc_ini missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_ARQUIVOFAT.dia_venc_fim, ref input_dia_venc_fim ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_ARQUIVOFAT.dia_venc_fim missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_ARQUIVOFAT.tg_debito, ref input_tg_debito ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_ARQUIVOFAT.tg_debito missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_ARQUIVOFAT.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_ARQUIVOFAT.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_arquivoFat " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_arquivoFat " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_arquivoFat " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_arquivoFat " ); 
		
			/// USER [ execute ]
			
			T_Faturamento fat = new T_Faturamento (this);
			T_Faturamento fat_upd = new T_Faturamento (this);
			
			if ( !fat.select_rows_dt_venc ( input_dia_venc_ini, 
			                                input_dia_venc_fim, 
			                                TipoSitFat.Pendente ) )
			{
				PublishError ( "Nenhum registro encontrado" );
				return false;
			}
			
			StringBuilder sb_content = new StringBuilder();
								
			T_Empresa emp = new T_Empresa (this);
			T_Loja 	  loj = new T_Loja (this);
			
			if ( input_tg_debito == Context.FALSE )
			{
				#region - DOC - 
			
				long seq = 1;
				long vr_total_tits = 0;
				
				string cnpj 	= "";
				string nome 	= "";
				string end  	= "";
				string cidade 	= "";
				string estado 	= "";
				string cep 		= "";
				
				#region - HEADER - 
				{
					DataPortable port = new DataPortable();
								
					string header = "01REMESSA" + 
						            " ".PadLeft ( 17, ' ' ) + 
									Parametros.Cedente.PadLeft ( 12, '0' ) + 
									" ".PadLeft ( 8, ' ' ) + 
									Parametros.Empresa.PadRight ( 30, ' ' ) + 
									"041BANRISUL" + 
									" ".PadLeft ( 7, ' ' ) + 
									DateTime.Now.Day.ToString("00") + 
									DateTime.Now.Month.ToString("00") + 
									( DateTime.Now.Year - 2000 ).ToString("00") + 
									" ".PadLeft ( 294, ' ' ) + 
									"000001";
					
					port.setValue ( "line" , header );
					
					sb_content.Append ( MemorySave ( ref port ) );
					sb_content.Append ( "," );
				}
				#endregion
				
				while ( fat.fetch() )
				{
					if ( fat.get_fk_empresa() != Context.FALSE )
					{
						if ( !emp.selectIdentity ( fat.get_fk_empresa() ) )
							return false;
	
						if ( emp.get_tg_tipoCobranca() !=  TipoCobranca.Doc )
							continue;
					}
					else
					{
						if ( !loj.selectIdentity ( fat.get_fk_loja() ) )
							return false;
						
						if ( loj.get_tg_tipoCobranca() !=  TipoCobranca.Doc )
							continue;
					}
					
					bool registroValido = true;
					
					if ( fat.get_int_vr_cobranca() < 500 && fat.get_int_vr_cobranca() > 0 )
					{
						ins_despesa tr = new ins_despesa (this);
						
						tr.input_cont_header = input_cont_header;
						
						if ( fat.get_fk_empresa() != Context.FALSE )
							tr.input_st_codigo = emp.get_st_empresa();
						else
							tr.input_st_codigo = loj.get_st_loja();
						
						tr.input_tg_desconto = Context.FALSE;
						tr.input_vr_cobranca = fat.get_vr_cobranca();
						tr.input_st_extra    = "Adiamento de cobrança";
						
						tr.quiet = true;
						
						tr.RunOnline();
						
						registroValido = false;
					}
					
					if ( fat.get_int_vr_cobranca() == 0 )
						registroValido = false;
					
					if ( registroValido )
					{
						seq++;
						
						StringBuilder sb_line = new StringBuilder();
						
						string dv = fat.get_dt_vencimento().Substring ( 8,2 ) + 	// dia
									fat.get_dt_vencimento().Substring ( 5,2 ) +		// mes
									fat.get_dt_vencimento().Substring ( 2,2 );		// ano
						
						vr_total_tits += fat.get_int_vr_cobranca() + 350;
						
						if ( fat.get_fk_empresa() != Context.FALSE )
						{
							nome   = emp.get_st_social().PadRight 	( 35, ' ' ).Substring ( 0, 35 );
							end    = emp.get_st_endereco().PadRight ( 40, ' ' ).Substring ( 0, 40 );
							cnpj   = emp.get_nu_CNPJ().PadLeft 		( 14, '0' );
							cidade = emp.get_st_cidade().PadRight   ( 15, ' ' ).Substring ( 0, 15 );
							estado = emp.get_st_estado().PadRight   ( 2, ' ' );
							cep    = emp.get_nu_CEP().PadRight   	( 8, '0' );
						}
						else
						{
							nome   = loj.get_st_social().PadRight 	( 35, ' ' ).Substring ( 0, 35 );
							end    = loj.get_st_endereco().PadRight ( 40, ' ' ).Substring ( 0, 40 );
							cnpj   = loj.get_nu_CNPJ().PadLeft 		( 14, '0' );
							cidade = loj.get_st_cidade().PadRight   ( 15, ' ' ).Substring ( 0, 15 );
							estado = loj.get_st_estado().PadRight   ( 2, ' ' );
							cep    = loj.get_nu_CEP().PadRight   	( 8, '0' );
						}
						
						sb_line.Append ( "1"  												);
						sb_line.Append ( "0".PadLeft ( 16, '0' )  							);
						sb_line.Append ( Parametros.Cedente.PadLeft ( 12, '0' ) 			);
						sb_line.Append ( "0".PadLeft ( 8, '0' )  							);
						sb_line.Append ( fat.get_identity().PadRight ( 25, ' ' ) 		 	); // ??? Dados de retorno
						sb_line.Append ( " ".PadLeft ( 10, ' ' )  							);
						sb_line.Append ( "Multa de 10% após vencto.".PadRight ( 32, ' ' ) 	); // Msg imp no bloqueto
						sb_line.Append ( " ".PadLeft (  3, ' ' )  							);
						sb_line.Append ( "1"  												); // tipo de carteira
						sb_line.Append ( "01"  												); // código de ocorrência
						sb_line.Append ( fat.get_identity().ToString().PadRight ( 10, ' ' ) ); // seu numero
						sb_line.Append ( dv 												); // dia vencimento
						sb_line.Append ( fat.get_vr_cobranca().PadLeft ( 13, '0' ) 			);
						sb_line.Append ( "041"												); // banco
						sb_line.Append ( " ".PadLeft ( 5, ' ' ) 							);
						sb_line.Append ( "06" 												); // cobrança escritural
						sb_line.Append ( "N"						 						); // aceite
						sb_line.Append ( DateTime.Now.Day.ToString	 ("00") 				);
						sb_line.Append ( DateTime.Now.Month.ToString ("00") 				);
						sb_line.Append ( ( DateTime.Now.Year - 2000 ).ToString ("00") 		);
						sb_line.Append ( "09" 												); // código de protesto! (09) protestar (15) devolver
						sb_line.Append ( "  " 												);
						sb_line.Append ( "0" 												); // codigo de mora (0) diario (1) mensal
						sb_line.Append ( "0".PadLeft ( 12, '0' ) 							); // valor juros diario
						sb_line.Append ( "0".PadLeft ( 6, '0' ) 							); // data desconto antecipado
						sb_line.Append ( "0".PadLeft ( 13, '0' ) 							); // valor desconto
						sb_line.Append ( "0".PadLeft ( 13, '0' ) 							); // valor iof
						sb_line.Append ( "0".PadLeft ( 13, '0' ) 							); // abatimento
						sb_line.Append ( "02" 												); // tipo de inscrição CNPJ			
						sb_line.Append ( cnpj 												); 
						sb_line.Append ( nome 												); 	
						sb_line.Append ( " ".PadLeft ( 5, ' ' ) 							);
						sb_line.Append ( end 												);
						sb_line.Append ( " ".PadLeft ( 7, ' ' ) 							);
						sb_line.Append ( "0".PadLeft ( 3, '0' ) 							);
						sb_line.Append ( "0".PadLeft ( 2, '0' ) 							);
						sb_line.Append ( cep 												); 
						sb_line.Append ( cidade 											);
						sb_line.Append ( estado 											);
						sb_line.Append ( "0".PadLeft ( 4, '0' ) 							);
						sb_line.Append ( " "												);
						sb_line.Append ( "0".PadLeft ( 13, '0' ) 							);
						sb_line.Append ( "15"												);
						sb_line.Append ( " ".PadLeft ( 23, ' ' ) 							);
						sb_line.Append ( seq.ToString().PadLeft ( 6, '0' ) 					);
										
						DataPortable port = new DataPortable();
						
						port.setValue ( "line" , sb_line.ToString() );
						
						sb_content.Append ( MemorySave ( ref port ) );
						sb_content.Append ( "," );
					}
					
					fat_upd.ExclusiveAccess();
					
					if ( !fat_upd.selectIdentity  ( fat.get_identity() 	) )
						return false;
					
					if ( registroValido )
						fat_upd.set_tg_situacao ( TipoSitFat.EmCobrança );
					else
						fat_upd.set_tg_situacao ( TipoSitFat.PagoDoc );
					
					if ( !fat_upd.synchronize_T_Faturamento() )
						return false;
					
					fat_upd.ReleaseExclusive();
				}
				
				// ## TRAILER
				{
					DataPortable port = new DataPortable();
								
					string trailer = "9" + 
									 " ".PadLeft ( 26, ' ' ) + 
									 vr_total_tits.ToString().PadLeft ( 13, '0' ) + 
						             " ".PadLeft ( 354, ' ' ) + 
									 seq.ToString("000000");
						            				
					port.setValue ( "line" , trailer );
					
					sb_content.Append ( MemorySave ( ref port ) );
					sb_content.Append ( "," );
				}
				
				#endregion
			}
			else
			{
				#region - DÉBITO EM CONTA -
				
				long seq = 1;
				long vr_total_tits = 0;
				
				string conta_deb = "";			
				string dt_venc   = "";			
								
				LOG_NSA l_nsa = new LOG_NSA (this);
				
				l_nsa.set_dt_log ( GetDataBaseTime() );
				
				l_nsa.create_LOG_NSA();
				
				#region - HEADER -
				{
					DataPortable port = new DataPortable();
								
					string header = "A1" + 
									Parametros.ConvenioDebConta 				+ 
						            " ".PadLeft ( 15, ' ' ) 					+ 
									"Starfiche".PadRight ( 20,' ') 				+ 
									"041BANRISUL".PadRight ( 23, ' ' )  		+
									DateTime.Now.Year.ToString("0000")			+
									DateTime.Now.Month.ToString("00") 			+ 
									DateTime.Now.Day.ToString("00") 			+ 
									l_nsa.get_identity().PadLeft ( 6, '0' ) 	+
									"04DEBITOAUTOMATICO".PadRight ( 69, ' ' );
														
					port.setValue ( "line" , header );
					
					sb_content.Append ( MemorySave ( ref port ) );
					sb_content.Append ( "," );
				}
				#endregion
				
				while ( fat.fetch() )
				{
					if ( fat.get_fk_empresa() != Context.FALSE )
					{
						if ( !emp.selectIdentity ( fat.get_fk_empresa() ) )
							return false;
	
						if ( emp.get_tg_tipoCobranca() == TipoCobranca.Doc )
							continue;
						
						if ( emp.get_int_nu_bancoFat() != 41 )
							continue;
						
						conta_deb = emp.get_nu_contaDeb();
					}
					else
					{
						if ( !loj.selectIdentity ( fat.get_fk_loja() ) )
							return false;
						
						if ( loj.get_tg_tipoCobranca() ==  TipoCobranca.Doc )
							continue;
						
						if ( loj.get_int_nu_bancoFat() != 41 )
							continue;
						
						conta_deb = loj.get_nu_contaDeb();
					}
					
					dt_venc   = fat.get_dt_vencimento().Substring ( 0,4 ) + 
								fat.get_dt_vencimento().Substring ( 5,2 ) +	
								fat.get_dt_vencimento().Substring ( 8,2 );
					
					vr_total_tits += fat.get_int_vr_cobranca();
					
					StringBuilder sb_line = new StringBuilder();
					
					sb_line.Append ( "E" 										);
					sb_line.Append ( fat.get_identity().PadRight ( 25, ' ' ) 	);
					sb_line.Append ( conta_deb.PadRight ( 14, ' ' ) 			);
					sb_line.Append ( " ".PadRight ( 4, ' ' ) 					);
					sb_line.Append ( dt_venc									);
					sb_line.Append ( fat.get_vr_cobranca().PadLeft ( 15, '0' ) 	);
					sb_line.Append ( "03" 										);
					sb_line.Append ( fat.get_identity().PadRight ( 60, ' ' ) 	);
					sb_line.Append ( " ".PadRight ( 20, ' ' )					);
					sb_line.Append ( "0"										);
					
					DataPortable port = new DataPortable();
					
					port.setValue ( "line" , sb_line.ToString() );
					
					sb_content.Append ( MemorySave ( ref port ) );
					sb_content.Append ( "," );
					
					fat_upd.ExclusiveAccess();
					
					if ( !fat_upd.selectIdentity  ( fat.get_identity() 	) )
						return false;
					
					fat_upd.set_tg_situacao ( TipoSitFat.EmCobrança );
					
					if ( !fat_upd.synchronize_T_Faturamento() )
						return false;
					
					fat_upd.ReleaseExclusive();
				}
				
				#region - TRAILER -
				{
					++seq;
					
					DataPortable port = new DataPortable();
								
					string trailer = "Z" + seq.ToString().PadLeft ( 6, '0' ) + 
									 vr_total_tits.ToString().PadLeft ( 17, '0' ) + 
						             " ".PadLeft ( 126, ' ' );
						            				
					port.setValue ( "line" , trailer );
					
					sb_content.Append ( MemorySave ( ref port ) );
					sb_content.Append ( "," );
				}
				#endregion
				
				#endregion
			}
					
			string list_ids = sb_content.ToString().TrimEnd ( ',' );
			
			if ( list_ids == "" )
			{
				PublishNote ( "Nenhum resultado foi encontrado" );
				return true;
			}
											
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
			
			output_st_msg = MemorySave ( ref dp );
			
			
			
			LOG_NS_FAT l_nsFat = new LOG_NS_FAT (this);
			
			l_nsFat.set_dt_log ( GetDataBaseTime() );
			
			l_nsFat.create_LOG_NS_FAT();
			
			output_nu_nsFat = l_nsFat.get_identity();
			
						
			// Limpa avisos do ins_despesa
			this.objection.Clear();
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_arquivoFat " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_arquivoFat " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_arquivoFat " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_ARQUIVOFAT.st_msg, output_st_msg ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_ARQUIVOFAT.nu_nsFat, output_nu_nsFat ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
