using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;

namespace SyCrafEngine
{
	#if DEBUG 
	public class tst_fetch_rel_4_rrp : tst_base
	{
/// USER [ usr_var_decl ]
/// USER [ usr_var_decl ] END

		public fetch_rel_4_rrp transaction = new fetch_rel_4_rrp();
		public UnitTest tst_unit = new UnitTest();

		public Communication 	m_Comm;
		public StreamWriter 	m_Log;
		public DB_Access 		m_my_access;

		#region - CONSTRUCTOR -

		public tst_fetch_rel_4_rrp ( ref StreamWriter p_m_Log, 
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
			if ( demand == "!" || demand == "fetch_rel_4_rrp" )
			{
				if ( Item1( ) ) itensOk++; else result += "1,"; currentItem++; m_Log.Flush(); Thread.Sleep(1);
			}

			if ( transaction.ut_max == 0 && demand == "!" )
			{
				result = " fetch_rel_4_rrp                    " + " ## no available coverage! ";
				currentItem++;
				return false;
			}

			if ( currentItem == 0 ) return true;

			if ( result.Length > 0 ) result = " (" + result.Substring(0,result.Length-1)+ ")";

			result = " fetch_rel_4_rrp                     " + 
					(currentItem- itensOk).ToString() + 
					" errors in " + 
					currentItem + 
					" tests executed. " + result;

			if (currentItem- itensOk != 0 ) return false;

			return true;
		}

		#region - EXCHANGE -

		public void call_fetch_rel_4_rrp ( string st_empresa, string dt_ini, string dt_fim, ref CNetHeader header ) 
		{
			m_Comm.Clear();
			
			DataPortable send_dp = new DataPortable();
			
			send_dp.MapTagValue ( COMM_IN_FETCH_REL_4_RRP.st_empresa, st_empresa );
			send_dp.MapTagValue ( COMM_IN_FETCH_REL_4_RRP.dt_ini, dt_ini );
			send_dp.MapTagValue ( COMM_IN_FETCH_REL_4_RRP.dt_fim, dt_fim );
			
			m_Comm.AddEntryPortable ( ref send_dp );
			
			DataPortable send_dp_cont_0 = new DataPortable();
			
			send_dp_cont_0.MapTagContainer ( COMM_IN_FETCH_REL_4_RRP.header, header as DataPortable );
			
			m_Comm.AddEntryPortable ( ref send_dp_cont_0 );
		}

		public void recv_fetch_rel_4_rrp ( ref string st_csv_content, ref string st_nome_empresa, ref string st_csv_lojas, ref string st_csv_subtotal, ref string st_total, ref string st_csv_nome_lojas, ref string st_csv_subtotal_geral, ref string st_total_geral )
		{
			DataPortable recv_dp = m_Comm.GetFirstExitPortable(); 
			
			recv_dp.GetMapValue ( COMM_OUT_FETCH_REL_4_RRP.st_csv_content , ref st_csv_content );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_REL_4_RRP.st_nome_empresa , ref st_nome_empresa );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_REL_4_RRP.st_csv_lojas , ref st_csv_lojas );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_REL_4_RRP.st_csv_subtotal , ref st_csv_subtotal );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_REL_4_RRP.st_total , ref st_total );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_REL_4_RRP.st_csv_nome_lojas , ref st_csv_nome_lojas );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_REL_4_RRP.st_csv_subtotal_geral , ref st_csv_subtotal_geral );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_REL_4_RRP.st_total_geral , ref st_total_geral );
		}

		#endregion

/// USER [ custom_functions ]
/// USER [ custom_functions ] END

		public bool Item1()
		{
			#region - INPUT VARS -
			
			transaction.MemoryClean();
			
			tst_unit.LogTest ( "fetch_rel_4_rrp Item1", ref m_Log );

			transaction.ut_abort = 0;

			string st_empresa = "";
			string dt_ini = "";
			string dt_fim = "";
			
			CNetHeader header = new CNetHeader(); 

			#endregion
		
/// USER [ setup_test_1 ]
/// USER [ setup_test_1 ] END

			#region - MAPPING TRANSACTION -

			call_fetch_rel_4_rrp ( st_empresa, dt_ini, dt_fim, ref  header ); 

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

			string st_csv_content = "";
			string st_nome_empresa = "";
			string st_csv_lojas = "";
			string st_csv_subtotal = "";
			string st_total = "";
			string st_csv_nome_lojas = "";
			string st_csv_subtotal_geral = "";
			string st_total_geral = "";

			recv_fetch_rel_4_rrp ( ref st_csv_content, ref st_nome_empresa, ref st_csv_lojas, ref st_csv_subtotal, ref st_total, ref st_csv_nome_lojas, ref st_csv_subtotal_geral, ref st_total_geral ); 

			transaction.sendObjections ( ref my_objections );

			#endregion

/// USER [ validate_1 ]
/// USER [ validate_1 ] END

			return true;
		}
	}
	#endif
}
