using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_limitesCartao : type_base
	{
		public string input_st_cpf = "";
		
		public string output_st_csv_cartoes = "";
		
		/// USER [ var_decl ]
		
		T_Proprietario 			prot;
				
		/// USER [ var_decl ] END
		
		public fetch_limitesCartao ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_limitesCartao";
			constructor();
		}
		
		public fetch_limitesCartao()
		{
			var_Alias = "fetch_limitesCartao";
		
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
			Registry ( "setup fetch_limitesCartao " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_LIMITESCARTAO.st_cpf, ref input_st_cpf ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_LIMITESCARTAO.st_cpf missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_LIMITESCARTAO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_LIMITESCARTAO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_limitesCartao " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_limitesCartao " ); 
		
			/// USER [ authenticate ]
			
			// ## Busca proprietário pelo CPF
			
			prot = new T_Proprietario (this);
			
			if ( !prot.select_rows_cpf ( input_st_cpf ) )
			{
				PublishError ( "CPF inválido" );
				return false;
			}
			
			if ( !prot.fetch() )
				return false;
						
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_limitesCartao " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_limitesCartao " ); 
		
			/// USER [ execute ]
			
			T_Cartao cart = new T_Cartao (this);
			
			if ( !cart.select_rows_prop ( prot.get_identity() ) )
			{
				PublishError ( "Nenhum cartão registrado para o cpf" );
				return false;
			}
			
			StringBuilder sb = new StringBuilder();
			
			bool verificaEmpresa = true;			
			
			string empresa = user.get_st_empresa();
					
			if ( input_cont_header.get_tg_user_type() == TipoUsuario.SuperUser )
				verificaEmpresa = false;
			
			while ( cart.fetch() )
			{
				// ## Somente cartões da empresa (administradores)
				
				if ( verificaEmpresa )
					if ( cart.get_st_empresa() != empresa )
						continue;
				
				// ## Somente cartões do tipo empresarial
				
				if ( cart.get_tg_tipoCartao() != TipoCartao.empresarial )
					continue;
				
				if ( cart.get_st_titularidade() != "01" )
					continue;
				
				// ## Copia dados para memória
				
				DadosCartao dc = new DadosCartao();
	
				dc.set_st_empresa	 		( cart.get_st_empresa() 		);
				dc.set_st_matricula		 	( cart.get_st_matricula() 		);
				dc.set_tg_status	 		( cart.get_tg_status() 			);
				dc.set_st_vencimento 		( cart.get_st_venctoCartao() 	);
				dc.set_vr_limiteTotal 		( cart.get_vr_limiteTotal() 	);
				dc.set_vr_limiteMensal 		( cart.get_vr_limiteMensal() 	);
				dc.set_vr_extraCota 		( cart.get_vr_extraCota()	 	);
				dc.set_vr_limiteRotativo 	( cart.get_vr_limiteRotativo() 	);
				dc.set_st_proprietario		( prot.get_st_nome() 			);
				                         
				DataPortable mem = dc as DataPortable;
				
				// ## obtem indexador
				
				sb.Append ( MemorySave ( ref mem ) );
				sb.Append ( ","   );
			}
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
									
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
						  
			output_st_csv_cartoes = MemorySave ( ref dp );

			/// USER [ execute ] END
		
			Registry ( "execute done fetch_limitesCartao " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_limitesCartao " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_limitesCartao " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_LIMITESCARTAO.st_csv_cartoes, output_st_csv_cartoes ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
