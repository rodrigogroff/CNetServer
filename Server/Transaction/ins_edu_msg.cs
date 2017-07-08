using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class ins_edu_msg : type_base
	{
		public DadosEduMessage input_cont_dem = new DadosEduMessage();
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public ins_edu_msg ( Transaction trans ) : base (trans)
		{
			var_Alias = "ins_edu_msg";
			constructor();
		}
		
		public ins_edu_msg()
		{
			var_Alias = "ins_edu_msg";
		
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
			Registry ( "setup ins_edu_msg " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_INS_EDU_MSG.dem, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_INS_EDU_MSG.dem missing! " ); 
				return false;
			}
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_INS_EDU_MSG.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_INS_EDU_MSG.header missing! " ); 
				return false;
			}
			
			input_cont_dem.Import ( ct_0 );
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done ins_edu_msg " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate ins_edu_msg " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done ins_edu_msg " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute ins_edu_msg " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( user.get_st_empresa() ) )
				return false;
			
			if ( !emp.fetch() )
				return false;
			
			T_MensagemEdu msg = new T_MensagemEdu (this);
			
			msg.set_fk_empresa ( emp.get_identity() 			);
			msg.set_st_mens    ( input_cont_dem.get_st_msg() 	);
			msg.set_dt_ini     ( input_cont_dem.get_dt_start() 	);
			msg.set_dt_fim     ( input_cont_dem.get_dt_end() 	);
			                    
			if ( !msg.create_T_MensagemEdu() )
				return false;
			
			PublishNote ( "Mensagem gravada com sucesso" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done ins_edu_msg " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish ins_edu_msg " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done ins_edu_msg " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
