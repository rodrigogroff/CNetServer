using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_rel_5_rle : type_base
	{
		public string input_st_empresa = "";
		public string input_st_dt_ini = "";
		public string input_st_dt_fim = "";
		
		public string output_st_total = "";
		public string output_st_total_cancelado = "";
		public string output_st_csv_subtotal = "";
		public string output_st_csv_subtotal_cancelado = "";
		public string output_st_csv = "";
		public string output_st_nome_empresa = "";
		
		public ArrayList output_array_generic_lstLojas = new ArrayList(); 
		
		/// USER [ var_decl ]
		
		LOG_Transacoes 	l_tr;
		T_Empresa  		emp;
		T_Loja  		loj;
		
		/// USER [ var_decl ] END
		
		public fetch_rel_5_rle ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_rel_5_rle";
			constructor();
		}
		
		public fetch_rel_5_rle()
		{
			var_Alias = "fetch_rel_5_rle";
		
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
			Registry ( "setup fetch_rel_5_rle " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_5_RLE.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_5_RLE.st_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_5_RLE.st_dt_ini, ref input_st_dt_ini ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_5_RLE.st_dt_ini missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_5_RLE.st_dt_fim, ref input_st_dt_fim ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_5_RLE.st_dt_fim missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_REL_5_RLE.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_REL_5_RLE.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_rel_5_rle " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_rel_5_rle " ); 
		
			/// USER [ authenticate ]
			
			if ( input_st_empresa.Length == 0 )
			{
				PublishError ( "Empresa inválida" );
				return false;
			}
			
			input_st_empresa = input_st_empresa.PadLeft ( 6, '0' );
			
			emp  = new T_Empresa      (this);
			loj  = new T_Loja         (this);
			l_tr = new LOG_Transacoes (this);
			
			// # Busca Empresa
			
			if ( !emp.select_rows_empresa ( input_st_empresa ) )
			{
				PublishError ( "Empresa inválida" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			output_st_nome_empresa = emp.get_st_fantasia();
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_rel_5_rle " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_rel_5_rle " ); 
		
			/// USER [ execute ]
			
			
			// # Disabilita escrita em disco
			// # AVISO: somente por motivos de performance
			// # Somente recomendado para relatórios em produção
			
			SQL_LOGGING_ENABLE = false;
			
			StringBuilder sb = new StringBuilder();
			
			Hashtable hsh_loja_confirmada = new Hashtable();
			Hashtable hsh_loja_cancelada  = new Hashtable();
			
			Hashtable hsh_loja = new Hashtable(); // guarda se container foi gerado
			ArrayList tmp_loja = new ArrayList(); // lista de  lojas
			
			long 	vr_sub_confirmada = 0, 
					vr_sub_cancelada  = 0,
					vr_tot_confirmada = 0,
					vr_tot_cancelada  = 0;
					
			LINK_LojaEmpresa 	link = new LINK_LojaEmpresa (this);
			T_Cartao 			cart = new T_Cartao (this);
			
			string id = "";
				
			// # Busca todos os convênios de uma empresa
			
			if ( link.select_fk_empresa_geral ( emp.get_identity() ) )
			{
				while ( link.fetch() )
				{
					loj.Reset();
					
					if ( !loj.selectIdentity ( link.get_fk_loja() ) )
						continue;
					
					id = loj.get_identity();
					
					#region - identifico a loja - 
					
					if ( hsh_loja [ id ] == null )
					{
						DadosLoja dl = new DadosLoja();
						
						dl.set_st_loja ( id 				);
						dl.set_st_nome ( "(" + loj.get_st_loja() + ") " + loj.get_st_nome() 	);
						
						output_array_generic_lstLojas.Add ( dl );
						
						tmp_loja.Add ( id );						
						hsh_loja [ id ] = 1;
					}
					
					#endregion
					
					if ( !l_tr.select_rows_dt_loj  ( input_st_dt_ini, 
					                                 input_st_dt_fim, 
					                                 id ) )
						continue;
					
					T_Parcelas parc = new T_Parcelas (this);
					
					while ( l_tr.fetch() )
					{
						if ( !cart.selectIdentity ( l_tr.get_fk_cartao() ) )
							continue;
						
						if ( cart.get_st_empresa() != input_st_empresa )
							continue;
						
						#region - contabiliza - 
						
						if ( l_tr.get_tg_contabil() == Context.TRUE )
						{
							long cur_val = l_tr.get_int_vr_total();
							
							if ( l_tr.get_tg_confirmada() == TipoConfirmacao.Confirmada )
							{
								if ( hsh_loja_confirmada [ id ] == null )
									vr_sub_confirmada  = (long) 0;
								else
									vr_sub_confirmada  = (long) hsh_loja_confirmada [ id ];
													
								vr_tot_confirmada += cur_val;
								
								hsh_loja_confirmada [ id ] = vr_sub_confirmada + cur_val;
							}
							else if ( l_tr.get_tg_confirmada() == TipoConfirmacao.Cancelada )
							{
								if ( hsh_loja_cancelada [ id ] == null )
									vr_sub_cancelada  = (long) 0;
								else
									vr_sub_cancelada  = (long) hsh_loja_cancelada [ id ];
								
								vr_tot_cancelada += cur_val;
								
								hsh_loja_cancelada [ id ] = vr_sub_cancelada + cur_val;
							}
						}
						
						#endregion
											
						Rel_RLE rle = new Rel_RLE();
				
						#region - atribui ao container - 
												
						rle.set_st_cartao 	 ( cart.get_st_empresa()   + "." +
							                   cart.get_st_matricula() + "." +  
						                       cart.get_st_titularidade() );
						
						rle.set_st_nsu	 	 ( l_tr.get_nu_nsu()			);
						rle.set_vr_total	 ( l_tr.get_vr_total() 			);
						rle.set_nu_parc 	 ( l_tr.get_nu_parcelas() 		);
						
						if ( parc.select_fk_log_trans ( l_tr.get_identity() ) )
							if ( parc.fetch() )
								rle.set_st_nsu	( l_tr.get_nu_nsu() );
						
						rle.set_dt_trans  	 ( l_tr.get_dt_transacao() 		);
						rle.set_tg_status 	 ( l_tr.get_tg_confirmada() 	);
						rle.set_st_motivo 	 ( l_tr.get_st_msg_transacao() 	);
						rle.set_en_op_cartao ( l_tr.get_en_operacao()		);
						rle.set_st_loja  	 ( id				 			);
						
						#endregion						
										
						DataPortable mem_rle = rle as DataPortable;
						
						// # Guarda registro
						
						sb.Append ( MemorySave ( ref mem_rle ) ); 
						sb.Append ( "," );						
					}
				}				
				
				string list_ids = sb.ToString().TrimEnd ( ',' );
									
				DataPortable dp = new DataPortable();
				
				dp.setValue ( "ids", list_ids );
							 
				// # Guarda todos os registros
				
				output_st_csv = MemorySave ( ref dp );
				
				#region - calcula totais - 
				
				long value_sub = 0;
			
				for ( int t=0; t < tmp_loja.Count; ++t )
				{
					id = tmp_loja[t] as string;
					
					if ( hsh_loja_confirmada [ id ] == null )	hsh_loja_confirmada [ id ]  = (long) 0;
					if ( hsh_loja_cancelada  [ id ] == null )	hsh_loja_cancelada  [ id ]  = (long) 0;
					
					value_sub = (long) hsh_loja_confirmada [ id ];
									
					output_st_csv_subtotal += value_sub.ToString() + ",";
					
					value_sub = (long) hsh_loja_cancelada [ id ];
					
					output_st_csv_subtotal_cancelado += value_sub.ToString() + ",";
				}
				
				#endregion
				
				output_st_csv_subtotal           = output_st_csv_subtotal.TrimEnd ( ',' );
				output_st_csv_subtotal_cancelado = output_st_csv_subtotal_cancelado.TrimEnd ( ',' );
				output_st_total                  = vr_tot_confirmada.ToString();
				output_st_total_cancelado        = vr_tot_cancelada.ToString();	
			}
			                                   
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_rel_5_rle " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_rel_5_rle " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_rel_5_rle " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_5_RLE.st_total, output_st_total ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_5_RLE.st_total_cancelado, output_st_total_cancelado ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_5_RLE.st_csv_subtotal, output_st_csv_subtotal ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_5_RLE.st_csv_subtotal_cancelado, output_st_csv_subtotal_cancelado ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_5_RLE.st_csv, output_st_csv ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_5_RLE.st_nome_empresa, output_st_nome_empresa ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			DataPortable dp_array_generic_lstLojas = new DataPortable();
		
			dp_array_generic_lstLojas.MapTagArray ( COMM_OUT_FETCH_REL_5_RLE.lstLojas , ref output_array_generic_lstLojas );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lstLojas );
		
			return true;
		}
	}
}
