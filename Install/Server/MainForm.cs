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
	public partial class MainForm : Form
	{
		public Translator 	var_trans = new Translator();
		public InstallData 	var_data  = new InstallData();
		public ExchangeArea var_ex    = new ExchangeArea();
		
		public int index = 0;
				
		public MainForm()
		{
			InitializeComponent();
			
			if ( var_data.IsAppInstalled )
			{
				var_trans.path = var_data.pathDir;
				var_trans.load();
			}
			
			lblVers.Text = var_data.st_version;
			
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
			
			Text = InfraSoftwareServer.nameServer + " Server";
			
			ctrl_Intro1.var_trans 				= var_trans;
			//ctrl_Lang1.var_trans  				= var_trans;
			ctrl_appDir1.var_trans  			= var_trans;
			ctrl_bdChoice1.var_trans  			= var_trans;
			ctrl_configInstall1.var_trans  		= var_trans;
			ctrl_installing1.var_trans  		= var_trans;
			//ctrl_uninstallConfirm1.var_trans  	= var_trans;
			ctrl_softRemove1.var_trans  		= var_trans;
			
			ctrl_Intro1.var_data 				= var_data;
			//ctrl_Lang1.var_data  				= var_data;
			ctrl_appDir1.var_data  				= var_data;
			ctrl_bdChoice1.var_data  			= var_data;
			ctrl_configInstall1.var_data	  	= var_data;
			ctrl_installing1.var_data  			= var_data;
			//ctrl_uninstallConfirm1.var_data		= var_data;
			ctrl_softRemove1.var_data			= var_data;
			
			ctrl_Intro1.var_ex 					= var_ex;
			//ctrl_Lang1.var_ex  					= var_ex;
			ctrl_appDir1.var_ex  				= var_ex;
			ctrl_bdChoice1.var_ex  				= var_ex;
			ctrl_configInstall1.var_ex		  	= var_ex;
			ctrl_installing1.var_ex  			= var_ex;
			//ctrl_uninstallConfirm1.var_ex		= var_ex;
			ctrl_softRemove1.var_ex				= var_ex;
		
			lblVers.Text = var_data.st_version;
			
			if ( var_data.IsAppInstalled )
			{
				if ( !var_data.IsUpgrade )
				{
					updateUninstallCtrls();
				}
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
			btnPrevious.Text = var_trans.GetMsg ( "SI_MainForm", "btnPrevious" );
			btnNext.Text 	 = var_trans.GetMsg ( "SI_MainForm", "btnNext" );
			
			if ( !var_data.IsAppInstalled || var_data.IsUpgrade )
			{
				if ( var_data.IsUpgrade )
				{
					switch ( index )
					{
						case 0:
						{
							lblTitle.Text    = var_trans.GetMsg ( "SI_MainForm", "lblTitle_ctrl_configInstallUpgrade" 	);
							lblSubTitle.Text = var_trans.GetMsg ( "SI_MainForm", "lblSubTitle_ctrl_configInstall" 	);
							break;
						}
							
						case 1:
						{
							lblTitle.Text    = var_trans.GetMsg ( "SI_MainForm", "lblTitle_ctrl_installingUpgrade" );
							lblSubTitle.Text = var_trans.GetMsg ( "SI_MainForm", "lblSubTitle_ctrl_installing" 		);
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
							lblTitle.Text    = var_trans.GetMsg ( "SI_MainForm", "lblTitle_ctrl_Lang" 		);
							lblSubTitle.Text = var_trans.GetMsg ( "SI_MainForm", "lblSubTitle_ctrl_Lang" 	);
							break;
						}
							
						case 1:	
						{
							lblTitle.Text    = var_trans.GetMsg ( "SI_MainForm", "lblTitle_ctrl_Intro" 		);
							lblSubTitle.Text = var_trans.GetMsg ( "SI_MainForm", "lblSubTitle_ctrl_Intro" 	);
							break;
						}
							
						case 2:
						{
							lblTitle.Text    = var_trans.GetMsg ( "SI_MainForm", "lblTitle_ctrl_appDir" 	);
							lblSubTitle.Text = var_trans.GetMsg ( "SI_MainForm", "lblSubTitle_ctrl_appDir" 	);
							break;
						}
							
						case 3:
						{
							lblTitle.Text    = var_trans.GetMsg ( "SI_MainForm", "lblTitle_ctrl_bdChoice" 	);
							lblSubTitle.Text = var_trans.GetMsg ( "SI_MainForm", "lblSubTitle_ctrl_bdChoice" );
							break;
						}
							
						case 4:
						{
							lblTitle.Text    = var_trans.GetMsg ( "SI_MainForm", "lblTitle_ctrl_configInstall" 	);
							lblSubTitle.Text = var_trans.GetMsg ( "SI_MainForm", "lblSubTitle_ctrl_configInstall" 	);
							break;
						}
							
						case 5:
						{
							lblTitle.Text    = var_trans.GetMsg ( "SI_MainForm", "lblTitle_ctrl_installing" );
							lblSubTitle.Text = var_trans.GetMsg ( "SI_MainForm", "lblSubTitle_ctrl_installing" 		);
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
						lblTitle.Text    = var_trans.GetMsg ( 	"SI_MainForm_un", 
							                                   	"lblTitle_ctrl_uninstallConfirm" 		);
							
						lblSubTitle.Text = var_trans.GetMsg ( 	"SI_MainForm_un", 
							                                   	"lblSubTitle_ctrl_uninstallConfirm" 	);
						break;
					}
						
					case 1:	
					{
						lblTitle.Text    = var_trans.GetMsg ( 	"SI_MainForm_un", 
							                                   	"lblTitle_ctrl_softRemove" 		);
							
						lblSubTitle.Text = var_trans.GetMsg ( 	"SI_MainForm_un", 
							                                   	"lblSubTitle_ctrl_softRemove" 	);
						break;
					}
						
					default: break;
				}				
			}
		}
		
		public void hideControls()
		{
			ctrl_Intro1.Visible 			= false;
			//ctrl_Lang1.Visible  			= false;
			ctrl_appDir1.Visible 			= false;
			ctrl_bdChoice1.Visible  		= false;
			ctrl_configInstall1.Visible		= false;
			ctrl_installing1.Visible  		= false;
			//ctrl_uninstallConfirm1.Visible 	= false;
			ctrl_softRemove1.Visible 		= false;
		}
			
		public void updateInstallCtrls()
		{
			translate();
			hideControls();

			btnPrevious.Enabled = true;
			btnNext.Enabled     = true;
			
			if ( var_data.IsUpgrade )
			{
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
				switch ( index )
				{
					case 0:	 	btnPrevious.Enabled = false; 							
								break;
					
					case 5:	 	btnPrevious.Enabled = false; 
								btnNext.Enabled 	= false; 	
								break;
					
					default: break;
				}			
				
				switch ( index )
				{
					//case 0:	 ctrl_Lang1.Visible  		 = true; ctrl_Lang1.reset();			break;
					case 1:	 ctrl_Intro1.Visible 		 = true; ctrl_Intro1.reset();			break;
					case 2:	 ctrl_appDir1.Visible 		 = true; ctrl_appDir1.reset();			break;
					case 3:	 ctrl_bdChoice1.Visible 	 = true; ctrl_bdChoice1.reset();		break;
					case 4:	 ctrl_configInstall1.Visible = true; ctrl_configInstall1.reset();	break;
					case 5:	 ctrl_installing1.Visible 	 = true; ctrl_installing1.reset();		break;
					
					default: break;
				}			
			}
		}
		
		public void updateUninstallCtrls()
		{
			translate();
			hideControls();
			
			btnPrevious.Enabled = false;
			btnNext.Enabled     = true;
			
			// Active Controls
			switch ( index )
			{
				//case 0:	 ctrl_uninstallConfirm1.Visible  = true; ctrl_uninstallConfirm1.reset();	break;
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
					
					if ( msg != "" ) MessageBox.Show ( msg,"System" );
				}
				else
				{
					switch ( index )
					{
						//case 0:	{ if ( ctrl_Lang1.IsNextReady 			( ref msg ) ) { index++; updateInstallCtrls(); return; } break; }
						case 1:	{ if ( ctrl_Intro1.IsNextReady 			( ref msg ) ) { index++; updateInstallCtrls(); return; } break; }
						case 2:	{ if ( ctrl_appDir1.IsNextReady			( ref msg ) ) { index++; updateInstallCtrls(); return; } break; }
						case 3:	{ if ( ctrl_bdChoice1.IsNextReady		( ref msg ) ) { index++; updateInstallCtrls(); return; } break; }
						case 4:	{ if ( ctrl_configInstall1.IsNextReady	( ref msg ) ) { index++; updateInstallCtrls(); return; } break; }
						
						case 5:	{ Close(); return; }
						
						default: return; 
					}			
					
					if ( msg != "" ) MessageBox.Show ( msg,"System" );
				}
			}
			else
			{
				switch ( index )
				{
					//case 0:	{ if ( ctrl_uninstallConfirm1.IsNextReady 	( ref msg ) ) { index++; updateUninstallCtrls(); return; } break; }
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
					// nothing to do!
				}
				else
				{
					switch ( index )
					{
						//case 0:	{ if ( ctrl_Lang1.IsPrevReady 			( ref msg ) ) { index--; updateInstallCtrls(); return; } break; }
						case 1:	{ if ( ctrl_Intro1.IsPrevReady 			( ref msg ) ) { index--; updateInstallCtrls(); return; } break; }
						case 2:	{ if ( ctrl_appDir1.IsPrevReady 		( ref msg ) ) { index--; updateInstallCtrls(); return; } break; }
						case 3:	{ if ( ctrl_bdChoice1.IsPrevReady 		( ref msg ) ) { index--; updateInstallCtrls(); return; } break; }
						case 4:	{ if ( ctrl_configInstall1.IsPrevReady 	( ref msg ) ) { index--; updateInstallCtrls(); return; } break; }
										
						default: return;
					}			
					
					if ( msg != "" ) MessageBox.Show ( msg,"System" );
				}
			}
		}
		
		void Timer1Tick ( object sender, EventArgs e )
		{
            /*
			if ( ctrl_Lang1.IsLangUpdated )
			{
				ctrl_Lang1.IsLangUpdated = false;
				translate();
			}
			else if ( ctrl_installing1.IsDBFailure )
			{
				timer1.Stop();
				Close();
			}				
			else if ( ctrl_softRemove1.IsSoftRemovalProblem )
			{
				MessageBox.Show ( var_trans.GetMsg ( "SI_MainForm", "Abort" ), "SYSTEM" );
				
				timer1.Stop();
				Close();
			}				
			else if ( ctrl_installing1.IsInstallDone || ctrl_softRemove1.IsSoftRemovalReady )
			{
				btnNext.Text = var_trans.GetMsg ( "SI_MainForm", "btnFinish" );	
				btnNext.Enabled = true; 
				
				timer1.Stop();
			}*/			
		}
	}
	
	public class ExchangeArea 
	{
		public bool tg_desktopShortcut = false;
	}
}
