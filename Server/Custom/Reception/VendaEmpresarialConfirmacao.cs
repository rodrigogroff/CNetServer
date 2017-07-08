using System;
using System.Text;
using System.Collections;
using System.IO;

namespace SyCrafEngine
{
	public class VendaEmpresarialConfirmacao : CustomTransactionRun
	{
		public override CustomTransactionRun getNew()
		{
			return new VendaEmpresarialConfirmacao();
		}
		
		public override bool Run ( string client_msg, ref Transaction trans, ref bool IsTerm, ref string buffer_response )
		{
			if (client_msg.Length < 61) 
		    	return false;
			
			string trilha = client_msg.Substring ( 14, 27 );
			
			POS_Entrada  pe = new POS_Entrada();
			
			pe.set_st_terminal 		( client_msg.Substring 	(  6,  8 ) );
			
            pe.set_st_empresa   	( trilha.Substring 		(  6,  6 ) );
            pe.set_st_matricula 	( trilha.Substring	 	( 12,  6 ) );
            pe.set_st_titularidade 	( trilha.Substring 		( 18,  2 ) );

            exec_pos_confirmaVendaEmpresarial tr = new exec_pos_confirmaVendaEmpresarial ( trans );
            
            tr.input_cont_pe  = pe;
            tr.input_st_nsu   = client_msg.Substring ( 41, 6 );
            
            tr.RunOnline(); 
            
            IsTerm = true;
            
            buffer_response = util.Get_POS_Buffer ( tr.output_cont_pr, tr.output_st_msg );
        
			return true;
		}
	}
}
