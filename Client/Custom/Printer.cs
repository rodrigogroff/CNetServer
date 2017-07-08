using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Text;

public class ConveyPrinter
{
    string st_font = "";
    
    int    i_size = 0, i_heigth = 0,  linesPrinted = 0;
    
    ArrayList lstReport; 
    
    PrintDocument       pdoc1 				= new PrintDocument();
	PrintDialog         printDialog1 		= new PrintDialog();
	PrintPreviewDialog  PrintPreviewDialog1 = new PrintPreviewDialog();

    public ConveyPrinter ( string font, int size, int heigth, ref ArrayList lst )
    {
    	st_font   = font;
    	i_size    = size;
    	i_heigth  = heigth;
    	
    	lstReport = lst;
    	
        pdoc1.PrintPage     += new PrintPageEventHandler( OnPrintPage   );
        pdoc1.BeginPrint    += new PrintEventHandler    ( OnBeginPrint  );
        
        PrintPreviewDialog1.Document = pdoc1;
        PrintPreviewDialog1.ShowDialog( );

        if (printDialog1.ShowDialog( ) == DialogResult.OK)
        {
            pdoc1.Print( );
        }
    }

    // OnBeginPrint 
    private void OnBeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        
    }
    
    // OnPrintPage
    private void OnPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        int x = 40, y = 40;
        
        Font myFont = new Font ( st_font, i_size );
        
        while (linesPrinted < lstReport.Count)
        {
        	e.Graphics.DrawString ( lstReport[linesPrinted++].ToString(), myFont, Brushes.Black, x, y);
            y += i_heigth;
            
            if (y >= e.MarginBounds.Bottom)
            {
                e.HasMorePages = true;
                return;
            }
        }

        linesPrinted = 0;
        e.HasMorePages = false;
    }
}
