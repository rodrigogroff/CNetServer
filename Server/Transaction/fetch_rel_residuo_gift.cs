using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_rel_residuo_gift : type_base
	{
		public string input_st_empresa = "";
		
		public string output_st_block = "";
		public string output_st_nome_empresa = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_rel_residuo_gift ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_rel_residuo_gift";
			constructor();
		}
		
		public fetch_rel_residuo_gift()
		{
			var_Alias = "fetch_rel_residuo_gift";
		
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
			Registry ( "setup fetch_rel_residuo_gift " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_RESIDUO_GIFT.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_RESIDUO_GIFT.st_empresa missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_REL_RESIDUO_GIFT.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_REL_RESIDUO_GIFT.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_rel_residuo_gift " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_rel_residuo_gift " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_rel_residuo_gift " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_rel_residuo_gift " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_st_empresa ) )
			{
				PublishError ( "Empresa não disponível" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			output_st_nome_empresa = emp.get_st_fantasia();
			
			T_Cartao 		cart = new T_Cartao 		(this);
			T_Proprietario 	prot = new T_Proprietario 	(this);
			T_Parcelas 		parc = new T_Parcelas 		(this);
			
			StringBuilder sb = new StringBuilder();
			
			LOG_VendaCartaoGift lvc = new LOG_VendaCartaoGift (this);
			
			if ( cart.select_rows_emp_valor ( input_st_empresa ) )
			{
				while ( cart.fetch() )
				{
					if ( cart.get_tg_tipoCartao() != TipoCartao.presente )
						continue;
					
					if ( !prot.selectIdentity ( cart.get_fk_dadosProprietario() ) )
						continue;
					
					if ( cart.get_int_vr_limiteTotal() == 0 )
						continue;
					
					if ( cart.get_tg_status() == CartaoStatus.Bloqueado )
						continue;
											
					DadosCartao dc = new DadosCartao();
			
					dc.set_st_matricula 	( cart.get_st_matricula() 	);
					dc.set_st_proprietario 	( prot.get_st_nome() 		);
					dc.set_vr_limiteTotal	( cart.get_vr_limiteTotal() );
			
					parc.SetReversedFetch();
					
					if ( parc.select_rows_ult_compra ( cart.get_identity() ) )
					{
						if ( !parc.fetch() )
							continue;
						
						dc.set_dt_ultUso ( parc.get_dt_inclusao() );
					}
					
					lvc.SetReversedFetch();
					
					if ( lvc.select_fk_cart ( cart.get_identity() ) )
					{
						if ( !lvc.fetch() )
							continue;
						
						dc.set_dt_ultCarga ( lvc.get_dt_compra() );
						dc.set_vr_extraCota ( lvc.get_vr_carga() );
					}
					else
					{
						dc.set_vr_extraCota ( "0" );
					}
				
					DataPortable port = dc as DataPortable;
					
					sb.Append ( MemorySave ( ref port ) );
					sb.Append ( "," 					);
				}
			}
			
			DataPortable port_ids = new DataPortable();
			
			port_ids.setValue ( "ids", sb.ToString().TrimEnd ( ',' ) );
			
			output_st_block = MemorySave ( ref port_ids );
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_rel_residuo_gift " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_rel_residuo_gift " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_rel_residuo_gift " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_RESIDUO_GIFT.st_block, output_st_block ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_RESIDUO_GIFT.st_nome_empresa, output_st_nome_empresa ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
