using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_consultaLojista : Transaction
	{
		public string input_cnpj = "";
		public string input_dt_ini = "";
		public string input_dt_fim = "";
		public string input_pass = "";
		
		public string output_st_content = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_consultaLojista ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_consultaLojista";
			constructor();
		}
		
		public fetch_consultaLojista()
		{
			var_Alias = "fetch_consultaLojista";
		
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
			Registry ( "setup fetch_consultaLojista " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CONSULTALOJISTA.cnpj, ref input_cnpj ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CONSULTALOJISTA.cnpj missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CONSULTALOJISTA.dt_ini, ref input_dt_ini ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CONSULTALOJISTA.dt_ini missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CONSULTALOJISTA.dt_fim, ref input_dt_fim ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CONSULTALOJISTA.dt_fim missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CONSULTALOJISTA.pass, ref input_pass ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CONSULTALOJISTA.pass missing! " ); 
				return false;
			}
			
			Registry ( "setup done fetch_consultaLojista " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate fetch_consultaLojista " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_consultaLojista " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute fetch_consultaLojista " ); 
		
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
			
			LOG_Transacoes ltr = new LOG_Transacoes (this);
			
			T_Cartao   		cart = new T_Cartao (this);
			T_Empresa  		emp  = new T_Empresa (this);
			
			StringBuilder 	sb = new StringBuilder();
			
			if ( ltr.select_rows_dt_loj ( input_dt_ini, input_dt_fim, loj.get_identity() ) )
			{
				while ( ltr.fetch() )
				{
					if ( !emp.selectIdentity ( ltr.get_fk_empresa() ) )
					    continue;
					
					if ( !cart.selectIdentity ( ltr.get_fk_cartao() ) )
						continue;
					
					DadosConsultaTransacao dct = new DadosConsultaTransacao ();
					
					dct.set_dt_transacao ( ltr.get_dt_transacao() 	);
					dct.set_st_nsu       ( ltr.get_nu_nsu()			);
					dct.set_vr_valor	 ( ltr.get_vr_total()		);
					dct.set_nu_parcelas  ( ltr.get_nu_parcelas()	);
					dct.set_tg_status	 ( ltr.get_tg_confirmada()  );
					
					dct.set_st_cartao    ( cart.get_st_empresa() 	+ "." + 
					                       cart.get_st_matricula() 	+ "." + 
					                       cart.get_st_titularidade() );
					
					dct.set_st_cod_empresa ( emp.get_st_empresa() );
					
					DataPortable tmp = dct as DataPortable;
					
					sb.Append ( MemorySave ( ref tmp ) );
					sb.Append ( "," 				   );
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
			
			// ## Obtem indexador geral
						  
			output_st_content = MemorySave ( ref dp );
						
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_consultaLojista " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish fetch_consultaLojista " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_consultaLojista " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_CONSULTALOJISTA.st_content, output_st_content ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
