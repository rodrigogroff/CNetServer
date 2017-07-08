using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using SyCrafEngine;

//UserIncludes
//UserIncludes END

namespace Client
{
	public class event_dlgPend : EventLayer
	{
		#region - EVENTS -
		public const int event_Load = 0;
		public const int event_Translate = 1;
		public const int event_FormIsOpening = 2;
		public const int event_BtnRemoverClick = 3;
		public const int event_BtnConfirmarClick = 4;
		#endregion

		public dlgPend i_Form;

		//UserVariables
		
		public CNetHeader header;
		
		//UserVariables END
		
		public ApplicationUtil 	var_util;
		public Exchange 		var_exchange;
		public Translator		var_Translator;
		
		public event_dlgPend ( ApplicationUtil util, Exchange ex )
		{
			var_util = util;
			var_exchange = ex;
		
			i_Form = new dlgPend ( this );
		}
		
		public override bool doEvent ( int event_number, object arg )
		{
			switch ( event_number )
			{
				#region - event_Load -
				
				case event_Load:
				{
					//InitEventCode event_Load
					
					doEvent ( event_Translate, 			null );
					doEvent ( event_FormIsOpening, 		null );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_Translate -
				
				case event_Translate:
				{
					//InitEventCode event_Translate
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_FormIsOpening -
				
				case event_FormIsOpening:
				{
					//InitEventCode event_FormIsOpening
					
					string upgradePath = "Pendencias";
					
					if ( var_util.offline )
						i_Form.BtnConfirmar.Enabled = false;
					
					i_Form.LstPend.Items.Clear();
					
					if ( Directory.Exists ( upgradePath ) )
		      		{
		      			string [] 	my_files = Directory.GetFiles ( upgradePath );
						int 		numFiles = my_files.GetLength (0);
					
						for ( int t=0; t < numFiles; ++t)
						{
							string fileName = my_files[t];
							
							StreamReader sr = new StreamReader ( fileName );
							
							string cart = sr.ReadLine();
							string valu = "R$ " + new SyCrafEngine.money().formatToMoney ( sr.ReadLine() );
							
							string [] full_row = { cart , valu };
							
							i_Form.LstPend.Items.Add ( var_util.GetListViewItem ( fileName, full_row ) );
							
							i_Form.LstPend.Items[ t].Selected = true;								
							
							sr.Close();
						}
					}
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnRemoverClick -
				
				case event_BtnRemoverClick:
				{
					//InitEventCode event_BtnRemoverClick
					
					if ( MessageBox.Show (	"Confirma remoção deste registro?",
			                    			"Aviso", 
			                    			MessageBoxButtons.YesNo, 
			                    			MessageBoxIcon.Question, 
			                    			MessageBoxDefaultButton.Button2 ) == DialogResult.No )
					{
						return false;
					}
					
					string file = var_util.getSelectedListViewItemTag ( i_Form.LstPend );
					
					File.Delete ( file );
					
					doEvent ( event_FormIsOpening, null );
					
					//EndEventCode
					return true;
				}
				
				#endregion
				
				#region - event_BtnConfirmarClick -
				
				case event_BtnConfirmarClick:
				{
					//InitEventCode event_BtnConfirmarClick
					
					if ( i_Form.LstPend.SelectedItems.Count == 0 )
						return false;
					
					int max =  i_Form.LstPend.SelectedItems.Count;
					
					for ( int t=0; t < max; ++t )
					{
						string st_cart  = i_Form.LstPend.SelectedItems[t].SubItems[0].Text;
						string vr_valor = i_Form.LstPend.SelectedItems[t].SubItems[1].Text;
						
						vr_valor = vr_valor.Replace ( "R$ ", "" ).Replace ( ".", "" ).Replace ( ",","" );
						
						string fileName = i_Form.LstPend.SelectedItems[t].Tag.ToString();
						
						if ( var_exchange.exec_venda_pend_lojista ( st_cart, 
						                                            vr_valor, 
						                                            ref header ) )
						{
							if ( File.Exists ( fileName ) ) 
								File.Delete ( fileName );
						}
					}
					
					doEvent ( event_FormIsOpening, null );
					
					//EndEventCode
					return true;
				}
				
				#endregion
		
				default: break;
			}
		
			return false;
		}
	}
}
