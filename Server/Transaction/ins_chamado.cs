using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class ins_chamado : type_base
	{
		public DadosChamado input_cont_dc = new DadosChamado();
		
		/// USER [ var_decl ]
		
		T_Loja loj;
				
		/// USER [ var_decl ] END
		
		public ins_chamado ( Transaction trans ) : base (trans)
		{
			var_Alias = "ins_chamado";
			constructor();
		}
		
		public ins_chamado()
		{
			var_Alias = "ins_chamado";
		
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
			Registry ( "setup ins_chamado " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_INS_CHAMADO.dc, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_INS_CHAMADO.dc missing! " ); 
				return false;
			}
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_INS_CHAMADO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_INS_CHAMADO.header missing! " ); 
				return false;
			}
			
			input_cont_dc.Import ( ct_0 );
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done ins_chamado " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate ins_chamado " ); 
		
			/// USER [ authenticate ]
			
			loj = new T_Loja (this);
						
			if ( !loj.select_rows_loja ( input_cont_dc.get_st_cod_loja() ) )
			{
				PublishError ( "Loja inexistente" );
				return false;
			}
			
			if ( !loj.fetch() )
				return false;
						
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done ins_chamado " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute ins_chamado " ); 
		
			/// USER [ execute ]
			
			T_Chamado cham = new T_Chamado (this);
			
			cham.set_dt_abertura	 	( GetDataBaseTime() 				);
			cham.set_fk_loja    		( loj.get_identity() 				);
			cham.set_fk_operador 		( user.get_identity()				);
			cham.set_fk_oper_criador	( user.get_identity()				);
			cham.set_tg_fechado	 		( Context.FALSE 					);
			cham.set_nu_prioridade 		( input_cont_dc.get_nu_prioridade() );
			cham.set_nu_categoria		( input_cont_dc.get_nu_categ() 		);
			cham.set_st_motivo			( input_cont_dc.get_st_motivo()		);
			cham.set_tg_tecnico    		( input_cont_dc.get_tg_tecnico() 	);
			
			if ( !cham.create_T_Chamado() )
				return false;
			
			LOG_Chamado l_c = new LOG_Chamado (this);
			
			l_c.set_fk_chamado 	( cham.get_identity() 		);
			l_c.set_fk_operador ( user.get_identity() 		);
			l_c.set_dt_solucao  ( cham.get_dt_abertura() 	);
			l_c.set_st_solucao  ( "## Criação do chamado" 	);
			
			if ( !l_c.create_LOG_Chamado() )
				return false;
			
			PublishNote ( "Chamado criado com sucesso!" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done ins_chamado " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish ins_chamado " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.CadChamadoConvey   );
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( "" );
				
				aud.set_fk_generic  ( 0 );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done ins_chamado " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
