using System;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SyCrafEngine
{
	public class SyCrafReport
	{
		string var_desc 	= "";
		string var_empresa 	= "";
		string var_dt_ini 	= "";
		string var_dt_fim 	= "";
		
		ArrayList lstHeader;
		ArrayList lstContents;
		ArrayList lstTableSizes;
		ArrayList lstFooters;
		ArrayList lstMessages;
		ArrayList lstFilters;
			
		public SyCrafReport ( 	string desc, 
			                    string sigla,
			                  	string empresa, 
			                  	string dt_ini, 
			                  	string dt_fim,
			                  	ref ArrayList tmp_lstHeader,
			                    ref ArrayList tmp_lstContents,
			                    ref ArrayList tmp_lstTableSizes,
			                    ref ArrayList tmp_lstFooters,
			                    ref ArrayList tmp_lstMessages,
			                    ref ArrayList tmp_lstFilters )
		{
			var_desc 	= desc;
			var_empresa = empresa;
		    var_dt_ini 	= dt_ini; 
		    var_dt_fim 	= dt_fim;
		    
		    lstHeader     = tmp_lstHeader;
		    lstContents   = tmp_lstContents;
		    lstTableSizes = tmp_lstTableSizes;
		    lstFooters    = tmp_lstFooters;
		    lstMessages	  = tmp_lstMessages;
		    lstFilters    = tmp_lstFilters;
			
		    string path   = var_empresa.PadLeft ( 6, '0')  					   + "_" +
							sigla 										 	   + "_" + 
		    				DateTime.Now.Day.ToString().PadLeft 	( 2, '0' ) +
							DateTime.Now.Month.ToString().PadLeft 	( 2, '0' ) +
							DateTime.Now.Year.ToString().PadLeft 	( 4, '0' ) +
							DateTime.Now.Hour.ToString().PadLeft 	( 2, '0' ) +
							DateTime.Now.Minute.ToString().PadLeft 	( 2, '0' ) +
							DateTime.Now.Second.ToString().PadLeft 	( 2, '0' ) +
							".html";
			
			FileStream 	file;
			
			if ( File.Exists ( path ) )
			{
        		file = new FileStream ( path, FileMode.Truncate, FileAccess.Write );
			}
			else
			{
				file = new FileStream ( path, FileMode.CreateNew, FileAccess.Write );
			}
			    
			StreamWriter configFile  = new StreamWriter ( file, System.Text.Encoding.Default );	
			
			CodeHead ( ref configFile );
			CodeBody ( ref configFile );
			
			configFile.Flush();
			configFile.Close();
			
			file.Close();		
			
			Process.Start ( path );
		}

		public void CodeHead ( ref StreamWriter html )
		{
			html.WriteLine ( "<html>" );
			html.WriteLine ( "<head>" );
			html.WriteLine ( "<meta http-equiv=~'Content-Type' content='text/html; charset=iso-8859-1' />" );
			html.WriteLine ( "<title>ConveyNET: " + var_desc + " </title>" );
			html.WriteLine ( "<style type='text/css'>" );
			html.WriteLine ( "<!--" );
			html.WriteLine ( ".style1 {color: #FFFFFF}" );
			html.WriteLine ( ".style2 {font-size: small}" );
			html.WriteLine ( ".style3 {" );
			html.WriteLine ( "	font-size: large;" );
			html.WriteLine ( "	font-weight: bold;" );
			html.WriteLine ( "	font-family: Tahoma;" );
			html.WriteLine ( "}" );
			html.WriteLine ( ".style4 {" );
			html.WriteLine ( "	font-family: Tahoma;" );
			html.WriteLine ( "	color: #003399;" );
			html.WriteLine ( "}" );
			html.WriteLine ( ".style5 {color: #666666}" );
			html.WriteLine ( ".style6 {color: #FFFFFF}" );
			html.WriteLine ( ".style7 {" );
			html.WriteLine ( "	font-family: Tahoma;" );
			html.WriteLine ( "	font-weight: normal;" );
			html.WriteLine ( "	font-size: x-small;" );
			html.WriteLine ( "	color: #0A0A0A;" );
			html.WriteLine ( "}" );
			html.WriteLine ( "-->" );
			html.WriteLine ( "</style>" );
			html.WriteLine ( "</head>" );
		}
		
		public void CodeBody ( ref StreamWriter html )
		{
			html.WriteLine ( "<body>" );
			html.WriteLine ( "<p class='style3'>ConveyNET</p>" );
			html.WriteLine ( "<p class='style4'>" + var_desc + "</p>" );
			html.WriteLine ( "<p class='style5'>" + var_empresa + "<br />" );
			
			if ( var_dt_fim != "" )
				html.WriteLine ( "  Período: " + var_dt_ini + " , " + var_dt_fim + "</p>" );  
			else
				html.WriteLine ( "  Dia: " + var_dt_ini + "</p>" );  

			if ( lstFilters.Count > 1 )
			{
				html.WriteLine ( "<p class='style2'>" + lstFilters[0].ToString() + "<br />" );
			
				int t=1;
				
				if ( lstFilters.Count > 2 )
				{
					for (; t < lstFilters.Count-1; ++t )
						html.WriteLine ( " " + lstFilters[t].ToString() + "<br />" );
				}
				
				html.WriteLine ( " " + lstFilters[t].ToString() + "</p>" );
			}
			else if ( lstFilters.Count == 1 )
				html.WriteLine ( "<p class='style2'>" + lstFilters[ 0 ].ToString() + "</p>" );			
			
			CodeReport ( ref html );
			
			html.WriteLine ( "<br />" );
			html.WriteLine ( "</body>" );
			html.WriteLine ( "</html>" );
		}
			
		public void CodeReport ( ref StreamWriter html )
		{
			for (int h=0; h < lstHeader.Count; ++h )
			{
				bool IsParLine = true;
				
				ArrayList tmp_head_cur_categ    = lstHeader   [h] as ArrayList;
				ArrayList tmp_content_cur_categ = lstContents [h] as ArrayList;
				ArrayList tmp_footer_cur_categ  = lstFooters  [h] as ArrayList;
			
				if ( lstMessages[h].ToString() != "" )
					html.WriteLine ( "<p class='style4'>" + lstMessages[h].ToString() + "</p>" );
				
				int size = (int) lstTableSizes[h];
					
				html.WriteLine ( "<table width='" + size + "' border='0' cellpadding='2' cellspacing='1' bgcolor='#006699'>" );
				
				if ( tmp_head_cur_categ.Count > 0 )
				{
					html.WriteLine ( "  <tr align='left'>" );
					html.WriteLine ( "    <th width='60'><span class='style6'>ID</span></th>" );
				}
				
				for (int t=0; t < tmp_head_cur_categ.Count; ++t )
				{
					string cont = tmp_head_cur_categ[t].ToString();
					
					bool IsMoney = false;
					
					for (int i=0; i < cont.Length; ++i )
					{
						if ( cont[i] == '$' )
						{
							IsMoney = true;
							break;
						}
					}
					
					if ( IsMoney )
						html.WriteLine ( "    <th nowrap align='right' ><span class='style6'>" + cont.ToString() + "</span></th>" );
					else
						html.WriteLine ( "    <th nowrap align='left' ><span class='style6'>" + cont.ToString() + "</span></th>" );
				}
				
				html.WriteLine ( "  </tr>" );
				
				for (int t=0; t < tmp_content_cur_categ.Count; ++t )
				{
					IsParLine = !IsParLine;
					
					ArrayList tmp_line = tmp_content_cur_categ[t] as ArrayList;
					
					if ( tmp_line.Count >  0 )
					{
						if ( IsParLine )
							html.WriteLine ( "  <tr align='left' bgcolor='#DDDDDD'>" );
						else
							html.WriteLine ( "  <tr align='left' bgcolor='#CCCCCC'>" );
							
						html.WriteLine ( "    <th ><span class='style7'>" + (t+1).ToString().PadLeft ( 6, '0' ) + " </span></th>" );
						
						for (int g=0; g < tmp_line.Count; ++g )	
						{
							string cont = tmp_line[ g ].ToString();
							
							bool IsNumber = true;
							
							for (int i=0; i < cont.Length; ++i )
							{
								if ( Char.IsLetter ( cont[i] ) )
								{
									IsNumber = false;
									break;
								}
							}
							
							if ( IsNumber )
								html.WriteLine ( "    <th nowrap align='right' ><span class='style7'>" + cont + "</span></th>" );
							else
								html.WriteLine ( "    <th nowrap align='left' ><span class='style7'>" + cont + "</span></th>" );
						}
					}
					
					html.WriteLine ( "  </tr>" );
				}
				
				html.WriteLine ( "</table>" );
				html.WriteLine ( "<p>" );
				
				if ( tmp_footer_cur_categ.Count > 0 )
				{
					int t=0;
					
					if ( tmp_footer_cur_categ.Count > 1 )
					{
						html.WriteLine ( "<p class='style2'>" + tmp_footer_cur_categ[t++].ToString() + "<br />" );
					
						if ( tmp_footer_cur_categ.Count > 2 )
						{
							for (; t < tmp_footer_cur_categ.Count-1; ++t )
								html.WriteLine ( " " + tmp_footer_cur_categ[t].ToString() + "<br />" );
						}
						
						html.WriteLine ( " " + tmp_footer_cur_categ[t].ToString() + "</p>" );
					}
					else
						html.WriteLine ( "<p class='style2'>" + tmp_footer_cur_categ[t++].ToString() + "</p>" );
				}
				
				html.WriteLine ( "<p>" );
			}
		}
	}
}
