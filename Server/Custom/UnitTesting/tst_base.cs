using System;
using System.IO;
using System.Text;
using System.Collections;

namespace SyCrafEngine
{
	#if DEBUG || LOAD
	
	public class tst_base
	{
		public int currentItem = 0;
		public int itensOk	= 0;

		public string result  = "";
		public string session = "";
		public string tmp = "";
		public string demand = "";
		public string tmp_associate_id = "";
	
		public Transaction 		my_transaction;	
		public ArrayList 		my_objections = new ArrayList();
		public ApplicationUtil 	util = new ApplicationUtil();
		
		///InitUserCode
		///EndUserCode
	}
	
	#endif
}
