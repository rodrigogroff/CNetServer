using System;
using System.Text;
using System.Collections;
using System.IO;

namespace SyCrafEngine
{
	public class PayFone_AutorizaVendaPendente : CustomTransactionRun
	{
		public override CustomTransactionRun getNew()
		{
			return new PayFone_AutorizaVendaPendente();
		}
		
		public override bool Run ( string client_msg, ref Transaction trans, ref bool IsTerm, ref string buffer_response )
		{
			if (client_msg.Length < 39) 
		    	return false;
			
            exec_pf_autorizaVendaPendente tr = new exec_pf_autorizaVendaPendente ( trans );
            
            tr.input_st_telefone  = client_msg.Substring (  6, 10 );
            tr.input_st_nsu       = client_msg.Substring ( 16,  6 );
            tr.input_st_senha     = client_msg.Substring ( 22, 16 );
            
			string FecharConexao  = client_msg.Substring ( 38,  1 );
			
            tr.RunOnline();
            
            buffer_response = new StringBuilder().Append ( tr.output_st_codResp.PadLeft   (  2, '0' ) )
            									 .Append ( tr.output_st_nsu_autorizado.PadLeft 	  (  6, '0' ) )
            									 .Append ( tr.output_st_msg.PadRight 	  ( 20, ' ' ) ).ToString();
            
            if ( FecharConexao == Context.TRUE )
            {
            	IsTerm = true;
            }
        
			return true;
		}
	}
}
