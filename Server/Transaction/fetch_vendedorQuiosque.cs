using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class fetch_vendedorQuiosque : type_base
	{
		public string input_st_empresa = "";
		public string input_st_desc = "";
		
		public ArrayList output_array_generic_lstVinc = new ArrayList(); 
		public ArrayList output_array_generic_lstOutros = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public fetch_vendedorQuiosque ( Transaction trans ) : base (trans)
		{
			var_Alias = "fetch_vendedorQuiosque";
			constructor();
		}
		
		public fetch_vendedorQuiosque()
		{
			var_Alias = "fetch_vendedorQuiosque";
		
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
			Registry ( "setup fetch_vendedorQuiosque " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_VENDEDORQUIOSQUE.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_VENDEDORQUIOSQUE.st_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_FETCH_VENDEDORQUIOSQUE.st_desc, ref input_st_desc ) == false ) 
			{
				Trace ( "# COMM_IN_FETCH_VENDEDORQUIOSQUE.st_desc missing! " ); 
				return false;
			}
			
			DataPortable ct_1 = new DataPortable();
			
			if ( var_Comm.GetEntryPortableAtPosition(1).GetMapContainer ( COMM_IN_FETCH_VENDEDORQUIOSQUE.header, ref ct_1 ) == false )
			{
				Trace ( "# COMM_IN_FETCH_VENDEDORQUIOSQUE.header missing! " ); 
				return false;
			}
			
			input_cont_header.Import ( ct_1 );
			
			Registry ( "setup done fetch_vendedorQuiosque " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			if ( base.authenticate() == false) return false;
			
			Registry ( "authenticate fetch_vendedorQuiosque " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done fetch_vendedorQuiosque " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			if ( base.execute() == false) return false;
			
			Registry ( "execute fetch_vendedorQuiosque " ); 
		
			/// USER [ execute ]
			
			T_Empresa emp = new T_Empresa (this);
			
			if ( !emp.select_rows_empresa ( input_st_empresa.PadLeft ( 6, '0' ) ) )
			{
				PublishError ( "Empresa não disponível" );
				return false;
			}
			
			if ( !emp.fetch() )
				return false;
			
			T_Quiosque q = new T_Quiosque (this);
			
			if ( !q.select_fk_empresa ( emp.get_identity() ) )
			{
				PublishError ( "Nenhum quiosque encontrado" );
				return false;
			}
			
			bool Found = false;
			
			while ( q.fetch() )
			{
				if ( q.get_st_nome() == input_st_desc )
				{
					Found = true;
					break;
				}
			}
			
			if ( !Found )
			{
				PublishError ( "Nenhum quiosque encontrado" );
				return false;
			}
			
			T_Usuario usrVend = new T_Usuario (this);
			
			if ( usrVend.select_fk_quiosque ( q.get_identity() ) )
			{
				while ( usrVend.fetch() )
				{
				//	if ( usrVend.get_tg_nivel() == TipoUsuario.VendedorGift )
					{
						if ( usrVend.get_tg_bloqueio() != Context.TRUE )
						{
							DadosUsuario du = new DadosUsuario();
							
							du.set_st_nome 		( usrVend.get_st_nome() 	);
							du.set_id_usuario 	( usrVend.get_identity() 	);
						
							output_array_generic_lstVinc.Add ( du );
						}
					}
				}
			}
			
			if ( usrVend.select_rows_empresa ( input_st_empresa.PadLeft ( 6, '0' ) ) )
			{
				while ( usrVend.fetch() )
				{
				//	if ( usrVend.get_tg_nivel() == TipoUsuario.VendedorGift )
					{
						if ( usrVend.get_fk_quiosque() != q.get_identity() )
						{
							if ( usrVend.get_tg_bloqueio() != Context.TRUE )
							{
								DadosUsuario du = new DadosUsuario();
							
								du.set_st_nome 		( usrVend.get_st_nome() 	);
								du.set_id_usuario 	( usrVend.get_identity() 	);
							
								
								output_array_generic_lstOutros.Add ( du );
							}
						}
					}
				}	
			}
			
			/// USER [ execute ] END
		
			Registry ( "execute done fetch_vendedorQuiosque " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			if ( base.finish() == false) return false;
			
			Registry ( "finish fetch_vendedorQuiosque " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done fetch_vendedorQuiosque " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_array_generic_lstVinc = new DataPortable();
			DataPortable dp_array_generic_lstOutros = new DataPortable();
		
			dp_array_generic_lstVinc.MapTagArray ( COMM_OUT_FETCH_VENDEDORQUIOSQUE.lstVinc , ref output_array_generic_lstVinc );
			dp_array_generic_lstOutros.MapTagArray ( COMM_OUT_FETCH_VENDEDORQUIOSQUE.lstOutros , ref output_array_generic_lstOutros );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lstVinc );
			var_Comm.AddExitPortable ( ref dp_array_generic_lstOutros );
		
			return true;
		}
	}
}
