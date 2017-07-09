using System;
using System.Text;
using System.Collections;
using System.IO;

namespace SyCrafEngine
{
	public class VendaEmpresarialDesfazer : CustomTransactionRun
	{
		public override CustomTransactionRun getNew()
		{
			return new VendaEmpresarialDesfazer();
		}
		
		public override bool Run ( string client_msg, ref Transaction trans, ref bool IsTerm, ref string buffer_response )
		{
			if (client_msg.Length < 69) 
		    	return false;
			
			POS_Entrada  pe = new POS_Entrada();
			
			pe.set_st_terminal 		( client_msg.Substring 	(  6,  8 ) );
			pe.set_vr_valor			( client_msg.Substring 	( 57, 12 ) );
			
            if (pe.get_st_terminal().StartsWith("1"))
            {
                pe.set_st_nsuOrigemSITEF(client_msg.Substring(200, 6));

                exec_pos_desfazVendaEmpresarialSITEF tr = new exec_pos_desfazVendaEmpresarialSITEF(trans);

                tr.input_cont_pe = pe;
                tr.RunOnline(); 
                buffer_response = util.Get_POS_Buffer(tr.output_cont_pr, tr.output_st_msg);
                IsTerm = true;
                return true;
            }
            else
            {
                exec_pos_desfazVendaEmpresarial tr = new exec_pos_desfazVendaEmpresarial(trans);
                tr.input_cont_pe = pe;
                tr.RunOnline();

                buffer_response = util.Get_POS_Buffer(tr.output_cont_pr, tr.output_st_msg);
                IsTerm = true;
                return true;
            }            
		}
	}
}
