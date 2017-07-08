using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_reciboRepasse : type_base
	{
		public string input_id_repasse = "";
		
		public DadosRepRecibo output_cont_rec = new DadosRepRecibo();
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_reciboRepasse ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_reciboRepasse";
			constructor();
		}
		
		public fetch_reciboRepasse()
		{
			var_Alias = "fetch_reciboRepasse";
		
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
			Registry ( "setup fetch_reciboRepasse " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_RECIBOREPASSE.id_repasse, ref input_id_repasse ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_RECIBOREPASSE.id_repasse missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_RECIBOREPASSE.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_RECIBOREPASSE.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_reciboRepasse " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_reciboRepasse " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_reciboRepasse " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_reciboRepasse " ); 
		
			/// USER [ execute ]
			
			T_RepasseLoja rep = new T_RepasseLoja (this);
			
			if ( !rep.selectIdentity ( input_id_repasse  ) )
				return false;
			
			string st_extra = rep.get_st_ident();
			
			T_Loja loj = new T_Loja (this);
			
			if ( !loj.selectIdentity ( rep.get_fk_loja() ) )
			    return false;
			
			output_cont_rec.set_loja	( loj.get_st_nome() + " - " + loj.get_st_social() );
			output_cont_rec.set_cnpj 	( loj.get_nu_CNPJ() 	);
			output_cont_rec.set_pagto 	( rep.get_tg_opcao() 	);
			
			LINK_RepasseParcela lrp 	= new LINK_RepasseParcela 	(this);
			T_Parcelas 			parc 	= new T_Parcelas 			(this);
			T_Cartao 			cart 	= new T_Cartao 				(this);
			LINK_LojaEmpresa 	loj_emp = new LINK_LojaEmpresa	 	(this);
			
			long vr_compras = 0;
			long dias_rep   = 0;
			
			string fk_empresa = "";			
			
			if ( lrp.select_fk_rep ( input_id_repasse ) )
			{
				while ( lrp.fetch() )
				{
					parc.selectIdentity ( lrp.get_fk_parcela() );
					cart.selectIdentity ( parc.get_fk_cartao() );
					
					if ( fk_empresa == "" )
					{
						fk_empresa = parc.get_fk_empresa();
				
						loj_emp.select_fk_empresa_loja ( fk_empresa, loj.get_identity() );
						loj_emp.fetch();
						
						dias_rep = loj_emp.get_int_nu_dias_repasse();
						
						if ( rep.get_tg_opcao() != TipoPagamento.Dinheiro )
						{
							if ( rep.get_tg_opcao() != TipoPagamento.Cheque )
							{
								// deposito
								st_extra = " Banco : " + loj_emp.get_st_banco() + " - Ag. " + loj_emp.get_st_ag() + " Conta: " + loj_emp.get_st_conta();
							}
							else
								st_extra = rep.get_st_ident();
						}
					}
					
					vr_compras += parc.get_int_vr_valor();
						
					DadosRepasse dr = new DadosRepasse();
					
					dr.set_st_cartao ( cart.get_st_empresa() + "." + cart.get_st_matricula() );
					dr.set_dt_trans  ( parc.get_dt_inclusao() 	);
					dr.set_st_nsu    ( parc.get_nu_nsu() 		);
					dr.set_vr_total  ( parc.get_vr_valor() 		);
					
					DateTime tim = Convert.ToDateTime (  parc.get_dt_inclusao() );
					
					tim = tim.AddDays ( dias_rep );
					
					dr.set_dt_repasse ( GetDataBaseTime ( tim ) );
						
					output_array_generic_lst.Add ( dr );
				}
			}
			
			long desc = vr_compras - rep.get_int_vr_valor();
							
			output_cont_rec.set_vr_compras 	( vr_compras.ToString() 										);
			output_cont_rec.set_tx_admin 	( new money().formatToMoney ( loj_emp.get_tx_admin() ) + "%" 	);
			output_cont_rec.set_vr_desc 	( new money().formatToMoney ( desc.ToString() ) 				);
			output_cont_rec.set_vr_tot_rep 	( rep.get_vr_valor() 											);
			output_cont_rec.set_st_extra    ( st_extra 														);
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_reciboRepasse " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_reciboRepasse " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_reciboRepasse " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_cont_1 = new DataPortable();
		
			dp_cont_1.MapTagContainer ( COMM_OUT_FETCH_RECIBOREPASSE.rec , output_cont_rec as DataPortable );
		
			var_Comm.AddExitPortable ( ref dp_cont_1 ); 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_FETCH_RECIBOREPASSE.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
