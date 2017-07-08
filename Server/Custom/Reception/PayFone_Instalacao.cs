using System;
using System.Text;
using System.Collections;
using System.IO;

namespace SyCrafEngine
{
	public class PayFone_Instalacao : CustomTransactionRun
	{
		public override CustomTransactionRun getNew()
		{
			return new PayFone_GravaPendencia();
		}
		
		public override bool Run ( string client_msg, ref Transaction trans, ref bool IsTerm, ref string buffer_response )
		{
			if (client_msg.Length < 15) 
		    	return false;
			
           	IsTerm = true;
           	
           	exec_pf_autorizaInstalacao tr = new exec_pf_autorizaInstalacao ( trans );
           	
           	tr.input_st_codigo = client_msg.Substring ( 6 , 8 );
           	
           	tr.RunOnline();
            
            buffer_response = new StringBuilder().Append ( "00" )
            									 .Append ( tr.output_st_codResp.PadLeft   	 (  2, '0' ) )
            									 .Append ( tr.output_st_msg.PadRight 	  	 ( 20, ' ' ) )
            									 .Append ( tr.output_st_telefone.PadRight 	 ( 10, '0' ) )
            									 .Append ( tr.output_st_terminal.PadRight 	 (  8, '0' ) )
            									 .Append ( tr.output_tg_tipoCelular.PadRight (  1, '0' ) )
            									 .Append ( tr.output_st_lojaTB.PadRight 	 ( 10, '0' ) ).ToString();
			return true;
		}
	}
}
