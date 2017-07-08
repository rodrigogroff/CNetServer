using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class ins_dependente : type_base
	{
		public string input_st_empresa = "";
		public string input_st_matricula = "";
		public string input_st_dependente = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public ins_dependente ( Transaction trans ) : base (trans)
		{
			var_Alias = "ins_dependente";
			constructor();
		}
		
		public ins_dependente()
		{
			var_Alias = "ins_dependente";
		
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
			Registry ( "setup ins_dependente " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_DEPENDENTE.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_INS_DEPENDENTE.st_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_DEPENDENTE.st_matricula, ref input_st_matricula ) == false ) 
			{
				Trace ( "# COMM_IN_INS_DEPENDENTE.st_matricula missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_DEPENDENTE.st_dependente, ref input_st_dependente ) == false ) 
			{
				Trace ( "# COMM_IN_INS_DEPENDENTE.st_dependente missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_INS_DEPENDENTE.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_INS_DEPENDENTE.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done ins_dependente " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate ins_dependente " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done ins_dependente " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute ins_dependente " ); 
		
			/// USER [ execute ]
			
			input_st_empresa  	= input_st_empresa.PadLeft 	( 6, '0' );
			input_st_matricula  = input_st_matricula.PadLeft ( 6, '0' );
			
			T_Cartao cart = new T_Cartao (this);
			
			if ( !cart.select_rows_tudo ( input_st_empresa, 
			                              input_st_matricula, 
			                              "01" ) )
			{
				PublishError ( "Cartão proprietário inexistente" );
				return false;
			}
			
			if ( !cart.fetch() )
				return false;
			
			T_Cartao cart_dep = new T_Cartao (this);
				
			cart_dep.copy ( ref cart );
			
			int tit = 0;
			
			T_Cartao cart_f = new T_Cartao (this);
			
			if ( cart_f.select_rows_empresa_matricula ( input_st_empresa, 
			                                            input_st_matricula ) )
			{
				while ( cart_f.fetch() )
					++tit;
			}
			
			++tit;
						
			cart_dep.set_st_titularidade ( tit.ToString().PadLeft ( 2, '0' ) 	);
			cart_dep.set_tg_emitido 	 ( StatusExpedicao.NaoExpedido 			);
			cart_dep.set_nu_viaCartao 	 ( 1 									);
			
			if ( !cart_dep.create_T_Cartao() )
				return false;
			
			T_Dependente dep = new T_Dependente (this);
			
			dep.Reset();
							
			dep.set_nu_titularidade ( tit.ToString().PadLeft ( 2, '0' ) );
			dep.set_st_nome 		( input_st_dependente				);
			dep.set_fk_proprietario ( cart.get_fk_dadosProprietario() 	);

			if ( !dep.create_T_Dependente () )
				return false;
			
			PublishNote ( "Dependente '" + 
			              input_st_dependente + 
			              "' de cartão " + 
			              input_st_matricula + 
			              " criado com sucesso" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done ins_dependente " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish ins_dependente " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.CadDepenCart    );
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( "" );
				
				aud.set_fk_generic  ( 0 );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done ins_dependente " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
