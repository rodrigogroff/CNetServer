using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;

namespace SyCrafEngine
{
	#if DEBUG 
	public class tst_exec_alteraLoja : tst_base
	{
/// USER [ usr_var_decl ]
/// USER [ usr_var_decl ] END

		public exec_alteraLoja transaction = new exec_alteraLoja();
		public UnitTest tst_unit = new UnitTest();

		public Communication 	m_Comm;
		public StreamWriter 	m_Log;
		public DB_Access 		m_my_access;

		#region - CONSTRUCTOR -

		public tst_exec_alteraLoja ( ref StreamWriter p_m_Log, 
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
			if ( demand == "!" || demand == "exec_alteraLoja" )
			{
				if ( Item1( ) ) itensOk++; else result += "1,"; currentItem++; m_Log.Flush(); Thread.Sleep(1);
			}

			if ( transaction.ut_max == 0 && demand == "!" )
			{
				result = " exec_alteraLoja                    " + " ## no available coverage! ";
				currentItem++;
				return false;
			}

			if ( currentItem == 0 ) return true;

			if ( result.Length > 0 ) result = " (" + result.Substring(0,result.Length-1)+ ")";

			result = " exec_alteraLoja                     " + 
					(currentItem- itensOk).ToString() + 
					" errors in " + 
					currentItem + 
					" tests executed. " + result;

			if (currentItem- itensOk != 0 ) return false;

			return true;
		}

		#region - EXCHANGE -

		public void call_exec_alteraLoja ( string st_csv_empresas, string st_csv_taxas, string st_csv_dias, string st_csv_banco, string st_csv_ag, string st_csv_conta, ref DadosLoja dl, ref CNetHeader header ) 
		{
			m_Comm.Clear();
			
			DataPortable send_dp = new DataPortable();
			
			send_dp.MapTagValue ( COMM_IN_EXEC_ALTERALOJA.st_csv_empresas, st_csv_empresas );
			send_dp.MapTagValue ( COMM_IN_EXEC_ALTERALOJA.st_csv_taxas, st_csv_taxas );
			send_dp.MapTagValue ( COMM_IN_EXEC_ALTERALOJA.st_csv_dias, st_csv_dias );
			send_dp.MapTagValue ( COMM_IN_EXEC_ALTERALOJA.st_csv_banco, st_csv_banco );
			send_dp.MapTagValue ( COMM_IN_EXEC_ALTERALOJA.st_csv_ag, st_csv_ag );
			send_dp.MapTagValue ( COMM_IN_EXEC_ALTERALOJA.st_csv_conta, st_csv_conta );
			
			m_Comm.AddEntryPortable ( ref send_dp );
			
			DataPortable send_dp_cont_0 = new DataPortable();
			DataPortable send_dp_cont_1 = new DataPortable();
			
			send_dp_cont_0.MapTagContainer ( COMM_IN_EXEC_ALTERALOJA.dl, dl as DataPortable );
			send_dp_cont_1.MapTagContainer ( COMM_IN_EXEC_ALTERALOJA.header, header as DataPortable );
			
			m_Comm.AddEntryPortable ( ref send_dp_cont_0 );
			m_Comm.AddEntryPortable ( ref send_dp_cont_1 );
		}

		public void recv_exec_alteraLoja (  )
		{
		}

		#endregion

/// USER [ custom_functions ]
/// USER [ custom_functions ] END

		public bool Item1()
		{
			#region - INPUT VARS -
			
			transaction.MemoryClean();
			
			tst_unit.LogTest ( "exec_alteraLoja Item1", ref m_Log );

			transaction.ut_abort = 0;

			string st_csv_empresas = "";
			string st_csv_taxas = "";
			string st_csv_dias = "";
			string st_csv_banco = "";
			string st_csv_ag = "";
			string st_csv_conta = "";
			
			DadosLoja dl = new DadosLoja(); 
			CNetHeader header = new CNetHeader(); 

			#endregion
		
/// USER [ setup_test_1 ]
/// USER [ setup_test_1 ] END

			#region - MAPPING TRANSACTION -

			call_exec_alteraLoja ( st_csv_empresas, st_csv_taxas, st_csv_dias, st_csv_banco, st_csv_ag, st_csv_conta, ref  dl, ref  header ); 

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

			transaction.sendObjections ( ref my_objections );

			#endregion

/// USER [ validate_1 ]
/// USER [ validate_1 ] END

			return true;
		}
	}
	#endif
}
