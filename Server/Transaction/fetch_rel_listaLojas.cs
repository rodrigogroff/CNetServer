using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_rel_listaLojas : type_base
	{
		public string input_emp = "";
		
		public string output_id = "";
		public string output_nome_emp = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_rel_listaLojas ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_rel_listaLojas";
			constructor();
		}
		
		public fetch_rel_listaLojas()
		{
			var_Alias = "fetch_rel_listaLojas";
		
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
			Registry ( "setup fetch_rel_listaLojas " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_REL_LISTALOJAS.emp, ref input_emp ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_REL_LISTALOJAS.emp missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_REL_LISTALOJAS.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_REL_LISTALOJAS.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_rel_listaLojas " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_rel_listaLojas " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_rel_listaLojas " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_rel_listaLojas " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa ( this );
			
			if ( !emp.select_rows_empresa (input_emp ) )
			{
				PublishError ( "Empresa "+ input_emp + " não disponível" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			output_nome_emp = emp.get_st_fantasia();
			
			LINK_LojaEmpresa loj_emp = new LINK_LojaEmpresa ( this );
			
			if ( !loj_emp.select_fk_empresa_geral ( emp.get_identity() ) )
			{
				PublishError ( "Nenhuma loja cadastrada" );
				return false;
			}
			
			T_Loja  loj = new T_Loja ( this );
			T_Terminal term = new T_Terminal ( this );
			
			StringBuilder sb = new StringBuilder ();
			
			while ( loj_emp.fetch() )
			{
				if ( !loj.selectIdentity ( loj_emp.get_fk_loja() ) )
					continue;
				
				if ( !term.select_fk_loja ( loj.get_identity() ) )
					continue;
				
				DataPortable port = new DataPortable ();
				
				port.setValue ( "cod", loj.get_st_loja() 	);
				port.setValue ( "nome", loj.get_st_nome() + " - " + loj.get_st_social()	);
				port.setValue ( "tel", loj.get_nu_telefone() 	);
				port.setValue ( "cid", loj.get_st_cidade()	);
				port.setValue ( "est", loj.get_st_estado()	);
				port.setValue ( "term", term.RowCount().ToString() 	);
				port.setValue ( "cnpj", loj.get_nu_CNPJ()	);
				port.setValue ( "drep", loj_emp.get_nu_dias_repasse() );
				port.setValue ( "prep", loj_emp.get_tx_admin().PadLeft ( 4, '0' ).Insert ( 2, "," ) + " %" );
				
				sb.Append ( MemorySave ( ref port ) );
				sb.Append ( "," );
			}
			
			string list_ids = sb.ToString().TrimEnd ( ',' );
										
			DataPortable dp = new DataPortable();
			
			dp.setValue ( "ids", list_ids );
				
			// ## obtem indice geral
			
			output_id = MemorySave ( ref dp );							
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_rel_listaLojas " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_rel_listaLojas " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_rel_listaLojas " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_LISTALOJAS.id, output_id ); 
			dp_out.MapTagValue ( COMM_OUT_FETCH_REL_LISTALOJAS.nome_emp, output_nome_emp ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			return true;
		}
	}
}
