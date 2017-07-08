using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_processaArqBancario : type_base
	{
		public string input_st_id = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_processaArqBancario ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_processaArqBancario";
			constructor();
		}
		
		public exec_processaArqBancario()
		{
			var_Alias = "exec_processaArqBancario";
		
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
			Registry ( "setup exec_processaArqBancario " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_PROCESSAARQBANCARIO.st_id, ref input_st_id ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_PROCESSAARQBANCARIO.st_id missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_PROCESSAARQBANCARIO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_PROCESSAARQBANCARIO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_processaArqBancario " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_processaArqBancario " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_processaArqBancario " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_processaArqBancario " ); 
		
			/// USER [ execute ]
			
			DataPortable csv_AllArchive = MemoryGet ( input_st_id );
			
			ApplicationUtil var_util = new ApplicationUtil();
			
			string st_ids = csv_AllArchive.getValue ( "ids" );
			
			Trace ( st_ids );
			
			int total_records = var_util.indexCSV ( st_ids );
			
			T_Faturamento fat = new T_Faturamento (this);
			
			for ( int t=0; t < total_records; ++t )
			{
				DataPortable port_line = MemoryGet ( var_util.getCSV (t) );
				
				string line = port_line.getValue ( "line" );
				
				Trace ( line );
				
				int pos = 0;
				
				//7                        
				//06
				//030908
				//7         
				//0509629684          
				//030908
				//0000000002108
				
				string fk   	 = line.Substring ( pos,25 ).Trim();	pos += 25;
				string cod  	 = line.Substring ( pos, 2 ).Trim();	pos += 2;
				string dt_banco  = line.Substring ( pos, 6 ).Trim();	pos += 6;
				string st_seuNum = line.Substring ( pos,10 ).Trim();	pos += 10;
				string st_nosNum = line.Substring ( pos,20 ).Trim();	pos += 20;
				string dt_venc   = line.Substring ( pos, 6 ).Trim();	pos += 6;
				string vr_pago   = line.Substring ( pos,13 ).Trim();	pos += 13;
				
				vr_pago = vr_pago.TrimStart ('0' );
				
				Trace ( line );
				
				fat.ExclusiveAccess();
				
				if ( !fat.selectIdentity ( fk ) )
				{
					Registry ( "Registro " + fk + " desconhecido!" );
					fat.ReleaseExclusive();
					continue;
				}
				
				fat.set_tg_retBanco ( cod );
				
				if ( cod == "00" )
				{
					fat.set_tg_situacao ( TipoSitFat.PagoCC );
				}
								
				if ( cod == "10" )
				{
					fat.set_tg_situacao ( TipoSitFat.BaixaCfeInst );
				}
				
				if ( cod == "06" || 
				     cod == "08" || 
				     cod == "15" || 
				     cod == "25" )
				{
					fat.set_tg_situacao ( TipoSitFat.PagoDoc );
				}
				
				fat.set_dt_baixa ( GetDataBaseTime ( new DateTime ( 2000 + Convert.ToInt32 ( dt_banco.Substring (4,2) ),
				                                                    Convert.ToInt32 ( dt_banco.Substring (2,2) ),
				                                                    Convert.ToInt32 ( dt_banco.Substring (0,2) ) ) ) );
				
				if ( !fat.synchronize_T_Faturamento() )
				{
					Registry ( "Registro " + fk + " não foi possível atualizar!" );
				}
				
				fat.ReleaseExclusive();
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_processaArqBancario " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_processaArqBancario " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.ProcArqBanConvey       		);
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( "" );
				
				aud.set_fk_generic  ( 0 );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done exec_processaArqBancario " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
