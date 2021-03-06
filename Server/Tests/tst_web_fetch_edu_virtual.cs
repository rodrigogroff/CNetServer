﻿using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;

namespace SyCrafEngine
{
	#if DEBUG 
	public class tst_web_fetch_edu_virtual : tst_base
	{
/// USER [ usr_var_decl ]
/// USER [ usr_var_decl ] END

		public web_fetch_edu_virtual transaction = new web_fetch_edu_virtual();
		public UnitTest tst_unit = new UnitTest();

		public Communication 	m_Comm;
		public StreamWriter 	m_Log;
		public DB_Access 		m_my_access;

		#region - CONSTRUCTOR -

		public tst_web_fetch_edu_virtual ( ref StreamWriter p_m_Log, 
									ref Communication p_m_Comm, 
									ref DB_Access p_m_my_access,  
									string p_session, 
									string current_demand )  
		{
			m_Comm      = p_m_Comm;
			m_Log       = p_m_Log;
			m_my_access = p_m_my_access; 
			demand      = current_demand;
			my_transaction = (Transaction) transaction;

			session = p_session;
			tst_unit.session = session;

			transaction.SetSessionKey     ( session           );
			transaction.SetCommunication  ( ref m_Comm        );
			transaction.SetLogAccess      ( ref m_Log         );
			transaction.SetAccess         ( ref m_my_access   );

			transaction.var_Translator = new Translator();
			transaction.ut_enabled = true;
		}

		#endregion

		public bool Test()
		{
			if ( demand == "!" || demand == "web_fetch_edu_virtual" )
			{
				if ( Item1( ) ) itensOk++; else result += "1,"; currentItem++; m_Log.Flush(); Thread.Sleep(1);
			}

			if ( transaction.ut_max == 0 && demand == "!" )
			{
				result = " web_fetch_edu_virtual              " + " ## no available coverage! ";
				currentItem++;
				return false;
			}

			if ( currentItem == 0 ) return true;

			if ( result.Length > 0 ) result = " (" + result.Substring(0,result.Length-1)+ ")";

			result = " web_fetch_edu_virtual               " + 
					(currentItem- itensOk).ToString() + 
					" errors in " + 
					currentItem + 
					" tests executed. " + result;

			if (currentItem- itensOk != 0 ) return false;

			return true;
		}

		#region - EXCHANGE -

		public void call_web_fetch_edu_virtual ( string st_cartao, string st_senha, string dt_mov ) 
		{
			m_Comm.Clear();
			
			DataPortable send_dp = new DataPortable();
			
			send_dp.MapTagValue ( COMM_IN_WEB_FETCH_EDU_VIRTUAL.st_cartao, st_cartao );
			send_dp.MapTagValue ( COMM_IN_WEB_FETCH_EDU_VIRTUAL.st_senha, st_senha );
			send_dp.MapTagValue ( COMM_IN_WEB_FETCH_EDU_VIRTUAL.dt_mov, dt_mov );
			
			m_Comm.AddEntryPortable ( ref send_dp );
		}

		public void recv_web_fetch_edu_virtual ( ref DadosCartaoEdu dce, ref ArrayList lst, ref ArrayList lstEmp )
		{
			DataPortable recv_dp_cont_dce = new DataPortable();
			
			m_Comm.GetExitPortableAtPosition (0).GetMapContainer ( COMM_OUT_WEB_FETCH_EDU_VIRTUAL.dce , ref recv_dp_cont_dce );
			
			dce.Import ( recv_dp_cont_dce );
			
			DataPortable recv_dp_array_generic_lst = m_Comm.GetExitPortableAtPosition (1);
			DataPortable recv_dp_array_generic_lstEmp = m_Comm.GetExitPortableAtPosition (2);
			
			recv_dp_array_generic_lst.GetMapArray ( COMM_OUT_WEB_FETCH_EDU_VIRTUAL.lst , ref lst );
			recv_dp_array_generic_lstEmp.GetMapArray ( COMM_OUT_WEB_FETCH_EDU_VIRTUAL.lstEmp , ref lstEmp );
		}

		#endregion

/// USER [ custom_functions ]
/// USER [ custom_functions ] END

		public bool Item1()
		{
			#region - INPUT VARS -
			
			transaction.MemoryClean();
			
			tst_unit.LogTest ( "web_fetch_edu_virtual Item1", ref m_Log );

			transaction.ut_abort = 0;

			string st_cartao = "";
			string st_senha = "";
			string dt_mov = "";

			#endregion
		
/// USER [ setup_test_1 ]
/// USER [ setup_test_1 ] END

			#region - MAPPING TRANSACTION -

			call_web_fetch_edu_virtual ( st_cartao, st_senha, dt_mov ); 

			if ( transaction.setup() == false )
				return false;

			try
			{

			#endregion

/// USER [ execute_1 ]
/// USER [ execute_1 ] END

			#region - OUTPUT VARS -
			}
			catch (System.Exception se)
			{
				if ( se.Message != "ABORT" ) MessageBox.Show ( se.ToString() );
			}

			if ( transaction.finish() == false )
				return false;

			DadosCartaoEdu dce = new DadosCartaoEdu();
			ArrayList lst = new ArrayList();
			ArrayList lstEmp = new ArrayList();

			recv_web_fetch_edu_virtual ( ref dce, ref lst, ref lstEmp ); 

			transaction.sendObjections ( ref my_objections );

			#endregion

/// USER [ validate_1 ]
/// USER [ validate_1 ] END

			dce.Clear();
			lst.Clear();
			lstEmp.Clear();

			return true;
		}
	}
	#endif
}
