using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_chamadoHist : type_base
	{
		public string input_id_chamado = "";
		
		public DadosChamado output_cont_dc = new DadosChamado();
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_chamadoHist ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_chamadoHist";
			constructor();
		}
		
		public fetch_chamadoHist()
		{
			var_Alias = "fetch_chamadoHist";
		
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
			Registry ( "setup fetch_chamadoHist " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CHAMADOHIST.id_chamado, ref input_id_chamado ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CHAMADOHIST.id_chamado missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_CHAMADOHIST.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CHAMADOHIST.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_chamadoHist " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_chamadoHist " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_chamadoHist " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_chamadoHist " ); 
		
			/// USER [ execute ]
			
			T_Chamado 	cham 		= new T_Chamado 	(this);
			T_Loja 		loj 		= new T_Loja 		(this);
			T_Usuario 	usrConvey 	= new T_Usuario 	(this);
			LOG_Chamado l_c 		= new LOG_Chamado 	(this);
			
			if ( !cham.selectIdentity ( input_id_chamado ) )
				return false;
			
			if ( !loj.selectIdentity ( cham.get_fk_loja() ) )
				return false;			    
			
			if ( !usrConvey.selectIdentity ( cham.get_fk_operador() 	) )
				return false;
			
			output_cont_dc.set_st_cod_loja 	( loj.get_st_loja() 		);
			output_cont_dc.set_st_nome_loja ( loj.get_st_nome() 		);
			output_cont_dc.set_st_motivo 	( cham.get_st_motivo()		);
			output_cont_dc.set_st_oper 		( usrConvey.get_st_nome()	);
			output_cont_dc.set_nu_categ		( cham.get_nu_categoria()	);
			output_cont_dc.set_tg_fechado 	( cham.get_tg_fechado() 	);
			output_cont_dc.set_dt_ab		( cham.get_dt_abertura()	);
			output_cont_dc.set_dt_fech		( cham.get_dt_fechamento()	);
			
			if ( l_c.select_fk_chamado ( cham.get_identity() ) )
			{
				l_c.SetReversedFetch();
				
				while ( l_c.fetch() )
				{
					if ( !usrConvey.selectIdentity ( l_c.get_fk_operador() ) )
						return false;
						
					DadosAlteracaoChamado dac = new DadosAlteracaoChamado();
					
					dac.set_dt_alt 		( l_c.get_dt_solucao() 		);
					dac.set_st_oper_alt ( usrConvey.get_st_nome() 	);
					dac.set_st_desc_alt ( l_c.get_st_solucao()		);
					
					output_array_generic_lst.Add ( dac );
				}
			}
							
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_chamadoHist " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_chamadoHist " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_chamadoHist " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_cont_1 = new DataPortable();
		
			dp_cont_1.MapTagContainer ( COMM_OUT_FETCH_CHAMADOHIST.dc , output_cont_dc as DataPortable );
		
			var_Comm.AddExitPortable ( ref dp_cont_1 ); 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_CHAMADOHIST.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
