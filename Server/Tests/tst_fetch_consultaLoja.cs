using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;

namespace SyCrafEngine
{
	#if DEBUG 
	public class tst_fetch_consultaLoja : tst_base
	{
/// USER [ usr_var_decl ]
/// USER [ usr_var_decl ] END

		public fetch_consultaLoja transaction = new fetch_consultaLoja();
		public UnitTest tst_unit = new UnitTest();

		public Communication 	m_Comm;
		public StreamWriter 	m_Log;
		public DB_Access 		m_my_access;

		#region - CONSTRUCTOR -

		public tst_fetch_consultaLoja ( ref StreamWriter p_m_Log, 
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
			if ( demand == "!" || demand == "fetch_consultaLoja" )
			{
				if ( Item1( ) ) itensOk++; else result += "1,"; currentItem++; m_Log.Flush(); Thread.Sleep(1);
			}

			if ( transaction.ut_max == 0 && demand == "!" )
			{
				result = " fetch_consultaLoja                 " + " ## no available coverage! ";
				currentItem++;
				return false;
			}

			if ( currentItem == 0 ) return true;

			if ( result.Length > 0 ) result = " (" + result.Substring(0,result.Length-1)+ ")";

			result = " fetch_consultaLoja                  " + 
					(currentItem- itensOk).ToString() + 
					" errors in " + 
					currentItem + 
					" tests executed. " + result;

			if (currentItem- itensOk != 0 ) return false;

			return true;
		}

		#region - EXCHANGE -

		public void call_fetch_consultaLoja ( ref DadosConsultaLoja dcl, ref CNetHeader header ) 
		{
			m_Comm.Clear();
			
			DataPortable send_dp_cont_0 = new DataPortable();
			DataPortable send_dp_cont_1 = new DataPortable();
			
			send_dp_cont_0.MapTagContainer ( COMM_IN_FETCH_CONSULTALOJA.dcl, dcl as DataPortable );
			send_dp_cont_1.MapTagContainer ( COMM_IN_FETCH_CONSULTALOJA.header, header as DataPortable );
			
			m_Comm.AddEntryPortable ( ref send_dp_cont_0 );
			m_Comm.AddEntryPortable ( ref send_dp_cont_1 );
		}

		public void recv_fetch_consultaLoja ( ref string st_csv_id )
		{
			DataPortable recv_dp = m_Comm.GetFirstExitPortable(); 
			
			recv_dp.GetMapValue ( COMM_OUT_FETCH_CONSULTALOJA.st_csv_id , ref st_csv_id );
		}

		#endregion

/// USER [ custom_functions ]
/// USER [ custom_functions ] END

		public bool Item1()
		{
			#region - INPUT VARS -
			
			transaction.MemoryClean();
			
			tst_unit.LogTest ( "fetch_consultaLoja Item1", ref m_Log );

			transaction.ut_abort = 0;

			DadosConsultaLoja dcl = new DadosConsultaLoja(); 
			CNetHeader header = new CNetHeader(); 

			#endregion
		
/// USER [ setup_test_1 ]
/// USER [ setup_test_1 ] END

			#region - MAPPING TRANSACTION -

			call_fetch_consultaLoja ( ref  dcl, ref  header ); 

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

			string st_csv_id = "";

			recv_fetch_consultaLoja ( ref st_csv_id ); 

			transaction.sendObjections ( ref my_objections );

			#endregion

/// USER [ validate_1 ]
/// USER [ validate_1 ] END

			return true;
		}
	}
	#endif
}
