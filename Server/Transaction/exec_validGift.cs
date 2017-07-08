using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_validGift : type_base
	{
		public string input_st_acesso = "";
		public string input_st_empresa = "";
		public string input_st_matricula = "";
		public string input_tg_recarga = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_validGift ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_validGift";
			constructor();
		}
		
		public exec_validGift()
		{
			var_Alias = "exec_validGift";
		
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
			Registry ( "setup exec_validGift " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_VALIDGIFT.st_acesso, ref input_st_acesso ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_VALIDGIFT.st_acesso missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_VALIDGIFT.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_VALIDGIFT.st_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_VALIDGIFT.st_matricula, ref input_st_matricula ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_VALIDGIFT.st_matricula missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_VALIDGIFT.tg_recarga, ref input_tg_recarga ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_VALIDGIFT.tg_recarga missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_VALIDGIFT.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_VALIDGIFT.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_validGift " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_validGift " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_validGift " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_validGift " ); 
		
			/// USER [ execute ]
			
			T_Cartao cart = new T_Cartao (this);
			
			input_st_empresa = input_st_empresa.PadLeft ( 6, '0' );
			input_st_matricula = input_st_matricula.PadLeft ( 6, '0' );
			
			if ( !cart.select_rows_empresa_matricula ( input_st_empresa,
			                                           input_st_matricula ) )
           	{
				PublishError ( "Cartão não disponível" );
           		return false;
           	}
			
			if ( !cart.fetch() )
				return false;
			
			ApplicationUtil util = new ApplicationUtil();
			
			string cod_acesso = util.calculaCodigoAcesso ( 	cart.get_st_empresa(),
							          							cart.get_st_matricula(),
							          							cart.get_st_venctoCartao() );
			
			Trace ( cod_acesso );
			
			if ( input_st_acesso != cod_acesso )
			{
				PublishError ( "Código de acesso inválido" );
				return false;
			}
			
			if ( input_tg_recarga == Context.TRUE )
			{
				if ( cart.get_fk_dadosProprietario() == Context.NONE )
				{
					PublishError ( "Cartão previamente adquirido" );
					return false;
				}	
			}
						
			/// USER [ execute ] END
		
			Registry ( "execute done exec_validGift " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_validGift " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_validGift " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
