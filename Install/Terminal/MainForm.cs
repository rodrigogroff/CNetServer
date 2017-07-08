using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SyCrafEngine;

namespace ClientSetup
{
	public partial class MainForm : Form
	{
		public Translator 	var_trans = new Translator();
		public InstallData 	var_data  = new InstallData();
		
		public int index = 0;
				
		public MainForm()
		{
			InitializeComponent();
			
			lblVers.Text = var_data.st_version;
			
			if ( var_data.IsAppInstalled )
			{
				var_trans.path = var_data.pathDir;
				var_trans.load();
			}
			
			timer1.Start();

			if ( var_data.IsAppInstalled )
			{
				var_trans.SetLanguage ( var_data.language.ToString() );
			}
			else
			{
				var_trans.SetLanguage ( Language.English.ToString() );
			}
			
			if ( !var_data.IsEnabled )
			{
				MessageBox.Show ( var_trans.GetMsg ( "ServerSystem.NotEnabled" ), "SYSTEM" );
				throw ( new System.Exception ( "Exit" ) );
			}
			
			this.Text = InstallData.app;
			
			ctrl_Intro1.var_trans 				= var_trans;
			ctrl_Lang1.var_trans  				= var_trans;
			ctrl_appDir1.var_trans  			= var_trans;
			ctrl_configInstall1.var_trans  		= var_trans;
			ctrl_installing1.var_trans  		= var_trans;
			ctrl_uninstallConfirm1.var_trans  	= var_trans;
			ctrl_softRemove1.var_trans  		= var_trans;
			
			ctrl_Intro1.var_data 				= var_data;
			ctrl_Lang1.var_data  				= var_data;
			ctrl_appDir1.var_data  				= var_data;
			ctrl_configInstall1.var_data	  	= var_data;
			ctrl_installing1.var_data  			= var_data;
			ctrl_uninstallConfirm1.var_data		= var_data;
			ctrl_softRemove1.var_data			= var_data;
			
			lblVers.Text = var_data.st_version;
			
			if ( var_data.IsAppInstalled )
			{
				if ( !var_data.IsUpgrade )
					updateUninstallCtrls();
				else
					updateInstallCtrls();
			}
			else
			{
				updateInstallCtrls();
			}
		}
		
		public void translate()
		{
			btnPrevious.Text = var_trans.GetMsg ( "CI_MainForm", "btnPrevious" );
			btnNext.Text 	 = var_trans.GetMsg ( "CI_MainForm", "btnNext" );
			
			if ( !var_data.IsAppInstalled || var_data.IsUpgrade )
			{
				if ( var_data.IsUpgrade )
				{
					switch ( index )
					{
						case 0:
						{
							lblTitle.Text    = var_trans.GetMsg ( "CI_MainForm", "lblTitle_ctrl_configInstallUpgrade" 		);
							lblSubTitle.Text = var_trans.GetMsg ( "CI_MainForm", "lblSubTitle_ctrl_configInstallUpgrade" 	);
							break;
						}
							
						case 1:
						{
							lblTitle.Text    = var_trans.GetMsg ( "CI_MainForm", "lblTitle_ctrl_installing" 		);
							lblSubTitle.Text = var_trans.GetMsg ( "CI_MainForm", "lblSubTitle_ctrl_installing" 		);
							break;
						}
							
						default: break;
					}
				}
				else
				{
					switch ( index )
					{
						case 0:	
						{
							if ( var_data.IsUpgrade )
								lblTitle.Text    = var_trans.GetMsg ( "CI_MainForm", "lblTitle_ctrl_LangUpdate" 		);
							else
								lblTitle.Text    = var_trans.GetMsg ( "CI_MainForm", "lblTitle_ctrl_Lang" 		);
							
							lblSubTitle.Text = var_trans.GetMsg ( "CI_MainForm", "lblSubTitle_ctrl_Lang" 	);
							break;
						}
							
						case 1:	
						{
							lblTitle.Text    = var_trans.GetMsg ( "CI_MainForm", "lblTitle_ctrl_Intro" 		);
							lblSubTitle.Text = var_trans.GetMsg ( "CI_MainForm", "lblSubTitle_ctrl_Intro" 	);
							break;
						}
							
						case 2:
						{
							lblTitle.Text    = var_trans.GetMsg ( "CI_MainForm", "lblTitle_ctrl_appDir" 	);
							lblSubTitle.Text = var_trans.GetMsg ( "CI_MainForm", "lblSubTitle_ctrl_appDir" 	);
							break;
						}
							
						case 3:
						{
							lblTitle.Text    = var_trans.GetMsg ( "CI_MainForm", "lblTitle_ctrl_configInstall" 		);
							lblSubTitle.Text = var_trans.GetMsg ( "CI_MainForm", "lblSubTitle_ctrl_configInstall" 	);
							break;
						}
							
						case 4:
						{
							lblTitle.Text    = var_trans.GetMsg ( "CI_MainForm", "lblTitle_ctrl_installing" 		);
							lblSubTitle.Text = var_trans.GetMsg ( "CI_MainForm", "lblSubTitle_ctrl_installing" 		);
							break;
						}
							
						default: break;
					}
				}
			}
			else
			{
				switch ( index )
				{
					case 0:	
					{
						lblTitle.Text    = var_trans.GetMsg ( "CI_MainForm_un", "lblTitle_ctrl_Lang" 		);
						lblSubTitle.Text = var_trans.GetMsg ( "CI_MainForm_un", "lblSubTitle_ctrl_Lang" 	);
						break;
					}
						
					case 1:	
					{
						lblTitle.Text    = var_trans.GetMsg ( "CI_MainForm_un", "lblTitle_ctrl_uninstallConfirm" 		);
						lblSubTitle.Text = var_trans.GetMsg ( "CI_MainForm_un", "lblSubTitle_ctrl_uninstallConfirm" 	);
						break;
					}
						
					case 2:	
					{
						lblTitle.Text    = var_trans.GetMsg ( "CI_MainForm_un", "lblTitle_ctrl_softRemove" 		);
						lblSubTitle.Text = var_trans.GetMsg ( "CI_MainForm_un", "lblSubTitle_ctrl_softRemove" 	);
						break;
					}
						
					default: break;
				}				
			}
		}
		
		public void hideControls()
		{
			ctrl_Intro1.Visible 			= false;
			ctrl_Lang1.Visible  			= false;
			ctrl_appDir1.Visible 			= false;
			ctrl_configInstall1.Visible		= false;
			ctrl_installing1.Visible  		= false;
			ctrl_uninstallConfirm1.Visible 	= false;
			ctrl_softRemove1.Visible 		= false;
		}
			
		public void updateInstallCtrls()
		{
			translate();
			hideControls();
			
			if ( var_data.IsUpgrade )
			{
				btnPrevious.Enabled = true;
				btnNext.Enabled     = true;
				
				switch ( index )
				{
					case 0:	 	btnPrevious.Enabled = false; 							
								break;
					
					case 1:	 	btnPrevious.Enabled = false; 
								btnNext.Enabled 	= false; 	
								break;
					
					default: break;
				}
				
				switch ( index )
				{
					case 0:	 ctrl_configInstall1.Visible = true; ctrl_configInstall1.reset();	break;
					case 1:	 ctrl_installing1.Visible 	 = true; ctrl_installing1.reset();		break;
					
					default: break;
				}

			}
			else
			{
				btnPrevious.Enabled = true;
				btnNext.Enabled     = true;
					
				switch ( index )
				{
					case 0:	 	btnPrevious.Enabled = false; 							
								break;
					
					case 4:	 	btnPrevious.Enabled = false; 
								btnNext.Enabled 	= false; 	
								break;
					
					default: break;
				}
				
				// Active Controls
				switch ( index )
				{
					case 0:	 ctrl_Lang1.Visible  		 = true; ctrl_Lang1.reset();			break;
					case 1:	 ctrl_Intro1.Visible 		 = true; ctrl_Intro1.reset();			break;
					case 2:	 ctrl_appDir1.Visible 		 = true; ctrl_appDir1.reset();			break;
					case 3:	 ctrl_configInstall1.Visible = true; ctrl_configInstall1.reset();	break;
					case 4:	 ctrl_installing1.Visible 	 = true; ctrl_installing1.reset();		break;
					
					default: break;
				}
			}
			
			
		}
		
		public void updateUninstallCtrls()
		{
			translate();
			hideControls();
			
			btnPrevious.Enabled = true;
			btnNext.Enabled     = true;
			
			// Flow Control
			switch ( index )
			{
				case 0:	 	btnPrevious.Enabled = false; 							
							break;
				
				case 1:	 	btnPrevious.Enabled = false; 							
							btnNext.Enabled     = false;
							break;
				
				default: break;
			}			
			
			// Active Controls
			switch ( index )
			{
				case 0:	 ctrl_uninstallConfirm1.Visible  = true; ctrl_uninstallConfirm1.reset();	break;
				case 1:	 ctrl_softRemove1.Visible  	     = true; ctrl_softRemove1.reset();			break;
				
				default: break;
			}			
		}
		
		void BtnNextClick ( object sender, EventArgs e )
		{
			string msg = "";
			
			if ( !var_data.IsAppInstalled || var_data.IsUpgrade )
			{
				if ( var_data.IsUpgrade )
				{
					switch ( index )
					{
						case 0:	{ if ( ctrl_configInstall1.IsNextReady	( ref msg ) ) { index++; updateInstallCtrls(); return; } break; }
						case 1:	{ Close(); return; }
						
						default: return; 
					}			
				}
				else
				{
					switch ( index )
					{
						case 0:	{ if ( ctrl_Lang1.IsNextReady 			( ref msg ) ) { index++; updateInstallCtrls(); return; } break; }
						case 1:	{ if ( ctrl_Intro1.IsNextReady 			( ref msg ) ) { index++; updateInstallCtrls(); return; } break; }
						case 2:	{ if ( ctrl_appDir1.IsNextReady			( ref msg ) ) { index++; updateInstallCtrls(); return; } break; }
						case 3:	{ if ( ctrl_configInstall1.IsNextReady	( ref msg ) ) { index++; updateInstallCtrls(); return; } break; }
						
						case 4:	{ Close(); return; }
						
						default: return; 
					}			
				}
				
				if ( msg != "" ) MessageBox.Show ( msg,"System" );
			}
			else
			{
				switch ( index )
				{
					case 0:	{ if ( ctrl_uninstallConfirm1.IsNextReady 	( ref msg ) ) { index++; updateUninstallCtrls(); return; } break; }
					case 1:	{ Close(); return; }
					
					default: return; 
				}			
				
				if ( msg != "" ) MessageBox.Show ( msg,"System" );
			}
		}
		
		void BtnPreviousClick ( object sender, EventArgs e )
		{
			string msg = "";
			
			if ( !var_data.IsAppInstalled || var_data.IsUpgrade )
			{
				if ( var_data.IsUpgrade )
				{
					switch ( index )
					{
						case 0:	{ if ( ctrl_configInstall1.IsPrevReady 	( ref msg ) ) { index--; updateInstallCtrls(); return; } break; }
										
						default: return;
					}
				}
				else
				{
					switch ( index )
					{
						case 0:	{ if ( ctrl_Lang1.IsPrevReady 			( ref msg ) ) { index--; updateInstallCtrls(); return; } break; }
						case 1:	{ if ( ctrl_Intro1.IsPrevReady 			( ref msg ) ) { index--; updateInstallCtrls(); return; } break; }
						case 2:	{ if ( ctrl_appDir1.IsPrevReady 		( ref msg ) ) { index--; updateInstallCtrls(); return; } break; }
						case 3:	{ if ( ctrl_configInstall1.IsPrevReady 	( ref msg ) ) { index--; updateInstallCtrls(); return; } break; }
										
						default: return;
					}
				}
				
				if ( msg != "" ) MessageBox.Show ( msg,"System" );
			}
			else
			{
				switch ( index )
				{
					case 0:	{ if ( ctrl_uninstallConfirm1.IsPrevReady 	( ref msg ) ) { index--; updateUninstallCtrls(); return; } break; }
									
					default: return;
				}			
				
				if ( msg != "" ) MessageBox.Show ( msg,"System" );
			}
		}
		
		void Timer1Tick ( object sender, EventArgs e )
		{
			if ( ctrl_Lang1.IsLangUpdated )
			{
				ctrl_Lang1.IsLangUpdated = false;
				translate();
			}
			else if ( ctrl_softRemove1.IsSoftRemovalProblem )
			{
				MessageBox.Show ( var_trans.GetMsg ( "CI_MainForm", "Abort" ), "SYSTEM" );
				
				timer1.Stop();
				Close();
			}				
			else if ( ctrl_installing1.IsInstallDone || ctrl_softRemove1.IsSoftRemovalReady )
			{
				btnNext.Text = var_trans.GetMsg ( "CI_MainForm", "btnFinish" );	
				btnNext.Enabled = true; 
				
				timer1.Stop();
			}			
		}
	}
}
