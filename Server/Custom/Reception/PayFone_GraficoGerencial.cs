using System;
using System.Text;
using System.Collections;
using System.IO;

namespace SyCrafEngine
{
	public class PayFone_GraficoGerencial : CustomTransactionRun
	{
		public override CustomTransactionRun getNew()
		{
			return new PayFone_GraficoGerencial();
		}
		
		public override bool Run ( string client_msg, ref Transaction trans, ref bool IsTerm, ref string buffer_response )
		{
			if (client_msg.Length < 8 ) 
		    	return false;
						
			exec_pf_graficoGerencial tr = new exec_pf_graficoGerencial ( trans );
			
            tr.input_tg_tipo = client_msg.Substring (  6, 2 );
			
            tr.RunOnline();
            
            for ( int t=0; t < tr.output_array_generic_lst.Count; ++t )
            {
            	DataPortable p = tr.output_array_generic_lst[t] as DataPortable;
            	
            	buffer_response += p.getValue ( "desc"  ).PadRight ( 10, ' ');
            	buffer_response += p.getValue ( "valor" ).PadLeft  ( 12, '0');
            }
            
            IsTerm = true;
        
			return true;
		}
	}
}
