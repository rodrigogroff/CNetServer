using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Collections;
using Microsoft.Win32;

namespace SyCrafEngine
{	
	public class ApplicationUtil : Infra_ApplicationUtil
	{
		public string getDDMMYYYY_format ( string val )
		{
			DateTime t = Convert.ToDateTime (val);
			
			return t.ToString ( "dd/MM/yyyy HH:mm:ss" );
		}
		
		public void GetSaldoDisponivel ( ref T_Cartao cart, ref long dispMensal, ref long dispTotal )
		{
			Transaction tr = cart.var_Transaction;
			
			bool changed = false;
			
			if  ( tr.SQL_LOGGING_ENABLE == true )
			{
				tr.SQL_LOGGING_ENABLE = false;
				changed = true;
			}
							
			ArrayList lstCartoes = new ArrayList();
			
			T_Cartao c_t = new T_Cartao ( tr );
			
			c_t.select_rows_empresa_matricula ( cart.get_st_empresa(), cart.get_st_matricula() );
			
			while ( c_t.fetch() )
				lstCartoes.Add ( c_t.get_identity() );
			
			if ( cart.get_tg_tipoCartao() == TipoCartao.empresarial )
			{
				tr.Trace ( "Empresarial!" );
				
				LOG_Transacoes  ltr  = new LOG_Transacoes 	( tr );
				T_Parcelas 		parc = new T_Parcelas 		( tr );
				
				// Verifica disponivel mensal nas parcelas
				if ( parc.select_rows_cartao_mensal ( ref lstCartoes, "1" ) ) // este mês
	    		{
					while ( parc.fetch() )
					{
						if ( ltr.selectIdentity ( parc.get_fk_log_transacoes() ) ) // busca transação
						{
							if ( ltr.get_tg_confirmada() == TipoConfirmacao.Confirmada || 
							     ltr.get_tg_confirmada() == TipoConfirmacao.Pendente )
							{
								dispMensal -= parc.get_int_vr_valor();
							}
						}
					}
				}
				
				parc.Reset();
				
				// Verifica disponivel total nas parcelas
				if ( parc.select_rows_cartao ( ref lstCartoes, "1"  ) ) // nu_parcela >= 1 (ou seja, no futuro) 
	    		{
					while ( parc.fetch() )
					{
						if ( ltr.selectIdentity ( parc.get_fk_log_transacoes() ) ) // busca transação
						{
							if ( ltr.get_tg_confirmada() == TipoConfirmacao.Confirmada || 
							     ltr.get_tg_confirmada() == TipoConfirmacao.Pendente )
							{
								dispTotal -= parc.get_int_vr_valor();
							}
						}
					}
				}
				
				if ( dispMensal < 0 ) 
					dispMensal = 0;
				
				if ( dispTotal < 0 ) 
					dispTotal = 0;
			}
			else if ( cart.get_tg_tipoCartao() == TipoCartao.educacional )
			{
				dispMensal = cart.get_int_vr_disp_educacional();				
				dispTotal  = cart.get_int_vr_disp_educacional();
			}	
			
			if ( changed )
				tr.SQL_LOGGING_ENABLE = true;
		}
		
		public string Get_POS_Buffer ( POS_Resposta resp, string desc )
		{
			StringBuilder sb = new StringBuilder ( "00" );
            
			sb.Append ( resp.get_st_codResp().PadLeft ( 4, '0' ) 		); 
			sb.Append ( "S" 											);
			sb.Append ( resp.get_st_nsuRcb().PadLeft ( 6, '0' ) 		);
			sb.Append ( resp.get_st_nsuBanco().PadLeft ( 14, '0' ) 		);
			sb.Append ( resp.get_st_nomeCliente().PadRight ( 40, ' ' ) 	);
			sb.Append ( "004200" 										);
			sb.Append ( desc.PadRight ( 20, ' ') 						);
			sb.Append ( resp.get_st_loja().PadLeft (  15, '0' ) 		);
			sb.Append ( resp.get_st_PAN().PadLeft ( 14, '0' ) 			);
			sb.Append ( resp.get_st_mesPri().PadLeft ( 2, '0' ) 		);

			sb.Append ( DateTime.Now.ToString("dd/MM/yyyy") 			);
			sb.Append ( DateTime.Now.ToString("HH:mm:ss") 				);
            
			int tamVar = resp.get_st_variavel().Length;
            
            sb.Append ( tamVar.ToString("000") 	);
            sb.Append ( resp.get_st_variavel()  );

            return sb.ToString();
		}
		
		public string Get_POS_BufferCancela ( POS_Resposta resp, 
		                                      string nsuRCB, 
		                                      string nsuBanco, 
		                                      string valor,
		                                      string dt_orig,
		                                      string desc )
		{
			StringBuilder sb = new StringBuilder ( "00" );
            
			sb.Append ( resp.get_st_codResp().PadLeft ( 4, '0' ) 		);
			sb.Append ( "S" 											);
			sb.Append ( resp.get_st_nsuRcb().PadLeft ( 6, '0' ) 		);
			sb.Append ( resp.get_st_nsuBanco().PadLeft ( 14, '0' ) 		);
			sb.Append ( resp.get_st_nomeCliente().PadRight ( 40, ' ' ) 	);
			sb.Append ( "290000"										);
			sb.Append ( "Cancelado".PadRight( 20, ' ' ) 				);
			sb.Append ( resp.get_st_loja().PadLeft ( 15, '0' )			);
			sb.Append ( nsuBanco.PadLeft ( 14, '0' ) 					);
			sb.Append ( nsuRCB.PadLeft 	 ( 6, '0' ) 					);
			sb.Append ( resp.get_st_PAN().PadLeft ( 19, '0' ) 			);
			sb.Append ( valor.PadLeft ( 12, '0' ) 						);
			
			DateTime tim = Convert.ToDateTime ( dt_orig );
			
			sb.Append ( tim.ToString("dd/MM/yyyy")   		); 					
			sb.Append ( tim.ToString("HH:mm:ss")			);
			
			sb.Append ( DateTime.Now.ToString("dd/MM/yyyy")	);
			sb.Append ( DateTime.Now.ToString("HH:mm:ss")  	);
			
            return sb.ToString();
		}
		
		/// <summary>
	    /// Rotina que usa DESNBS para criptografar uma senha
	    /// </summary>
	    /// <param name="dados">Dados a serem criptografados</param>
	    /// <param name="chave">Chave de criptografia</param>
	    /// <returns>String com 16 bytes com os 8 caracteres ASCII retornados</returns>
	    public string DESCript ( string dados, string chave )
	    {
	    	dados = dados.PadLeft ( 8, '*' );
	    	
	        byte[] key = System.Text.Encoding.ASCII.GetBytes(chave);//{1,2,3,4,5,6,7,8};
	        byte[] data = System.Text.Encoding.ASCII.GetBytes(dados);
	
	        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
	
	        des.Key = key;
	        des.Mode = CipherMode.ECB;
	
	        ICryptoTransform DESt = des.CreateEncryptor();
	        DESt.TransformBlock(data, 0, 8, data, 0);
	        	
	        string retorno = "";
	        for (int n = 0; n < 8; n++)
	        {
	            retorno += String.Format("{0:X2}", data[n]);
	        }
	        
	        return retorno;
	    }
	    
	    public static string DESdeCript(string dados, string chave)
	    {
	        byte[] key = System.Text.Encoding.ASCII.GetBytes(chave);//{1,2,3,4,5,6,7,8};
	        byte[] data = new byte[8];
	
	        for (int n = 0; n < dados.Length / 2; n++)
	        {
	            data[n] = (byte)Convert.ToInt32(dados.Substring(n * 2, 2), 16);
	        }
	
	        DES des = new DESCryptoServiceProvider();
	        des.Key = key;
	        des.Mode = CipherMode.ECB;
	        ICryptoTransform crypto     = des.CreateDecryptor();
	        MemoryStream cipherStream   = new MemoryStream();
	        CryptoStream cryptoStream   = new CryptoStream( cipherStream, crypto, CryptoStreamMode.Write );
	        cryptoStream.Write( data, 0, data.Length );
	        crypto.TransformBlock( data, 0, 8, data, 0 );
	        System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
	        string retorno = enc.GetString(data);
	
	        return retorno;
	    }

	    
	    public string getMd5Hash(string input)
	    {
	        // Create a new instance of the MD5CryptoServiceProvider object.
	        MD5 md5Hasher = MD5.Create();
	
	        // Convert the input string to a byte array and compute the hash.
	        byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
	
	        // Create a new Stringbuilder to collect the bytes
	        // and create a string.
	        StringBuilder sBuilder = new StringBuilder();
	
	        // Loop through each byte of the hashed data 
	        // and format each one as a hexadecimal string.
	        for (int i = 0; i < data.Length; i++)
	        {
	            sBuilder.Append(data[i].ToString("x2"));
	        }
	
	        // Return the hexadecimal string.
	        return sBuilder.ToString();
	    }

	    // Verify a hash against a string.
	    public bool verifyMd5Hash(string input, string hash)
	    {
	        // Hash the input.
	        string hashOfInput = getMd5Hash(input);
	
	        // Create a StringComparer an comare the hashes.
	        StringComparer comparer = StringComparer.OrdinalIgnoreCase;
	
	        if (0 == comparer.Compare(hashOfInput, hash))
	        {
	            return true;
	        }
	        else
	        {
	            return false;
	        }
	    }
	    
	    // calculo para codigo de acesso cartao presente     
        public string calculaCodigoAcesso(string empresa, string matricula, string  vencto)
        {
            string chave = matricula + empresa + vencto;
            int temp = 0;
            for ( int n = 0; n < chave.Length; n++ )
            {
                string s = chave.Substring(n, 1);
                char c   = s[0]; // First character in s
                int i    = c; // ascii code
                temp    += i;
            }
            string calculado = temp.ToString("0000");
            temp    += int.Parse( calculado[3].ToString() ) * 1000;
            temp    += int.Parse( calculado[2].ToString() );
            if ( temp > 9999 ) 
                temp -= 2000;
            calculado = temp.ToString( "0000" );
            calculado = calculado.Substring( 2,1 ) + 
                        calculado.Substring( 0,1 ) + 
                        calculado.Substring( 3,1 ) + 
                        calculado.Substring( 1,1 );
            return calculado;
        }

        // calculo codigo de acesso para cartoes convenio
        public string calculaCodigoAcesso( string empresa, string matricula, string titularidade, string via, string cpf) 
        {
            string chave = matricula + empresa + "01" + via + cpf.PadRight(14,' ');
            int temp = 0;
            for (int n = 0; n < chave.Length; n++)
            {
                string s = chave.Substring(n, 1);
                char c = s[0]; // First character in s
                int i = c; // ascii code
                temp += i;
            }
            string calculado = temp.ToString("0000");
            temp += int.Parse( calculado[3].ToString() ) * 1000;
            temp += int.Parse( calculado[2].ToString() );
            if (temp > 9999) temp -= 2000;
            calculado = temp.ToString("0000");
            calculado = calculado.Substring( 2, 1 ) + 
                        calculado.Substring( 0, 1 ) + 
                        calculado.Substring( 3, 1 ) + 
                        calculado.Substring( 1, 1 );
            return calculado;
        }

	}
}
