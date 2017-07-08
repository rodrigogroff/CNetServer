using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_chequeGift : type_base
	{
		public string input_st_ident = "";
		
		public string output_st_dados = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_chequeGift ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_chequeGift";
			constructor();
		}
		
		public fetch_chequeGift()
		{
			var_Alias = "fetch_chequeGift";
		
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
			Registry ( "setup fetch_chequeGift " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CHEQUEGIFT.st_ident, ref input_st_ident ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CHEQUEGIFT.st_ident missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_CHEQUEGIFT.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CHEQUEGIFT.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_chequeGift " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_chequeGift " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_chequeGift " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_chequeGift " ); 
		
			/// USER [ execute ]
			
			T_ChequesGift chq = new T_ChequesGift (this);
			
			if ( !chq.select_rows_ident ( input_st_ident ) ) 
			{
				PublishError ( "Cheque não disponível" );
				return false;
			}
			
			if ( !chq.fetch() )
				return false;
			
			T_Cartao cart = new T_Cartao (this);
			
			if ( !cart.selectIdentity ( chq.get_fk_cartao() ) )
				return false;
			
			T_Proprietario prot = new T_Proprietario (this);
			
			if ( !prot.selectIdentity ( cart.get_fk_dadosProprietario() ) )
				return false;
			
			output_st_dados += "Nome: " + prot.get_st_nome() + "@";
			output_st_dados += "CPF: " 	+ prot.get_st_cpf() + "@";
			output_st_dados += "Valor do cheque: R$ " + new money().formatToMoney ( chq.get_vr_valor() ) + "@@";
			output_st_dados += "Situação: ";
			
			if ( chq.get_tg_compensado() == Context.FALSE )
			{
				output_st_dados += "Aguardando confirmação de depósito";	
			}
			else if ( chq.get_tg_compensado() == Context.TRUE )
			{
				output_st_dados += "Depósito confirmado";	
			}
			else // 2
			{
				output_st_dados += "Cheque cancelado";	
			}			
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_chequeGift " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_chequeGift " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_chequeGift " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_CHEQUEGIFT.st_dados, output_st_dados ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
