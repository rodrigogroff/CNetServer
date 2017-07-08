using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_rel_listaCarts : type_base
	{
		public string input_emp = "";
		
		public string output_id = "";
		public string output_nome_emp = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_rel_listaCarts ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_rel_listaCarts";
			constructor();
		}
		
		public fetch_rel_listaCarts()
		{
			var_Alias = "fetch_rel_listaCarts";
		
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
			Registry ( "setup fetch_rel_listaCarts " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_LISTACARTS.emp, ref input_emp ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_LISTACARTS.emp missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_REL_LISTACARTS.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_REL_LISTACARTS.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_rel_listaCarts " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_rel_listaCarts " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_rel_listaCarts " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_rel_listaCarts " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa ( this );
			
			if ( !emp.select_rows_empresa ( input_emp ) )
			{
				PublishError ( "Empresa " + input_emp + " não disponível" );
				return false;
			}
					
			if ( !emp.fetch() )
				return false;
			
			output_nome_emp = emp.get_st_fantasia();
			
			T_Cartao cart = new T_Cartao ( this );
			T_Cartao cart_prop = new T_Cartao ( this );
			
			T_Dependente dep_f = new T_Dependente(this);
			T_Proprietario 	prot = new T_Proprietario (this);
			
			ApplicationUtil util = new ApplicationUtil();
			
			if  ( cart.select_rows_empresa ( input_emp ) )
			{
				StringBuilder sb = new StringBuilder();
				
				while ( cart.fetch() )
				{
					DataPortable port= new DataPortable();
					
					port.setValue ( "cart", cart.get_st_empresa().PadLeft (6, '0' )+ "." + cart.get_st_matricula().PadLeft ( 6, '0' ) + "." + cart.get_st_titularidade().PadLeft (2, '0') );
					
					if ( cart.get_tg_status() == CartaoStatus.Habilitado )
						port.setValue ( "bloq", "N" );
					else
						port.setValue ( "bloq", "S" );
					
					long dispMensal = 0, dispTotal  = 0;
						 
					if ( cart.get_st_titularidade() != "01" )
					{
						if ( !dep_f.select_rows_prop_tit ( 	cart.get_fk_dadosProprietario(), cart.get_st_titularidade() ) )
						continue;
					
						if ( !dep_f.fetch() )
							continue;
						
						port.setValue ( "prop", dep_f.get_st_nome() );
						
						if ( !cart_prop.select_rows_tudo ( 	cart.get_st_empresa(),
						                            		cart.get_st_matricula(),
						                            		"01" ) )
						{
							continue;
						}
						
						if ( !cart_prop.fetch() )
							continue;
						
						port.setValue ( "ltot", cart_prop.get_vr_limiteTotal() 	);
						port.setValue ( "lmen", cart_prop.get_vr_limiteMensal() 	);
						port.setValue ( "ext",  cart_prop.get_vr_extraCota() 		);
						
						dispMensal = cart_prop.get_int_vr_limiteMensal() + cart_prop.get_int_vr_extraCota();
						dispTotal  = cart_prop.get_int_vr_limiteTotal() + cart_prop.get_int_vr_extraCota();
					}
					else
					{
						if ( !prot.selectIdentity ( cart.get_fk_dadosProprietario() ) )
							return false;
						
						port.setValue ( "prop", prot.get_st_nome() + " " + prot.get_st_cpf() );
						
						port.setValue ( "ltot", cart.get_vr_limiteTotal() 	);
						port.setValue ( "lmen", cart.get_vr_limiteMensal() 	);
						port.setValue ( "ext", cart.get_vr_extraCota() 		);
						
						port.setValue ( "end", prot.get_st_endereco() + " Num: " + prot.get_st_numero() + " Compl: " + prot.get_st_complemento() );
						port.setValue ( "cpf", "CPF: " + prot.get_st_cpf() );
						port.setValue ( "tel", "Telefone: " + prot.get_st_telefone() );
						port.setValue ( "cel", "Celular: " + cart.get_st_celCartao() );
						
						dispMensal = cart.get_int_vr_limiteMensal() + cart.get_int_vr_extraCota();
						dispTotal  = cart.get_int_vr_limiteTotal() + cart.get_int_vr_extraCota();
					}
					
					// ## Obtem saldo disponível
						 
					util.GetSaldoDisponivel ( ref cart, ref dispMensal, ref dispTotal );
					
					port.setValue ( "dmen", dispMensal.ToString() );
					port.setValue ( "dtot", dispTotal.ToString()  );
					
					port.setValue ( "val", cart.get_st_venctoCartao().Insert (2, "/" ));
									
					sb.Append ( MemorySave ( ref port ) );
					sb.Append ( "," );
				}
				
				string list_ids = sb.ToString().TrimEnd ( ',' );
										
				DataPortable dp = new DataPortable();
				
				dp.setValue ( "ids", list_ids );
					
				// ## obtem indice geral
				
				output_id = MemorySave ( ref dp );
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_rel_listaCarts " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_rel_listaCarts " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_rel_listaCarts " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_LISTACARTS.id, output_id ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_LISTACARTS.nome_emp, output_nome_emp ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
