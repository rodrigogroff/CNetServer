using System;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace ServerSetup
{
	public partial class ctrl_appDir : UserControl
	{
		public Translator var_trans;
		public InstallData  var_data;
		public ExchangeArea var_ex;
			
		public ctrl_appDir()
		{
			InitializeComponent();
		}
		
		public void reset ()
		{
			lblLocation.Text 	= var_trans.GetMsg ( "SI_ctrl_appDir", "lblLocation" );
			
			btnFind.Text 		= var_trans.GetMsg ( "SI_ctrl_appDir", "btnFind"	 );
			btnFS.Text 			= var_trans.GetMsg ( "SI_ctrl_appDir", "btnFind"	 );
			
			txtLocation.Text    = "C:\\" + InfraSoftwareServer.nameServer;
			
			LblUpgradePath.Text = var_trans.GetMsg ( "SI_ctrl_appDir", "LblUpgradePath"	 	);
			btnFindPath.Text 	= var_trans.GetMsg ( "SI_ctrl_appDir", "btnFindPath"	 	);
			
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
			                           
			var_ex.tg_desktopShortcut       = true;
			
			var_data.pathDir 				= txtLocation.Text;
			var_data.clientServerPort 		= nu_CSP.Value.ToString();
			var_data.maxPacket        		= nu_MPS.Value.ToString();
			var_data.upgradePath			= TxtUpgradePath.Text;
			var_data.standBy				= TxtStandby.Text;
			var_data.standByPort			= numStandPort.Value.ToString();
			var_data.failFS					= TxtFailFS.Text;
			var_data.webStandBy				= TxtWebStandby.Text;
			
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
		
		void BtnFSClick(object sender, EventArgs e)
		{
			folderBrowserDialog1.Description = lblLocation.Text;
			folderBrowserDialog1.ShowDialog();
			
			if ( folderBrowserDialog1.SelectedPath != "" )
			{
				TxtFailFS.Text = folderBrowserDialog1.SelectedPath;
			}
		}
	}
}
