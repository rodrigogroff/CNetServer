using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace ClientSetup
{
	public partial class ctrl_Lang : UserControl
	{
		public Translator 	var_trans;
		public InstallData  var_data;
		
		public bool IsLangUpdated = false;
			
		public ctrl_Lang()
		{
			InitializeComponent();
		}
		
		public void reset ( )
		{
			lblLang.Text = var_trans.GetMsg ( "CI_ctrl_Lang", "lblLang" );
				
			if ( cboLang.Items.Count == 0 )
			{
				ArrayList vec = new LanguageDesc().GetArray();
				for ( int t=0 ; t < vec.Count; ++t )
					cboLang.Items.Add ( var_trans.GetMsg ( vec[t].ToString() ) );
				
				cboLang.SelectedIndex = 0;
			}
		}
		
		public bool IsPrevReady ( ref string msg )
		{
			return false;
		}
		
		public bool IsNextReady ( ref string msg )
		{
			return true;
		}
		
		void CboLangSelectedIndexChanged(object sender, EventArgs e)
		{
			var_data.language = cboLang.SelectedIndex.ToString();
			
			var_trans.SetLanguage ( var_data.language );
			IsLangUpdated = true;
			reset();
		}
	}
}
