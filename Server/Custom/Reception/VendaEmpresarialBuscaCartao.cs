using System;
using System.Text;
using System.Collections;
using System.IO;

namespace SyCrafEngine
{
	public class VendaEmpresarialBuscaCartao : CustomTransactionRun
	{
		public override CustomTransactionRun getNew()
		{
			return new VendaEmpresarialBuscaCartao();
		}
		
		public override bool Run ( string client_msg, ref Transaction trans, ref bool IsTerm, ref string buffer_response )
		{
			if (client_msg.Length < 26) 
		    	return false;
			
            exec_pos_buscaCartao tr = new exec_pos_buscaCartao ( trans );

            tr.input_st_empresa   = client_msg.Substring ( 6,   6 );
            tr.input_st_matricula = client_msg.Substring ( 12,  6 );
            tr.input_st_terminal  = client_msg.Substring ( 18,  8 );
            
            tr.RunOnline();      
            
            buffer_response = "00";
            
            if ( tr.IsFail )
            {
            	buffer_response += "9999";
            	
            	for ( int y=0; y < 10; ++y )
            		buffer_response += "99" + " ".PadRight ( 20, ' ' );
            }
            else
            {
            	buffer_response += "0000";
            	
            	int max = tr.output_array_generic_lst.Count;
            
	            for ( int t=0; t < tr.output_array_generic_lst.Count; ++t )
	            {
	            	DadosCartao dc = new DadosCartao ( tr.output_array_generic_lst[t] as DataPortable );
	
	            	buffer_response += dc.get_st_titularidade().PadLeft ( 2, '0' );
	            	buffer_response += dc.get_st_proprietario().PadRight ( 20, ' ' );
	            }
	            
	            for ( int y=max; y < 10; ++y )
            		buffer_response += "99" + " ".PadRight ( 20, ' ' );
            }
            
           	IsTerm = true;	
            
			return true;
		}
	}
}
