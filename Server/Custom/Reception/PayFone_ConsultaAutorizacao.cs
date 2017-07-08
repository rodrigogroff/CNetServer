using System;
using System.Text;
using System.Collections;
using System.IO;

namespace SyCrafEngine
{
	public class PayFone_ConsultaAutorizacao : CustomTransactionRun
	{
		public override CustomTransactionRun getNew()
		{
			return new PayFone_ConsultaAutorizacao();
		}
		
		public override bool Run ( string client_msg, ref Transaction trans, ref bool IsTerm, ref string buffer_response )
		{
			if (client_msg.Length < 27) 
		    	return false;
			
            exec_pf_consultaAutorizacao tr = new exec_pf_consultaAutorizacao ( trans );
			
			tr.input_st_tel_lojista  = client_msg.Substring (  6, 10 );
			tr.input_st_telefone     = client_msg.Substring ( 16, 10 );
			
			string FecharConexao     = client_msg.Substring ( 26,  1 );
            	
            tr.RunOnline();
            
            buffer_response = tr.output_st_codResp + tr.output_st_msg.PadLeft ( 20, ' ' );
            
            for ( int t=0; t < tr.output_array_generic_lst.Count; ++t )
            {
            	PF_DadosConsultaAutorizacao tmp = new PF_DadosConsultaAutorizacao ( tr.output_array_generic_lst[t] as DataPortable );

            	buffer_response +=   new StringBuilder().Append ( tmp.get_vr_valor().PadLeft ( 12, '0' ) )
            	                                      	.Append ( tmp.get_st_nsu().PadLeft   (  6, '0' ) )
            										  	.Append ( tmp.get_tg_sit().PadLeft   (  1, '0' ) ) 
            											.Append ( tmp.get_dt_ocorr().PadLeft ( 10, '0' ) ).ToString();
            }
            
            if ( FecharConexao == Context.TRUE )
            {
            	IsTerm = true;
            }
        
			return true;
		}
	}
}
