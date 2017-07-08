using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_cotaExtraEmpresa : type_base
	{
		public string input_emp = "";
		public string input_valor = "";
		public string input_csv_excluded = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_cotaExtraEmpresa ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_cotaExtraEmpresa";
			constructor();
		}
		
		public exec_cotaExtraEmpresa()
		{
			var_Alias = "exec_cotaExtraEmpresa";
		
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
			Registry ( "setup exec_cotaExtraEmpresa " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_COTAEXTRAEMPRESA.emp, ref input_emp ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_COTAEXTRAEMPRESA.emp missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_COTAEXTRAEMPRESA.valor, ref input_valor ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_COTAEXTRAEMPRESA.valor missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_COTAEXTRAEMPRESA.csv_excluded, ref input_csv_excluded ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_COTAEXTRAEMPRESA.csv_excluded missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_COTAEXTRAEMPRESA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_COTAEXTRAEMPRESA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_cotaExtraEmpresa " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_cotaExtraEmpresa " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_cotaExtraEmpresa " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_cotaExtraEmpresa " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa ( this );
			
			if ( !emp.select_rows_empresa ( input_emp.PadLeft ( 6, '0' ) ) )
				return false;
			
			if ( !emp.fetch() )
				return false;
			
			ApplicationUtil var_util = new ApplicationUtil();
			
			T_Cartao cart = new T_Cartao ( this );
			T_Cartao cart_upd = new T_Cartao ( this );
			
			if ( cart.select_rows_empresa ( input_emp.PadLeft ( 6, '0' ) ) )
			{
				while ( cart.fetch() )
				{
					if ( input_csv_excluded.Contains ( cart.get_st_matricula() ) )
						continue;
					
					if ( cart.get_tg_status() != CartaoStatus.Habilitado )
						continue;
					
					cart_upd.ExclusiveAccess();
					
					cart_upd.selectIdentity ( cart.get_identity() );
					cart_upd.set_vr_extraCota ( input_valor );
					
					cart_upd.synchronize_T_Cartao();
					cart_upd.ReleaseExclusive();		
				}
			}
			
			int tot = var_util.indexCSV ( input_csv_excluded );
			
			for ( int t=0; t < tot; ++t )
			{
				cart_upd.ExclusiveAccess();
					
				cart_upd.select_rows_empresa_matricula ( input_emp.PadLeft ( 6, '0' ), var_util.getCSV (t) );
				cart_upd.fetch();
				cart_upd.set_vr_extraCota ( "0" );
				
				cart_upd.synchronize_T_Cartao();
				cart_upd.ReleaseExclusive();		
			}
			
			PublishNote ( "Cota extra aplicada com sucesso!\nEstes valores serão zerados no próximo fechamento mensal." );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_cotaExtraEmpresa " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_cotaExtraEmpresa " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.CotaExtraMensal      		);
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( "Empresa " + input_emp + " Valor: " + new money().formatToMoney(input_valor) );
				
				aud.set_fk_generic  ( 0 );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}

			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_cotaExtraEmpresa " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
