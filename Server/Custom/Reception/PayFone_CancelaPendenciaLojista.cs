using System;
using System.Text;
using System.Collections;
using System.IO;

namespace SyCrafEngine
{
	public class PayFone_CancelaPendenciaLojista : CustomTransactionRun
	{
		public override CustomTransactionRun getNew()
		{
			return new PayFone_CancelaPendenciaLojista();
		}
		
		public override bool Run ( string client_msg, ref Transaction trans, ref bool IsTerm, ref string buffer_response )
		{
			if (client_msg.Length < 32) 
		    	return false;
			
            exec_pf_cancelaPendenciaLojista tr = new exec_pf_cancelaPendenciaLojista ( trans );
            
            tr.input_st_telefone 	  = client_msg.Substring (  6, 10 );
            tr.input_st_tel_lojista   = client_msg.Substring ( 16, 10 );
            tr.input_st_nsu_cancelado = client_msg.Substring ( 26,  6 );
						
			string FecharConexao      = client_msg.Substring ( 32,  1 );
			
            tr.RunOnline();
            
            buffer_response = new StringBuilder().Append ( tr.output_st_codResp.PadLeft   (  2, '0' ) )
            									 .Append ( tr.output_st_msg.PadRight 	  ( 20, ' ' ) ).ToString();
            
            
            if ( FecharConexao == Context.TRUE )
            {
            	IsTerm = true;
            }
        
			return true;
		}
	}
}
