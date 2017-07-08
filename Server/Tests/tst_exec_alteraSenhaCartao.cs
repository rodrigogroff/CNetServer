﻿using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;

namespace SyCrafEngine
{
	#if DEBUG 
	public class tst_exec_alteraSenhaCartao : tst_base
	{
/// USER [ usr_var_decl ]
/// USER [ usr_var_decl ] END

		public exec_alteraSenhaCartao transaction = new exec_alteraSenhaCartao();
		public UnitTest tst_unit = new UnitTest();

		public Communication 	m_Comm;
		public StreamWriter 	m_Log;
		public DB_Access 		m_my_access;

		#region - CONSTRUCTOR -

		public tst_exec_alteraSenhaCartao ( ref StreamWriter p_m_Log, 
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
			if ( demand == "!" || demand == "exec_alteraSenhaCartao" )
			{
				if ( Item1( ) ) itensOk++; else result += "1,"; currentItem++; m_Log.Flush(); Thread.Sleep(1);
			}

			if ( transaction.ut_max == 0 && demand == "!" )
			{
				result = " exec_alteraSenhaCartao             " + " ## no available coverage! ";
				currentItem++;
				return false;
			}

			if ( currentItem == 0 ) return true;

			if ( result.Length > 0 ) result = " (" + result.Substring(0,result.Length-1)+ ")";

			result = " exec_alteraSenhaCartao              " + 
					(currentItem- itensOk).ToString() + 
					" errors in " + 
					currentItem + 
					" tests executed. " + result;

			if (currentItem- itensOk != 0 ) return false;

			return true;
		}

		#region - EXCHANGE -

		public void call_exec_alteraSenhaCartao ( string st_cart_empresa, string st_cart_mat, string st_cart_tit, string st_senha, string st_novaSenha, ref CNetHeader header ) 
		{
			m_Comm.Clear();
			
			DataPortable send_dp = new DataPortable();
			
			send_dp.MapTagValue ( COMM_IN_EXEC_ALTERASENHACARTAO.st_cart_empresa, st_cart_empresa );
			send_dp.MapTagValue ( COMM_IN_EXEC_ALTERASENHACARTAO.st_cart_mat, st_cart_mat );
			send_dp.MapTagValue ( COMM_IN_EXEC_ALTERASENHACARTAO.st_cart_tit, st_cart_tit );
			send_dp.MapTagValue ( COMM_IN_EXEC_ALTERASENHACARTAO.st_senha, st_senha );
			send_dp.MapTagValue ( COMM_IN_EXEC_ALTERASENHACARTAO.st_novaSenha, st_novaSenha );
			
			m_Comm.AddEntryPortable ( ref send_dp );
			
			DataPortable send_dp_cont_0 = new DataPortable();
			
			send_dp_cont_0.MapTagContainer ( COMM_IN_EXEC_ALTERASENHACARTAO.header, header as DataPortable );
			
			m_Comm.AddEntryPortable ( ref send_dp_cont_0 );
		}

		public void recv_exec_alteraSenhaCartao (  )
		{
		}

		#endregion

/// USER [ custom_functions ]
/// USER [ custom_functions ] END

		public bool Item1()
		{
			#region - INPUT VARS -
			
			transaction.MemoryClean();
			
			tst_unit.LogTest ( "exec_alteraSenhaCartao Item1", ref m_Log );

			transaction.ut_abort = 0;

			string st_cart_empresa = "";
			string st_cart_mat = "";
			string st_cart_tit = "";
			string st_senha = "";
			string st_novaSenha = "";
			
			CNetHeader header = new CNetHeader(); 

			#endregion
		
/// USER [ setup_test_1 ]
/// USER [ setup_test_1 ] END

			#region - MAPPING TRANSACTION -

			call_exec_alteraSenhaCartao ( st_cart_empresa, st_cart_mat, st_cart_tit, st_senha, st_novaSenha, ref  header ); 

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
