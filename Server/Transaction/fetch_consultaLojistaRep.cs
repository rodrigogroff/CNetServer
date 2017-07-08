using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_consultaLojistaRep : Transaction
	{
		public string input_cnpj = "";
		public string input_pass = "";
		public string input_mes = "";
		public string input_ano = "";
		public string input_empresa = "";
		
		public string output_st_content = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_consultaLojistaRep ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_consultaLojistaRep";
			constructor();
		}
		
		public fetch_consultaLojistaRep()
		{
			var_Alias = "fetch_consultaLojistaRep";
		
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
			Registry ( "setup fetch_consultaLojistaRep " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CONSULTALOJISTAREP.cnpj, ref input_cnpj ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CONSULTALOJISTAREP.cnpj missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CONSULTALOJISTAREP.pass, ref input_pass ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CONSULTALOJISTAREP.pass missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CONSULTALOJISTAREP.mes, ref input_mes ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CONSULTALOJISTAREP.mes missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CONSULTALOJISTAREP.ano, ref input_ano ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CONSULTALOJISTAREP.ano missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CONSULTALOJISTAREP.empresa, ref input_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CONSULTALOJISTAREP.empresa missing! " ); 
				return false;
			}
			
			Registry ( "setup done fetch_consultaLojistaRep " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate fetch_consultaLojistaRep " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_consultaLojistaRep " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute fetch_consultaLojistaRep " ); 
		
			/// USER [ execute ]
			
			T_Loja loj = new T_Loja (this);
			
			if ( !loj.select_rows_loja ( input_cnpj ) )
			{
				PublishError ( "Cnpj não disponível" );
				return false;
			}
			
			if ( !loj.fetch() )
				return false;
			
			if ( loj.get_st_senha() != input_pass )
			{
				PublishError ( "Senha inválida" );
				return false;
			}
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_empresa.PadLeft ( 6, '0' ) ) )
			{
				PublishError ( "Empresa não disponível" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			LINK_LojaEmpresa lje = new LINK_LojaEmpresa (this);
			
			if ( !lje.select_fk_empresa_loja ( emp.get_identity(), loj.get_identity() ) )
			{
				PublishError ( "Loja não conveniada com associação" );
				return false;
			}
			
			if ( !lje.fetch() )
				return false;
			
			double 	 tx   = lje.get_int_tx_admin();
			
			T_Cartao 		cart = new T_Cartao (this);
			T_Parcelas      parc = new T_Parcelas (this);
			LOG_Transacoes 	ltr  = new LOG_Transacoes (this);
			LOG_Fechamento 	lf   = new LOG_Fechamento (this);
			
			StringBuilder 	sb = new StringBuilder();
			
			if ( lf.select_rows_mes_ano ( input_mes.PadLeft ( 2, '0'),
			                              input_ano.PadLeft ( 2, '0'),
			                              emp.get_identity() ) )
			{
				if ( lf.RowCount() > 0 )
				{
					while ( lf.fetch() )
					{
						if  ( lf.get_fk_loja() != loj.get_identity() )
							continue;
						
						if ( !parc.selectIdentity ( lf.get_fk_parcela() ) )
							return false;
						
						if ( !ltr.selectIdentity ( parc.get_fk_log_transacoes() ) )
						    return false;
						
						if ( !emp.selectIdentity ( ltr.get_fk_empresa() ) )
					    	return false;
						
						if ( !cart.selectIdentity ( ltr.get_fk_cartao() ) )
							return false;
						
						DadosConsultaTransacao dct = new DadosConsultaTransacao ();
						
						dct.set_dt_transacao ( ltr.get_dt_transacao() 	);
						dct.set_st_nsu       ( ltr.get_nu_nsu()			);
						dct.set_nu_parcelas  ( parc.get_nu_indice() 	);
						
						dct.set_st_cartao    ( cart.get_st_empresa() 	+ "." + 
						                       cart.get_st_matricula() 	+ "." + 
						                       cart.get_st_titularidade() );
						
						dct.set_vr_valor	 ( ltr.get_vr_total()		);
						
						long repasse = Convert.ToInt64 ( lf.get_int_vr_valor() - 
						                               ( lf.get_int_vr_valor() * tx / 10000 ) );
						
						dct.set_vr_repasse ( repasse.ToString() );
						
						DataPortable tmp = dct as DataPortable;
						
						sb.Append ( MemorySave ( ref tmp ) );
						sb.Append ( "," 				   );
					}
				}
			}
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
			
			if ( list_ids == "" )
			{
				PublishNote ( "Nenhum resultado foi encontrado" );
				return true;
			}
											
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
			
			output_st_content = MemorySave ( ref dp );
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_consultaLojistaRep " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish fetch_consultaLojistaRep " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_consultaLojistaRep " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_CONSULTALOJISTAREP.st_content, output_st_content ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
