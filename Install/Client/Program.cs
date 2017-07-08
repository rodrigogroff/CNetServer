using System;
using System.Windows.Forms;

namespace ClientSetup
{
	internal sealed class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
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
