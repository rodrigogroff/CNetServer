using System;
using System.Text;
using System.Collections;
using System.IO;

namespace SyCrafEngine
{
	public class VendaEmpresarialDigitado : CustomTransactionRun
	{
		public override CustomTransactionRun getNew()
		{
			return new VendaEmpresarialDigitado();
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
			
			pe.set_st_senha ( pe.get_st_senha().Substring ( 12,4 ) );
            
            exec_pos_vendaEmpresarial tr = new exec_pos_vendaEmpresarial ( trans );
            
            tr.input_cont_pe  = pe;
            tr.IsDigitado = true;
            
            tr.RunOnline();      
            
            if ( tr.IsFail )
            {
            	IsTerm = true;	
            }
            else
            {
            	IsTerm = false;
            }
            
            buffer_response = util.Get_POS_Buffer ( tr.output_cont_pr, tr.output_st_msg );
        
			return true;
		}
	}
}
