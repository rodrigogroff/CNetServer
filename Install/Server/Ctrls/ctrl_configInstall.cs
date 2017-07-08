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

using SyCrafEngine;

namespace ServerSetup
{
	public partial class ctrl_configInstall : UserControl
	{
		public Translator var_trans;
		public InstallData  var_data;
		public ExchangeArea var_ex;
		
		public bool tg_desktopShortcut = false;

		public ctrl_configInstall()
		{
			InitializeComponent();
		}
		
		public void reset ()
		{
			string newLine = "\r\n";

			lblConfig.Text = var_trans.GetMsg ( "SI_ctrl_configInstall", "lblOpt1" ).Replace ( "{$1}", newLine + var_data.pathDir + newLine );
			lblConfig.Text += newLine;
			
			if ( tg_desktopShortcut )
			{
				lblConfig.Text += 	var_trans.GetMsg ( "SI_ctrl_configInstall", "lblOpt2" ) + newLine;
			}
			
			if ( var_data.slaveOnly == "True" )
			{
				lblConfig.Text += 	var_trans.GetMsg ( "SI_ctrl_configInstall", "lblOpt21" ) + newLine;
			}
			else
			{
				if ( var_data.IsUpgrade )
					lblConfig.Text += 	var_trans.GetMsg ( "SI_ctrl_configInstall", "lblOpt3" ).Replace ( "{$1}", InfraSoftwareServer.db_schema ) + newLine;
				else
					lblConfig.Text += 	var_trans.GetMsg ( "SI_ctrl_configInstall", "lblOpt3" ).Replace ( "{$1}", var_data.db_schema ) + newLine;
			}
				
			lblFinal.Text = var_trans.GetMsg ( "SI_ctrl_configInstall", "lblFinal" 	);
			lblNext.Text  = var_trans.GetMsg ( "SI_ctrl_configInstall", "lblNext" 	);
		}
		
		public bool IsPrevReady ( ref string msg )
		{
			return true;
		}
		
		public bool IsNextReady ( ref string msg )
		{
			Process[ ] lista = Process.GetProcessesByName ( InfraSoftwareServer.nameServer );
			
			if (lista.Length > 0 )
			{
			    MessageBox.Show ( "Close server application to proceed", "Error" );
				
				Application.Exit();
			    return false;
			}
			
			return true;
		}
	}
}
