using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_dadosCartao : type_base
	{
		public string input_st_cart_empresa = "";
		public string input_st_cart_mat = "";
		public string input_st_cart_tit = "";
		
		public string output_nu_maxParcelas = "";
		public string output_vr_dispMes = "";
		public string output_vr_dispTotal = "";
		public string output_st_nome = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_dadosCartao ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_dadosCartao";
			constructor();
		}
		
		public fetch_dadosCartao()
		{
			var_Alias = "fetch_dadosCartao";
		
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
			Registry ( "setup fetch_dadosCartao " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_DADOSCARTAO.st_cart_empresa, ref input_st_cart_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_DADOSCARTAO.st_cart_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_DADOSCARTAO.st_cart_mat, ref input_st_cart_mat ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_DADOSCARTAO.st_cart_mat missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_DADOSCARTAO.st_cart_tit, ref input_st_cart_tit ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_DADOSCARTAO.st_cart_tit missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_DADOSCARTAO.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_DADOSCARTAO.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_dadosCartao " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_dadosCartao " ); 
		
			/// USER [ authenticate ]
			
			input_st_cart_empresa = input_st_cart_empresa.PadLeft 	( 6, '0' );
			input_st_cart_mat     = input_st_cart_mat.PadLeft 		( 6, '0' );
			input_st_cart_tit     = input_st_cart_tit.PadLeft 		( 2, '0' );
			
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_dadosCartao " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_dadosCartao " ); 
		
			/// USER [ execute ]
			
			T_Cartao cart = new T_Cartao (this);
			
			// ## Busca cartão específico
			
			if ( !cart.select_rows_tudo ( input_st_cart_empresa, 
			                              input_st_cart_mat, 
			                              input_st_cart_tit ) )
			{
				PublishError ( "Cartão inexistente" );
				return false;
			}
			
			if ( !cart.fetch() )
				return false;
			
			// ## Busca proprietário
			
			T_Proprietario prot = new T_Proprietario (this);
			
			if ( !prot.selectIdentity ( cart.get_fk_dadosProprietario() ) )
				return false;
			
			// ## Obter nome
			
			if ( cart.get_tg_tipoCartao() == TipoCartao.educacional )
			{
				output_st_nome = cart.get_st_aluno();
			}
			else
			{
				output_st_nome = prot.get_st_nome();
				
				T_Dependente dep_f = new T_Dependente(this);
					
				if ( dep_f.select_rows_prop_tit ( 	cart.get_fk_dadosProprietario(), 
				                                 	cart.get_st_titularidade() ) )
				{
					if ( dep_f.fetch() )
						output_st_nome = dep_f.get_st_nome();
				}
			}
			
			if ( cart.get_tg_tipoCartao() != TipoCartao.presente )
			{
				// ## Conferir parcelas
				
				T_Parcelas parc = new T_Parcelas (this);
	
				long vr_limMes = cart.get_int_vr_limiteMensal();
				long vr_limTot = cart.get_int_vr_limiteTotal() + cart.get_int_vr_extraCota();
					
				// ## Obter saldo disponivel
				
				new ApplicationUtil().GetSaldoDisponivel ( ref cart, ref vr_limMes, ref vr_limTot );
	
				output_vr_dispMes   = vr_limMes.ToString();
				output_vr_dispTotal = vr_limTot.ToString();
				
				// ## Obter empresa
				
				T_Empresa emp = new T_Empresa (this);
				
				if ( !emp.select_rows_empresa ( input_st_cart_empresa ) )
					return false;
				
				if ( !emp.fetch() )
					return false;
			
				// ## informar max de parcelas
			
				output_nu_maxParcelas = emp.get_nu_parcelas();				
			}
			else
			{
				output_vr_dispTotal = cart.get_vr_limiteTotal();
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_dadosCartao " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_dadosCartao " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_dadosCartao " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_DADOSCARTAO.nu_maxParcelas, output_nu_maxParcelas ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_DADOSCARTAO.vr_dispMes, output_vr_dispMes ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_DADOSCARTAO.vr_dispTotal, output_vr_dispTotal ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_DADOSCARTAO.st_nome, output_st_nome ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
