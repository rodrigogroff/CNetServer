using System;
using System.IO;
using System.Text;
using System.Collections;

namespace SyCrafEngine
{
	#if DEBUG || LOAD
	
	public class UnitTest
	{
		public string session = "";
		public string os = "";
		
		public void LogTest ( string tst, ref StreamWriter m_Log )
		{
			m_Log.WriteLine( "" );
			m_Log.WriteLine( "-----------------------------------------------" );
			m_Log.WriteLine( tst );
			m_Log.WriteLine( "-----------------------------------------------" );
			m_Log.WriteLine( "" );
		}
	}
	
	#endif
}
