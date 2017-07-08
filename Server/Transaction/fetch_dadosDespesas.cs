using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_dadosDespesas : type_base
	{
		public string input_tg_empresa = "";
		public string input_st_codigo = "";
		
		public string output_st_nome = "";
		
		public ArrayList output_array_generic_list = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_dadosDespesas ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_dadosDespesas";
			constructor();
		}
		
		public fetch_dadosDespesas()
		{
			var_Alias = "fetch_dadosDespesas";
		
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
			Registry ( "setup fetch_dadosDespesas " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_DADOSDESPESAS.tg_empresa, ref input_tg_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_DADOSDESPESAS.tg_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_DADOSDESPESAS.st_codigo, ref input_st_codigo ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_DADOSDESPESAS.st_codigo missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_DADOSDESPESAS.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_DADOSDESPESAS.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_dadosDespesas " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_dadosDespesas " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_dadosDespesas " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_dadosDespesas " ); 
		
			/// USER [ execute ]
			
			string fk = "";
			
			if ( input_tg_empresa == Context.TRUE )
			{
				T_Empresa emp = new T_Empresa (this);
				
				if ( !emp.select_rows_empresa ( input_st_codigo.PadLeft ( 6, '0' ) ) )
				{
					PublishError ( "Código de empresa inválido" );
					return false;
				}
				
				if ( !emp.fetch() )
					return false;
				
				fk = emp.get_identity();
				output_st_nome = emp.get_st_fantasia();
			}
			else
			{
				T_Loja loj = new T_Loja (this);
				
				if ( !loj.select_rows_loja ( input_st_codigo ) )
				{
					PublishError ( "Código de loja inválido" );
					return false;
				}
				
				if ( !loj.fetch() )
					return false;
				
				fk = loj.get_identity();
				output_st_nome = loj.get_st_nome();
			}
			
			T_FaturamentoDetalhes fat_det = new T_FaturamentoDetalhes (this);
			
			if ( input_tg_empresa == Context.TRUE )
			{
				if ( !fat_det.select_rows_emp ( fk, TipoFat.Extras ) )
				{
					PublishError ( "Nenhuma despesa encontrada" );
					return false;
				}
			}
			else
			{
				if ( !fat_det.select_rows_loja ( fk, TipoFat.Extras ) )
				{
					PublishError ( "Nenhuma despesa encontrada" );
					return false;
				}
			}
			
			T_Faturamento fat = new T_Faturamento (this);
			
			while ( fat_det.fetch() )
			{
				if ( fat.selectIdentity ( fat_det.get_fk_fatura() ) )
					if ( fat.get_tg_situacao() != TipoSitFat.Pendente )
						continue;
				
				DadosDespesas dd = new DadosDespesas();
				
				dd.set_fk_faturadet ( fat_det.get_identity() 	);
				dd.set_st_info      ( fat_det.get_st_extras() 	);
				
				if ( fat_det.get_tg_desconto() == Context.TRUE )
					dd.set_vr_cobrança  ( "-" + fat_det.get_vr_cobranca() );
				else
					dd.set_vr_cobrança  ( fat_det.get_vr_cobranca() );
				
				output_array_generic_list.Add ( dd );
			}
				
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_dadosDespesas " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_dadosDespesas " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_dadosDespesas " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_out = new DataPortable(); 
		
			dp_out.MapTagValue ( COMM_OUT_FETCH_DADOSDESPESAS.st_nome, output_st_nome ); 
		
			var_Comm.AddExitPortable ( ref dp_out ); 
		
			DataPortable dp_array_generic_list = new DataPortable();
		
			dp_array_generic_list.MapTagArray ( COMM_OUT_FETCH_DADOSDESPESAS.list , ref output_array_generic_list );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_list );
		
			return true;
		}
	}
}
