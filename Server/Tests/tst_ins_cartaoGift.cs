using System;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;

namespace SyCrafEngine
{
	#if DEBUG || LOAD
	public class tst_ins_cartaoGift : tst_base
	{
/// USER [ usr_var_decl ]
/// USER [ usr_var_decl ] END

		public ins_cartaoGift transaction = new ins_cartaoGift();
		public UnitTest tst_unit = new UnitTest();

		public Communication 	m_Comm;
		public StreamWriter 	m_Log;
		public DB_Access 		m_my_access;

		#region - CONSTRUCTOR -

		public tst_ins_cartaoGift ( ref StreamWriter p_m_Log, 
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
			
			if ( demand == "!" || demand == "ins_cartaoGift" )
			{
				#if DEBUG
				if ( Item1( ) ) itensOk++; else result += "1,"; currentItem++; m_Log.Flush(); Thread.Sleep(1);
				#endif
			}

			if ( transaction.ut_max == 0 && demand == "!" )
			{
				result = " ins_cartaoGift                     " + " ## no available coverage! ";
				currentItem++;
				return false;
			}

			if ( currentItem == 0 ) return true;

			if ( result.Length > 0 ) result = " (" + result.Substring(0,result.Length-1)+ ")";

			result = " ins_cartaoGift                      " + 
					(currentItem- itensOk).ToString() + 
					" errors in " + 
					currentItem + 
					" tests executed. " + result;

			if (currentItem- itensOk != 0 ) return false;

			#endif
			return true;
		}

		#region - EXCHANGE -

		public void call_ins_cartaoGift ( string st_empresa, string st_matricula, string tg_tipoPag, string tg_tipoCartao, string st_cheque, string vr_carga, ref CNetHeader header, ref ArrayList prod ) 
		{
			m_Comm.Clear();
			
			DataPortable send_dp = new DataPortable();
			
			send_dp.MapTagValue ( COMM_IN_INS_CARTAOGIFT.st_empresa, st_empresa );
			send_dp.MapTagValue ( COMM_IN_INS_CARTAOGIFT.st_matricula, st_matricula );
			send_dp.MapTagValue ( COMM_IN_INS_CARTAOGIFT.tg_tipoPag, tg_tipoPag );
			send_dp.MapTagValue ( COMM_IN_INS_CARTAOGIFT.tg_tipoCartao, tg_tipoCartao );
			send_dp.MapTagValue ( COMM_IN_INS_CARTAOGIFT.st_cheque, st_cheque );
			send_dp.MapTagValue ( COMM_IN_INS_CARTAOGIFT.vr_carga, vr_carga );
			
			m_Comm.AddEntryPortable ( ref send_dp );
			
			DataPortable send_dp_cont_0 = new DataPortable();
			
			send_dp_cont_0.MapTagContainer ( COMM_IN_INS_CARTAOGIFT.header, header as DataPortable );
			
			m_Comm.AddEntryPortable ( ref send_dp_cont_0 );
			
			DataPortable send_dp_array_generic_prod = new DataPortable();
				
			send_dp_array_generic_prod.MapTagArray ( COMM_IN_INS_CARTAOGIFT.prod, ref prod ); 
				
			m_Comm.AddEntryPortable ( ref send_dp_array_generic_prod );
		}

		public void recv_ins_cartaoGift ( ref string id_giftCard )
		{
			DataPortable recv_dp = m_Comm.GetFirstExitPortable(); 
			
			recv_dp.GetMapValue ( COMM_OUT_INS_CARTAOGIFT.id_giftCard , ref id_giftCard );
		}

		#endregion

/// USER [ custom_functions ]
/// USER [ custom_functions ] END

		public bool Item1()
		{
			#region - INPUT VARS -
			
			transaction.MemoryClean();
			
			tst_unit.LogTest ( "ins_cartaoGift Item1", ref m_Log );

			transaction.ut_abort = 0;

			string st_empresa = "";
			string st_matricula = "";
			string tg_tipoPag = "";
			string tg_tipoCartao = "";
			string st_cheque = "";
			string vr_carga = "";
			
			CNetHeader header = new CNetHeader(); 
			
			ArrayList prod = new ArrayList();

			#endregion
		
/// USER [ setup_test_1 ]
/// USER [ setup_test_1 ] END

			#region - MAPPING TRANSACTION -

			call_ins_cartaoGift ( st_empresa, st_matricula, tg_tipoPag, tg_tipoCartao, st_cheque, vr_carga, ref  header, ref prod ); 

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

			string id_giftCard = "";

			recv_ins_cartaoGift ( ref id_giftCard ); 

			transaction.sendObjections ( ref my_objections );

			#endregion

/// USER [ validate_1 ]
/// USER [ validate_1 ] END

			return true;
		}
	}
	#endif
}
