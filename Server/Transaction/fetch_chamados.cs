using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_chamados : type_base
	{
		public string input_nu_categ = "";
		public string input_nu_prioridade = "";
		public string input_st_operador = "";
		public string input_tg_closed = "";
		public string input_dt_ini_ab = "";
		public string input_dt_fim_ab = "";
		public string input_dt_ini_fech = "";
		public string input_dt_fim_fech = "";
		public string input_tg_tecnico = "";
		public string input_st_loja = "";
		public string input_st_resp = "";
		
		public string output_st_block = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_chamados ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_chamados";
			constructor();
		}
		
		public fetch_chamados()
		{
			var_Alias = "fetch_chamados";
		
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
			Registry ( "setup fetch_chamados " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CHAMADOS.nu_categ, ref input_nu_categ ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CHAMADOS.nu_categ missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CHAMADOS.nu_prioridade, ref input_nu_prioridade ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CHAMADOS.nu_prioridade missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CHAMADOS.st_operador, ref input_st_operador ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CHAMADOS.st_operador missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CHAMADOS.tg_closed, ref input_tg_closed ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CHAMADOS.tg_closed missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CHAMADOS.dt_ini_ab, ref input_dt_ini_ab ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CHAMADOS.dt_ini_ab missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CHAMADOS.dt_fim_ab, ref input_dt_fim_ab ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CHAMADOS.dt_fim_ab missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CHAMADOS.dt_ini_fech, ref input_dt_ini_fech ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CHAMADOS.dt_ini_fech missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CHAMADOS.dt_fim_fech, ref input_dt_fim_fech ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CHAMADOS.dt_fim_fech missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CHAMADOS.tg_tecnico, ref input_tg_tecnico ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CHAMADOS.tg_tecnico missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CHAMADOS.st_loja, ref input_st_loja ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CHAMADOS.st_loja missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CHAMADOS.st_resp, ref input_st_resp ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CHAMADOS.st_resp missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_CHAMADOS.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CHAMADOS.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_chamados " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_chamados " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_chamados " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_chamados " ); 
		
			/// USER [ execute ]
			
			T_Usuario usrConvey = new T_Usuario (this);
			T_Usuario usrConveyCriador = new T_Usuario (this);
			
			if ( input_st_operador.Length > 0 )
			{
				if ( !usrConvey.select_rows_login ( input_st_operador, "000000" ) )
				{
					PublishError ( "Usuário inexistente" );
					return false;
				}
				
				if ( !usrConvey.fetch() )
					return false;
			}
			
			if ( input_st_resp.Length > 0 )
			{
				if ( !usrConveyCriador.select_rows_login ( input_st_resp, "000000" ) )
				{
					PublishError ( "Usuário inexistente" );
					return false;
				}
				
				if ( !usrConveyCriador.fetch() )
					return false;
			}
			
			T_Loja loj = new T_Loja (this);
			
			if ( input_st_loja.Length > 0 )
			{
				if ( !loj.select_rows_loja ( input_st_loja ) )
				{
					PublishError ( "Código de loja inválido" );
					return false;
				}
				
				if ( !loj.fetch() )
					return false;
			}
			
			T_Chamado cham = new T_Chamado (this);
			
			#region - busca pela data - 
			
			if ( 	input_dt_ini_ab.Length   > 0 && 
			    	input_dt_fim_ab.Length   > 0 &&
			    	input_dt_ini_fech.Length > 0 &&
			    	input_dt_fim_fech.Length > 0 )
			{
				if ( !cham.select_rows_abert_fech ( input_dt_ini_ab, 
				            						input_dt_fim_ab, 
				                              		input_dt_ini_fech, 
				                              		input_dt_fim_fech ) )
				{
					PublishError ( "Nenhum registro encontrado" );
					return false;
				}
			}
			else if ( 	input_dt_ini_ab.Length   > 0 && 
			    		input_dt_fim_ab.Length   > 0 &&
			    		input_dt_ini_fech.Length > 0 &&
			    		input_dt_fim_fech.Length == 0  )
			{
				if ( !cham.select_rows_abert_fech ( input_dt_ini_ab, 
				            						input_dt_fim_ab, 
				                              		input_dt_ini_fech ) )
				{
					PublishError ( "Nenhum registro encontrado" );
					return false;
				}
			}
			else if ( 	input_dt_ini_ab.Length   > 0 && 
			    		input_dt_fim_ab.Length   > 0 &&
			    		input_dt_ini_fech.Length == 0 &&
			    		input_dt_fim_fech.Length == 0 )
			{
				if ( !cham.select_rows_abert_fech ( input_dt_ini_ab, 
				            						input_dt_fim_ab 	) )
				{
					PublishError ( "Nenhum registro encontrado" );
					return false;
				}
			}
			else if ( 	input_dt_ini_ab.Length   > 0 && 
			    		input_dt_fim_ab.Length   == 0 &&
			    		input_dt_ini_fech.Length == 0 &&
			    		input_dt_fim_fech.Length == 0 )
			{
				if ( !cham.select_rows_abert_fech ( input_dt_ini_ab	) )
				{
					PublishError ( "Nenhum registro encontrado" );
					return false;
				}
			}
			else if ( 	input_dt_ini_ab.Length   > 0 && 
			    		input_dt_fim_ab.Length   == 0 &&
			    		input_dt_ini_fech.Length > 0 &&
			    		input_dt_fim_fech.Length == 0 )
			{
				if ( !cham.select_rows_abert_fech_ini ( input_dt_ini_ab, 
				                                        input_dt_ini_fech ) )
				{
					PublishError ( "Nenhum registro encontrado" );
					return false;
				}
			}
			else if ( 	input_dt_ini_ab.Length   == 0 && 
			    		input_dt_fim_ab.Length   == 0 &&
			    		input_dt_ini_fech.Length > 0 &&
			    		input_dt_fim_fech.Length == 0 )
			{
				if ( !cham.select_rows_fech ( input_dt_ini_fech ) )
				{
					PublishError ( "Nenhum registro encontrado" );
					return false;
				}
			}
			
			#endregion
						
			StringBuilder sb = new StringBuilder();
			
			while ( cham.fetch() )
			{
				if ( input_st_loja.Length > 0 )
					if ( cham.get_fk_loja() != loj.get_identity() )
						continue;
				
				if ( input_st_operador.Length > 0 )
				{
					if ( cham.get_fk_operador() != usrConvey.get_identity() )
						continue;
				}
				else if ( !usrConvey.selectIdentity ( cham.get_fk_operador() ) )
					continue;
				
				if ( input_st_resp.Length > 0 )
				{
					if ( cham.get_fk_oper_criador() != usrConveyCriador.get_identity() )
						continue;
				}
				else if ( !usrConveyCriador.selectIdentity ( cham.get_fk_oper_criador() ) )
					continue;
								
				if ( input_nu_prioridade != "-1" )
					if ( cham.get_nu_prioridade() != input_nu_prioridade )
						continue;
				
				if ( input_nu_categ != "-1" )
					if ( cham.get_nu_categoria() != input_nu_categ )
						continue;
				
				if ( cham.get_tg_fechado() != input_tg_closed )
					continue;
				
				if ( cham.get_tg_tecnico() != input_tg_tecnico )
					continue;
				
				DadosChamado dc = new DadosChamado();
				
				dc.set_id_chamado   ( cham.get_identity() 				);
				dc.set_st_oper 		( usrConvey.get_st_nome() 			);
				dc.set_st_resp 		( usrConveyCriador.get_st_nome() 	);
				dc.set_dt_ab   		( cham.get_dt_abertura() 			);
				dc.set_st_motivo	( cham.get_st_motivo() 				);
								
				if ( cham.get_tg_fechado() == Context.TRUE )
					dc.set_dt_fech  ( cham.get_dt_fechamento() 	);
				
				DataPortable tmp = dc as DataPortable;
				
				// ## indexa em memória
				
				sb.Append ( MemorySave ( ref tmp ) );
				sb.Append ( "," 				 	  );
			}
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
			
			if ( list_ids == "" )
			{
				PublishNote ( "Nenhum resultado foi encontrado" );
				return true;
			}
											
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
			
			// ## cria indexador de bloco
						  
			output_st_block = MemorySave ( ref dp );
						
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_chamados " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_chamados " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_chamados " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_CHAMADOS.st_block, output_st_block ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
