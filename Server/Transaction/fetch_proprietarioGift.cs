using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_proprietarioGift : type_base
	{
		public string input_st_matricula = "";
		
		public DadosProprietario output_cont_dp = new DadosProprietario();
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_proprietarioGift ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_proprietarioGift";
			constructor();
		}
		
		public fetch_proprietarioGift()
		{
			var_Alias = "fetch_proprietarioGift";
		
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
			Registry ( "setup fetch_proprietarioGift " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_PROPRIETARIOGIFT.st_matricula, ref input_st_matricula ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_PROPRIETARIOGIFT.st_matricula missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_PROPRIETARIOGIFT.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_PROPRIETARIOGIFT.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_proprietarioGift " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_proprietarioGift " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_proprietarioGift " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_proprietarioGift " ); 
		
			/// USER [ execute ]
			
			T_Cartao cart = new T_Cartao (this);
			
			if ( !cart.select_rows_empresa_matricula ( input_cont_header.get_st_empresa(), 
			                                           input_st_matricula.PadLeft ( 6, '0' ) ) )
			{
				PublishError ( "Cartão inválido" );
				return false;
			}
			
			if ( !cart.fetch() )
				return false;
			
			if ( cart.get_fk_dadosProprietario() == Context.NONE )
			{
				PublishError ( "Cartão inválido" );
				return false;
			}			
			
			T_Proprietario prot = new T_Proprietario (this);
			
			if ( !prot.selectIdentity ( cart.get_fk_dadosProprietario() ) )
			{
				PublishError ( "Cartão inválido" );
				return false;
			}
			
			output_cont_dp.set_st_nome 		( prot.get_st_nome() 		);
			output_cont_dp.set_st_cpf		( prot.get_st_cpf() 		);
			output_cont_dp.set_st_telefone 	( prot.get_st_telefone() 	);
			output_cont_dp.set_st_endereco 	( prot.get_st_endereco() 	);
						
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_proprietarioGift " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_proprietarioGift " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_proprietarioGift " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_cont_1 = new DataPortable();
		
			dp_cont_1.MapTagContainer ( COMM_OUT_FETCH_PROPRIETARIOGIFT.dp , output_cont_dp as DataPortable );
		
			var_Comm.AddExitPortable ( ref dp_cont_1 ); 
		
			return true;
		}
	}
}
