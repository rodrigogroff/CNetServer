using System;
using System.Text;
using System.Collections;
using System.IO;

namespace SyCrafEngine
{
	public class VendaEmpresarialCancelamento : CustomTransactionRun
	{
		public override CustomTransactionRun getNew()
		{
			return new VendaEmpresarialCancelamento();
		}
		
		public override bool Run ( string client_msg, ref Transaction trans, ref bool IsTerm, ref string buffer_response )
		{
			if (client_msg.Length < 60) 
		    	return false;
			
			string trilha = client_msg.Substring ( 14, 27 );
			
			POS_Entrada  pe = new POS_Entrada();
			
			pe.set_st_terminal 		( client_msg.Substring 	(  6,  8 ) );
			pe.set_st_senha    		( client_msg.Substring 	( 14, 16 ) );
            pe.set_st_empresa   	( trilha.Substring 		(  6,  6 ) );
            pe.set_st_matricula 	( trilha.Substring	 	( 12,  6 ) );
            pe.set_st_titularidade 	( trilha.Substring 		( 18,  2 ) );
            
            string	nsuRCB       = client_msg.Substring(41, 6);
            string  nsuBanco     = client_msg.Substring(47, 14);

            if (client_msg.Length > 200)
                pe.set_st_terminalSITEF(client_msg.Substring(200)); // veio do sitef

            exec_pos_cancelaVendaEmpresarial tr = new exec_pos_cancelaVendaEmpresarial ( trans );
            
            tr.input_st_nsu_cancel = nsuRCB;
            tr.input_cont_pe = pe;
            
            tr.RunOnline();           	
	        
            buffer_response = util.Get_POS_BufferCancela ( tr.output_cont_pr, 
                                                           nsuRCB, 
                                                           nsuBanco, 
                                                           tr.valor,
                                                           tr.dt_orig,
                                                           tr.output_st_msg );
        
           	IsTerm = true;
           
			return true;
		}
	}
}
