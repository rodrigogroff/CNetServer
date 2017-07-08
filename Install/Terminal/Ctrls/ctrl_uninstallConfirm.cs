using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace ClientSetup
{
	public partial class ctrl_uninstallConfirm : UserControl
	{
		public Translator 	var_trans;
		public InstallData  var_data;
		
		public ctrl_uninstallConfirm()
		{
			InitializeComponent();
		}
		
		public void reset ( )
		{
			lblConf.Text = var_trans.GetMsg ( "CI_ctrl_uninstallConfirm", "lblConf" );
			rbYes.Text 	 = var_trans.GetMsg ( "CI_ctrl_uninstallConfirm", "rbYes" );
			rbNo.Text 	 = var_trans.GetMsg ( "CI_ctrl_uninstallConfirm", "rbNo" );
		}
		
		public bool IsPrevReady ( ref string msg )
		{
			return true;
		}
		
		public bool IsNextReady ( ref string msg )
		{
			if ( !rbYes.Checked )
				return false;
			else
				return true;
		}
	}
}
