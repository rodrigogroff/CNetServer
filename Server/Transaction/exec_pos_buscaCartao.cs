using System;
using System.IO;
using System.Text;
using System.Collections;

/// USER [ using_decl ]
/// USER [ using_decl ] END

namespace SyCrafEngine
{
	public class exec_pos_buscaCartao : Transaction
	{
		public string input_st_empresa = "";
		public string input_st_matricula = "";
		public string input_st_terminal = "";
		
		public ArrayList output_array_generic_lst = new ArrayList(); 
		
		/// USER [ var_decl ]
		/// USER [ var_decl ] END
		
		public exec_pos_buscaCartao ( Transaction trans ) : base (trans)
		{
			var_Alias = "exec_pos_buscaCartao";
			constructor();
		}
		
		public exec_pos_buscaCartao()
		{
			var_Alias = "exec_pos_buscaCartao";
		
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
			Registry ( "setup exec_pos_buscaCartao " ); 
		
			if ( var_Comm.GetEntryPortCount() == 0 ) 
			{
				Trace ( "# Communication Failed!" );
				return false;
			}
			
			DataPortable dp_in = var_Comm.GetFirstEntryPortable();
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_POS_BUSCACARTAO.st_empresa, ref input_st_empresa ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_POS_BUSCACARTAO.st_empresa missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_POS_BUSCACARTAO.st_matricula, ref input_st_matricula ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_POS_BUSCACARTAO.st_matricula missing! " ); 
				return false;
			}
			
			if ( dp_in.GetMapValue ( COMM_IN_EXEC_POS_BUSCACARTAO.st_terminal, ref input_st_terminal ) == false ) 
			{
				Trace ( "# COMM_IN_EXEC_POS_BUSCACARTAO.st_terminal missing! " ); 
				return false;
			}
			
			Registry ( "setup done exec_pos_buscaCartao " ); 
			#endregion
		
			return true;
		}
		
		public override bool authenticate ( ) 
		{
			Registry ( "authenticate exec_pos_buscaCartao " ); 
		
			/// USER [ authenticate ]
			/// USER [ authenticate ] END
		
			Registry ( "authenticate done exec_pos_buscaCartao " ); 
		
			return true;
		}
		
		public override bool execute ( ) 
		{
			Registry ( "execute exec_pos_buscaCartao " ); 
		
			/// USER [ execute ]
			
			T_Cartao 	cart 	= new T_Cartao   		(this);
			T_Empresa 	emp 	= new T_Empresa  		(this);
			T_Terminal	term 	= new T_Terminal 		(this);
			
			if ( !term.select_rows_terminal ( input_st_terminal ) )
            {
            	return false;
            }
            
            if ( !term.fetch() )
            {
            	return false;
            }
			
            if ( !emp.select_rows_empresa ( input_st_empresa ) )
            {
            	return false;
            }
            
            if ( !emp.fetch() )
            {
            	return false;
            }
            
            if ( emp.get_tg_blocked() == Context.TRUE )
            {
            	return false;
            }
            
            if ( !cart.select_rows_empresa_matricula ( 	input_st_empresa, input_st_matricula ) )
            {
            	return false;
            }
            
            while ( cart.fetch() )
            {
            	DadosCartao dc = new DadosCartao();
            	
            	dc.set_st_titularidade ( cart.get_st_titularidade() );
            	
            	if ( cart.get_st_titularidade() != "01" )
            	{
            		// dependente
            		
            		T_Dependente dep = new T_Dependente (this);
            		
            		if ( dep.select_rows_prop_tit ( cart.get_fk_dadosProprietario(),
            		                               cart.get_st_titularidade() ) )
					{
            			if ( dep.fetch() )
            			{
            				string nome = dep.get_st_nome().Trim();
            				
            				if ( nome.Length > 20 )
            					nome = nome.Substring (0,20);
            				
            				dc.set_st_proprietario ( nome );
            			}
                   	}
            	}
            	else
            	{
            		// proprietario
            		
            		T_Proprietario prop = new T_Proprietario(this);
            		
            		if ( prop.selectIdentity ( cart.get_fk_dadosProprietario() ) )
            		{
            			string nome = prop.get_st_nome().Trim();
            				
        				if ( nome.Length > 20 )
        					nome = nome.Substring (0,20);
            				
            			dc.set_st_proprietario ( nome );
            		}
            	}
            	
            	output_array_generic_lst.Add ( dc );
            }
            
			/// USER [ execute ] END
		
			Registry ( "execute done exec_pos_buscaCartao " ); 
		
			return true;
		}
		
		public override bool finish ( ) 
		{
			Registry ( "finish exec_pos_buscaCartao " ); 
		
			/// USER [ finish ]
			/// USER [ finish ] END
		
			Registry ( "finish done exec_pos_buscaCartao " ); 
		
			if ( remoteTransaction == true ) return true; 
		
			DataPortable dp_array_generic_lst = new DataPortable();
		
			dp_array_generic_lst.MapTagArray ( COMM_OUT_EXEC_POS_BUSCACARTAO.lst , ref output_array_generic_lst );
		
			var_Comm.AddExitPortable ( ref dp_array_generic_lst );
		
			return true;
		}
	}
}
