using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_consultaLoja : type_base
	{
		public DadosConsultaLoja input_cont_dcl = new DadosConsultaLoja();
		
		public string output_st_csv_id = "";
		
		/// USER [ var_decl ]
		
		T_Loja 				loj;
		T_Empresa 			emp;
		LINK_LojaEmpresa 	loj_emp;
		
		bool IsEmpresa = false;
		
		/// USER [ var_decl ] END
		
		public fetch_consultaLoja ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_consultaLoja";
			constructor();
		}
		
		public fetch_consultaLoja()
		{
			var_Alias = "fetch_consultaLoja";
		
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
			Registry ( "setup fetch_consultaLoja " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable ct_0 = new DataPortable();
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(0).GetMapContainer ( COMM_IN_FETCH_CONSULTALOJA.dcl, ref ct_0 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CONSULTALOJA.dcl missing! " ); 
				return false;
			}
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_CONSULTALOJA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CONSULTALOJA.header missing! " ); 
				return false;
			}
			
			input_cont_dcl.Import ( ct_0 );
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_consultaLoja " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_consultaLoja " ); 
		
			/// USER [ authenticate ]
			
			loj = new T_Loja (this);
			emp = new T_Empresa (this);
			loj_emp = new LINK_LojaEmpresa (this);
			
			// ## Filtro ou por determinada empresa (administrador)
			// ## ou todas as lojas (root)
			
			string st_empresa = input_cont_dcl.get_st_empresa();
			
			if ( input_cont_dcl.get_st_loja().Length > 0 && st_empresa.Length > 0 )
			{
				if ( !loj.select_rows_loja ( input_cont_dcl.get_st_loja() ) )
				{
					PublishError ( "Nenhuma loja encontrada" );
					return false;
				}
				
				if ( !loj.fetch() )
					return false;
				
				if ( !emp.select_rows_empresa ( st_empresa.PadLeft ( 6, '0' ) ) )
				{
					PublishError ( "Código de empresa inválido" );
					return false;
				}
				
				if ( !emp.fetch() )
					return false;
				
				LINK_LojaEmpresa lje = new LINK_LojaEmpresa (this);
				
				if ( !lje.select_fk_empresa_loja ( emp.get_identity(), loj.get_identity() ) )
				{
					PublishError ( "Loja " + input_cont_dcl.get_st_loja() + " não conveniada com empresa" );
					return false;
				}
			}
			else if ( input_cont_dcl.get_st_cnpj().Length > 0 )
			{
				if ( !loj.select_rows_cnpj ( input_cont_dcl.get_st_cnpj() ) )
				{
					PublishError ( "Nenhuma loja encontrada" );
					return false;
				}
			}
			else if ( st_empresa.Length > 0 )
			{
				// ## Buscar empresa
				
				IsEmpresa = true;
			
				if ( !emp.select_rows_empresa ( st_empresa.PadLeft ( 6, '0' ) ) )
				{
					PublishError ( "Código de empresa inválido" );
					return false;
				}
				
				if ( !emp.fetch() )
					return false;
				
				// ## Se não existirem lojas, sair
				
				if ( !loj_emp.select_fk_empresa_geral ( emp.get_identity() ) )
				{
					PublishError ( "Nenhuma loja cadastrada com convênio " + input_cont_dcl.get_st_empresa() );
					return false;
				}
			}
			else	
			{
				// ## Todas as lojas
				
				if ( !loj.selectAll() )
				{
					PublishError ( "Nenhuma loja cadastrada" );
					return false;
				}
			}
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_consultaLoja " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_consultaLoja " ); 
		
			/// USER [ execute ]
			
			T_Terminal term = new T_Terminal (this);
			
			// ## Obtem filtros da entrada
			
			string 	nome   	= input_cont_dcl.get_st_nome().ToUpper(),
					cidade 	= input_cont_dcl.get_st_cidade(),
					estado 	= input_cont_dcl.get_st_estado(),
					codigo  = input_cont_dcl.get_st_loja();
			
			long 	min_qtd = 0;
			
			if ( input_cont_dcl.get_nu_qtd_term().Length > 0 )	
				min_qtd = Convert.ToInt32 ( input_cont_dcl.get_nu_qtd_term() );
						
			long memory = Convert.ToInt64 ( new InstallData().maxPacket ) / 360;
			
			Hashtable hshLojas = new Hashtable();
			
			#region - lojas para um determinado administrador - 
						
			if ( user.get_tg_nivel() == TipoUsuario.Administrador )
			{
				if ( !emp.select_rows_empresa ( user.get_st_empresa() ) )
				{
					PublishError ( "CNPJ de empresa inválido" );
					return false;
				}
				
				if ( !emp.fetch() )
					return false;
								
				LINK_LojaEmpresa lnk = new LINK_LojaEmpresa (this);
				
				if ( lnk.select_fk_empresa_geral ( emp.get_identity() ) )
				{
					while ( lnk.fetch() )
					{
						hshLojas [ lnk.get_fk_loja() ] = "*";
					}
				}
			}
			
			#endregion
						
			bool bNome = false;
			
			if ( nome.Length > 0 )
				bNome = true;
			
			bool bCod = false;
			
			if ( codigo.Length > 0 )
				bCod = true;
			
			ArrayList lstSortLojas = new ArrayList();
			Hashtable hshSortLojas = new Hashtable();
			
			LINK_LojaEmpresa loj_emp_conv = new LINK_LojaEmpresa (this);
			T_Empresa emp_comp = new T_Empresa (this);
			
			// ## Loop diferente para ambos os tipos de consulta
			// ## em um só bloco
			
			for (;;)
			{
				if ( IsEmpresa )
				{
					// ## Busca do relacionamento loja e empresa
					
					if ( !loj_emp.fetch() )
						break;
					
					// ## Se loja não existir, sair
					
					if ( !loj.selectIdentity ( loj_emp.get_fk_loja() ) )
						return false;
				}
				else
				{
					// ## busca proximo registro do select all
					
					if ( !loj.fetch() )
						break;
					
					if ( hshLojas.Count > 0 )
					{
						// ##  filtro lojas no caso de admin
						
						if ( hshLojas [ loj.get_identity() ] == null )
							continue;
					}
				}
			
				// ## Verifica qtd de terminais
				
				term.select_fk_loja ( loj.get_identity() );
								
				if ( bCod )
					if ( loj.get_st_loja() != codigo )
						continue;
				
				if ( bNome )	
					if ( !loj.get_st_nome().ToUpper().Contains ( nome ) )
						if ( !loj.get_st_social().ToUpper().Contains ( nome ) )
							continue;
				
				if ( min_qtd > 0 )
					if ( term.GetCount() < min_qtd )
						continue;
				
				if ( cidade.Length > 0	)	
					if ( !loj.get_st_cidade().Contains 	( cidade ) )	
						continue;
								
				if ( estado.Length > 0	)	
					if ( !loj.get_st_estado().Contains 	( estado ) )	
						continue;
				
				// ## Copia dados para memória
				
				DadosLoja dl = new DadosLoja();
				
				string id_loja = loj.get_st_nome().Trim() + " - " + loj.get_st_social().Trim();
				
				lstSortLojas.Add ( id_loja );
				
				dl.set_st_loja		( loj.get_st_loja() 			);
				dl.set_st_nome		( id_loja						);
				dl.set_st_cidade	( loj.get_st_cidade() 			);
				dl.set_st_estado	( loj.get_st_estado() 			);
				
				dl.set_st_endereco  ( "Tel: "  + loj.get_nu_telefone() + " End: " + loj.get_st_endereco() );
				
				dl.set_nu_diasRep	( loj_emp.get_nu_dias_repasse()	);
				
				string tx = loj_emp.get_tx_admin().PadLeft ( 3, '0' );
				
				dl.set_nu_pctRep	( tx.Insert ( tx.Length -2, "," ) + "%" );
				
				string st_terms = " (";
				
				int terms = 0 ;
				
				while ( term.fetch() )
				{
					if ( term.get_fk_loja() == Context.NOT_SET )
						continue;
					
					terms++;
					
					st_terms += term.get_nu_terminal().TrimStart ( '0' ) + ", ";
				}
				
				st_terms = terms.ToString() + st_terms.Trim().TrimEnd ( ',' ) + ")";
				
				dl.set_st_obs		( st_terms				);
				dl.set_nu_CNPJ		( loj.get_nu_CNPJ() 	);
				
				string convs = "";
				
				if ( loj_emp_conv.select_fk_loja ( loj.get_identity() ) )
			    {
					while ( loj_emp_conv.fetch() )
					{
						emp_comp.selectIdentity ( loj_emp_conv.get_fk_empresa() );
						
						convs += emp_comp.get_st_empresa().TrimStart ( '0' ) + ",";
					}
			    }
				
				dl.set_st_convenios ( convs.TrimEnd ( ',' ) );
				
				hshSortLojas [ id_loja ] = dl;
			}

			lstSortLojas.Sort();
			
			StringBuilder sb = new StringBuilder();
			
			for ( int t=0; t < lstSortLojas.Count; ++t )
			{
				DadosLoja dl = hshSortLojas [ lstSortLojas [t] ] as DadosLoja;
				
				DataPortable tmp = dl as DataPortable;
				
				// ## obtem indexador
				
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
			
			// ## Obtem indexador geral
						  
			output_st_csv_id = MemorySave ( ref dp );
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_consultaLoja " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_consultaLoja " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_consultaLoja " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_CONSULTALOJA.st_csv_id, output_st_csv_id ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
