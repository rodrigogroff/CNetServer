using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_edu_messages : type_base
	{
		public string output_st_content = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_edu_messages ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_edu_messages";
			constructor();
		}
		
		public fetch_edu_messages()
		{
			var_Alias = "fetch_edu_messages";
		
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
			Registry ( "setup fetch_edu_messages " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_FETCH_EDU_MESSAGES.header, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_EDU_MESSAGES.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_0 );
			
			Registry ( "setup done fetch_edu_messages " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_edu_messages " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_edu_messages " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_edu_messages " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( user.get_st_empresa() ) )
				return false;
			
			if ( !emp.fetch() )
				return false;
			
			T_MensagemEdu msg = new T_MensagemEdu (this);
			
			if ( !msg.select_rows_empresa ( emp.get_identity() ) )
			{
				PublishError ( "Nenhuma mensagem gravada" );
				return false;
			}
			
			StringBuilder sb = new StringBuilder();
			
			msg.SetReversedFetch();
			
			while ( msg.fetch() )
			{
				DadosEduMessage dem = new DadosEduMessage();
				
				dem.set_id_mem 		( msg.get_identity() 	);
				dem.set_st_msg 		( msg.get_st_mens() 	);
				dem.set_dt_start 	( msg.get_dt_ini() 		);
				dem.set_dt_end  	( msg.get_dt_fim() 		);
				
				DataPortable mem_dem = dem as DataPortable;
				
				sb.Append ( MemorySave ( ref mem_dem ) );
				sb.Append ( ","   );			
			}
			
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", sb.ToString().TrimEnd ( ',' ) );
						
			output_st_content = MemorySave ( ref dp );
						
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_edu_messages " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_edu_messages " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_edu_messages " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_EDU_MESSAGES.st_content, output_st_content ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
