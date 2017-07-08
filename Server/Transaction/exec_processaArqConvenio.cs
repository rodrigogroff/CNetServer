using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_processaArqConvenio : type_base
	{
		public string input_st_id = "";
		public string input_st_empresa = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_processaArqConvenio ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_processaArqConvenio";
			constructor();
		}
		
		public exec_processaArqConvenio()
		{
			var_Alias = "exec_processaArqConvenio";
		
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
			Registry ( "setup exec_processaArqConvenio " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_PROCESSAARQCONVENIO.st_id, ref input_st_id ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_PROCESSAARQCONVENIO.st_id missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_PROCESSAARQCONVENIO.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_PROCESSAARQCONVENIO.st_empresa missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_PROCESSAARQCONVENIO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_PROCESSAARQCONVENIO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_processaArqConvenio " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_processaArqConvenio " ); 
		
			/// USER [ authenticate ]
			
			input_st_empresa = input_st_empresa.PadLeft ( 6, '0' );
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_processaArqConvenio " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_processaArqConvenio " ); 
		
			/// USER [ execute ]
			
			DataPortable csv_AllArchive = MemoryGet ( input_st_id );
			
			ApplicationUtil var_util = new ApplicationUtil();
			
			string st_ids = csv_AllArchive.getValue ( "ids" );
			
			Trace ( st_ids );
			
			int total_records = var_util.indexCSV ( st_ids );
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_st_empresa ) )
			{
				PublishError ( "" );
				return false;
			}
			
			if ( !emp.fetch() )
			{
				PublishError ( "" );
				return false;
			}	
			
			T_Cartao 				cart 	 = new T_Cartao 				(this);
			T_Cartao 				cart_mat = new T_Cartao				    (this);
			T_Proprietario 			prot 	 = new T_Proprietario 			(this);
			T_InfoAdicionais        info     = new T_InfoAdicionais			(this);
			T_Dependente 			dep  	 = new T_Dependente 			(this);			
			LINK_ProprietarioCartao lpc  	 = new LINK_ProprietarioCartao	(this);
			
			int linha = 0;
					
			for ( int t=0; t < total_records; ++t )
			{
				linha++;
								
				DataPortable port_line = MemoryGet ( var_util.getCSV (t) );
				
				string line = port_line.getValue ( "line" );
				
				Trace ( line );
				
				int pos = 0; 

				try
				{
					string st_mat     = line.Substring ( pos,6 ).Trim();	pos += 6;
					string cpf        = line.Substring ( pos,11 ).Trim();	pos += 11;
					string tit        = line.Substring ( pos, 2 ).Trim();	pos +=  2;
					string nome       = line.Substring ( pos,50 ).Trim();	pos += 50;
					string end        = line.Substring ( pos,40 ).Trim();	pos += 40;
					string bairro     = line.Substring ( pos,20 ).Trim();	pos += 20;
					string cep        = line.Substring ( pos, 8 ).Trim();	pos +=  8;
					string cidade     = line.Substring ( pos,20 ).Trim();	pos += 20;
					string tel        = line.Substring ( pos,10 ).Trim();	pos += 10;
					string email      = line.Substring ( pos,50 ).Trim();	pos += 50;
					string dt_nasc    = line.Substring ( pos, 8 ).Trim();	pos +=  8;
					string lim_mensal = line.Substring ( pos, 12 ).Trim().TrimStart ( '0' ).PadLeft ( 1, '0' );	pos +=  12;
					string lim_total  = line.Substring ( pos, 12 ).Trim().TrimStart ( '0' ).PadLeft ( 1, '0' );	pos +=  12;
					
					if ( lim_total == "0" )
					{
						lim_total = lim_mensal;
					}
					
					st_mat = st_mat.PadLeft ( 6, '0' );
					
					bool found = false;
					
					if ( cart_mat.select_rows_empresa_matricula ( input_st_empresa, st_mat ) )
					{
						PublishNote ( "Matricula " + st_mat + " já cadastrada. Registro descartado" );
						continue;					
					}
					
					if ( Convert.ToInt32 ( tit ) == 1 ) // titular
					{
						if ( prot.select_rows_cpf ( cpf ) )
						{
							if ( prot.fetch() )
							{
								if ( cart.select_rows_prop ( prot.get_identity() ) )
								{
									while ( cart.fetch() )
									{
										if ( cart.get_st_empresa() == input_st_empresa )
										{
											if ( cart.get_st_titularidade() == "01" )
											{
												found = true;
												break;
											}
										}
									}
									
									if ( found )
										continue; // descarta pois cartão já foi criado
								}
							}
							
							// não precisa criar dadosproprietario, só o cartão desta empresa
							found = true;
						}
						
						if ( !found )
						{
							// cria dados proprietario
							
							prot.Reset();
							
							prot.set_st_nome 		( nome 			);
							prot.set_st_cpf			( cpf			);
							prot.set_st_endereco 	( end 			);
							prot.set_st_bairro      ( bairro    	);
							prot.set_st_cidade      ( cidade    	);
							prot.set_st_telefone    ( tel			);
							prot.set_st_email		( email     	);
							
							if ( dt_nasc == "00000000" )
							{
								dt_nasc = GetDataBaseTime();
							}
							else
							{
								int year  = Convert.ToInt32 ( dt_nasc.Substring ( 4,4 ) );
								int month = Convert.ToInt32 ( dt_nasc.Substring ( 2,2 ) );
								int day   = Convert.ToInt32 ( dt_nasc.Substring ( 0,2 ) );
						
								dt_nasc = GetDataBaseTime ( new DateTime ( year, month, day ) );
							}
							
							prot.set_dt_nasc ( dt_nasc );
												
							prot.create_T_Proprietario();
							
							
						}
						
						info.Reset();
						
						info.set_st_empresa 	( input_st_empresa 	);
						info.set_st_matricula 	( st_mat 			);
						
						info.create_T_InfoAdicionais();
						
						cart.Reset();
						
						cart.set_st_empresa      ( input_st_empresa 		);
						cart.set_st_matricula    ( st_mat 					);
						cart.set_st_titularidade ( tit.PadLeft ( 2, '0' ) 	);
																		
						cart.set_tg_emitido	  		  ( StatusExpedicao.NaoExpedido 	);
						
						cart.set_fk_dadosProprietario ( prot.get_identity() 			);						
						cart.set_fk_infoAdicionais    ( info.get_identity() 			);
						
						cart.set_vr_limiteMensal 	  ( lim_mensal 						);
						cart.set_vr_limiteTotal  	  ( lim_total  						);
						
						cart.set_tg_tipoCartao   	( "0" );
						cart.set_st_venctoCartao 	(  DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + 
						                          	 ( DateTime.Now.Year + 5 ).ToString().Substring ( 2,2 ) );
						
						cart.set_tg_status   		( "0" );
						cart.set_nu_viaCartao 		( "1" );
						
						cart.create_T_Cartao();				
					}
					else // dependente
					{
						// busca proprietario
						if ( prot.select_rows_cpf ( cpf ) )
						{
							if ( prot.fetch() )
							{
								dep.Reset();
								
								dep.set_st_nome 		( nome 					);
								dep.set_nu_titularidade ( tit 					);
								dep.set_fk_proprietario ( prot.get_identity() 	);
																		
								dep.create_T_Dependente();
								
								info.Reset();
						
								info.set_st_empresa 	( input_st_empresa 	);
								info.set_st_matricula 	( st_mat 			);
								
								info.create_T_InfoAdicionais();
								
								cart.Reset();
					
								cart.set_st_empresa      ( input_st_empresa 					);
								cart.set_st_titularidade ( tit.PadLeft ( 2, '0' ) 				);
								cart.set_st_matricula    ( st_mat 								);
														
								cart.set_tg_emitido	  		  ( StatusExpedicao.NaoExpedido 	);
								
								cart.set_fk_dadosProprietario ( prot.get_identity() 			);
								cart.set_fk_infoAdicionais    ( info.get_identity() 			);
								
								cart.set_vr_limiteMensal 	  ( lim_mensal 						);
								cart.set_vr_limiteTotal  	  ( lim_total  						);
								
								cart.set_tg_tipoCartao   	( "0" );
								cart.set_st_venctoCartao 	(  DateTime.Now.Month.ToString().PadLeft ( 2, '0' ) + 
								                          	 ( DateTime.Now.Year + 5 ).ToString().Substring ( 2,2 ) );
								
								cart.set_tg_status   		( "0" );
								cart.set_nu_viaCartao 		( "1" );
								
								cart.create_T_Cartao();				
							}
						}
					}
				}
				catch ( System.Exception ex )
				{
					ex.ToString();
					
					PublishError ( "Arquivo com registro inválido na linha " + linha );
					return false;
				}
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_processaArqConvenio " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_processaArqConvenio " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_processaArqConvenio " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
