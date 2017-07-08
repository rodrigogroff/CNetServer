using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;

namespace SyCrafEngine
{
	#if DEBUG || LOAD
	public class tst_fetch_cadastros : tst_base
	{
/// USER [ usr_var_decl ]
/// USER [ usr_var_decl ] END

		public fetch_cadastros transaction = new fetch_cadastros();
		public UnitTest tst_unit = new UnitTest();

		public Communication 	m_Comm;
		public StreamWriter 	m_Log;
		public DB_Access 		m_my_access;

		#region - CONSTRUCTOR -

		public tst_fetch_cadastros ( ref StreamWriter p_m_Log, 
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
			#if LOAD
			/// USER [ test_selection ]
			/// USER [ test_selection ] END
			#else
			
			if ( demand == "!" || demand == "fetch_cadastros" )
			{
				#if DEBUG
				if ( Item1( ) ) itensOk++; else result += "1,"; currentItem++; m_Log.Flush(); Thread.Sleep(1);
				#endif
			}

			if ( transaction.ut_max == 0 && demand == "!" )
			{
				result = " fetch_cadastros                    " + " ## no available coverage! ";
				currentItem++;
				return false;
			}

			if ( currentItem == 0 ) return true;

			if ( result.Length > 0 ) result = " (" + result.Substring(0,result.Length-1)+ ")";

			result = " fetch_cadastros                     " + 
					(currentItem- itensOk).ToString() + 
					" errors in " + 
					currentItem + 
					" tests executed. " + result;

			if (currentItem- itensOk != 0 ) return false;

			#endif
			return true;
		}

		#region - EXCHANGE -

		public void call_fetch_cadastros ( ref CNetHeader header ) 
		{
			m_Comm.Clear();
			
			DataPortable send_dp_cont_0 = new DataPortable();
			
			send_dp_cont_0.MapTagContainer ( COMM_IN_FETCH_CADASTROS.header, header as DataPortable );
			
			m_Comm.AddEntryPortable ( ref send_dp_cont_0 );
		}

		public void recv_fetch_cadastros ( ref string st_csv_futebol, ref string st_csv_profissoes, ref string st_csv_comoSoube, ref string st_csv_futebol_id, ref string st_csv_profissoes_id, ref string st_csv_comoSoube_id )
		{
			DataPortable recv_dp = m_Comm.GetFirstExitPortable(); 
			
			recv_dp.GetMapValue ( COMM_OUT_FETCH_CADASTROS.st_csv_futebol , ref st_csv_futebol );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_CADASTROS.st_csv_profissoes , ref st_csv_profissoes );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_CADASTROS.st_csv_comoSoube , ref st_csv_comoSoube );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_CADASTROS.st_csv_futebol_id , ref st_csv_futebol_id );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_CADASTROS.st_csv_profissoes_id , ref st_csv_profissoes_id );
			recv_dp.GetMapValue ( COMM_OUT_FETCH_CADASTROS.st_csv_comoSoube_id , ref st_csv_comoSoube_id );
		}

		#endregion

/// USER [ custom_functions ]
/// USER [ custom_functions ] END

		public bool Item1()
		{
			#region - INPUT VARS -
			
			transaction.MemoryClean();
			
			tst_unit.LogTest ( "fetch_cadastros Item1", ref m_Log );

			transaction.ut_abort = 0;

			CNetHeader header = new CNetHeader(); 

			#endregion
		
/// USER [ setup_test_1 ]

			string tmp_id = "";

			T_Futebol fut = new T_Futebol ( my_transaction );
			
			fut.setup ( true,  ref tmp_id, "logotipo", "gr?mio" );
			fut.setup ( false, ref tmp_id, "logotipo", "inter" );
			fut.setup ( false, ref tmp_id, "logotipo", "caxias" );
			fut.setup ( false, ref tmp_id, "logotipo", "juventude" );
			
			T_Profissoes pro = new T_Profissoes ( my_transaction );
			
			pro.setup ( true,  ref tmp_id, "101", "analista de sistemas" );
			pro.setup ( false, ref tmp_id, "102", "programador" );
			pro.setup ( false, ref tmp_id, "103", "testador" );
			pro.setup ( false, ref tmp_id, "104", "projetista" );
			
			T_ComoSoube  cms = new T_ComoSoube ( my_transaction );
			
			cms.setup ( true,  ref tmp_id, "revista" );
			cms.setup ( false, ref tmp_id, "jornal" );
			cms.setup ( false, ref tmp_id, "TV" );
			cms.setup ( false, ref tmp_id, "internet" );

/// USER [ setup_test_1 ] END

			#region - MAPPING TRANSACTION -

			call_fetch_cadastros ( ref  header ); 

			if ( transaction.setup() == false )
				return false;

			try
			{

			#endregion

/// USER [ execute_1 ]

			if ( !my_transaction.execute() )
				return false;

/// USER [ execute_1 ] END

			#region - OUTPUT VARS -
			}
			catch (System.Exception se)
			{
				if ( se.Message != "ABORT" ) MessageBox.Show ( se.ToString() );
			}

			if ( transaction.finish() == false )
				return false;

			string st_csv_futebol = "";
			string st_csv_profissoes = "";
			string st_csv_comoSoube = "";
			string st_csv_futebol_id = "";
			string st_csv_profissoes_id = "";
			string st_csv_comoSoube_id = "";

			recv_fetch_cadastros ( ref st_csv_futebol, ref st_csv_profissoes, ref st_csv_comoSoube, ref st_csv_futebol_id, ref st_csv_profissoes_id, ref st_csv_comoSoube_id ); 

			transaction.sendObjections ( ref my_objections );

			#endregion

/// USER [ validate_1 ]
/// USER [ validate_1 ] END

			return true;
		}
	}
	#endif
}
