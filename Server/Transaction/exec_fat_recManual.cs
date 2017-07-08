using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_fat_recManual : type_base
	{
		public string input_tg_empresa = "";
		public string input_st_codigo = "";
		public string input_vr_valor = "";
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_fat_recManual ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_fat_recManual";
			constructor();
		}
		
		public exec_fat_recManual()
		{
			var_Alias = "exec_fat_recManual";
		
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
			Registry ( "setup exec_fat_recManual " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_FAT_RECMANUAL.tg_empresa, ref input_tg_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_FAT_RECMANUAL.tg_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_FAT_RECMANUAL.st_codigo, ref input_st_codigo ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_FAT_RECMANUAL.st_codigo missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_FAT_RECMANUAL.vr_valor, ref input_vr_valor ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_FAT_RECMANUAL.vr_valor missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_EXEC_FAT_RECMANUAL.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_EXEC_FAT_RECMANUAL.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done exec_fat_recManual " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate exec_fat_recManual " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_fat_recManual " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute exec_fat_recManual " ); 
		
			/// USER [ execute ]
			
			T_Empresa 	emp = new T_Empresa (this);
			T_Loja 		loj = new T_Loja 	(this);
			
			if ( input_tg_empresa == Context.TRUE )
			{
				if ( !emp.select_rows_empresa ( input_st_codigo.PadLeft ( 6, '0' ) ) )
				{
					PublishError ( "Empresa não disponível" );
					return false;
				}
				
				if ( !emp.fetch() )
					return false;
			}
			else
			{
				if ( !loj.select_rows_loja ( input_st_codigo ) )
				{
					PublishError ( "Loja não disponível" );
					return false;
				}
				
				if ( !loj.fetch() )
					return false;
			}
			
			T_Faturamento fat 	  = new T_Faturamento (this);
			T_Faturamento fat_upd = new T_Faturamento (this);
			
			if ( input_tg_empresa == Context.TRUE )
				fat.select_rows_emp ( emp.get_identity() );
			else
				fat.select_rows_loj ( loj.get_identity() );
			
			while ( fat.fetch() )
			{
				if ( fat.get_tg_situacao() == TipoSitFat.EmCobrança )
				{
					fat_upd.ExclusiveAccess();
					
					if ( !fat_upd.selectIdentity ( fat.get_identity() ) )
						return false;
					
					fat_upd.set_tg_situacao ( TipoSitFat.PagoOutros );
					fat_upd.set_vr_cobranca ( input_vr_valor 		);
					
					if ( !fat_upd.synchronize_T_Faturamento() )
						return false;
					
					fat_upd.ReleaseExclusive();
					
					PublishNote ( "Faturamento atualizado com sucesso" );
					break;
				}
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done exec_fat_recManual " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish exec_fat_recManual " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_fat_recManual " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
