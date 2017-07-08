using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_venda_pend_lojista : type_base
	{
		public string input_st_cartao = "";
		public string input_vr_valor = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_venda_pend_lojista ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_venda_pend_lojista";
			constructor();
		}
		
		public exec_venda_pend_lojista()
		{
			var_Alias = "exec_venda_pend_lojista";
		
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
			Registry ( "setup exec_venda_pend_lojista " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_VENDA_PEND_LOJISTA.st_cartao, ref input_st_cartao ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_VENDA_PEND_LOJISTA.st_cartao missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_VENDA_PEND_LOJISTA.vr_valor, ref input_vr_valor ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_VENDA_PEND_LOJISTA.vr_valor missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_VENDA_PEND_LOJISTA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_VENDA_PEND_LOJISTA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_venda_pend_lojista " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_venda_pend_lojista " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_venda_pend_lojista " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_venda_pend_lojista " ); 
		
			/// USER [ execute ]
			
			T_Cartao  cart = new T_Cartao (this);
			
			if ( !cart.select_rows_tudo ( input_st_cartao.Substring ( 0, 6 ),
			                             input_st_cartao.Substring ( 6, 6 ),
			                             input_st_cartao.Substring ( 12, 2 ) ) )
			{
				PublishError ( "Cartão inválido" );
				return false;
			}
			
			if ( !cart.fetch() )
				return false;
			
			POS_Entrada  pe = new POS_Entrada();
			
			pe.set_st_senha    		( cart.get_st_senha() 						);
            pe.set_st_empresa   	( input_st_cartao.Substring ( 0, 6 ) 		);
            pe.set_st_matricula 	( input_st_cartao.Substring ( 6, 6 ) 		);
            pe.set_st_titularidade 	( input_st_cartao.Substring ( 12, 2 ) 		);
			pe.set_vr_valor			( input_vr_valor.PadLeft ( 12, '0' ) 		);
			pe.set_st_terminal		( input_cont_header.get_nu_terminal()		);
			pe.set_nu_parcelas		( "1"										);
			pe.set_st_valores		( input_vr_valor.PadLeft ( 12, '0' ) 		);
			
			exec_pos_vendaEmpresarial epv = new exec_pos_vendaEmpresarial (this);
			
			epv.input_cont_pe = pe;
			
			if ( !epv.RunOnline() )
			{
				PublishError ( epv.output_st_msg );
				return false;
			}
			
			exec_pos_confirmaVendaEmpresarial epcve = new exec_pos_confirmaVendaEmpresarial (this);
			
			epcve.input_cont_pe = pe;
			epcve.input_st_nsu  = epv.output_cont_pr.get_st_nsuRcb();
			
			if ( !epcve.RunOnline() )
	       	{
				PublishError ( epcve.output_st_msg );
				return false;
			}
			
			PublishNote ( "Venda offline confirmada" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_venda_pend_lojista " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_venda_pend_lojista " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_venda_pend_lojista " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
