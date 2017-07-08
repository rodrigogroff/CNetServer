using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_repasseLoja : type_base
	{
		public string input_st_codLoja = "";
		public string input_tg_opcao = "";
		public string input_st_ident = "";
		public string input_vr_valor = "";
		
		public ArrayList input_array_generic_lstPar = new ArrayList();
		
		public string output_id_confRepasse = "";
		
		/// USER [ var_decl ]
		
		T_Loja loj;
		
		/// USER [ var_decl ] END
		
		public exec_repasseLoja ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_repasseLoja";
			constructor();
		}
		
		public exec_repasseLoja()
		{
			var_Alias = "exec_repasseLoja";
		
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
			Registry ( "setup exec_repasseLoja " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_REPASSELOJA.st_codLoja, ref input_st_codLoja ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_REPASSELOJA.st_codLoja missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_REPASSELOJA.tg_opcao, ref input_tg_opcao ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_REPASSELOJA.tg_opcao missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_REPASSELOJA.st_ident, ref input_st_ident ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_REPASSELOJA.st_ident missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_REPASSELOJA.vr_valor, ref input_vr_valor ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_REPASSELOJA.vr_valor missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_REPASSELOJA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_REPASSELOJA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			DataPortable dp_array_generic_lstPar = var_Comm.GetEntryPortableAtPosition ( 2 );
			
			if ( dp_array_generic_lstPar.GetMapArray ( COMM_IN_EXEC_REPASSELOJA.lstPar , ref input_array_generic_lstPar ) == false )
			{
				Trace ( "# COMM_IN_EXEC_REPASSELOJA.lstPar missing! " ); 
				return false;
			}
			
			Registry ( "setup done exec_repasseLoja " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_repasseLoja " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_repasseLoja " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_repasseLoja " ); 
		
			/// USER [ execute ]
			
			loj = new T_Loja (this);
			
			if ( !loj.select_rows_loja ( input_st_codLoja ) )
				return false;
			
			if ( !loj.fetch() )
				return false;
			
			T_RepasseLoja rl = new T_RepasseLoja (this);
			
			rl.set_dt_efetiva ( GetDataBaseTime() 	);
			rl.set_fk_loja    ( loj.get_identity() 	);
			rl.set_st_ident	  ( input_st_ident 		);
			rl.set_tg_opcao	  ( input_tg_opcao		);
			rl.set_vr_valor	  ( input_vr_valor		);
			
			if ( !rl.create_T_RepasseLoja() )
				return false;
			
			output_id_confRepasse = rl.get_identity();
			
			LINK_RepasseParcela lrp = new LINK_RepasseParcela (this);
			
			T_Parcelas parc = new T_Parcelas (this);
			
			for ( int t=0; t < input_array_generic_lstPar.Count; ++t )
			{
				DadosRepasse dr = new DadosRepasse ( input_array_generic_lstPar[t] as DataPortable );
				
				if ( dr.get_tg_confirmado() == Context.FALSE )
					continue;
				
				parc.ExclusiveAccess();
				
				if ( !parc.selectIdentity ( dr.get_id_parcela() ) )
					return false;
				
				// esta parcela foi repassada
				parc.set_tg_pago ( Context.TRUE );
				
				if ( !parc.synchronize_T_Parcelas() )
					return false;
				
				parc.ReleaseExclusive();
				
				lrp.set_fk_parcela ( parc.get_identity() );
				lrp.set_fk_repasseLoja ( rl.get_identity() );
				
				if ( !lrp.create_LINK_RepasseParcela() )
					return false;
			}
			
			PublishNote ( "Repasse feito com sucesso" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_repasseLoja " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_repasseLoja " ); 
		
			/// USER [ finish ]

			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.RepasseLojaGift         		);
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( loj.get_st_loja() );
				
				aud.set_fk_generic  ( 0 );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_repasseLoja " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_EXEC_REPASSELOJA.id_confRepasse, output_id_confRepasse ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
