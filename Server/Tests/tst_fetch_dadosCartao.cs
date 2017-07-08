using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;

namespace SyCrafEngine
{
	#if DEBUG 
	public class tst_fetch_dadosCartao : tst_base
	{
/// USER [ usr_var_decl ]
/// USER [ usr_var_decl ] END

		public fetch_dadosCartao transaction = new fetch_dadosCartao();
		public UnitTest tst_unit = new UnitTest();

		public Communication 	m_Comm;
		public StreamWriter 	m_Log;
		public DB_Access 		m_my_access;

		#region - CONSTRUCTOR -

		public tst_fetch_dadosCartao ( ref StreamWriter p_m_Log, 
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
			if ( demand == "!" || demand == "fetch_dadosCartao" )
			{
				if ( Item1( ) ) itensOk++; else result += "1,"; currentItem++; m_Log.Flush(); Thread.Sleep(1);
			}

			if ( transaction.ut_max == 0 && demand == "!" )
			{
				result = " fetch_dadosCartao                  " + " ## no available coverage! ";
				currentItem++;
				return false;
			}

			if ( currentItem == 0 ) return true;

			if ( result.Length > 0 ) result = " (" + result.Substring(0,result.Length-1)+ ")";

			result = " fetch_dadosCartao                   " + 
					(currentItem- itensOk).ToString() + 
					" errors in " + 
					currentItem + 
					" tests executed. " + result;

			if (currentItem- itensOk != 0 ) return false;

			return true;
		}

		#region - EXCHANGE -

		public void call_fetch_dadosCartao ( string st_cart_empresa, string st_cart_mat, string st_cart_tit, ref CNetHeader header ) 
		{
			m_Comm.Clear();
			
			DataPortable send_dp = new DataPortable();
			
			send_dp.MapTagValue ( COMM_IN_FETCH_DADOSCARTAO.st_cart_empresa, st_cart_empresa );
			send_dp.MapTagValue ( COMM_IN_FETCH_DADOSCARTAO.st_cart_mat, st_cart_mat );
			send_dp.MapTagValue ( COMM_IN_FETCH_DADOSCARTAO.st_cart_tit, st_cart_tit );
			
			m_Comm.AddEntryPortable ( ref send_dp );
			
			DataPortable send_dp_cont_0 = new DataPortable();
			
			send_dp_cont_0.MapTagContainer ( COMM_IN_FETCH_DADOSCARTAO.header, header as DataPortable );
			
			m_Comm.AddEntryPortable ( ref send_dp_cont_0 );
		}

		public void recv_fetch_dadosCartao ( ref string nu_maxParcelas, ref string vr_dispMes, ref string vr_dispTotal, ref string st_nome )
		{
			DataPortable recv_dp = m_Comm.GetFirstExitPortable(); 
			
			recv_dp.GetMapValue ( COMM_OUT_FETCH_DADOSCARTAO.nu_maxParcelas , ref nu_maxParcelas );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_DADOSCARTAO.vr_dispMes , ref vr_dispMes );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_DADOSCARTAO.vr_dispTotal , ref vr_dispTotal );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_DADOSCARTAO.st_nome , ref st_nome );
		}

		#endregion

/// USER [ custom_functions ]
/// USER [ custom_functions ] END

		public bool Item1()
		{
			#region - INPUT VARS -
			
			transaction.MemoryClean();
			
			tst_unit.LogTest ( "fetch_dadosCartao Item1", ref m_Log );

			transaction.ut_abort = 0;

			string st_cart_empresa = "";
			string st_cart_mat = "";
			string st_cart_tit = "";
			
			CNetHeader header = new CNetHeader(); 

			#endregion
		
/// USER [ setup_test_1 ]
/// USER [ setup_test_1 ] END

			#region - MAPPING TRANSACTION -

			call_fetch_dadosCartao ( st_cart_empresa, st_cart_mat, st_cart_tit, ref  header ); 

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

			string nu_maxParcelas = "";
			string vr_dispMes = "";
			string vr_dispTotal = "";
			string st_nome = "";

			recv_fetch_dadosCartao ( ref nu_maxParcelas, ref vr_dispMes, ref vr_dispTotal, ref st_nome ); 

			transaction.sendObjections ( ref my_objections );

			#endregion

/// USER [ validate_1 ]
/// USER [ validate_1 ] END

			return true;
		}
	}
	#endif
}
