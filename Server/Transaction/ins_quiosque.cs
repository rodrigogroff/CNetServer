using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class ins_quiosque : type_base
	{
		public string input_st_empresa = "";
		public string input_st_desc = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public ins_quiosque ( Transaction trans ) : base (trans)
		{
			var_Alias = "ins_quiosque";
			constructor();
		}
		
		public ins_quiosque()
		{
			var_Alias = "ins_quiosque";
		
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
			Registry ( "setup ins_quiosque " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_QUIOSQUE.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_INS_QUIOSQUE.st_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_QUIOSQUE.st_desc, ref input_st_desc ) == false ) 
			{
				Trace ( "# COMM_IN_INS_QUIOSQUE.st_desc missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_INS_QUIOSQUE.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_INS_QUIOSQUE.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done ins_quiosque " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate ins_quiosque " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done ins_quiosque " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute ins_quiosque " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_st_empresa.PadLeft ( 6, '0' ) ) )
			{
				PublishError ( "Empresa não disponível" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			T_Quiosque q = new T_Quiosque (this);
			
			if ( q.select_fk_empresa ( emp.get_identity() ) )
			{
				while ( q.fetch() )
				{
					if ( q.get_st_nome() == input_st_desc )
					{
						PublishError ( "Quiosque inválido" );
						return false;
					}
				}
			}
			
			q.set_st_nome 	 ( input_st_desc 		);
			q.set_fk_empresa ( emp.get_identity() 	);
			
			if ( !q.create_T_Quiosque() )
				return false;
			
			PublishNote ( "Quiosque " + input_st_desc + " criado com sucesso" );			
			
			/// USER [ execute ] END
		
			Registry ( "execute done ins_quiosque " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish ins_quiosque " ); 
		
			/// USER [ finish ]
		
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.CadNovoQuiosque      );
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				aud.set_st_observacao ( "" );
				
				aud.set_fk_generic  ( 0 );
				
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done ins_quiosque " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
