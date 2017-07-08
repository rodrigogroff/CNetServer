using System;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace ClientSetup
{
	public partial class ctrl_Intro : UserControl
	{
		public Translator var_trans;
		public InstallData  var_data;

		public ctrl_Intro()
		{
			InitializeComponent();
		}
		
		public void reset ()
		{
			rbAgree.Text 	= var_trans.GetMsg ( "CI_ctrl_Intro", "rbAgree" 	);
			rbDisagree.Text = var_trans.GetMsg ( "CI_ctrl_Intro", "rbDisagree" 	);
			
			StreamReader sr = new StreamReader ( "contrato.txt", Encoding.Default );
			
			txtIntro.Text   = sr.ReadToEnd();
			
			sr.Close();
		}
		
		public bool IsPrevReady ( ref string msg )
		{
			return true;
		}
		
		public bool IsNextReady ( ref string msg )
		{
			if ( rbAgree.Checked )
				return true;
			
			msg = var_trans.GetMsg ( "CI_ctrl_Intro", "Verify" );
			return false;			
		}
	}
}
