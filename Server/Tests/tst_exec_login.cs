using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;

namespace SyCrafEngine
{
	#if DEBUG 
	public class tst_exec_login : tst_base
	{
/// USER [ usr_var_decl ]
/// USER [ usr_var_decl ] END

		public exec_login transaction = new exec_login();
		public UnitTest tst_unit = new UnitTest();

		public Communication 	m_Comm;
		public StreamWriter 	m_Log;
		public DB_Access 		m_my_access;

		#region - CONSTRUCTOR -

		public tst_exec_login ( ref StreamWriter p_m_Log, 
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
			if ( demand == "!" || demand == "exec_login" )
			{
				if ( Item1( ) ) itensOk++; else result += "1,"; currentItem++; m_Log.Flush(); Thread.Sleep(1);
			}

			if ( transaction.ut_max == 0 && demand == "!" )
			{
				result = " exec_login                         " + " ## no available coverage! ";
				currentItem++;
				return false;
			}

			if ( currentItem == 0 ) return true;

			if ( result.Length > 0 ) result = " (" + result.Substring(0,result.Length-1)+ ")";

			result = " exec_login                          " + 
					(currentItem- itensOk).ToString() + 
					" errors in " + 
					currentItem + 
					" tests executed. " + result;

			if (currentItem- itensOk != 0 ) return false;

			return true;
		}

		#region - EXCHANGE -

		public void call_exec_login ( string st_nome, string st_empresa, string st_senha ) 
		{
			m_Comm.Clear();
			
			DataPortable send_dp = new DataPortable();
			
			send_dp.MapTagValue ( COMM_IN_EXEC_LOGIN.st_nome, st_nome );
			send_dp.MapTagValue ( COMM_IN_EXEC_LOGIN.st_empresa, st_empresa );
			send_dp.MapTagValue ( COMM_IN_EXEC_LOGIN.st_senha, st_senha );
			
			m_Comm.AddEntryPortable ( ref send_dp );
		}

		public void recv_exec_login ( ref string tg_trocaSenha, ref CNetHeader header )
		{
			DataPortable recv_dp = m_Comm.GetFirstExitPortable(); 
			
			recv_dp.GetMapValue ( COMM_OUT_EXEC_LOGIN.tg_trocaSenha , ref tg_trocaSenha );
			
			DataPortable recv_dp_cont_header = new DataPortable();
			
			m_Comm.GetExitPortableAtPosition (1).GetMapContainer ( COMM_OUT_EXEC_LOGIN.header , ref recv_dp_cont_header );
			
			header.Import ( recv_dp_cont_header );
		}

		#endregion

/// USER [ custom_functions ]
/// USER [ custom_functions ] END

		public bool Item1()
		{
			#region - INPUT VARS -
			
			transaction.MemoryClean();
			
			tst_unit.LogTest ( "exec_login Item1", ref m_Log );

			transaction.ut_abort = 0;

			string st_nome = "";
			string st_empresa = "";
			string st_senha = "";

			#endregion
		
/// USER [ setup_test_1 ]

			string m_sSessionSeed = "abcdefghijklmnopqrstuvxywz0123456789";
			Random randObj = new Random();
           
       		int iLen = m_sSessionSeed.Length;
       		for (int t=0; t < 15; ++t)
				st_nome += m_sSessionSeed[ randObj.Next( 0, iLen ) ].ToString();
			
       		st_senha = new ApplicationUtil().getMd5Hash ( "12345678" );
			
			T_Usuario u = new T_Usuario ( transaction );
			
			//string id = "";
				
			/*u.setup ( 	false,
			         	ref id, 
			         	TipoUsuario.Administrador, 
			         	Context.TRUE,
			         	transaction.GetDataBaseTime(), 
			         	transaction.GetDataBaseTime(),
			         	"0",
			         	Context.FALSE,
			         	"",
			         	"", 
			         	"", 
			         	"", 
			         	"",
			         	st_empresa, 
						st_senha, 
				        Context.FALSE, 
			         	st_nome 	);
			         	*/

/// USER [ setup_test_1 ] END

			#region - MAPPING TRANSACTION -

			call_exec_login ( st_nome, st_empresa, st_senha ); 

			if ( transaction.setup() == false )
				return false;

			try
			{

			#endregion

/// USER [ execute_1 ]

			if ( !transaction.authenticate() )
				return false;
			
			if ( !transaction.execute() )
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

			string tg_trocaSenha = "";
			CNetHeader header = new CNetHeader();

			recv_exec_login ( ref tg_trocaSenha, ref header ); 

			transaction.sendObjections ( ref my_objections );

			#endregion

/// USER [ validate_1 ]
/// USER [ validate_1 ] END

			header.Clear();

			return true;
		}
	}
	#endif
}
