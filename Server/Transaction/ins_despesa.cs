using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class ins_despesa : type_base
	{
		public string input_vr_cobranca = "";
		public string input_st_codigo = "";
		public string input_tg_empresa = "";
		public string input_st_extra = "";
		public string input_tg_desconto = "";
		
		/// USER [ var_decl ]
		
		T_Empresa emp;
		T_Loja loj; 
		
		public bool quiet = false;
		
		/// USER [ var_decl ] END
		
		public ins_despesa ( Transaction trans ) : base (trans)
		{
			var_Alias = "ins_despesa";
			constructor();
		}
		
		public ins_despesa()
		{
			var_Alias = "ins_despesa";
		
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
			Registry ( "setup ins_despesa " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_DESPESA.vr_cobranca, ref input_vr_cobranca ) == false ) 
			{
				Trace ( "# COMM_IN_INS_DESPESA.vr_cobranca missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_DESPESA.st_codigo, ref input_st_codigo ) == false ) 
			{
				Trace ( "# COMM_IN_INS_DESPESA.st_codigo missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_DESPESA.tg_empresa, ref input_tg_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_INS_DESPESA.tg_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_DESPESA.st_extra, ref input_st_extra ) == false ) 
			{
				Trace ( "# COMM_IN_INS_DESPESA.st_extra missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_INS_DESPESA.tg_desconto, ref input_tg_desconto ) == false ) 
			{
				Trace ( "# COMM_IN_INS_DESPESA.tg_desconto missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_INS_DESPESA.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_INS_DESPESA.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done ins_despesa " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate ins_despesa " ); 
		
			/// USER [ authenticate ]
			
			emp = new T_Empresa (this);
			loj = new T_Loja (this);

			/// USER [ authenticate ] END
		
			Registry ( "authenticate done ins_despesa " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute ins_despesa " ); 
		
			/// USER [ execute ]
			
			T_FaturamentoDetalhes det = new T_FaturamentoDetalhes (this);
			
			det.set_vr_cobranca ( input_vr_cobranca );
			det.set_tg_tipoFat  ( TipoFat.Extras	);
			det.set_st_extras	( input_st_extra	);
				
			if ( input_tg_empresa == Context.TRUE )
			{
				if ( !emp.select_rows_empresa ( input_st_codigo.PadLeft ( 6, '0' ) ) )
				{
					PublishError ( "Empresa inexistente" );
					return false;
				}
				
				if ( !emp.fetch() )
					return false;
				
				det.set_fk_empresa  ( emp.get_identity() );
			}
			else
			{
				if ( !loj.select_rows_loja ( input_st_codigo ) )
				{
					PublishError ( "Loja inexistente" );
					return false;
				}
				
				if ( !loj.fetch() )
					return false;
				
				det.set_fk_loja  ( loj.get_identity() );
			}
			
			if ( Convert.ToInt64 ( input_vr_cobranca ) == 0 )
			{
				PublishNote ( "Despesa de " + new money().formatToMoney ( input_vr_cobranca ) + " não registrada" );
				return true;
			}
			
			det.set_tg_desconto ( input_tg_desconto );
			
			if ( !det.create_T_FaturamentoDetalhes() )
				return false;
			
			if ( !quiet )
				PublishNote ( "Despesa de " + new money().formatToMoney ( input_vr_cobranca ) + " criada" );
			
			/// USER [ execute ] END
		
			Registry ( "execute done ins_despesa " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish ins_despesa " ); 
		
			/// USER [ finish ]
			
			if ( !IsFail )
			{
				LOG_Audit aud = new LOG_Audit (this);
				
				aud.set_tg_operacao	( TipoOperacao.CadDespesa );
				
				aud.set_fk_usuario	( input_cont_header.get_st_user_id() 	);
				aud.set_dt_operacao ( GetDataBaseTime() 					);
				
				if ( input_tg_empresa == Context.TRUE )
				{
					aud.set_st_observacao 	( emp.get_nu_CNPJ() 	);
					aud.set_fk_generic  	( emp.get_identity() 	);
				}
				else
				{
					aud.set_st_observacao ( loj.get_nu_CNPJ()  );
					aud.set_fk_generic    ( loj.get_identity() );
				}
								
				if ( !aud.create_LOG_Audit() )
					return false;
			}
			
			/// USER [ finish ] END
		
			Registry ( "finish done ins_despesa " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			return true;
		}
	}
}
