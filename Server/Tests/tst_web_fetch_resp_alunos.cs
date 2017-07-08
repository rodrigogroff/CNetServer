using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;

namespace SyCrafEngine
{
	#if DEBUG 
	public class tst_web_fetch_resp_alunos : tst_base
	{
/// USER [ usr_var_decl ]
/// USER [ usr_var_decl ] END

		public web_fetch_resp_alunos transaction = new web_fetch_resp_alunos();
		public UnitTest tst_unit = new UnitTest();

		public Communication 	m_Comm;
		public StreamWriter 	m_Log;
		public DB_Access 		m_my_access;

		#region - CONSTRUCTOR -

		public tst_web_fetch_resp_alunos ( ref StreamWriter p_m_Log, 
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
			if ( demand == "!" || demand == "web_fetch_resp_alunos" )
			{
				if ( Item1( ) ) itensOk++; else result += "1,"; currentItem++; m_Log.Flush(); Thread.Sleep(1);
			}

			if ( transaction.ut_max == 0 && demand == "!" )
			{
				result = " web_fetch_resp_alunos              " + " ## no available coverage! ";
				currentItem++;
				return false;
			}

			if ( currentItem == 0 ) return true;

			if ( result.Length > 0 ) result = " (" + result.Substring(0,result.Length-1)+ ")";

			result = " web_fetch_resp_alunos               " + 
					(currentItem- itensOk).ToString() + 
					" errors in " + 
					currentItem + 
					" tests executed. " + result;

			if (currentItem- itensOk != 0 ) return false;

			return true;
		}

		#region - EXCHANGE -

		public void call_web_fetch_resp_alunos ( string st_cpf, string st_senha ) 
		{
			m_Comm.Clear();
			
			DataPortable send_dp = new DataPortable();
			
			send_dp.MapTagValue ( COMM_IN_WEB_FETCH_RESP_ALUNOS.st_cpf, st_cpf );
			send_dp.MapTagValue ( COMM_IN_WEB_FETCH_RESP_ALUNOS.st_senha, st_senha );
			
			m_Comm.AddEntryPortable ( ref send_dp );
		}

		public void recv_web_fetch_resp_alunos ( ref string st_nomeResp, ref ArrayList lst, ref ArrayList lstMsg )
		{
			DataPortable recv_dp = m_Comm.GetFirstExitPortable(); 
			
			recv_dp.GetMapValue ( COMM_OUT_WEB_FETCH_RESP_ALUNOS.st_nomeResp , ref st_nomeResp );
			
			DataPortable recv_dp_array_generic_lst = m_Comm.GetExitPortableAtPosition (1);
			DataPortable recv_dp_array_generic_lstMsg = m_Comm.GetExitPortableAtPosition (2);
			
			recv_dp_array_generic_lst.GetMapArray ( COMM_OUT_WEB_FETCH_RESP_ALUNOS.lst , ref lst );
			recv_dp_array_generic_lstMsg.GetMapArray ( COMM_OUT_WEB_FETCH_RESP_ALUNOS.lstMsg , ref lstMsg );
		}

		#endregion

/// USER [ custom_functions ]
/// USER [ custom_functions ] END

		public bool Item1()
		{
			#region - INPUT VARS -
			
			transaction.MemoryClean();
			
			tst_unit.LogTest ( "web_fetch_resp_alunos Item1", ref m_Log );

			transaction.ut_abort = 0;

			string st_cpf = "";
			string st_senha = "";

			#endregion
		
/// USER [ setup_test_1 ]
/// USER [ setup_test_1 ] END

			#region - MAPPING TRANSACTION -

			call_web_fetch_resp_alunos ( st_cpf, st_senha ); 

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

			string st_nomeResp = "";
			ArrayList lst = new ArrayList();
			ArrayList lstMsg = new ArrayList();

			recv_web_fetch_resp_alunos ( ref st_nomeResp, ref lst, ref lstMsg ); 

			transaction.sendObjections ( ref my_objections );

			#endregion

/// USER [ validate_1 ]
/// USER [ validate_1 ] END

			lst.Clear();
			lstMsg.Clear();

			return true;
		}
	}
	#endif
}
