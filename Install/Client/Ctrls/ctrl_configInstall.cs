using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace ClientSetup
{
	public partial class ctrl_configInstall : UserControl
	{
		public Translator var_trans;
		public InstallData  var_data;

		public ctrl_configInstall()
		{
			InitializeComponent();
		}
		
		public void reset ()
		{
			string newLine = "\r\n";

			lblConfig.Text = var_trans.GetMsg ( "CI_ctrl_configInstall", "lblOpt1" ).Replace ( "{$1}", newLine + var_data.pathDir + newLine );
			lblConfig.Text += newLine;
			
			lblConfig.Text += var_trans.GetMsg ( "CI_ctrl_configInstall", "lblOpt2" ).
								Replace ( "{$1}", var_data.serverMachine ).
								Replace ( "{$2}", var_data.clientServerPort );
							
			lblConfig.Text += newLine;
				
			lblFinal.Text = var_trans.GetMsg ( "CI_ctrl_configInstall", "lblFinal" 	);
			lblNext.Text  = var_trans.GetMsg ( "CI_ctrl_configInstall", "lblNext" 	);
		}
		
		public bool IsPrevReady ( ref string msg )
		{
			return true;
		}
		
		public bool IsNextReady ( ref string msg )
		{
			return true;
		}
	}
}
