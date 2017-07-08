using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace ServerSetup
{
	public partial class ctrl_bdChoice : UserControl
	{
		public Translator var_trans;
		public InstallData  var_data;
		public ExchangeArea var_ex;

		public ctrl_bdChoice()
		{
			InitializeComponent();
		}
		
		public void reset ()
		{
			lblBDSel.Text 		= var_trans.GetMsg 	( "SI_ctrl_bdChoice", "lblBDSel" 	 );
			lblUser.Text 		= var_trans.GetMsg 	( "SI_ctrl_bdChoice", "lblUser" 	 );
			lblPassword.Text 	= var_trans.GetMsg 	( "SI_ctrl_bdChoice", "lblPassword"	 );
			lblPort.Text 		= var_trans.GetMsg 	( "SI_ctrl_bdChoice", "lblPort" 	 );
			lblDBMachine.Text 	= var_trans.GetMsg 	( "SI_ctrl_bdChoice", "lblDBMachine" );
			
			txtDB.Text 			= "localhost";
			
			infra_DB_Options  db_opt = new infra_DB_Options();
			
			lstBD.Items.Clear();
			for (int t=0; t < db_opt.lstOpt.Count; ++t )
				lstBD.Items.Add ( db_opt.lstOpt[t] as string );
		}
		
		public bool IsPrevReady ( ref string msg )
		{
			return true;
		}
		
		public bool IsNextReady ( ref string msg )
		{
			var_data.user 				= txtUser.Text; 
			var_data.password			= txtPassword.Text;
			var_data.db_port			= txtPort.Text;
			var_data.slaveOnly			= "False";
					
			if ( var_data.slaveOnly == "False" )
			{
				if ( txtUser.Text.Length 	 == 0 || 
				     txtPassword.Text.Length == 0 ||
				     txtPort.Text.Length	 == 0 )
				{
					msg = var_trans.GetMsg ( "SI_ctrl_bdChoice", "VerifyDBOpt" );
					return false;
				}
					
				if ( lstBD.SelectedItem == null ) 
				{
					msg = var_trans.GetMsg ( "SI_ctrl_bdChoice", "Verify" );
					return false;			
				}
				else
				{
					var_data.db_schema	    = InfraSoftwareServer.db_schema;
					var_data.nameServer     = InfraSoftwareServer.nameServer;
					var_data.db_choice 		= lstBD.SelectedIndex.ToString();
					var_data.db_machine  	= txtDB.Text;
					return true;			
				}
			}
			
			return true;
		}
	}
}
