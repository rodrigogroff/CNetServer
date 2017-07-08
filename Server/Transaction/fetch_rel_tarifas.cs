using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_rel_tarifas : type_base
	{
		public string output_st_csv = "";
		public string output_st_csv_emp = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_rel_tarifas ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_rel_tarifas";
			constructor();
		}
		
		public fetch_rel_tarifas()
		{
			var_Alias = "fetch_rel_tarifas";
		
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
			Registry ( "setup fetch_rel_tarifas " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_FETCH_REL_TARIFAS.header, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_REL_TARIFAS.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_0 );
			
			Registry ( "setup done fetch_rel_tarifas " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_rel_tarifas " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_rel_tarifas " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_rel_tarifas " ); 
		
			/// USER [ execute ]
			
			StringBuilder sb_emp = new StringBuilder();
			StringBuilder sb_content = new StringBuilder();
			
			money mon_help = new money();
						
			T_Empresa emp = new T_Empresa (this);
			
			emp.select_rows_tarifas();
		
			while ( emp.fetch() )
			{
				DadosEmpresa de = new DadosEmpresa();
				
				de.set_st_fantasia ( "(E) "  + emp.get_st_empresa() + " " + emp.get_st_fantasia() );
				
				DataPortable tmp = de as DataPortable;
					
				sb_emp.Append ( MemorySave ( ref tmp ) );
				sb_emp.Append ( "," 						 );

				{
					Rel_Tarifas rt = new Rel_Tarifas();
				
					rt.set_st_emp ( de.get_st_fantasia() );
					//rt.set_st_desc ( "Empresa" );
					rt.set_st_val  ( emp.get_st_fantasia() );
					
					DataPortable port_rt = rt as DataPortable;
					
					sb_content.Append ( MemorySave ( ref port_rt )   );
					sb_content.Append ( "," 						 );
				}
				
				{
					Rel_Tarifas rt = new Rel_Tarifas();
				
					rt.set_st_emp ( de.get_st_fantasia() );
					//rt.set_st_desc ( "Mensalidade" );
					rt.set_st_val  ( mon_help.formatToMoney ( emp.get_vr_mensalidade() ) );
					
					DataPortable port_rt = rt as DataPortable;
					
					sb_content.Append ( MemorySave ( ref port_rt )   );
					sb_content.Append ( "," 						 );
				}
				
				{
					Rel_Tarifas rt = new Rel_Tarifas();
				
					rt.set_st_emp ( de.get_st_fantasia() );
					//rt.set_st_desc ( "Percentual sobre transação" );
					
					string pct = emp.get_nu_pctValor().PadLeft ( 3, '0' );
					
					pct = pct.Insert ( pct.Length - 2, "," ) + "%";
					
					rt.set_st_val  ( pct );
					
					DataPortable port_rt = rt as DataPortable;
					
					sb_content.Append ( MemorySave ( ref port_rt )   );
					sb_content.Append ( "," 						 );
				}
				
				{
					Rel_Tarifas rt = new Rel_Tarifas();
				
					rt.set_st_emp ( de.get_st_fantasia() );
					//rt.set_st_desc ( "Valor transação" );
					rt.set_st_val  ( mon_help.formatToMoney ( emp.get_vr_transacao() ) );
					
					DataPortable port_rt = rt as DataPortable;
					
					sb_content.Append ( MemorySave ( ref port_rt )   );
					sb_content.Append ( "," 						 );
				}
				
				{
					Rel_Tarifas rt = new Rel_Tarifas();
				
					rt.set_st_emp ( de.get_st_fantasia() );
					//rt.set_st_desc ( "Valor mínimo" );
					rt.set_st_val  ( mon_help.formatToMoney ( emp.get_vr_minimo() ) );
					
					DataPortable port_rt = rt as DataPortable;
					
					sb_content.Append ( MemorySave ( ref port_rt )   );
					sb_content.Append ( "," 						 );
				}
				
				{
					Rel_Tarifas rt = new Rel_Tarifas();
				
					rt.set_st_emp ( de.get_st_fantasia() );
					//rt.set_st_desc ( "Franquia de transações" );
					rt.set_st_val  ( emp.get_nu_franquia() );
					
					DataPortable port_rt = rt as DataPortable;
					
					sb_content.Append ( MemorySave ( ref port_rt )   );
					sb_content.Append ( "," 						 );
				}
				
				{
					Rel_Tarifas rt = new Rel_Tarifas();
				
					rt.set_st_emp ( de.get_st_fantasia() );
					//rt.set_st_desc ( "Valor por cartão ativo" );
					rt.set_st_val  ( mon_help.formatToMoney (  emp.get_vr_cartaoAtivo() ) );
					
					DataPortable port_rt = rt as DataPortable;
					
					sb_content.Append ( MemorySave ( ref port_rt )   );
					sb_content.Append ( "," 						 );
				}
				
				{
					Rel_Tarifas rt = new Rel_Tarifas();
				
					rt.set_st_emp ( de.get_st_fantasia() );
					//rt.set_st_desc ( "Isento de Fatura" );
					
					if ( emp.get_tg_isentoFat() == Context.TRUE )
						rt.set_st_val  ( "SIM" );
					else
						rt.set_st_val  ( "NÃO" );
					
					DataPortable port_rt = rt as DataPortable;
					
					sb_content.Append ( MemorySave ( ref port_rt )   );
					sb_content.Append ( "," 						 );
				}
				
				{
					Rel_Tarifas rt = new Rel_Tarifas();
				
					rt.set_st_emp ( de.get_st_fantasia() );
					//rt.set_st_desc ( "Situação" );
					
					if ( emp.get_tg_blocked() == Context.TRUE )
						rt.set_st_val  ( "Bloq." );	
					else
						rt.set_st_val  ( "Ativo" );
					
					DataPortable port_rt = rt as DataPortable;
					
					sb_content.Append ( MemorySave ( ref port_rt )   );
					sb_content.Append ( "," 						 );
				}
			}
			
			T_Loja loj = new T_Loja (this);
			
			loj.select_rows_tarifas();
		
			while ( loj.fetch() )
			{
				DadosEmpresa de = new DadosEmpresa();
				
				string id = "(" + loj.get_st_loja() + ") CNPJ: " + loj.get_nu_CNPJ() + " " + loj.get_st_nome() + " - " + loj.get_st_social();
				
				de.set_st_fantasia ( id );
				
				DataPortable tmp = de as DataPortable;
					
				sb_emp.Append ( MemorySave ( ref tmp ) );
				sb_emp.Append ( "," 				   );

				{
					Rel_Tarifas rt = new Rel_Tarifas();
				
					rt.set_st_emp ( de.get_st_fantasia() );
					//rt.set_st_desc ( "Empresa" );
					rt.set_st_val  ( id );
					
					DataPortable port_rt = rt as DataPortable;
					
					sb_content.Append ( MemorySave ( ref port_rt )   );
					sb_content.Append ( "," 						 );
				}
				
				{
					Rel_Tarifas rt = new Rel_Tarifas();
				
					rt.set_st_emp ( id );
					//rt.set_st_desc ( "Mensalidade" );
					rt.set_st_val  ( mon_help.formatToMoney ( loj.get_vr_mensalidade() ) );
					
					DataPortable port_rt = rt as DataPortable;
					
					sb_content.Append ( MemorySave ( ref port_rt )   );
					sb_content.Append ( "," 						 );
				}
				
				{
					Rel_Tarifas rt = new Rel_Tarifas();
				
					rt.set_st_emp ( id );
					//rt.set_st_desc ( "Percentual sobre transação" );
					
					string pct = loj.get_nu_pctValor().PadLeft ( 3, '0' );
					
					pct = pct.Insert ( pct.Length - 2, "," ) + "%";
					
					rt.set_st_val  ( pct );
					
					DataPortable port_rt = rt as DataPortable;
					
					sb_content.Append ( MemorySave ( ref port_rt )   );
					sb_content.Append ( "," 						 );
				}
				
				{
					Rel_Tarifas rt = new Rel_Tarifas();
				
					rt.set_st_emp ( id );
					//rt.set_st_desc ( "Valor transação" );
					rt.set_st_val  ( mon_help.formatToMoney ( loj.get_vr_transacao() ) );
					
					DataPortable port_rt = rt as DataPortable;
					
					sb_content.Append ( MemorySave ( ref port_rt )   );
					sb_content.Append ( "," 						 );
				}
				
				{
					Rel_Tarifas rt = new Rel_Tarifas();
				
					rt.set_st_emp ( id );
					//rt.set_st_desc ( "Valor mínimo" );
					rt.set_st_val  ( mon_help.formatToMoney ( loj.get_vr_minimo() ) );
					
					DataPortable port_rt = rt as DataPortable;
					
					sb_content.Append ( MemorySave ( ref port_rt )   );
					sb_content.Append ( "," 						 );
				}
				
				{
					Rel_Tarifas rt = new Rel_Tarifas();
				
					rt.set_st_emp ( id );
					//rt.set_st_desc ( "Franquia de transações" );
					rt.set_st_val  ( loj.get_nu_franquia() );
					
					DataPortable port_rt = rt as DataPortable;
					
					sb_content.Append ( MemorySave ( ref port_rt )   );
					sb_content.Append ( "," 						 );
				}
				
				{
					Rel_Tarifas rt = new Rel_Tarifas();
				
					rt.set_st_emp ( de.get_st_fantasia() );
					//rt.set_st_desc ( "Valor por cartão ativo" );
					rt.set_st_val  ( "0" );
					
					DataPortable port_rt = rt as DataPortable;
					
					sb_content.Append ( MemorySave ( ref port_rt )   );
					sb_content.Append ( "," 						 );
				}
				
				{
					Rel_Tarifas rt = new Rel_Tarifas();
				
					rt.set_st_emp ( id );
					//rt.set_st_desc ( "Isento de Fatura" );
					
					if ( loj.get_tg_isentoFat() == Context.TRUE )
						rt.set_st_val  ( "SIM" );
					else
						rt.set_st_val  ( "NÃO" );
					
					DataPortable port_rt = rt as DataPortable;
					
					sb_content.Append ( MemorySave ( ref port_rt )   );
					sb_content.Append ( "," 						 );
				}
				
				{
					Rel_Tarifas rt = new Rel_Tarifas();
				
					rt.set_st_emp ( de.get_st_fantasia() );
					//rt.set_st_desc ( "Situação" );
					
					if ( loj.get_tg_blocked() == Context.TRUE )
						rt.set_st_val  ( "Bloq." );	
					else
						rt.set_st_val  ( "Ativo" );
					
					if ( loj.get_tg_cancel() == Context.TRUE )
						rt.set_st_val  ( "Cancel." );
					
					DataPortable port_rt = rt as DataPortable;
					
					sb_content.Append ( MemorySave ( ref port_rt )   );
					sb_content.Append ( "," 						 );
				}
			}
			
			// content
			{
				string list_ids = sb_content.ToString().TrimEnd ( ',' );
									
				DataPortable dp = new DataPortable();
				
				dp.setValue ( "ids", list_ids );
							  
				output_st_csv = MemorySave ( ref dp );
			}
			
			// entidades
			{
				string list_ids = sb_emp.ToString().TrimEnd ( ',' );
									
				DataPortable dp = new DataPortable();
				
				dp.setValue ( "ids", list_ids );
							  
				output_st_csv_emp = MemorySave ( ref dp );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_rel_tarifas " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_rel_tarifas " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_rel_tarifas " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_TARIFAS.st_csv, output_st_csv ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_TARIFAS.st_csv_emp, output_st_csv_emp ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
