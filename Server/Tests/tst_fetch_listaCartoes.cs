using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;

namespace SyCrafEngine
{
	#if DEBUG || LOAD
	public class tst_fetch_listaCartoes : tst_base
	{
/// USER [ usr_var_decl ]
/// USER [ usr_var_decl ] END

		public fetch_listaCartoes transaction = new fetch_listaCartoes();
		public UnitTest tst_unit = new UnitTest();

		public Communication 	m_Comm;
		public StreamWriter 	m_Log;
		public DB_Access 		m_my_access;

		#region - CONSTRUCTOR -

		public tst_fetch_listaCartoes ( ref StreamWriter p_m_Log, 
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
			
			if ( demand == "!" || demand == "fetch_listaCartoes" )
			{
				#if DEBUG
				if ( Item1( ) ) itensOk++; else result += "1,"; currentItem++; m_Log.Flush(); Thread.Sleep(1);
				#endif
			}

			if ( transaction.ut_max == 0 && demand == "!" )
			{
				result = " fetch_listaCartoes                 " + " ## no available coverage! ";
				currentItem++;
				return false;
			}

			if ( currentItem == 0 ) return true;

			if ( result.Length > 0 ) result = " (" + result.Substring(0,result.Length-1)+ ")";

			result = " fetch_listaCartoes                  " + 
					(currentItem- itensOk).ToString() + 
					" errors in " + 
					currentItem + 
					" tests executed. " + result;

			if (currentItem- itensOk != 0 ) return false;

			#endif
			return true;
		}

		#region - EXCHANGE -

		public void call_fetch_listaCartoes ( string st_csv_cartoes, ref CNetHeader header ) 
		{
			m_Comm.Clear();
			
			DataPortable send_dp = new DataPortable();
			
			send_dp.MapTagValue ( COMM_IN_FETCH_LISTACARTOES.st_csv_cartoes, st_csv_cartoes );
			
			m_Comm.AddEntryPortable ( ref send_dp );
			
			DataPortable send_dp_cont_0 = new DataPortable();
			
			send_dp_cont_0.MapTagContainer ( COMM_IN_FETCH_LISTACARTOES.header, header as DataPortable );
			
			m_Comm.AddEntryPortable ( ref send_dp_cont_0 );
		}

		public void recv_fetch_listaCartoes ( ref ArrayList lst )
		{
			DataPortable recv_dp_array_generic_lst = m_Comm.GetExitPortableAtPosition (0);
			
			recv_dp_array_generic_lst.GetMapArray ( COMM_OUT_FETCH_LISTACARTOES.lst , ref lst );
		}

		#endregion

/// USER [ custom_functions ]
/// USER [ custom_functions ] END

		public bool Item1()
		{
			#region - INPUT VARS -
			
			transaction.MemoryClean();
			
			tst_unit.LogTest ( "fetch_listaCartoes Item1", ref m_Log );

			transaction.ut_abort = 0;

			string st_csv_cartoes = "";
			
			CNetHeader header = new CNetHeader(); 

			#endregion
		
/// USER [ setup_test_1 ]
/// USER [ setup_test_1 ] END

			#region - MAPPING TRANSACTION -

			call_fetch_listaCartoes ( st_csv_cartoes, ref  header ); 

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

			ArrayList lst = new ArrayList();

			recv_fetch_listaCartoes ( ref lst ); 

			transaction.sendObjections ( ref my_objections );

			#endregion

/// USER [ validate_1 ]
/// USER [ validate_1 ] END

			lst.Clear();

			return true;
		}
	}
	#endif
}
