using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;

namespace SyCrafEngine
{
	#if DEBUG 
	public class tst_fetch_rel_1_rtc : tst_base
	{
/// USER [ usr_var_decl ]
/// USER [ usr_var_decl ] END

		public fetch_rel_1_rtc transaction = new fetch_rel_1_rtc();
		public UnitTest tst_unit = new UnitTest();

		public Communication 	m_Comm;
		public StreamWriter 	m_Log;
		public DB_Access 		m_my_access;

		#region - CONSTRUCTOR -

		public tst_fetch_rel_1_rtc ( ref StreamWriter p_m_Log, 
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
			if ( demand == "!" || demand == "fetch_rel_1_rtc" )
			{
				if ( Item1( ) ) itensOk++; else result += "1,"; currentItem++; m_Log.Flush(); Thread.Sleep(1);
			}

			if ( transaction.ut_max == 0 && demand == "!" )
			{
				result = " fetch_rel_1_rtc                    " + " ## no available coverage! ";
				currentItem++;
				return false;
			}

			if ( currentItem == 0 ) return true;

			if ( result.Length > 0 ) result = " (" + result.Substring(0,result.Length-1)+ ")";

			result = " fetch_rel_1_rtc                     " + 
					(currentItem- itensOk).ToString() + 
					" errors in " + 
					currentItem + 
					" tests executed. " + result;

			if (currentItem- itensOk != 0 ) return false;

			return true;
		}

		#region - EXCHANGE -

		public void call_fetch_rel_1_rtc ( string st_cart, string st_pf, string st_cidade, string st_estado, string st_loja, string st_dt_ini, string st_dt_fim, ref CNetHeader header ) 
		{
			m_Comm.Clear();
			
			DataPortable send_dp = new DataPortable();
			
			send_dp.MapTagValue ( COMM_IN_FETCH_REL_1_RTC.st_cart, st_cart );
			send_dp.MapTagValue ( COMM_IN_FETCH_REL_1_RTC.st_pf, st_pf );
			send_dp.MapTagValue ( COMM_IN_FETCH_REL_1_RTC.st_cidade, st_cidade );
			send_dp.MapTagValue ( COMM_IN_FETCH_REL_1_RTC.st_estado, st_estado );
			send_dp.MapTagValue ( COMM_IN_FETCH_REL_1_RTC.st_loja, st_loja );
			send_dp.MapTagValue ( COMM_IN_FETCH_REL_1_RTC.st_dt_ini, st_dt_ini );
			send_dp.MapTagValue ( COMM_IN_FETCH_REL_1_RTC.st_dt_fim, st_dt_fim );
			
			m_Comm.AddEntryPortable ( ref send_dp );
			
			DataPortable send_dp_cont_0 = new DataPortable();
			
			send_dp_cont_0.MapTagContainer ( COMM_IN_FETCH_REL_1_RTC.header, header as DataPortable );
			
			m_Comm.AddEntryPortable ( ref send_dp_cont_0 );
		}

		public void recv_fetch_rel_1_rtc ( ref string st_csv, ref string st_empresa, ref string st_total_periodo, ref string st_cartao, ref string st_total_cancelado, ref string st_parcs, ref string st_parcs_total, ref string st_parcs_content )
		{
			DataPortable recv_dp = m_Comm.GetFirstExitPortable(); 
			
			recv_dp.GetMapValue ( COMM_OUT_FETCH_REL_1_RTC.st_csv , ref st_csv );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_REL_1_RTC.st_empresa , ref st_empresa );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_REL_1_RTC.st_total_periodo , ref st_total_periodo );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_REL_1_RTC.st_cartao , ref st_cartao );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_REL_1_RTC.st_total_cancelado , ref st_total_cancelado );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_REL_1_RTC.st_parcs , ref st_parcs );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_REL_1_RTC.st_parcs_total , ref st_parcs_total );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_REL_1_RTC.st_parcs_content , ref st_parcs_content );
		}

		#endregion

/// USER [ custom_functions ]
/// USER [ custom_functions ] END

		public bool Item1()
		{
			#region - INPUT VARS -
			
			transaction.MemoryClean();
			
			tst_unit.LogTest ( "fetch_rel_1_rtc Item1", ref m_Log );

			transaction.ut_abort = 0;

			string st_cart = "";
			string st_pf = "";
			string st_cidade = "";
			string st_estado = "";
			string st_loja = "";
			string st_dt_ini = "";
			string st_dt_fim = "";
			
			CNetHeader header = new CNetHeader(); 

			#endregion
		
/// USER [ setup_test_1 ]
/// USER [ setup_test_1 ] END

			#region - MAPPING TRANSACTION -

			call_fetch_rel_1_rtc ( st_cart, st_pf, st_cidade, st_estado, st_loja, st_dt_ini, st_dt_fim, ref  header ); 

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

			string st_csv = "";
			string st_empresa = "";
			string st_total_periodo = "";
			string st_cartao = "";
			string st_total_cancelado = "";
			string st_parcs = "";
			string st_parcs_total = "";
			string st_parcs_content = "";

			recv_fetch_rel_1_rtc ( ref st_csv, ref st_empresa, ref st_total_periodo, ref st_cartao, ref st_total_cancelado, ref st_parcs, ref st_parcs_total, ref st_parcs_content ); 

			transaction.sendObjections ( ref my_objections );

			#endregion

/// USER [ validate_1 ]
/// USER [ validate_1 ] END

			return true;
		}
	}
	#endif
}
