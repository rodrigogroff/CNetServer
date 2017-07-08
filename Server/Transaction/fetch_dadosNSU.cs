using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_dadosNSU : type_base
	{
		public string input_st_nsu = "";
		public string input_dt_hoje = "";
		public string input_tg_confirmada = "";
		
		public DadosNSU output_cont_d_nsu = new DadosNSU();
		
		/// USER [ var_decl ]
		
		T_Parcelas parc;
		LOG_Transacoes l_tr;
			
		/// USER [ var_decl ] END
		
		public fetch_dadosNSU ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_dadosNSU";
			constructor();
		}
		
		public fetch_dadosNSU()
		{
			var_Alias = "fetch_dadosNSU";
		
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
			Registry ( "setup fetch_dadosNSU " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_DADOSNSU.st_nsu, ref input_st_nsu ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_DADOSNSU.st_nsu missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_DADOSNSU.dt_hoje, ref input_dt_hoje ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_DADOSNSU.dt_hoje missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_DADOSNSU.tg_confirmada, ref input_tg_confirmada ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_DADOSNSU.tg_confirmada missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_DADOSNSU.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_DADOSNSU.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_dadosNSU " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_dadosNSU " ); 
		
			/// USER [ authenticate ]
			
			input_st_nsu = input_st_nsu.PadLeft ( 6, '0' );
			
			// ## Obter transação original
			
			parc = new T_Parcelas (this);
			l_tr = new LOG_Transacoes (this);
			
			DateTime start = Convert.ToDateTime ( input_dt_hoje );
			DateTime end = Convert.ToDateTime ( input_dt_hoje ).AddDays (1);
			
			// ## Filtrar por NSU e data informada
			
			if ( !l_tr.select_rows_nsu ( input_st_nsu, 
			                           	GetDataBaseTime ( start ), 
			                           	GetDataBaseTime ( end ) ) )
			{
				PublishError ( "NSU inválido" );
				return false;
			}

			if ( !l_tr.fetch() )
				return false;
			
			if ( l_tr.get_tg_confirmada() != input_tg_confirmada )
			{
				if ( input_tg_confirmada == TipoConfirmacao.Pendente )
				{
					PublishError ( "NSU não está pendente" );
					return false;
				}
				else
				{
					PublishError ( "NSU previamente cancelado" );
					return false;
				}				
			}
			
			// ## Buscar parcelas
			
			if ( !parc.select_rows_nsu ( input_st_nsu,
										GetDataBaseTime ( start ), 
										GetDataBaseTime ( end ) ) )
			{
				PublishError ( "NSU inválido" );
				return false;
			}
			
			if ( !parc.fetch() )
				return false;
				
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_dadosNSU " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_dadosNSU " ); 
		
			/// USER [ execute ]
			
			// ## Obter cartão pela parcela
			
			T_Cartao cart = new T_Cartao (this);
			
			if ( !cart.selectIdentity ( parc.get_fk_cartao() ) )
				return false;
				
			// ## Obter proprietário
			
			T_Proprietario prot = new T_Proprietario (this);
			
			if ( !prot.selectIdentity ( cart.get_fk_dadosProprietario() ) )
				return false;
			
			// ## Obter terminal
					
			T_Terminal term = new T_Terminal (this);
			
			if ( !term.selectIdentity ( l_tr.get_fk_terminal() ) )
				return false;
			
			// ## Obter valor primeira parcela
			
			long valor = parc.get_int_vr_valor(); 
			
			// ## Somar valor demais parcelas
			
			while ( parc.fetch() ) 
			{
				valor += parc.get_int_vr_valor();
			}
			
			// ## Copiar dados
			
			output_cont_d_nsu.set_st_terminal 		( term.get_nu_terminal() 		);
			output_cont_d_nsu.set_st_nome 			( prot.get_st_nome()			);
			
			T_Dependente dep_f = new T_Dependente(this);
				
			if ( dep_f.select_rows_prop_tit ( 	cart.get_fk_dadosProprietario(), 
			                                 	cart.get_st_titularidade() ) )
			{
				if ( dep_f.fetch() )
					output_cont_d_nsu.set_st_nome ( dep_f.get_st_nome() );
			}
			
			output_cont_d_nsu.set_dt_operacao 		( parc.get_dt_inclusao() 		);
			output_cont_d_nsu.set_st_empresa		( cart.get_st_empresa()			);
			output_cont_d_nsu.set_st_matricula		( cart.get_st_matricula()		);
			output_cont_d_nsu.set_st_titularidade	( cart.get_st_titularidade()	);
			output_cont_d_nsu.set_vr_valor 			( valor.ToString()				);
			output_cont_d_nsu.set_st_cartao 		( 	cart.get_st_empresa() 	+ 
			                                  			cart.get_st_matricula() + 
			                                  			cart.get_st_titularidade() 	);
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_dadosNSU " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_dadosNSU " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_dadosNSU " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_cont_1 = new DataPortable();
		
			dp_cont_1.MapTagContainer ( COMM_OUT_FETCH_DADOSNSU.d_nsu , output_cont_d_nsu as DataPortable );
		
			var_Comm.AddExitPortable ( ref dp_cont_1 ); 
		
			return true;
		}
	}
}
