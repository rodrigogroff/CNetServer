using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;

namespace SyCrafEngine
{
	#if DEBUG 
	public class tst_web_exec_confirmaBoleto : tst_base
	{
/// USER [ usr_var_decl ]
/// USER [ usr_var_decl ] END

		public web_exec_confirmaBoleto transaction = new web_exec_confirmaBoleto();
		public UnitTest tst_unit = new UnitTest();

		public Communication 	m_Comm;
		public StreamWriter 	m_Log;
		public DB_Access 		m_my_access;

		#region - CONSTRUCTOR -

		public tst_web_exec_confirmaBoleto ( ref StreamWriter p_m_Log, 
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
			if ( demand == "!" || demand == "web_exec_confirmaBoleto" )
			{
				if ( Item1( ) ) itensOk++; else result += "1,"; currentItem++; m_Log.Flush(); Thread.Sleep(1);
			}

			if ( transaction.ut_max == 0 && demand == "!" )
			{
				result = " web_exec_confirmaBoleto            " + " ## no available coverage! ";
				currentItem++;
				return false;
			}

			if ( currentItem == 0 ) return true;

			if ( result.Length > 0 ) result = " (" + result.Substring(0,result.Length-1)+ ")";

			result = " web_exec_confirmaBoleto             " + 
					(currentItem- itensOk).ToString() + 
					" errors in " + 
					currentItem + 
					" tests executed. " + result;

			if (currentItem- itensOk != 0 ) return false;

			return true;
		}

		#region - EXCHANGE -

		public void call_web_exec_confirmaBoleto ( string vr_fundoEdu, string vr_imediato, string st_cartao ) 
		{
			m_Comm.Clear();
			
			DataPortable send_dp = new DataPortable();
			
			send_dp.MapTagValue ( COMM_IN_WEB_EXEC_CONFIRMABOLETO.vr_fundoEdu, vr_fundoEdu );
			send_dp.MapTagValue ( COMM_IN_WEB_EXEC_CONFIRMABOLETO.vr_imediato, vr_imediato );
			send_dp.MapTagValue ( COMM_IN_WEB_EXEC_CONFIRMABOLETO.st_cartao, st_cartao );
			
			m_Comm.AddEntryPortable ( ref send_dp );
		}

		public void recv_web_exec_confirmaBoleto ( ref string st_id )
		{
			DataPortable recv_dp = m_Comm.GetFirstExitPortable(); 
			
			recv_dp.GetMapValue ( COMM_OUT_WEB_EXEC_CONFIRMABOLETO.st_id , ref st_id );
		}

		#endregion

/// USER [ custom_functions ]
/// USER [ custom_functions ] END

		public bool Item1()
		{
			#region - INPUT VARS -
			
			transaction.MemoryClean();
			
			tst_unit.LogTest ( "web_exec_confirmaBoleto Item1", ref m_Log );

			transaction.ut_abort = 0;

			string vr_fundoEdu = "";
			string vr_imediato = "";
			string st_cartao = "";

			#endregion
		
/// USER [ setup_test_1 ]
/// USER [ setup_test_1 ] END

			#region - MAPPING TRANSACTION -

			call_web_exec_confirmaBoleto ( vr_fundoEdu, vr_imediato, st_cartao ); 

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

			string st_id = "";

			recv_web_exec_confirmaBoleto ( ref st_id ); 

			transaction.sendObjections ( ref my_objections );

			#endregion

/// USER [ validate_1 ]
/// USER [ validate_1 ] END

			return true;
		}
	}
	#endif
}
