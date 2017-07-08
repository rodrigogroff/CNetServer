using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace SyCrafEngine
{
	public class ApplicationUtil : InfraApplicationUtil
	{
		public bool offline = false;
		
		public int max_pack = Convert.ToInt32 ( new InstallData().maxPacket );
				
		public ListViewItem GetListViewItem ( string id, string [] vars )
		{
			if ( vars.Length == 0)
				return new ListViewItem();
			
			ListViewItem item = new ListViewItem ( vars[0] );
			
			item.Tag = id;
			for (int t=1; t < vars.Length; ++t)
				item.SubItems.Add ( vars [t] );
			
			return item;
		}

		public ListViewItem GetListViewItem ( string id, string [] vars, Color color, Color colorBg )
		{
			if ( vars.Length == 0)
				return new ListViewItem();
			
			Font x = new Font ( "Microsoft Sans Serif", (float) 8.2 );

			ListViewItem item = new ListViewItem ( vars, 0, color, colorBg, x );
			
			item.Tag = id;

			return item;
		}
		
		public string getSelectedListViewItemTag ( ListView lstView )
		{
			for (int t=0; t < lstView.Items.Count; ++t )
				if ( lstView.Items[t].Selected == true )
					return Convert.ToString ( lstView.Items[t].Tag );
			
			return null;
		}
					
		public string getDDMMYYYY_format ( string val )
		{
			DateTime t = Convert.ToDateTime (val);
			
			return t.ToString ( "dd/MM/yyyy HH:mm:ss" );
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
	}	
}
