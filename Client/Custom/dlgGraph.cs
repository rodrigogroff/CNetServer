using System;
using System.Drawing;
using System.Windows.Forms;

using ZedGraph;

namespace Client
{
	public partial class dlgGraph : Form
	{
		public string title = "";
				
		public dlgGraph()
		{
			InitializeComponent();
			
			Text = title;
			
			DlgGraphResize (null, null );
		}
		
		void DlgGraphResize(object sender, EventArgs e)
		{
			zed.Location = new Point( 10, 10 );
			// Leave a small margin around the outside of the control
			zed.Size = new Size( this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 20 );
		}
	}
}
