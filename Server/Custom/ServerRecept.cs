using System;
using System.Text;
using System.Collections;
using System.IO;

namespace SyCrafEngine
{
	public class CustomTransactionRun
	{
		public ApplicationUtil util = new ApplicationUtil();
		
		public virtual CustomTransactionRun getNew()
		{
			return new CustomTransactionRun();
		}
		
		public virtual bool Run ( string msg, 
		                          ref Transaction trans, 
		                          ref bool IsTerm, 
		                          ref string buffer_response )	
		{	return false;	
		}
	}
	
	public class ServerRecept : CustomRecept
	{
		Hashtable hsh_custom = new Hashtable ();
		
		public override CustomRecept getNew()
		{
			return new ServerRecept();
		}
		
		public ServerRecept()	
		{ 
			// Atribuir códigos para classes
			
			hsh_custom [ "CEBC" ] = new VendaEmpresarialBuscaCartao();
			hsh_custom [ "CECE" ] = new VendaEmpresarial(); // muitos ajustes (ok)
            hsh_custom [ "CECG" ] = new VendaEmpresarialGift();
			hsh_custom [ "CECC" ] = new VendaEmpresarialConfirmacao(); // não precisou de ajuste (ok)
			hsh_custom [ "CECA" ] = new VendaEmpresarialCancelamento(); // pequeno ajuste (ok)
			hsh_custom [ "CEDF" ] = new VendaEmpresarialDesfazer(); // muitos ajustes (a fazer)
			hsh_custom [ "DICE" ] = new VendaEmpresarialDigitado();
			
			hsh_custom [ "GFGG" ] = new PayFone_GraficoGerencial();
			
			hsh_custom [ "PFGP" ] = new PayFone_GravaPendencia();
			hsh_custom [ "PFCP" ] = new PayFone_ConsultaPendencia();
			hsh_custom [ "PFXP" ] = new PayFone_CancelaPendencia();
			hsh_custom [ "PFXV" ] = new PayFone_CancelaVenda();
			hsh_custom [ "PFXL" ] = new PayFone_CancelaPendenciaLojista();			
			hsh_custom [ "PFVP" ] = new PayFone_AutorizaVendaPendente();
			hsh_custom [ "PFCL" ] = new PayFone_ConsultaAutorizacao(); 
			hsh_custom [ "PFIN" ] = new PayFone_Instalacao(); 
		}
		
		public override bool ProcessRequest ( string client_msg, ref Transaction trans, ref bool IsTerm )
		{
			if ( client_msg == "PING" )
				return false;	
			
			if ( client_msg.Length < 6 )
				return true;
			
            string id_integrador   = client_msg.Substring(0, 2);
            string tipoCartao      = client_msg.Substring(2, 2);
            string operacao        = client_msg.Substring(4, 2);
            
            CustomTransactionRun custom = hsh_custom [ tipoCartao + operacao ] as CustomTransactionRun;
            
            if ( custom != null )
            {
            	CustomTransactionRun custom_new = custom.getNew();
            	
            	return custom_new.Run ( client_msg, ref trans, ref IsTerm, ref buffer_response );
            }
			
			return false;
		}
	}
}
