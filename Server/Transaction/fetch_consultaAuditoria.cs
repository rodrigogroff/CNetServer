using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_consultaAuditoria : type_base
	{
		public DadosConsultaAuditoria input_cont_dca = new DadosConsultaAuditoria();
		
		public string output_st_csv_audit = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_consultaAuditoria ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_consultaAuditoria";
			constructor();
		}
		
		public fetch_consultaAuditoria()
		{
			var_Alias = "fetch_consultaAuditoria";
		
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
			Registry ( "setup fetch_consultaAuditoria " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_FETCH_CONSULTAAUDITORIA.dca, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CONSULTAAUDITORIA.dca missing! " ); 
				return false;
			}
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_CONSULTAAUDITORIA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CONSULTAAUDITORIA.header missing! " ); 
				return false;
			}
			
			input_cont_dca.Import ( ct_0 );
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_consultaAuditoria " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_consultaAuditoria " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_consultaAuditoria " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_consultaAuditoria " ); 
		
			/// USER [ execute ]
			
			StringBuilder sb = new StringBuilder();
			
			string 	obs  = input_cont_dca.get_st_obs(),
					nome = input_cont_dca.get_st_user();
			
			long 	nu_oper  = 0,
					val 	 = 0;
			
			// ## Se existe operador específico
					
			if ( input_cont_dca.get_nu_oper().Length > 0 )	
				nu_oper = Convert.ToInt32 ( input_cont_dca.get_nu_oper() );
			
			LOG_Audit aud_log = new LOG_Audit (this);
			
			bool ReqObs = true;
			bool ReqNome = true;
			
			if ( obs.Length == 0 )		ReqObs = false;
			if ( nome.Length == 0 )		ReqNome = false;
			
			// ## Para datas especificas
			
			if ( input_cont_dca.get_dt_ini().Length > 0 && 
			     input_cont_dca.get_dt_fim().Length > 0 )
			{
				if ( !aud_log.select_rows_dt_ini_fim ( 	input_cont_dca.get_dt_ini(), 
				                                 	input_cont_dca.get_dt_fim() ) )
					return true;
			}
			
			// ## Se somente data de inicio
			
			else if ( input_cont_dca.get_dt_ini().Length > 0 )
			{
				if ( !aud_log.select_rows_dt_ini ( input_cont_dca.get_dt_ini() ) )
					return true;
			}
			
			// ## Se somente data final
			
			else if ( input_cont_dca.get_dt_fim().Length > 0 )
			{
				if ( !aud_log.select_rows_dt_fim ( input_cont_dca.get_dt_fim() ) )
					return true;
			}
			
			// ## Se tiver alguma obs especifica
			
			else if ( obs.Length > 0 )
			{
				ReqObs = false;
				
				if ( !aud_log.select_rows_obs ( obs ) )
					return true;
			}
			
			// ## Seleciona tudo...
			
			else
			{
				if ( !aud_log.selectAll () )
					return true;
			}
			
			// ## Tabela auxiliar de operadores
			
			Hashtable hshOpers = new Hashtable();
			
			if ( user.get_tg_nivel() == TipoUsuario.Administrador || 
			     user.get_tg_nivel() == TipoUsuario.AdminGift )
			{
				// ## Para caso de administradores, filtrar somente
				// ## transações de seus usuários
				
				T_Usuario user_tb = new T_Usuario (this);
				
				if ( user_tb.select_rows_empresa ( user.get_st_empresa() ) )
				{
					while ( user_tb.fetch() )
					{
						// ## indexa
						
						hshOpers [ user_tb.get_identity() ] = "*";
					}
				}
			}
			
			// ## busca registros selecionados
			
			while ( aud_log.fetch() )
			{
				val = aud_log.get_int_tg_operacao();
				
				// ## Confere se operador está dentro de uma
				// ## determinada empresa
				
				if ( hshOpers.Count > 0 )
					if ( hshOpers [ aud_log.get_fk_usuario() ] == null )
						continue;
				
				// ## Confere operador especifico
				
				if ( nu_oper > 0 ) 		
					if ( val != nu_oper ) 	
						continue;
				
				// ## Confere se Obs deve ser filtrada
				
				if ( ReqObs )
					if ( !aud_log.get_st_observacao().Contains ( obs ) )	
						continue;
				
				// ## Busca usuário em questão
				
				if ( !user.selectIdentity ( aud_log.get_fk_usuario() ) )
					continue;
				
				// ## Se for nome em especifico
				
				if ( ReqNome )
				{
					if ( !user.get_st_nome().Contains ( nome ) ) 
						continue;
				}
				
				// ## Copia dados para memória
				
				DadosAuditoria da = new DadosAuditoria();
									
				da.set_nu_oper		( aud_log.get_tg_operacao() 	);
				da.set_dt_operacao	( aud_log.get_dt_operacao() 	);
				da.set_st_usuario	( user.get_st_nome()			);
				da.set_st_obs		( aud_log.get_st_observacao() 	);
				da.set_id_link		( aud_log.get_fk_generic() 		);
				
				DataPortable tmp = da as DataPortable;
				
				sb.Append ( MemorySave ( ref tmp ) );
				sb.Append ( "," 				 	  );
			}
			
			// ## gera bloco de identificadores
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
			
			if ( list_ids == "" )
			{
				PublishNote ( "Nenhum resultado foi encontrado" );
				return true;
			}
						
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
						  
			output_st_csv_audit = MemorySave ( ref dp );
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_consultaAuditoria " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_consultaAuditoria " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_consultaAuditoria " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_CONSULTAAUDITORIA.st_csv_audit, output_st_csv_audit ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
