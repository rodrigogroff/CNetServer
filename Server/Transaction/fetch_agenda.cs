using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_agenda : type_base
	{
		public string output_st_csv = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_agenda ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_agenda";
			constructor();
		}
		
		public fetch_agenda()
		{
			var_Alias = "fetch_agenda";
		
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
			Registry ( "setup fetch_agenda " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_FETCH_AGENDA.header, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_AGENDA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_0 );
			
			Registry ( "setup done fetch_agenda " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_agenda " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_agenda " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_agenda " ); 
		
			/// USER [ execute ]
			
			LINK_Agenda l_a = new LINK_Agenda (this);
			
			// ## Busca todos os registros de agendamento
			
			if ( l_a.selectAll() )
			{
				StringBuilder sb = new StringBuilder();
				
				T_Empresa emp = new T_Empresa (this);
				I_Scheduler sch = new I_Scheduler (this);
				
				ApplicationUtil var_util = new ApplicationUtil();
								
				while ( l_a.fetch() )
				{
					// ## Cria container de dados
					
					DadosAgenda da = new DadosAgenda();
					
					// ## Valida links para outras tabelas
					
					if ( !emp.selectIdentity ( l_a.get_fk_empresa() ) )
						continue;
					
					if ( !sch.selectIdentity ( l_a.get_fk_schedule() ) )
						continue;
					
					var_util.indexCSV ( sch.get_st_job(), ';' );
					
					string aff = "";
					string job = var_util.getCSV   ( 0 );
					
					if ( sch.get_st_job().IndexOf ( "afiliada" ) > 0 )
						if ( job == "schedule_fech_mensal" )
							aff = " - " + var_util.getCSV ( 4 );
					
					// ## Copia dados
					
					da.set_fk_agenda		( l_a.get_identity() 			);
					da.set_st_empresa 		( emp.get_st_empresa() + aff	);
					da.set_st_nome_empresa 	( emp.get_st_fantasia() 		);
					da.set_en_atividade 	( l_a.get_en_atividade() 		);
					da.set_dt_ultima 		( sch.get_dt_last() 			);
					
					// ## Formata
					
					switch ( sch.get_tg_type() )
					{
						#region - Monthly -
						
						case Scheduler.Monthly:
						{
							da.set_st_info ( 	"Mensal, Dia " + 
								                sch.get_nu_monthly_day() + 
								                ", Hora " + 
								                sch.get_st_monthly_hhmm().Substring (0,2) + 
								                ":" + 
								                sch.get_st_monthly_hhmm().Substring (2,2) );
								
							break;
						}
						
						#endregion
						
						#region - Weekly -
											
						case Scheduler.Weekly:
						{
							string dia = "";
							
							switch ( sch.get_st_weekly_dow() )
							{
								case "0": dia = "Domingo";	break;
								case "1": dia = "Segunda"; 	break;
								case "2": dia = "Terça"; 		break;
								case "3": dia = "Quarta"; 	break;
								case "4": dia = "Quinta"; 	break;
								case "5": dia = "Sexta"; 		break;
								case "6": dia = "Sábado"; 	break;
							}
								
							da.set_st_info ( 	"Semanal, Dia " + 
								                dia + 
								                ", Hora " + 
								                sch.get_st_weekly_hhmm().Substring (0,2) + 
								                ":" + 
								                sch.get_st_weekly_hhmm().Substring (2,2) );
								
							break;
						}
						
						#endregion
							
						#region - Daily -
						
						case Scheduler.Daily:
						{
							da.set_st_info ( 	"Diariamente " +
								                sch.get_st_daily_hhmm().Substring (0,2) + 
								                ":" + 
								                sch.get_st_daily_hhmm().Substring (2,2) );
								
							break;
						}
						
						#endregion
					}
					
					// ## Guarda em memória
					
					DataPortable mem_rtc = da as DataPortable;
				
					sb.Append ( MemorySave ( ref mem_rtc ) 	);
					sb.Append ( ","   							);
				}

				// ## Guarda todos os identificadores em um bloco
				
				string list_ids = sb.ToString().TrimEnd ( ',' );
									
				DataPortable dp = new DataPortable();
				
				dp.setValue ( "ids", list_ids );
				
				// ## Envia para client a identificação do bloco
							  
				output_st_csv = MemorySave ( ref dp );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_agenda " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_agenda " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_agenda " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_AGENDA.st_csv, output_st_csv ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
