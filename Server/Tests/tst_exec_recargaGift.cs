using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;

namespace SyCrafEngine
{
	#if DEBUG 
	public class tst_exec_recargaGift : tst_base
	{
/// USER [ usr_var_decl ]
/// USER [ usr_var_decl ] END

		public exec_recargaGift transaction = new exec_recargaGift();
		public UnitTest tst_unit = new UnitTest();

		public Communication 	m_Comm;
		public StreamWriter 	m_Log;
		public DB_Access 		m_my_access;

		#region - CONSTRUCTOR -

		public tst_exec_recargaGift ( ref StreamWriter p_m_Log, 
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
			if ( demand == "!" || demand == "exec_recargaGift" )
			{
				if ( Item1( ) ) itensOk++; else result += "1,"; currentItem++; m_Log.Flush(); Thread.Sleep(1);
			}

			if ( transaction.ut_max == 0 && demand == "!" )
			{
				result = " exec_recargaGift                   " + " ## no available coverage! ";
				currentItem++;
				return false;
			}

			if ( currentItem == 0 ) return true;

			if ( result.Length > 0 ) result = " (" + result.Substring(0,result.Length-1)+ ")";

			result = " exec_recargaGift                    " + 
					(currentItem- itensOk).ToString() + 
					" errors in " + 
					currentItem + 
					" tests executed. " + result;

			if (currentItem- itensOk != 0 ) return false;

			return true;
		}

		#region - EXCHANGE -

		public void call_exec_recargaGift ( string st_empresa, string st_matricula, string vr_carga, string tg_tipoPag, string tg_tipoCartao, string st_cheque, string tg_adesao, ref CNetHeader header, ref ArrayList lstProd ) 
		{
			m_Comm.Clear();
			
			DataPortable send_dp = new DataPortable();
			
			send_dp.MapTagValue ( COMM_IN_EXEC_RECARGAGIFT.st_empresa, st_empresa );
			send_dp.MapTagValue ( COMM_IN_EXEC_RECARGAGIFT.st_matricula, st_matricula );
			send_dp.MapTagValue ( COMM_IN_EXEC_RECARGAGIFT.vr_carga, vr_carga );
			send_dp.MapTagValue ( COMM_IN_EXEC_RECARGAGIFT.tg_tipoPag, tg_tipoPag );
			send_dp.MapTagValue ( COMM_IN_EXEC_RECARGAGIFT.tg_tipoCartao, tg_tipoCartao );
			send_dp.MapTagValue ( COMM_IN_EXEC_RECARGAGIFT.st_cheque, st_cheque );
			send_dp.MapTagValue ( COMM_IN_EXEC_RECARGAGIFT.tg_adesao, tg_adesao );
			
			m_Comm.AddEntryPortable ( ref send_dp );
			
			DataPortable send_dp_cont_0 = new DataPortable();
			
			send_dp_cont_0.MapTagContainer ( COMM_IN_EXEC_RECARGAGIFT.header, header as DataPortable );
			
			m_Comm.AddEntryPortable ( ref send_dp_cont_0 );
			
			DataPortable send_dp_array_generic_lstProd = new DataPortable();
				
			send_dp_array_generic_lstProd.MapTagArray ( COMM_IN_EXEC_RECARGAGIFT.lstProd, ref lstProd ); 
				
			m_Comm.AddEntryPortable ( ref send_dp_array_generic_lstProd );
		}

		public void recv_exec_recargaGift ( ref string id_gift )
		{
			DataPortable recv_dp = m_Comm.GetFirstExitPortable(); 
			
			recv_dp.GetMapValue ( COMM_OUT_EXEC_RECARGAGIFT.id_gift , ref id_gift );
		}

		#endregion

/// USER [ custom_functions ]
/// USER [ custom_functions ] END

		public bool Item1()
		{
			#region - INPUT VARS -
			
			transaction.MemoryClean();
			
			tst_unit.LogTest ( "exec_recargaGift Item1", ref m_Log );

			transaction.ut_abort = 0;

			string st_empresa = "";
			string st_matricula = "";
			string vr_carga = "";
			string tg_tipoPag = "";
			string tg_tipoCartao = "";
			string st_cheque = "";
			string tg_adesao = "";
			
			CNetHeader header = new CNetHeader(); 
			
			ArrayList lstProd = new ArrayList();

			#endregion
		
/// USER [ setup_test_1 ]
/// USER [ setup_test_1 ] END

			#region - MAPPING TRANSACTION -

			call_exec_recargaGift ( st_empresa, st_matricula, vr_carga, tg_tipoPag, tg_tipoCartao, st_cheque, tg_adesao, ref  header, ref lstProd ); 

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

			string id_gift = "";

			recv_exec_recargaGift ( ref id_gift ); 

			transaction.sendObjections ( ref my_objections );

			#endregion

/// USER [ validate_1 ]
/// USER [ validate_1 ] END

			return true;
		}
	}
	#endif
}
