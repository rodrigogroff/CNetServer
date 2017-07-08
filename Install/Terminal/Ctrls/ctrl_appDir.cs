using System;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace ClientSetup
{
	public partial class ctrl_appDir : UserControl
	{
		public Translator 	var_trans;
		public InstallData  var_data;
			
		public ctrl_appDir()
		{
			InitializeComponent();
		}
		
		public void reset ()
		{
			txtLocation.Text    = "C:\\" + InfraSoftwareClient.nameClient + " " + InstallData.app;
			txtSrvName.Text 	= "localhost";
			
			lblLocation.Text 	= var_trans.GetMsg ( "CI_ctrl_appDir", "lblLocation" 		);
			lblServerName.Text  = var_trans.GetMsg ( "CI_ctrl_appDir", "lblServerName" 		);
			lblServerPort.Text  = var_trans.GetMsg ( "CI_ctrl_appDir", "lblServerPort"	 	);
			lblMPS.Text  		= var_trans.GetMsg ( "CI_ctrl_appDir", "lblMPS"			 	);
			btnFind.Text 		= var_trans.GetMsg ( "CI_ctrl_appDir", "btnFind"	 		);
			
			LblUpgradePath.Text = var_trans.GetMsg ( "CI_ctrl_appDir", "LblUpgradePath"	 	);
			btnFindPath.Text 	= var_trans.GetMsg ( "CI_ctrl_appDir", "btnFindPath"	 	);
			
			TxtUpgradePath.Text = var_data.upgradePath;
		}
		
		public bool IsPrevReady ( ref string msg )
		{
			return true;
		}
		
		public bool IsNextReady ( ref string msg )
		{
			try
			{
				Directory.CreateDirectory ( txtLocation.Text );
			}
			catch ( System.Exception ex )
			{
				msg = ex.ToString();
				return false;				
			}
			                           
			var_data.pathDir         	= txtLocation.Text;
			var_data.serverMachine      = txtSrvName.Text;
			var_data.clientServerPort 	= nu_CSP.Value.ToString();
			var_data.maxPacket        	= nu_MPS.Value.ToString();
			var_data.upgradePath		= TxtUpgradePath.Text;
			
			return true;			
		}		
		
		void BtnFindClick ( object sender, EventArgs e )
		{
			folderBrowserDialog1.Description = lblLocation.Text;
			folderBrowserDialog1.ShowDialog();
			
			if ( folderBrowserDialog1.SelectedPath != "" )
			{
				txtLocation.Text = folderBrowserDialog1.SelectedPath;
			}
		}
		
		void BtnFindPathClick(object sender, EventArgs e)
		{
			folderBrowserDialog1.Description = lblLocation.Text;
			folderBrowserDialog1.ShowDialog();
			
			if ( folderBrowserDialog1.SelectedPath != "" )
			{
				TxtUpgradePath.Text = folderBrowserDialog1.SelectedPath;
			}
		}
	}
}
