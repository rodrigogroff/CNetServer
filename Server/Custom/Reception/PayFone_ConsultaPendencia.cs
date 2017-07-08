using System;
using System.Text;
using System.Collections;
using System.IO;

namespace SyCrafEngine
{
	public class PayFone_ConsultaPendencia : CustomTransactionRun
	{
		public override CustomTransactionRun getNew()
		{
			return new PayFone_ConsultaPendencia();
		}
		
		public override bool Run ( string client_msg, ref Transaction trans, ref bool IsTerm, ref string buffer_response )
		{
			if (client_msg.Length < 17) 
		    	return false;
			
            exec_pf_consultaPendencia tr = new exec_pf_consultaPendencia ( trans );
            
            tr.input_st_telefone  = client_msg.Substring (  6, 10 );
            
			string FecharConexao  = client_msg.Substring ( 16,  1 );
            	
            tr.RunOnline();
            
            buffer_response = new StringBuilder().Append ( tr.output_st_codResp.PadLeft   (  2, '0' ) )
            									 .Append ( tr.output_st_nsu.PadLeft 	  (  6, '0' ) )
            									 .Append ( tr.output_st_valor.PadLeft 	  ( 12, '0' ) )
            									 .Append ( tr.output_st_nomeLoja.PadRight ( 25, ' ' ) )
            									 .Append ( tr.output_st_msg.PadRight 	  ( 20, ' ' ) ).ToString();
            
            
            if ( FecharConexao == Context.TRUE )
            {
            	IsTerm = true;
            }
        
			return true;
		}
	}
}
