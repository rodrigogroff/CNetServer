using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;

namespace SyCrafEngine
{
	#if DEBUG 
	public class tst_exec_pf_autorizaInstalacao : tst_base
	{
/// USER [ usr_var_decl ]
/// USER [ usr_var_decl ] END

		public exec_pf_autorizaInstalacao transaction = new exec_pf_autorizaInstalacao();
		public UnitTest tst_unit = new UnitTest();

		public Communication 	m_Comm;
		public StreamWriter 	m_Log;
		public DB_Access 		m_my_access;

		#region - CONSTRUCTOR -

		public tst_exec_pf_autorizaInstalacao ( ref StreamWriter p_m_Log, 
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
			if ( demand == "!" || demand == "exec_pf_autorizaInstalacao" )
			{
				if ( Item1( ) ) itensOk++; else result += "1,"; currentItem++; m_Log.Flush(); Thread.Sleep(1);
			}

			if ( transaction.ut_max == 0 && demand == "!" )
			{
				result = " exec_pf_autorizaInstalacao         " + " ## no available coverage! ";
				currentItem++;
				return false;
			}

			if ( currentItem == 0 ) return true;

			if ( result.Length > 0 ) result = " (" + result.Substring(0,result.Length-1)+ ")";

			result = " exec_pf_autorizaInstalacao          " + 
					(currentItem- itensOk).ToString() + 
					" errors in " + 
					currentItem + 
					" tests executed. " + result;

			if (currentItem- itensOk != 0 ) return false;

			return true;
		}

		#region - EXCHANGE -

		public void call_exec_pf_autorizaInstalacao ( string st_codigo ) 
		{
			m_Comm.Clear();
			
			DataPortable send_dp = new DataPortable();
			
			send_dp.MapTagValue ( COMM_IN_EXEC_PF_AUTORIZAINSTALACAO.st_codigo, st_codigo );
			
			m_Comm.AddEntryPortable ( ref send_dp );
		}

		public void recv_exec_pf_autorizaInstalacao ( ref string st_codResp, ref string st_msg, ref string st_telefone, ref string st_terminal, ref string tg_tipoCelular, ref string st_lojaTB )
		{
			DataPortable recv_dp = m_Comm.GetFirstExitPortable(); 
			
			recv_dp.GetMapValue ( COMM_OUT_EXEC_PF_AUTORIZAINSTALACAO.st_codResp , ref st_codResp );
			recv_dp.GetMapValue ( COMM_OUT_EXEC_PF_AUTORIZAINSTALACAO.st_msg , ref st_msg );
			recv_dp.GetMapValue ( COMM_OUT_EXEC_PF_AUTORIZAINSTALACAO.st_telefone , ref st_telefone );
			recv_dp.GetMapValue ( COMM_OUT_EXEC_PF_AUTORIZAINSTALACAO.st_terminal , ref st_terminal );
			recv_dp.GetMapValue ( COMM_OUT_EXEC_PF_AUTORIZAINSTALACAO.tg_tipoCelular , ref tg_tipoCelular );
			recv_dp.GetMapValue ( COMM_OUT_EXEC_PF_AUTORIZAINSTALACAO.st_lojaTB , ref st_lojaTB );
		}

		#endregion

/// USER [ custom_functions ]
/// USER [ custom_functions ] END

		public bool Item1()
		{
			#region - INPUT VARS -
			
			transaction.MemoryClean();
			
			tst_unit.LogTest ( "exec_pf_autorizaInstalacao Item1", ref m_Log );

			transaction.ut_abort = 0;

			string st_codigo = "";

			#endregion
		
/// USER [ setup_test_1 ]
/// USER [ setup_test_1 ] END

			#region - MAPPING TRANSACTION -

			call_exec_pf_autorizaInstalacao ( st_codigo ); 

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

			string st_codResp = "";
			string st_msg = "";
			string st_telefone = "";
			string st_terminal = "";
			string tg_tipoCelular = "";
			string st_lojaTB = "";

			recv_exec_pf_autorizaInstalacao ( ref st_codResp, ref st_msg, ref st_telefone, ref st_terminal, ref tg_tipoCelular, ref st_lojaTB ); 

			transaction.sendObjections ( ref my_objections );

			#endregion

/// USER [ validate_1 ]
/// USER [ validate_1 ] END

			return true;
		}
	}
	#endif
}
