using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Data.Odbc;
using System.ComponentModel;

namespace ClientSetup
{
	internal sealed class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			bool isFirstInstance;
			
			using ( Mutex mtx = new Mutex ( true, "ClientSetup", out isFirstInstance ) )
			{
				if (!isFirstInstance) 
				{
					Application.Exit();
					return;
				} 
				
				try
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Application.Run(new MainForm());
				}
				catch ( System.Security.SecurityException ex )
				{
					ex.ToString();
					MessageBox.Show ( "Please copy the installation program into a local folder.", "SYSTEM" );
				}
				catch ( System.Exception ex )
				{
					if ( ex.Message != "Exit" )
						MessageBox.Show ( ex.Message, "SYSTEM" );
				}
			}
		}
	}
}
