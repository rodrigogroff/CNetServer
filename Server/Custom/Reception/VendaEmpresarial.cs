using System;
using System.Text;
using System.Collections;
using System.IO;

namespace SyCrafEngine
{
	public class VendaEmpresarial : CustomTransactionRun
	{
		public override CustomTransactionRun getNew()
		{
			return new VendaEmpresarial();
		}
		
        public override bool Run ( string client_msg, ref Transaction trans, ref bool IsTerm, ref string buffer_response )
		{
			if (client_msg.Length < 71) 
		    	return false;
			
			POS_Entrada  pe = new POS_Entrada();
			
			pe.set_st_terminal 		( client_msg.Substring 	(  6,  8 ) );
			
			string trilha = client_msg.Substring ( 14, 27 );
			
			pe.set_st_empresa   	( trilha.Substring 		(  6,  6 ) );
            pe.set_st_matricula 	( trilha.Substring	 	( 12,  6 ) );
            pe.set_st_titularidade 	( trilha.Substring 		( 18,  2 ) );
			
			pe.set_st_senha    		( client_msg.Substring 	( 41, 16 ) );
			pe.set_vr_valor			( client_msg.Substring 	( 57, 12 ) );
			pe.set_nu_parcelas 		( client_msg.Substring 	( 69,  2 ) );
			pe.set_st_valores  		( client_msg.Substring 	( 71     ) );

            if (client_msg.Length > 200)
            {
                pe.set_st_terminalSITEF(client_msg.Substring(200, 8)); // veio do sitef
                pe.set_st_nsuOrigemSITEF(client_msg.Substring(208, 6)); // veio do sitef
            }                

            // ajustado
            if (pe.get_st_terminal().StartsWith("1"))
            {
                exec_pos_vendaEmpresarialSITEF tr = new exec_pos_vendaEmpresarialSITEF(trans);

                tr.input_cont_pe = pe;
                tr.RunOnline();
                               
                IsTerm = tr.IsFail;
                
                buffer_response = util.Get_POS_Buffer(tr.output_cont_pr, tr.output_st_msg);

                return true;
            }
            else
            {
                exec_pos_vendaEmpresarial tr = new exec_pos_vendaEmpresarial(trans);

                tr.input_cont_pe = pe;
                tr.RunOnline();

                IsTerm = tr.IsFail;
                buffer_response = util.Get_POS_Buffer(tr.output_cont_pr, tr.output_st_msg);

                return true;
            }            
		}
	}
}
