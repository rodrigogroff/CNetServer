using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_relFat : type_base
	{
		public string input_st_dt_ini = "";
		public string input_st_dt_fim = "";
		public string input_tg_type = "";
		
		public string output_st_total = "";
		public string output_st_content_block = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_relFat ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_relFat";
			constructor();
		}
		
		public fetch_relFat()
		{
			var_Alias = "fetch_relFat";
		
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
			Registry ( "setup fetch_relFat " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_RELFAT.st_dt_ini, ref input_st_dt_ini ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_RELFAT.st_dt_ini missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_RELFAT.st_dt_fim, ref input_st_dt_fim ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_RELFAT.st_dt_fim missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_RELFAT.tg_type, ref input_tg_type ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_RELFAT.tg_type missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_RELFAT.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_RELFAT.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_relFat " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_relFat " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_relFat " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_relFat " ); 
		
			/// USER [ execute ]
			
			T_Faturamento fat = new T_Faturamento (this);
			
			if ( !fat.select_rows_dt_venc ( input_st_dt_ini, 
			                                input_st_dt_fim,
			                                input_tg_type ) )
			{
				PublishError ( "Nenhum registro encontrado" );
				return false;
			}
			
			T_Empresa 		emp 	= new T_Empresa	(this);
			T_Loja 			loj 	= new T_Loja	(this);
			T_RetCobranca 	ret_cob = new T_RetCobranca (this);
			
			string nome = "";	
			long total_cob = 0;
			
			StringBuilder sb_content = new StringBuilder();
			
			while ( fat.fetch() )
			{
				if ( input_tg_type == TipoSitFat.PagoDoc ||
				     input_tg_type == TipoSitFat.PagoCC )
					if ( fat.get_tg_retBanco() == "0" )
						continue;
				
				Rel_FatCompleto rel = new Rel_FatCompleto();
				
				
				
				if ( fat.get_fk_empresa() != Context.FALSE )
				{
					if ( !emp.selectIdentity ( fat.get_fk_empresa() ) )
						return false;
					
					if ( emp.get_tg_isentoFat() == Context.TRUE )
						continue;
					
					nome = "(E) " + emp.get_st_social();
					
					ret_cob.select_rows_cod ( emp.get_nu_bancoFat(), 
					                          fat.get_tg_retBanco(), 
					                          emp.get_tg_tipoCobranca() );
					
					total_cob += fat.get_int_vr_cobranca();
				}
				else
				{
					if ( !loj.selectIdentity ( fat.get_fk_loja() ) )
						return false;
					
					nome = "(L) [" + loj.get_st_loja() + "] " + loj.get_st_social() + " - " + loj.get_st_nome();
					
					if ( loj.get_tg_isentoFat() == Context.TRUE )
						nome = "(ISENTO) " + nome;
					else
						total_cob += fat.get_int_vr_cobranca();
					
					ret_cob.select_rows_cod ( loj.get_nu_bancoFat(), 
					                          fat.get_tg_retBanco(), 
					                          loj.get_tg_tipoCobranca() );
				}
				
				ret_cob.fetch();
				
				rel.set_st_nome 		( nome 						);
				rel.set_vr_cobranca 	( fat.get_vr_cobranca() 	);
				rel.set_dt_vencimento 	( fat.get_dt_vencimento() 	);
				
				if ( fat.get_tg_situacao() != TipoSitFat.EmCobrança )
				{
					rel.set_dt_baixa	    ( fat.get_dt_baixa() 		);
					rel.set_cod_retBanco	( fat.get_tg_retBanco()		);
					rel.set_st_msgBanco		( ret_cob.get_st_codMsg()	);
				}
				
				DataPortable port = rel as DataPortable;
				
				sb_content.Append ( MemorySave ( ref port ) 	);
				sb_content.Append ( "," 						);
			}
			
			output_st_total = total_cob.ToString();
			
			// content
			{
				string list_ids = sb_content.ToString().TrimEnd ( ',' );
				
				if ( list_ids == "" )
				{
					PublishError ( "Nenhum registro encontrado" );
					return false;
				}
				else
				{
					DataPortable dp = new DataPortable();
					
					dp.setValue ( "ids", list_ids );
								  
					output_st_content_block = MemorySave ( ref dp );
				}
			}
						
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_relFat " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_relFat " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_relFat " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_RELFAT.st_total, output_st_total ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_RELFAT.st_content_block, output_st_content_block ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
