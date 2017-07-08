using System;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_listaAuditoria : type_base
	{
		public string input_st_csv_auditoria = "";
		
		public ArrayList output_array_generic_list = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_listaAuditoria ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_listaAuditoria";
		}
		
		public fetch_listaAuditoria()
		{
			var_Alias = "fetch_listaAuditoria";
		
			dbProcedure = DB_PROCEDURE.on_demand;
		
			ut_max = 0;
			
			/// USER [ constructor ]
			/// USER [ constructor ] END
		}
		
		public override bool setup ( ) 
		{
			Registry ( "setup fetch_listaAuditoria " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_LISTAAUDITORIA.st_csv_auditoria, ref input_st_csv_auditoria ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_LISTAAUDITORIA.st_csv_auditoria missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_LISTAAUDITORIA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_LISTAAUDITORIA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_listaAuditoria " ); 
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_listaAuditoria " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_listaAuditoria " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_listaAuditoria " ); 
		
			/// USER [ execute ]
			
			LOG_Audit aud = new LOG_Audit (this);
			
			for ( int t=0; t < var_util.indexCSV ( input_st_csv_auditoria ); ++t )
			{
				if ( !aud.selectIdentity ( var_util.getCSV ( t ) ) )
					return false;
				
				if ( !user.selectIdentity ( aud.get_fk_usuario() ) )
					return false;
				
				DadosAuditoria da = new DadosAuditoria();
				
				da.set_dt_operacao 	( aud.get_dt_operacao() 	);
				da.set_st_usuario   ( user.get_st_nome() 		);
				da.set_nu_oper		( aud.get_tg_operacao()		);
				da.set_st_obs		( aud.get_st_observacao() 	);
				da.set_id_link		( aud.get_fk_generic() 		);

				output_array_generic_list.Add ( da );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_listaAuditoria " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish fetch_listaAuditoria " ); 
		
			DataPortable dp_array_generic_list = new DataPortable();
		
			dp_array_generic_list.MapTagArray ( COMM_OUT_FETCH_LISTAAUDITORIA.list , ref output_array_generic_list );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_list );
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_listaAuditoria " ); 
		
			return true;
		}
	}
}
