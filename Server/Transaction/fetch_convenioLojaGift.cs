using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_convenioLojaGift : type_base
	{
		public string input_st_loja = "";
		
		public string output_st_banco = "";
		public string output_st_ag = "";
		public string output_st_conta = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_convenioLojaGift ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_convenioLojaGift";
			constructor();
		}
		
		public fetch_convenioLojaGift()
		{
			var_Alias = "fetch_convenioLojaGift";
		
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
			Registry ( "setup fetch_convenioLojaGift " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_CONVENIOLOJAGIFT.st_loja, ref input_st_loja ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_CONVENIOLOJAGIFT.st_loja missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_CONVENIOLOJAGIFT.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_CONVENIOLOJAGIFT.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_convenioLojaGift " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_convenioLojaGift " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_convenioLojaGift " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_convenioLojaGift " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_cont_header.get_st_empresa() ) )
				return false;
			
			if ( !emp.fetch () )
				return false;
			
			T_Loja loj = new T_Loja (this);
			
			if ( !loj.select_rows_loja ( input_st_loja ) )
				return false;
			
			if ( !loj.fetch () )
				return false;
			
			LINK_LojaEmpresa le = new LINK_LojaEmpresa (this);
			
			if ( !le.select_fk_empresa_loja ( emp.get_identity(), loj.get_identity() ) )
				return false;
			
			if ( !le.fetch() )
				return false;
			
			output_st_ag 	= le.get_st_ag();
			output_st_banco = le.get_st_banco();
			output_st_conta = le.get_st_conta();				
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_convenioLojaGift " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_convenioLojaGift " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_convenioLojaGift " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_CONVENIOLOJAGIFT.st_banco, output_st_banco ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_CONVENIOLOJAGIFT.st_ag, output_st_ag ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_CONVENIOLOJAGIFT.st_conta, output_st_conta ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
