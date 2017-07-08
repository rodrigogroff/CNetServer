using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_consultaEmpresa : type_base
	{
		public DadosConsultaEmpresa input_cont_dce = new DadosConsultaEmpresa();
		
		public string output_st_csv_empresas = "";
		
		/// USER [ var_decl ]
		
		T_Empresa emp;
		
		/// USER [ var_decl ] END
		
		public fetch_consultaEmpresa ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_consultaEmpresa";
			constructor();
		}
		
		public fetch_consultaEmpresa()
		{
			var_Alias = "fetch_consultaEmpresa";
		
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
			Registry ( "setup fetch_consultaEmpresa " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_FETCH_CONSULTAEMPRESA.dce, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CONSULTAEMPRESA.dce missing! " ); 
				return false;
			}
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_CONSULTAEMPRESA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CONSULTAEMPRESA.header missing! " ); 
				return false;
			}
			
			input_cont_dce.Import ( ct_0 );
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_consultaEmpresa " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_consultaEmpresa " ); 
		
			/// USER [ authenticate ]
			
			emp = new T_Empresa (this);
			
			// ## Busca sempre todas as empresas sem filtro
			
			if ( !emp.selectAll() )
			{
				PublishError ( "Nenhuma empresa cadastrada" );
				return false;
			}
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_consultaEmpresa " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_consultaEmpresa " ); 
		
			/// USER [ execute ]
			
			StringBuilder sb = new StringBuilder();
			
			string 	nome   	= input_cont_dce.get_st_nome(),
					cidade 	= input_cont_dce.get_st_cidade(),
					estado 	= input_cont_dce.get_st_estado();					
			
			long 	vr_min   = 0, 
			 	 	vr_max 	 = 0,
					qtd_cart = 0,
					qtd_parc = 0,
					nu_lojas = 0,
					val 	 = 0;
					
			// ## Prepara filtros
			
			if ( input_cont_dce.get_nu_cartoes().Length > 0 )	qtd_cart = Convert.ToInt32 ( input_cont_dce.get_nu_cartoes() );
			if ( input_cont_dce.get_nu_parcelas().Length > 0 )	qtd_parc = Convert.ToInt32 ( input_cont_dce.get_nu_parcelas() );
			if ( input_cont_dce.get_nu_lojas().Length > 0 )		nu_lojas = Convert.ToInt32 ( input_cont_dce.get_nu_lojas() );
			
			if ( input_cont_dce.get_vr_taxa_min().Length > 0 )	vr_min 	= Convert.ToInt32 ( input_cont_dce.get_vr_taxa_min() );
			if ( input_cont_dce.get_vr_taxa_min().Length > 0 )	vr_max 	= Convert.ToInt32 ( input_cont_dce.get_vr_taxa_max() );
			
			LINK_LojaEmpresa loj_emp = new LINK_LojaEmpresa (this);
			
			// ## Busca todos os registros
			
			nome = nome.ToUpper();
			
			while ( emp.fetch() )
			{
				val = emp.get_int_vr_mensalidade();
				
				if ( vr_min > 0 )	
					if ( val < vr_min )		
						continue;
				
				if ( vr_max > 0 )	
					if ( val > vr_max )		
					continue;
				
				if ( vr_min > 0 && vr_max > 0 )
					if ( val < vr_min || val > vr_max )
						continue;
			
				if ( qtd_cart > 0 )
					if ( emp.get_int_nu_cartoes() < qtd_cart )
						continue;

				if ( qtd_parc > 0 )
					if ( emp.get_int_nu_parcelas() < qtd_parc )
						continue;
				
				if ( nome.Length > 0	)	
				{
					if ( !emp.get_st_social().ToUpper().Contains ( nome ) )
						if ( !emp.get_st_fantasia().ToUpper().Contains ( nome ) )
							continue;
				}
				
				if ( cidade.Length > 0	)	if ( !emp.get_st_cidade().Contains 	 ( cidade ) )	continue;
				if ( estado.Length > 0	)	if ( !emp.get_st_estado().Contains   ( estado ) )	continue;
				
				// ## Contabiliza numero de lojas
				
				loj_emp.SetCountMode();
				loj_emp.select_fk_empresa_geral ( emp.get_identity() );
				
				if ( input_cont_dce.get_nu_lojas().Length > 0 )
					if ( loj_emp.GetCount() < nu_lojas )
						continue;
				
				// ## Copia dados para memória
				
				DadosEmpresa de = new DadosEmpresa();
				
				de.set_nu_lojas	( loj_emp.GetCount().ToString() );
				
				de.set_st_empresa		( emp.get_st_empresa() 		);
				de.set_st_fantasia		( emp.get_st_fantasia().Trim()	+ " - " + emp.get_st_social().Trim() );
				de.set_st_cidade		( emp.get_st_cidade()		);
				de.set_st_estado		( emp.get_st_estado()		);
				de.set_nu_cartoes		( emp.get_nu_cartoes()		);
				de.set_nu_parcelas		( emp.get_nu_parcelas()		);
				de.set_vr_mensalidade 	( emp.get_vr_mensalidade()	);
				de.set_nu_CNPJ			( emp.get_nu_CNPJ()			);
				de.set_tg_bloq 			( emp.get_tg_bloq()			);
				
				DataPortable tmp = de as DataPortable;
				
				// ## indexa em CSV
				
				sb.Append ( MemorySave ( ref tmp ) );
				sb.Append ( "," 				 	  );
			}
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
			
			if ( list_ids == "" )
			{
				PublishNote ( "Nenhum resultado foi encontrado" );
				return true;
			}
											
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
			
			// ## Obtem identificador de bloco
						  
			output_st_csv_empresas = MemorySave ( ref dp );
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_consultaEmpresa " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_consultaEmpresa " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_consultaEmpresa " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_CONSULTAEMPRESA.st_csv_empresas, output_st_csv_empresas ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
