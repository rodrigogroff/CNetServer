using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace SyCrafEngine
{
	#if DEBUG
	public class Automated 
	{
		public void showCoverage ( Transaction trans, ref ListBox lstResults )
		{
			if ( trans.ut_enabled == true )
			{
				if ( trans.ut_max > 0 )
				{
					float res = trans.ut_call.Count * 100 / trans.ut_max;
					if ( res < 100 ) lstResults.Items.Add ( " Coverage      >> " +  res + "%" );
									
					
					string bufferOut = "";
					
					for ( int t=1; t <= trans.ut_max; ++t )
					{
						if ( trans.ut_call[t] == null )
						{
							bufferOut += Convert.ToString ( t ) + " ";
							m_totalFailedCoverage++;
						}
					}
					
					if ( bufferOut == "" ) return; 
					
					lstResults.Items.Add ( " Failed Points >> " + bufferOut  );
					lstResults.Items.Add ( " " );
				}
			}
		}
	
		public int m_totalTests = 0;
		public int m_totalFailedCoverage = 0;
		public int m_totalTestsFailed = 0;
	
		public Automated ( string connString, string demand, ref ListBox lstResults )
		{
			LockArea 		m_lockArea = new LockArea();
			CPU_Monitor     m_cpu = new CPU_Monitor();
			DB_Access 		m_access   = new DB_Access ( connString, ref m_lockArea, ref m_cpu );
			
			string path = @"Log.txt";
			
			FileStream 		m_log_file;
			
			if (File.Exists(path)) 
				m_log_file = new FileStream ( path, FileMode.Append, FileAccess.Write);
			else
				m_log_file = new FileStream ( path, FileMode.Create, FileAccess.Write);
			
			StreamWriter 	m_Log 	   = new StreamWriter ( m_log_file );
			Communication 	m_Comm     = new Communication();
			
			int OkTests = 0, testsExec = 0, totalTests = 0;
			string session = "session";
			
			OkTests.ToString(); testsExec.ToString(); totalTests.ToString(); session.ToString();
			
			lstResults.Items.Add ("");
			lstResults.Items.Add (" Starting");
			lstResults.Items.Add (" ------------------------------------- ");
			lstResults.Items.Add ("");
			{
				tst_type_base type_base = new tst_type_base( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( type_base.Test() )	OkTests++; testsExec++; totalTests += type_base.currentItem;
				if (type_base.currentItem > 0 ) { lstResults.Items.Add ( type_base.result );
				showCoverage ( type_base.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_ins_cartaoProprietario ins_cartaoProprietario = new tst_ins_cartaoProprietario( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( ins_cartaoProprietario.Test() )	OkTests++; testsExec++; totalTests += ins_cartaoProprietario.currentItem;
				if (ins_cartaoProprietario.currentItem > 0 ) { lstResults.Items.Add ( ins_cartaoProprietario.result );
				showCoverage ( ins_cartaoProprietario.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_proprietario fetch_proprietario = new tst_fetch_proprietario( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_proprietario.Test() )	OkTests++; testsExec++; totalTests += fetch_proprietario.currentItem;
				if (fetch_proprietario.currentItem > 0 ) { lstResults.Items.Add ( fetch_proprietario.result );
				showCoverage ( fetch_proprietario.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_login exec_login = new tst_exec_login( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_login.Test() )	OkTests++; testsExec++; totalTests += exec_login.currentItem;
				if (exec_login.currentItem > 0 ) { lstResults.Items.Add ( exec_login.result );
				showCoverage ( exec_login.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_logoff exec_logoff = new tst_exec_logoff( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_logoff.Test() )	OkTests++; testsExec++; totalTests += exec_logoff.currentItem;
				if (exec_logoff.currentItem > 0 ) { lstResults.Items.Add ( exec_logoff.result );
				showCoverage ( exec_logoff.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_trocaSenha exec_trocaSenha = new tst_exec_trocaSenha( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_trocaSenha.Test() )	OkTests++; testsExec++; totalTests += exec_trocaSenha.currentItem;
				if (exec_trocaSenha.currentItem > 0 ) { lstResults.Items.Add ( exec_trocaSenha.result );
				showCoverage ( exec_trocaSenha.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_ins_usuario ins_usuario = new tst_ins_usuario( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( ins_usuario.Test() )	OkTests++; testsExec++; totalTests += ins_usuario.currentItem;
				if (ins_usuario.currentItem > 0 ) { lstResults.Items.Add ( ins_usuario.result );
				showCoverage ( ins_usuario.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_listaUsuarios fetch_listaUsuarios = new tst_fetch_listaUsuarios( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_listaUsuarios.Test() )	OkTests++; testsExec++; totalTests += fetch_listaUsuarios.currentItem;
				if (fetch_listaUsuarios.currentItem > 0 ) { lstResults.Items.Add ( fetch_listaUsuarios.result );
				showCoverage ( fetch_listaUsuarios.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_usuarios fetch_usuarios = new tst_fetch_usuarios( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_usuarios.Test() )	OkTests++; testsExec++; totalTests += fetch_usuarios.currentItem;
				if (fetch_usuarios.currentItem > 0 ) { lstResults.Items.Add ( fetch_usuarios.result );
				showCoverage ( fetch_usuarios.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_alteraUsuario exec_alteraUsuario = new tst_exec_alteraUsuario( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_alteraUsuario.Test() )	OkTests++; testsExec++; totalTests += exec_alteraUsuario.currentItem;
				if (exec_alteraUsuario.currentItem > 0 ) { lstResults.Items.Add ( exec_alteraUsuario.result );
				showCoverage ( exec_alteraUsuario.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_ins_empresa ins_empresa = new tst_ins_empresa( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( ins_empresa.Test() )	OkTests++; testsExec++; totalTests += ins_empresa.currentItem;
				if (ins_empresa.currentItem > 0 ) { lstResults.Items.Add ( ins_empresa.result );
				showCoverage ( ins_empresa.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_ins_loja ins_loja = new tst_ins_loja( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( ins_loja.Test() )	OkTests++; testsExec++; totalTests += ins_loja.currentItem;
				if (ins_loja.currentItem > 0 ) { lstResults.Items.Add ( ins_loja.result );
				showCoverage ( ins_loja.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_dadosEmpresa fetch_dadosEmpresa = new tst_fetch_dadosEmpresa( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_dadosEmpresa.Test() )	OkTests++; testsExec++; totalTests += fetch_dadosEmpresa.currentItem;
				if (fetch_dadosEmpresa.currentItem > 0 ) { lstResults.Items.Add ( fetch_dadosEmpresa.result );
				showCoverage ( fetch_dadosEmpresa.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_dadosLoja fetch_dadosLoja = new tst_fetch_dadosLoja( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_dadosLoja.Test() )	OkTests++; testsExec++; totalTests += fetch_dadosLoja.currentItem;
				if (fetch_dadosLoja.currentItem > 0 ) { lstResults.Items.Add ( fetch_dadosLoja.result );
				showCoverage ( fetch_dadosLoja.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_alteraEmpresa exec_alteraEmpresa = new tst_exec_alteraEmpresa( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_alteraEmpresa.Test() )	OkTests++; testsExec++; totalTests += exec_alteraEmpresa.currentItem;
				if (exec_alteraEmpresa.currentItem > 0 ) { lstResults.Items.Add ( exec_alteraEmpresa.result );
				showCoverage ( exec_alteraEmpresa.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_alteraLoja exec_alteraLoja = new tst_exec_alteraLoja( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_alteraLoja.Test() )	OkTests++; testsExec++; totalTests += exec_alteraLoja.currentItem;
				if (exec_alteraLoja.currentItem > 0 ) { lstResults.Items.Add ( exec_alteraLoja.result );
				showCoverage ( exec_alteraLoja.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_codTerminal fetch_codTerminal = new tst_fetch_codTerminal( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_codTerminal.Test() )	OkTests++; testsExec++; totalTests += fetch_codTerminal.currentItem;
				if (fetch_codTerminal.currentItem > 0 ) { lstResults.Items.Add ( fetch_codTerminal.result );
				showCoverage ( fetch_codTerminal.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_nomeEmpresa fetch_nomeEmpresa = new tst_fetch_nomeEmpresa( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_nomeEmpresa.Test() )	OkTests++; testsExec++; totalTests += fetch_nomeEmpresa.currentItem;
				if (fetch_nomeEmpresa.currentItem > 0 ) { lstResults.Items.Add ( fetch_nomeEmpresa.result );
				showCoverage ( fetch_nomeEmpresa.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_validaEmpresa fetch_validaEmpresa = new tst_fetch_validaEmpresa( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_validaEmpresa.Test() )	OkTests++; testsExec++; totalTests += fetch_validaEmpresa.currentItem;
				if (fetch_validaEmpresa.currentItem > 0 ) { lstResults.Items.Add ( fetch_validaEmpresa.result );
				showCoverage ( fetch_validaEmpresa.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_ins_terminal ins_terminal = new tst_ins_terminal( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( ins_terminal.Test() )	OkTests++; testsExec++; totalTests += ins_terminal.currentItem;
				if (ins_terminal.currentItem > 0 ) { lstResults.Items.Add ( ins_terminal.result );
				showCoverage ( ins_terminal.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_terminais fetch_terminais = new tst_fetch_terminais( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_terminais.Test() )	OkTests++; testsExec++; totalTests += fetch_terminais.currentItem;
				if (fetch_terminais.currentItem > 0 ) { lstResults.Items.Add ( fetch_terminais.result );
				showCoverage ( fetch_terminais.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_terminalLoja fetch_terminalLoja = new tst_fetch_terminalLoja( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_terminalLoja.Test() )	OkTests++; testsExec++; totalTests += fetch_terminalLoja.currentItem;
				if (fetch_terminalLoja.currentItem > 0 ) { lstResults.Items.Add ( fetch_terminalLoja.result );
				showCoverage ( fetch_terminalLoja.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_del_Terminal del_Terminal = new tst_del_Terminal( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( del_Terminal.Test() )	OkTests++; testsExec++; totalTests += del_Terminal.currentItem;
				if (del_Terminal.currentItem > 0 ) { lstResults.Items.Add ( del_Terminal.result );
				showCoverage ( del_Terminal.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_consultaLoja fetch_consultaLoja = new tst_fetch_consultaLoja( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_consultaLoja.Test() )	OkTests++; testsExec++; totalTests += fetch_consultaLoja.currentItem;
				if (fetch_consultaLoja.currentItem > 0 ) { lstResults.Items.Add ( fetch_consultaLoja.result );
				showCoverage ( fetch_consultaLoja.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_consultaEmpresa fetch_consultaEmpresa = new tst_fetch_consultaEmpresa( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_consultaEmpresa.Test() )	OkTests++; testsExec++; totalTests += fetch_consultaEmpresa.currentItem;
				if (fetch_consultaEmpresa.currentItem > 0 ) { lstResults.Items.Add ( fetch_consultaEmpresa.result );
				showCoverage ( fetch_consultaEmpresa.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_consultaAuditoria fetch_consultaAuditoria = new tst_fetch_consultaAuditoria( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_consultaAuditoria.Test() )	OkTests++; testsExec++; totalTests += fetch_consultaAuditoria.currentItem;
				if (fetch_consultaAuditoria.currentItem > 0 ) { lstResults.Items.Add ( fetch_consultaAuditoria.result );
				showCoverage ( fetch_consultaAuditoria.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_alteraTerminal exec_alteraTerminal = new tst_exec_alteraTerminal( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_alteraTerminal.Test() )	OkTests++; testsExec++; totalTests += exec_alteraTerminal.currentItem;
				if (exec_alteraTerminal.currentItem > 0 ) { lstResults.Items.Add ( exec_alteraTerminal.result );
				showCoverage ( exec_alteraTerminal.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_limitesCartao fetch_limitesCartao = new tst_fetch_limitesCartao( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_limitesCartao.Test() )	OkTests++; testsExec++; totalTests += fetch_limitesCartao.currentItem;
				if (fetch_limitesCartao.currentItem > 0 ) { lstResults.Items.Add ( fetch_limitesCartao.result );
				showCoverage ( fetch_limitesCartao.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_alteraCartao exec_alteraCartao = new tst_exec_alteraCartao( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_alteraCartao.Test() )	OkTests++; testsExec++; totalTests += exec_alteraCartao.currentItem;
				if (exec_alteraCartao.currentItem > 0 ) { lstResults.Items.Add ( exec_alteraCartao.result );
				showCoverage ( exec_alteraCartao.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_consultaCartao fetch_consultaCartao = new tst_fetch_consultaCartao( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_consultaCartao.Test() )	OkTests++; testsExec++; totalTests += fetch_consultaCartao.currentItem;
				if (fetch_consultaCartao.currentItem > 0 ) { lstResults.Items.Add ( fetch_consultaCartao.result );
				showCoverage ( fetch_consultaCartao.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_infra_SchedulerDispatcher infra_SchedulerDispatcher = new tst_infra_SchedulerDispatcher( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( infra_SchedulerDispatcher.Test() )	OkTests++; testsExec++; totalTests += infra_SchedulerDispatcher.currentItem;
				if (infra_SchedulerDispatcher.currentItem > 0 ) { lstResults.Items.Add ( infra_SchedulerDispatcher.result );
				showCoverage ( infra_SchedulerDispatcher.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_schedule_base schedule_base = new tst_schedule_base( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( schedule_base.Test() )	OkTests++; testsExec++; totalTests += schedule_base.currentItem;
				if (schedule_base.currentItem > 0 ) { lstResults.Items.Add ( schedule_base.result );
				showCoverage ( schedule_base.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_pos_vendaEmpresarial exec_pos_vendaEmpresarial = new tst_exec_pos_vendaEmpresarial( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_pos_vendaEmpresarial.Test() )	OkTests++; testsExec++; totalTests += exec_pos_vendaEmpresarial.currentItem;
				if (exec_pos_vendaEmpresarial.currentItem > 0 ) { lstResults.Items.Add ( exec_pos_vendaEmpresarial.result );
				showCoverage ( exec_pos_vendaEmpresarial.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_pos_confirmaVendaEmpresarial exec_pos_confirmaVendaEmpresarial = new tst_exec_pos_confirmaVendaEmpresarial( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_pos_confirmaVendaEmpresarial.Test() )	OkTests++; testsExec++; totalTests += exec_pos_confirmaVendaEmpresarial.currentItem;
				if (exec_pos_confirmaVendaEmpresarial.currentItem > 0 ) { lstResults.Items.Add ( exec_pos_confirmaVendaEmpresarial.result );
				showCoverage ( exec_pos_confirmaVendaEmpresarial.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_consultaTransacao fetch_consultaTransacao = new tst_fetch_consultaTransacao( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_consultaTransacao.Test() )	OkTests++; testsExec++; totalTests += fetch_consultaTransacao.currentItem;
				if (fetch_consultaTransacao.currentItem > 0 ) { lstResults.Items.Add ( fetch_consultaTransacao.result );
				showCoverage ( fetch_consultaTransacao.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_pf_gravaPendencia exec_pf_gravaPendencia = new tst_exec_pf_gravaPendencia( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_pf_gravaPendencia.Test() )	OkTests++; testsExec++; totalTests += exec_pf_gravaPendencia.currentItem;
				if (exec_pf_gravaPendencia.currentItem > 0 ) { lstResults.Items.Add ( exec_pf_gravaPendencia.result );
				showCoverage ( exec_pf_gravaPendencia.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_pf_consultaPendencia exec_pf_consultaPendencia = new tst_exec_pf_consultaPendencia( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_pf_consultaPendencia.Test() )	OkTests++; testsExec++; totalTests += exec_pf_consultaPendencia.currentItem;
				if (exec_pf_consultaPendencia.currentItem > 0 ) { lstResults.Items.Add ( exec_pf_consultaPendencia.result );
				showCoverage ( exec_pf_consultaPendencia.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_type_pf_base type_pf_base = new tst_type_pf_base( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( type_pf_base.Test() )	OkTests++; testsExec++; totalTests += type_pf_base.currentItem;
				if (type_pf_base.currentItem > 0 ) { lstResults.Items.Add ( type_pf_base.result );
				showCoverage ( type_pf_base.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_pf_cancelaPendencia exec_pf_cancelaPendencia = new tst_exec_pf_cancelaPendencia( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_pf_cancelaPendencia.Test() )	OkTests++; testsExec++; totalTests += exec_pf_cancelaPendencia.currentItem;
				if (exec_pf_cancelaPendencia.currentItem > 0 ) { lstResults.Items.Add ( exec_pf_cancelaPendencia.result );
				showCoverage ( exec_pf_cancelaPendencia.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_pf_autorizaVendaPendente exec_pf_autorizaVendaPendente = new tst_exec_pf_autorizaVendaPendente( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_pf_autorizaVendaPendente.Test() )	OkTests++; testsExec++; totalTests += exec_pf_autorizaVendaPendente.currentItem;
				if (exec_pf_autorizaVendaPendente.currentItem > 0 ) { lstResults.Items.Add ( exec_pf_autorizaVendaPendente.result );
				showCoverage ( exec_pf_autorizaVendaPendente.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_pf_consultaAutorizacao exec_pf_consultaAutorizacao = new tst_exec_pf_consultaAutorizacao( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_pf_consultaAutorizacao.Test() )	OkTests++; testsExec++; totalTests += exec_pf_consultaAutorizacao.currentItem;
				if (exec_pf_consultaAutorizacao.currentItem > 0 ) { lstResults.Items.Add ( exec_pf_consultaAutorizacao.result );
				showCoverage ( exec_pf_consultaAutorizacao.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_ins_payFone ins_payFone = new tst_ins_payFone( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( ins_payFone.Test() )	OkTests++; testsExec++; totalTests += ins_payFone.currentItem;
				if (ins_payFone.currentItem > 0 ) { lstResults.Items.Add ( ins_payFone.result );
				showCoverage ( ins_payFone.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_ins_payFoneLojista ins_payFoneLojista = new tst_ins_payFoneLojista( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( ins_payFoneLojista.Test() )	OkTests++; testsExec++; totalTests += ins_payFoneLojista.currentItem;
				if (ins_payFoneLojista.currentItem > 0 ) { lstResults.Items.Add ( ins_payFoneLojista.result );
				showCoverage ( ins_payFoneLojista.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_alteraSenhaCartao exec_alteraSenhaCartao = new tst_exec_alteraSenhaCartao( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_alteraSenhaCartao.Test() )	OkTests++; testsExec++; totalTests += exec_alteraSenhaCartao.currentItem;
				if (exec_alteraSenhaCartao.currentItem > 0 ) { lstResults.Items.Add ( exec_alteraSenhaCartao.result );
				showCoverage ( exec_alteraSenhaCartao.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_pf_cancelaVenda exec_pf_cancelaVenda = new tst_exec_pf_cancelaVenda( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_pf_cancelaVenda.Test() )	OkTests++; testsExec++; totalTests += exec_pf_cancelaVenda.currentItem;
				if (exec_pf_cancelaVenda.currentItem > 0 ) { lstResults.Items.Add ( exec_pf_cancelaVenda.result );
				showCoverage ( exec_pf_cancelaVenda.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_pf_telefoneLojista fetch_pf_telefoneLojista = new tst_fetch_pf_telefoneLojista( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_pf_telefoneLojista.Test() )	OkTests++; testsExec++; totalTests += fetch_pf_telefoneLojista.currentItem;
				if (fetch_pf_telefoneLojista.currentItem > 0 ) { lstResults.Items.Add ( fetch_pf_telefoneLojista.result );
				showCoverage ( fetch_pf_telefoneLojista.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_dadosCartao fetch_dadosCartao = new tst_fetch_dadosCartao( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_dadosCartao.Test() )	OkTests++; testsExec++; totalTests += fetch_dadosCartao.currentItem;
				if (fetch_dadosCartao.currentItem > 0 ) { lstResults.Items.Add ( fetch_dadosCartao.result );
				showCoverage ( fetch_dadosCartao.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_nomeLoja fetch_nomeLoja = new tst_fetch_nomeLoja( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_nomeLoja.Test() )	OkTests++; testsExec++; totalTests += fetch_nomeLoja.currentItem;
				if (fetch_nomeLoja.currentItem > 0 ) { lstResults.Items.Add ( fetch_nomeLoja.result );
				showCoverage ( fetch_nomeLoja.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_termLoja fetch_termLoja = new tst_fetch_termLoja( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_termLoja.Test() )	OkTests++; testsExec++; totalTests += fetch_termLoja.currentItem;
				if (fetch_termLoja.currentItem > 0 ) { lstResults.Items.Add ( fetch_termLoja.result );
				showCoverage ( fetch_termLoja.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_nomeLojaTerminal fetch_nomeLojaTerminal = new tst_fetch_nomeLojaTerminal( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_nomeLojaTerminal.Test() )	OkTests++; testsExec++; totalTests += fetch_nomeLojaTerminal.currentItem;
				if (fetch_nomeLojaTerminal.currentItem > 0 ) { lstResults.Items.Add ( fetch_nomeLojaTerminal.result );
				showCoverage ( fetch_nomeLojaTerminal.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_pf_cancelaPendenciaLojista exec_pf_cancelaPendenciaLojista = new tst_exec_pf_cancelaPendenciaLojista( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_pf_cancelaPendenciaLojista.Test() )	OkTests++; testsExec++; totalTests += exec_pf_cancelaPendenciaLojista.currentItem;
				if (exec_pf_cancelaPendenciaLojista.currentItem > 0 ) { lstResults.Items.Add ( exec_pf_cancelaPendenciaLojista.result );
				showCoverage ( exec_pf_cancelaPendenciaLojista.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_dadosNSU fetch_dadosNSU = new tst_fetch_dadosNSU( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_dadosNSU.Test() )	OkTests++; testsExec++; totalTests += fetch_dadosNSU.currentItem;
				if (fetch_dadosNSU.currentItem > 0 ) { lstResults.Items.Add ( fetch_dadosNSU.result );
				showCoverage ( fetch_dadosNSU.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_pos_cancelaVendaEmpresarial exec_pos_cancelaVendaEmpresarial = new tst_exec_pos_cancelaVendaEmpresarial( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_pos_cancelaVendaEmpresarial.Test() )	OkTests++; testsExec++; totalTests += exec_pos_cancelaVendaEmpresarial.currentItem;
				if (exec_pos_cancelaVendaEmpresarial.currentItem > 0 ) { lstResults.Items.Add ( exec_pos_cancelaVendaEmpresarial.result );
				showCoverage ( exec_pos_cancelaVendaEmpresarial.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_rel_1_rtc fetch_rel_1_rtc = new tst_fetch_rel_1_rtc( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_rel_1_rtc.Test() )	OkTests++; testsExec++; totalTests += fetch_rel_1_rtc.currentItem;
				if (fetch_rel_1_rtc.currentItem > 0 ) { lstResults.Items.Add ( fetch_rel_1_rtc.result );
				showCoverage ( fetch_rel_1_rtc.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_rel_2_rlt fetch_rel_2_rlt = new tst_fetch_rel_2_rlt( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_rel_2_rlt.Test() )	OkTests++; testsExec++; totalTests += fetch_rel_2_rlt.currentItem;
				if (fetch_rel_2_rlt.currentItem > 0 ) { lstResults.Items.Add ( fetch_rel_2_rlt.result );
				showCoverage ( fetch_rel_2_rlt.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_schedule_nsu schedule_nsu = new tst_schedule_nsu( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( schedule_nsu.Test() )	OkTests++; testsExec++; totalTests += schedule_nsu.currentItem;
				if (schedule_nsu.currentItem > 0 ) { lstResults.Items.Add ( schedule_nsu.result );
				showCoverage ( schedule_nsu.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_pf_autorizaInstalacao exec_pf_autorizaInstalacao = new tst_exec_pf_autorizaInstalacao( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_pf_autorizaInstalacao.Test() )	OkTests++; testsExec++; totalTests += exec_pf_autorizaInstalacao.currentItem;
				if (exec_pf_autorizaInstalacao.currentItem > 0 ) { lstResults.Items.Add ( exec_pf_autorizaInstalacao.result );
				showCoverage ( exec_pf_autorizaInstalacao.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_ins_agenda ins_agenda = new tst_ins_agenda( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( ins_agenda.Test() )	OkTests++; testsExec++; totalTests += ins_agenda.currentItem;
				if (ins_agenda.currentItem > 0 ) { lstResults.Items.Add ( ins_agenda.result );
				showCoverage ( ins_agenda.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_schedule_fech_mensal schedule_fech_mensal = new tst_schedule_fech_mensal( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( schedule_fech_mensal.Test() )	OkTests++; testsExec++; totalTests += schedule_fech_mensal.currentItem;
				if (schedule_fech_mensal.currentItem > 0 ) { lstResults.Items.Add ( schedule_fech_mensal.result );
				showCoverage ( schedule_fech_mensal.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_agenda fetch_agenda = new tst_fetch_agenda( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_agenda.Test() )	OkTests++; testsExec++; totalTests += fetch_agenda.currentItem;
				if (fetch_agenda.currentItem > 0 ) { lstResults.Items.Add ( fetch_agenda.result );
				showCoverage ( fetch_agenda.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_del_agenda del_agenda = new tst_del_agenda( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( del_agenda.Test() )	OkTests++; testsExec++; totalTests += del_agenda.currentItem;
				if (del_agenda.currentItem > 0 ) { lstResults.Items.Add ( del_agenda.result );
				showCoverage ( del_agenda.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_rel_3_fech fetch_rel_3_fech = new tst_fetch_rel_3_fech( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_rel_3_fech.Test() )	OkTests++; testsExec++; totalTests += fetch_rel_3_fech.currentItem;
				if (fetch_rel_3_fech.currentItem > 0 ) { lstResults.Items.Add ( fetch_rel_3_fech.result );
				showCoverage ( fetch_rel_3_fech.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_memory fetch_memory = new tst_fetch_memory( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_memory.Test() )	OkTests++; testsExec++; totalTests += fetch_memory.currentItem;
				if (fetch_memory.currentItem > 0 ) { lstResults.Items.Add ( fetch_memory.result );
				showCoverage ( fetch_memory.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_schedule_educacional schedule_educacional = new tst_schedule_educacional( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( schedule_educacional.Test() )	OkTests++; testsExec++; totalTests += schedule_educacional.currentItem;
				if (schedule_educacional.currentItem > 0 ) { lstResults.Items.Add ( schedule_educacional.result );
				showCoverage ( schedule_educacional.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_listaConveniosLoja fetch_listaConveniosLoja = new tst_fetch_listaConveniosLoja( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_listaConveniosLoja.Test() )	OkTests++; testsExec++; totalTests += fetch_listaConveniosLoja.currentItem;
				if (fetch_listaConveniosLoja.currentItem > 0 ) { lstResults.Items.Add ( fetch_listaConveniosLoja.result );
				showCoverage ( fetch_listaConveniosLoja.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_rel_4_rrp fetch_rel_4_rrp = new tst_fetch_rel_4_rrp( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_rel_4_rrp.Test() )	OkTests++; testsExec++; totalTests += fetch_rel_4_rrp.currentItem;
				if (fetch_rel_4_rrp.currentItem > 0 ) { lstResults.Items.Add ( fetch_rel_4_rrp.result );
				showCoverage ( fetch_rel_4_rrp.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_dadosAluno fetch_dadosAluno = new tst_fetch_dadosAluno( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_dadosAluno.Test() )	OkTests++; testsExec++; totalTests += fetch_dadosAluno.currentItem;
				if (fetch_dadosAluno.currentItem > 0 ) { lstResults.Items.Add ( fetch_dadosAluno.result );
				showCoverage ( fetch_dadosAluno.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_depotEduImediato exec_depotEduImediato = new tst_exec_depotEduImediato( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_depotEduImediato.Test() )	OkTests++; testsExec++; totalTests += exec_depotEduImediato.currentItem;
				if (exec_depotEduImediato.currentItem > 0 ) { lstResults.Items.Add ( exec_depotEduImediato.result );
				showCoverage ( exec_depotEduImediato.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_rel_edu_extrato fetch_rel_edu_extrato = new tst_fetch_rel_edu_extrato( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_rel_edu_extrato.Test() )	OkTests++; testsExec++; totalTests += fetch_rel_edu_extrato.currentItem;
				if (fetch_rel_edu_extrato.currentItem > 0 ) { lstResults.Items.Add ( fetch_rel_edu_extrato.result );
				showCoverage ( fetch_rel_edu_extrato.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_bloqueio exec_bloqueio = new tst_exec_bloqueio( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_bloqueio.Test() )	OkTests++; testsExec++; totalTests += exec_bloqueio.currentItem;
				if (exec_bloqueio.currentItem > 0 ) { lstResults.Items.Add ( exec_bloqueio.result );
				showCoverage ( exec_bloqueio.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_desbloqueio exec_desbloqueio = new tst_exec_desbloqueio( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_desbloqueio.Test() )	OkTests++; testsExec++; totalTests += exec_desbloqueio.currentItem;
				if (exec_desbloqueio.currentItem > 0 ) { lstResults.Items.Add ( exec_desbloqueio.result );
				showCoverage ( exec_desbloqueio.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_cancelaEmpresa exec_cancelaEmpresa = new tst_exec_cancelaEmpresa( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_cancelaEmpresa.Test() )	OkTests++; testsExec++; totalTests += exec_cancelaEmpresa.currentItem;
				if (exec_cancelaEmpresa.currentItem > 0 ) { lstResults.Items.Add ( exec_cancelaEmpresa.result );
				showCoverage ( exec_cancelaEmpresa.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_web_fetch_saldo_edu web_fetch_saldo_edu = new tst_web_fetch_saldo_edu( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( web_fetch_saldo_edu.Test() )	OkTests++; testsExec++; totalTests += web_fetch_saldo_edu.currentItem;
				if (web_fetch_saldo_edu.currentItem > 0 ) { lstResults.Items.Add ( web_fetch_saldo_edu.result );
				showCoverage ( web_fetch_saldo_edu.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_web_fetch_edu_inicial web_fetch_edu_inicial = new tst_web_fetch_edu_inicial( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( web_fetch_edu_inicial.Test() )	OkTests++; testsExec++; totalTests += web_fetch_edu_inicial.currentItem;
				if (web_fetch_edu_inicial.currentItem > 0 ) { lstResults.Items.Add ( web_fetch_edu_inicial.result );
				showCoverage ( web_fetch_edu_inicial.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_web_fetch_rel_edu_extrato web_fetch_rel_edu_extrato = new tst_web_fetch_rel_edu_extrato( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( web_fetch_rel_edu_extrato.Test() )	OkTests++; testsExec++; totalTests += web_fetch_rel_edu_extrato.currentItem;
				if (web_fetch_rel_edu_extrato.currentItem > 0 ) { lstResults.Items.Add ( web_fetch_rel_edu_extrato.result );
				showCoverage ( web_fetch_rel_edu_extrato.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_web_fetch_resp_alunos web_fetch_resp_alunos = new tst_web_fetch_resp_alunos( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( web_fetch_resp_alunos.Test() )	OkTests++; testsExec++; totalTests += web_fetch_resp_alunos.currentItem;
				if (web_fetch_resp_alunos.currentItem > 0 ) { lstResults.Items.Add ( web_fetch_resp_alunos.result );
				showCoverage ( web_fetch_resp_alunos.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_web_exec_trocaLim web_exec_trocaLim = new tst_web_exec_trocaLim( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( web_exec_trocaLim.Test() )	OkTests++; testsExec++; totalTests += web_exec_trocaLim.currentItem;
				if (web_exec_trocaLim.currentItem > 0 ) { lstResults.Items.Add ( web_exec_trocaLim.result );
				showCoverage ( web_exec_trocaLim.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_web_exec_alterSenhaEdu web_exec_alterSenhaEdu = new tst_web_exec_alterSenhaEdu( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( web_exec_alterSenhaEdu.Test() )	OkTests++; testsExec++; totalTests += web_exec_alterSenhaEdu.currentItem;
				if (web_exec_alterSenhaEdu.currentItem > 0 ) { lstResults.Items.Add ( web_exec_alterSenhaEdu.result );
				showCoverage ( web_exec_alterSenhaEdu.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_schedule_batch schedule_batch = new tst_schedule_batch( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( schedule_batch.Test() )	OkTests++; testsExec++; totalTests += schedule_batch.currentItem;
				if (schedule_batch.currentItem > 0 ) { lstResults.Items.Add ( schedule_batch.result );
				showCoverage ( schedule_batch.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_schedule_proc_batch schedule_proc_batch = new tst_schedule_proc_batch( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( schedule_proc_batch.Test() )	OkTests++; testsExec++; totalTests += schedule_proc_batch.currentItem;
				if (schedule_proc_batch.currentItem > 0 ) { lstResults.Items.Add ( schedule_proc_batch.result );
				showCoverage ( schedule_proc_batch.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_load_edu load_edu = new tst_load_edu( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( load_edu.Test() )	OkTests++; testsExec++; totalTests += load_edu.currentItem;
				if (load_edu.currentItem > 0 ) { lstResults.Items.Add ( load_edu.result );
				showCoverage ( load_edu.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_type_load type_load = new tst_type_load( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( type_load.Test() )	OkTests++; testsExec++; totalTests += type_load.currentItem;
				if (type_load.currentItem > 0 ) { lstResults.Items.Add ( type_load.result );
				showCoverage ( type_load.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_edu_habilita exec_edu_habilita = new tst_exec_edu_habilita( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_edu_habilita.Test() )	OkTests++; testsExec++; totalTests += exec_edu_habilita.currentItem;
				if (exec_edu_habilita.currentItem > 0 ) { lstResults.Items.Add ( exec_edu_habilita.result );
				showCoverage ( exec_edu_habilita.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_cartoes_grafica fetch_cartoes_grafica = new tst_fetch_cartoes_grafica( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_cartoes_grafica.Test() )	OkTests++; testsExec++; totalTests += fetch_cartoes_grafica.currentItem;
				if (fetch_cartoes_grafica.currentItem > 0 ) { lstResults.Items.Add ( fetch_cartoes_grafica.result );
				showCoverage ( fetch_cartoes_grafica.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_edu_alteraDiario exec_edu_alteraDiario = new tst_exec_edu_alteraDiario( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_edu_alteraDiario.Test() )	OkTests++; testsExec++; totalTests += exec_edu_alteraDiario.currentItem;
				if (exec_edu_alteraDiario.currentItem > 0 ) { lstResults.Items.Add ( exec_edu_alteraDiario.result );
				showCoverage ( exec_edu_alteraDiario.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_web_fetch_edu_virtual web_fetch_edu_virtual = new tst_web_fetch_edu_virtual( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( web_fetch_edu_virtual.Test() )	OkTests++; testsExec++; totalTests += web_fetch_edu_virtual.currentItem;
				if (web_fetch_edu_virtual.currentItem > 0 ) { lstResults.Items.Add ( web_fetch_edu_virtual.result );
				showCoverage ( web_fetch_edu_virtual.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_load_edu_emp_virtual load_edu_emp_virtual = new tst_load_edu_emp_virtual( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( load_edu_emp_virtual.Test() )	OkTests++; testsExec++; totalTests += load_edu_emp_virtual.currentItem;
				if (load_edu_emp_virtual.currentItem > 0 ) { lstResults.Items.Add ( load_edu_emp_virtual.result );
				showCoverage ( load_edu_emp_virtual.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_schedule_edu_fundo schedule_edu_fundo = new tst_schedule_edu_fundo( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( schedule_edu_fundo.Test() )	OkTests++; testsExec++; totalTests += schedule_edu_fundo.currentItem;
				if (schedule_edu_fundo.currentItem > 0 ) { lstResults.Items.Add ( schedule_edu_fundo.result );
				showCoverage ( schedule_edu_fundo.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_web_fetch_edu_emp_hist web_fetch_edu_emp_hist = new tst_web_fetch_edu_emp_hist( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( web_fetch_edu_emp_hist.Test() )	OkTests++; testsExec++; totalTests += web_fetch_edu_emp_hist.currentItem;
				if (web_fetch_edu_emp_hist.currentItem > 0 ) { lstResults.Items.Add ( web_fetch_edu_emp_hist.result );
				showCoverage ( web_fetch_edu_emp_hist.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_web_exec_edu_aplic_fundo web_exec_edu_aplic_fundo = new tst_web_exec_edu_aplic_fundo( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( web_exec_edu_aplic_fundo.Test() )	OkTests++; testsExec++; totalTests += web_exec_edu_aplic_fundo.currentItem;
				if (web_exec_edu_aplic_fundo.currentItem > 0 ) { lstResults.Items.Add ( web_exec_edu_aplic_fundo.result );
				showCoverage ( web_exec_edu_aplic_fundo.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_edu_cancelaCartao exec_edu_cancelaCartao = new tst_exec_edu_cancelaCartao( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_edu_cancelaCartao.Test() )	OkTests++; testsExec++; totalTests += exec_edu_cancelaCartao.currentItem;
				if (exec_edu_cancelaCartao.currentItem > 0 ) { lstResults.Items.Add ( exec_edu_cancelaCartao.result );
				showCoverage ( exec_edu_cancelaCartao.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_edu_segundaVia exec_edu_segundaVia = new tst_exec_edu_segundaVia( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_edu_segundaVia.Test() )	OkTests++; testsExec++; totalTests += exec_edu_segundaVia.currentItem;
				if (exec_edu_segundaVia.currentItem > 0 ) { lstResults.Items.Add ( exec_edu_segundaVia.result );
				showCoverage ( exec_edu_segundaVia.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_dadosAdministradora fetch_dadosAdministradora = new tst_fetch_dadosAdministradora( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_dadosAdministradora.Test() )	OkTests++; testsExec++; totalTests += fetch_dadosAdministradora.currentItem;
				if (fetch_dadosAdministradora.currentItem > 0 ) { lstResults.Items.Add ( fetch_dadosAdministradora.result );
				showCoverage ( fetch_dadosAdministradora.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_alteraAdminEmpresa exec_alteraAdminEmpresa = new tst_exec_alteraAdminEmpresa( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_alteraAdminEmpresa.Test() )	OkTests++; testsExec++; totalTests += exec_alteraAdminEmpresa.currentItem;
				if (exec_alteraAdminEmpresa.currentItem > 0 ) { lstResults.Items.Add ( exec_alteraAdminEmpresa.result );
				showCoverage ( exec_alteraAdminEmpresa.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_web_fetch_edu_ranking web_fetch_edu_ranking = new tst_web_fetch_edu_ranking( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( web_fetch_edu_ranking.Test() )	OkTests++; testsExec++; totalTests += web_fetch_edu_ranking.currentItem;
				if (web_fetch_edu_ranking.currentItem > 0 ) { lstResults.Items.Add ( web_fetch_edu_ranking.result );
				showCoverage ( web_fetch_edu_ranking.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_conf_cartao exec_conf_cartao = new tst_exec_conf_cartao( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_conf_cartao.Test() )	OkTests++; testsExec++; totalTests += exec_conf_cartao.currentItem;
				if (exec_conf_cartao.currentItem > 0 ) { lstResults.Items.Add ( exec_conf_cartao.result );
				showCoverage ( exec_conf_cartao.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_edu_nomeAluno fetch_edu_nomeAluno = new tst_fetch_edu_nomeAluno( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_edu_nomeAluno.Test() )	OkTests++; testsExec++; totalTests += fetch_edu_nomeAluno.currentItem;
				if (fetch_edu_nomeAluno.currentItem > 0 ) { lstResults.Items.Add ( fetch_edu_nomeAluno.result );
				showCoverage ( fetch_edu_nomeAluno.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_load_legado load_legado = new tst_load_legado( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( load_legado.Test() )	OkTests++; testsExec++; totalTests += load_legado.currentItem;
				if (load_legado.currentItem > 0 ) { lstResults.Items.Add ( load_legado.result );
				showCoverage ( load_legado.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_rel_5_rle fetch_rel_5_rle = new tst_fetch_rel_5_rle( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_rel_5_rle.Test() )	OkTests++; testsExec++; totalTests += fetch_rel_5_rle.currentItem;
				if (fetch_rel_5_rle.currentItem > 0 ) { lstResults.Items.Add ( fetch_rel_5_rle.result );
				showCoverage ( fetch_rel_5_rle.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_pos_desfazVendaEmpresarial exec_pos_desfazVendaEmpresarial = new tst_exec_pos_desfazVendaEmpresarial( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_pos_desfazVendaEmpresarial.Test() )	OkTests++; testsExec++; totalTests += exec_pos_desfazVendaEmpresarial.currentItem;
				if (exec_pos_desfazVendaEmpresarial.currentItem > 0 ) { lstResults.Items.Add ( exec_pos_desfazVendaEmpresarial.result );
				showCoverage ( exec_pos_desfazVendaEmpresarial.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_schedule_faturamento schedule_faturamento = new tst_schedule_faturamento( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( schedule_faturamento.Test() )	OkTests++; testsExec++; totalTests += schedule_faturamento.currentItem;
				if (schedule_faturamento.currentItem > 0 ) { lstResults.Items.Add ( schedule_faturamento.result );
				showCoverage ( schedule_faturamento.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_dadosFaturamento fetch_dadosFaturamento = new tst_fetch_dadosFaturamento( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_dadosFaturamento.Test() )	OkTests++; testsExec++; totalTests += fetch_dadosFaturamento.currentItem;
				if (fetch_dadosFaturamento.currentItem > 0 ) { lstResults.Items.Add ( fetch_dadosFaturamento.result );
				showCoverage ( fetch_dadosFaturamento.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_ins_despesa ins_despesa = new tst_ins_despesa( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( ins_despesa.Test() )	OkTests++; testsExec++; totalTests += ins_despesa.currentItem;
				if (ins_despesa.currentItem > 0 ) { lstResults.Items.Add ( ins_despesa.result );
				showCoverage ( ins_despesa.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_dadosDespesas fetch_dadosDespesas = new tst_fetch_dadosDespesas( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_dadosDespesas.Test() )	OkTests++; testsExec++; totalTests += fetch_dadosDespesas.currentItem;
				if (fetch_dadosDespesas.currentItem > 0 ) { lstResults.Items.Add ( fetch_dadosDespesas.result );
				showCoverage ( fetch_dadosDespesas.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_cancelaDespesa exec_cancelaDespesa = new tst_exec_cancelaDespesa( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_cancelaDespesa.Test() )	OkTests++; testsExec++; totalTests += exec_cancelaDespesa.currentItem;
				if (exec_cancelaDespesa.currentItem > 0 ) { lstResults.Items.Add ( exec_cancelaDespesa.result );
				showCoverage ( exec_cancelaDespesa.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_rel_6_fat fetch_rel_6_fat = new tst_fetch_rel_6_fat( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_rel_6_fat.Test() )	OkTests++; testsExec++; totalTests += fetch_rel_6_fat.currentItem;
				if (fetch_rel_6_fat.currentItem > 0 ) { lstResults.Items.Add ( fetch_rel_6_fat.result );
				showCoverage ( fetch_rel_6_fat.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_segundaVia exec_segundaVia = new tst_exec_segundaVia( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_segundaVia.Test() )	OkTests++; testsExec++; totalTests += exec_segundaVia.currentItem;
				if (exec_segundaVia.currentItem > 0 ) { lstResults.Items.Add ( exec_segundaVia.result );
				showCoverage ( exec_segundaVia.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_arquivoFat fetch_arquivoFat = new tst_fetch_arquivoFat( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_arquivoFat.Test() )	OkTests++; testsExec++; totalTests += fetch_arquivoFat.currentItem;
				if (fetch_arquivoFat.currentItem > 0 ) { lstResults.Items.Add ( fetch_arquivoFat.result );
				showCoverage ( fetch_arquivoFat.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_upload_archive upload_archive = new tst_upload_archive( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( upload_archive.Test() )	OkTests++; testsExec++; totalTests += upload_archive.currentItem;
				if (upload_archive.currentItem > 0 ) { lstResults.Items.Add ( upload_archive.result );
				showCoverage ( upload_archive.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_processaArqBancario exec_processaArqBancario = new tst_exec_processaArqBancario( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_processaArqBancario.Test() )	OkTests++; testsExec++; totalTests += exec_processaArqBancario.currentItem;
				if (exec_processaArqBancario.currentItem > 0 ) { lstResults.Items.Add ( exec_processaArqBancario.result );
				showCoverage ( exec_processaArqBancario.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_relFat fetch_relFat = new tst_fetch_relFat( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_relFat.Test() )	OkTests++; testsExec++; totalTests += fetch_relFat.currentItem;
				if (fetch_relFat.currentItem > 0 ) { lstResults.Items.Add ( fetch_relFat.result );
				showCoverage ( fetch_relFat.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_alteraProprietario exec_alteraProprietario = new tst_exec_alteraProprietario( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_alteraProprietario.Test() )	OkTests++; testsExec++; totalTests += exec_alteraProprietario.currentItem;
				if (exec_alteraProprietario.currentItem > 0 ) { lstResults.Items.Add ( exec_alteraProprietario.result );
				showCoverage ( exec_alteraProprietario.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_conveyUsuarios fetch_conveyUsuarios = new tst_fetch_conveyUsuarios( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_conveyUsuarios.Test() )	OkTests++; testsExec++; totalTests += fetch_conveyUsuarios.currentItem;
				if (fetch_conveyUsuarios.currentItem > 0 ) { lstResults.Items.Add ( fetch_conveyUsuarios.result );
				showCoverage ( fetch_conveyUsuarios.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_chamados fetch_chamados = new tst_fetch_chamados( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_chamados.Test() )	OkTests++; testsExec++; totalTests += fetch_chamados.currentItem;
				if (fetch_chamados.currentItem > 0 ) { lstResults.Items.Add ( fetch_chamados.result );
				showCoverage ( fetch_chamados.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_ins_chamado ins_chamado = new tst_ins_chamado( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( ins_chamado.Test() )	OkTests++; testsExec++; totalTests += ins_chamado.currentItem;
				if (ins_chamado.currentItem > 0 ) { lstResults.Items.Add ( ins_chamado.result );
				showCoverage ( ins_chamado.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_chamadoHist fetch_chamadoHist = new tst_fetch_chamadoHist( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_chamadoHist.Test() )	OkTests++; testsExec++; totalTests += fetch_chamadoHist.currentItem;
				if (fetch_chamadoHist.currentItem > 0 ) { lstResults.Items.Add ( fetch_chamadoHist.result );
				showCoverage ( fetch_chamadoHist.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_alteraChamado exec_alteraChamado = new tst_exec_alteraChamado( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_alteraChamado.Test() )	OkTests++; testsExec++; totalTests += exec_alteraChamado.currentItem;
				if (exec_alteraChamado.currentItem > 0 ) { lstResults.Items.Add ( exec_alteraChamado.result );
				showCoverage ( exec_alteraChamado.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_extraGift fetch_extraGift = new tst_fetch_extraGift( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_extraGift.Test() )	OkTests++; testsExec++; totalTests += fetch_extraGift.currentItem;
				if (fetch_extraGift.currentItem > 0 ) { lstResults.Items.Add ( fetch_extraGift.result );
				showCoverage ( fetch_extraGift.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_ins_extraGift ins_extraGift = new tst_ins_extraGift( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( ins_extraGift.Test() )	OkTests++; testsExec++; totalTests += ins_extraGift.currentItem;
				if (ins_extraGift.currentItem > 0 ) { lstResults.Items.Add ( ins_extraGift.result );
				showCoverage ( ins_extraGift.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_del_extraGift del_extraGift = new tst_del_extraGift( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( del_extraGift.Test() )	OkTests++; testsExec++; totalTests += del_extraGift.currentItem;
				if (del_extraGift.currentItem > 0 ) { lstResults.Items.Add ( del_extraGift.result );
				showCoverage ( del_extraGift.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_quiosque fetch_quiosque = new tst_fetch_quiosque( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_quiosque.Test() )	OkTests++; testsExec++; totalTests += fetch_quiosque.currentItem;
				if (fetch_quiosque.currentItem > 0 ) { lstResults.Items.Add ( fetch_quiosque.result );
				showCoverage ( fetch_quiosque.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_vendedorQuiosque fetch_vendedorQuiosque = new tst_fetch_vendedorQuiosque( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_vendedorQuiosque.Test() )	OkTests++; testsExec++; totalTests += fetch_vendedorQuiosque.currentItem;
				if (fetch_vendedorQuiosque.currentItem > 0 ) { lstResults.Items.Add ( fetch_vendedorQuiosque.result );
				showCoverage ( fetch_vendedorQuiosque.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_vincQuiosque exec_vincQuiosque = new tst_exec_vincQuiosque( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_vincQuiosque.Test() )	OkTests++; testsExec++; totalTests += exec_vincQuiosque.currentItem;
				if (exec_vincQuiosque.currentItem > 0 ) { lstResults.Items.Add ( exec_vincQuiosque.result );
				showCoverage ( exec_vincQuiosque.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_ins_quiosque ins_quiosque = new tst_ins_quiosque( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( ins_quiosque.Test() )	OkTests++; testsExec++; totalTests += ins_quiosque.currentItem;
				if (ins_quiosque.currentItem > 0 ) { lstResults.Items.Add ( ins_quiosque.result );
				showCoverage ( ins_quiosque.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_del_quiosque del_quiosque = new tst_del_quiosque( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( del_quiosque.Test() )	OkTests++; testsExec++; totalTests += del_quiosque.currentItem;
				if (del_quiosque.currentItem > 0 ) { lstResults.Items.Add ( del_quiosque.result );
				showCoverage ( del_quiosque.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_comprov_Gift fetch_comprov_Gift = new tst_fetch_comprov_Gift( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_comprov_Gift.Test() )	OkTests++; testsExec++; totalTests += fetch_comprov_Gift.currentItem;
				if (fetch_comprov_Gift.currentItem > 0 ) { lstResults.Items.Add ( fetch_comprov_Gift.result );
				showCoverage ( fetch_comprov_Gift.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_validGift exec_validGift = new tst_exec_validGift( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_validGift.Test() )	OkTests++; testsExec++; totalTests += exec_validGift.currentItem;
				if (exec_validGift.currentItem > 0 ) { lstResults.Items.Add ( exec_validGift.result );
				showCoverage ( exec_validGift.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_recargaGift exec_recargaGift = new tst_exec_recargaGift( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_recargaGift.Test() )	OkTests++; testsExec++; totalTests += exec_recargaGift.currentItem;
				if (exec_recargaGift.currentItem > 0 ) { lstResults.Items.Add ( exec_recargaGift.result );
				showCoverage ( exec_recargaGift.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_consultaLojasGift fetch_consultaLojasGift = new tst_fetch_consultaLojasGift( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_consultaLojasGift.Test() )	OkTests++; testsExec++; totalTests += fetch_consultaLojasGift.currentItem;
				if (fetch_consultaLojasGift.currentItem > 0 ) { lstResults.Items.Add ( fetch_consultaLojasGift.result );
				showCoverage ( fetch_consultaLojasGift.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_consultaCartaoGift fetch_consultaCartaoGift = new tst_fetch_consultaCartaoGift( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_consultaCartaoGift.Test() )	OkTests++; testsExec++; totalTests += fetch_consultaCartaoGift.currentItem;
				if (fetch_consultaCartaoGift.currentItem > 0 ) { lstResults.Items.Add ( fetch_consultaCartaoGift.result );
				showCoverage ( fetch_consultaCartaoGift.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_reciboVendaGift fetch_reciboVendaGift = new tst_fetch_reciboVendaGift( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_reciboVendaGift.Test() )	OkTests++; testsExec++; totalTests += fetch_reciboVendaGift.currentItem;
				if (fetch_reciboVendaGift.currentItem > 0 ) { lstResults.Items.Add ( fetch_reciboVendaGift.result );
				showCoverage ( fetch_reciboVendaGift.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_proprietarioGift fetch_proprietarioGift = new tst_fetch_proprietarioGift( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_proprietarioGift.Test() )	OkTests++; testsExec++; totalTests += fetch_proprietarioGift.currentItem;
				if (fetch_proprietarioGift.currentItem > 0 ) { lstResults.Items.Add ( fetch_proprietarioGift.result );
				showCoverage ( fetch_proprietarioGift.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_chequeGift fetch_chequeGift = new tst_fetch_chequeGift( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_chequeGift.Test() )	OkTests++; testsExec++; totalTests += fetch_chequeGift.currentItem;
				if (fetch_chequeGift.currentItem > 0 ) { lstResults.Items.Add ( fetch_chequeGift.result );
				showCoverage ( fetch_chequeGift.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_compensaChequeGift exec_compensaChequeGift = new tst_exec_compensaChequeGift( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_compensaChequeGift.Test() )	OkTests++; testsExec++; totalTests += exec_compensaChequeGift.currentItem;
				if (exec_compensaChequeGift.currentItem > 0 ) { lstResults.Items.Add ( exec_compensaChequeGift.result );
				showCoverage ( exec_compensaChequeGift.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_cancelaChequeGift exec_cancelaChequeGift = new tst_exec_cancelaChequeGift( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_cancelaChequeGift.Test() )	OkTests++; testsExec++; totalTests += exec_cancelaChequeGift.currentItem;
				if (exec_cancelaChequeGift.currentItem > 0 ) { lstResults.Items.Add ( exec_cancelaChequeGift.result );
				showCoverage ( exec_cancelaChequeGift.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_repasseData fetch_repasseData = new tst_fetch_repasseData( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_repasseData.Test() )	OkTests++; testsExec++; totalTests += fetch_repasseData.currentItem;
				if (fetch_repasseData.currentItem > 0 ) { lstResults.Items.Add ( fetch_repasseData.result );
				showCoverage ( fetch_repasseData.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_repasseLoja exec_repasseLoja = new tst_exec_repasseLoja( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_repasseLoja.Test() )	OkTests++; testsExec++; totalTests += exec_repasseLoja.currentItem;
				if (exec_repasseLoja.currentItem > 0 ) { lstResults.Items.Add ( exec_repasseLoja.result );
				showCoverage ( exec_repasseLoja.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_convenioLojaGift fetch_convenioLojaGift = new tst_fetch_convenioLojaGift( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_convenioLojaGift.Test() )	OkTests++; testsExec++; totalTests += fetch_convenioLojaGift.currentItem;
				if (fetch_convenioLojaGift.currentItem > 0 ) { lstResults.Items.Add ( fetch_convenioLojaGift.result );
				showCoverage ( fetch_convenioLojaGift.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_softwareVersion fetch_softwareVersion = new tst_fetch_softwareVersion( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_softwareVersion.Test() )	OkTests++; testsExec++; totalTests += fetch_softwareVersion.currentItem;
				if (fetch_softwareVersion.currentItem > 0 ) { lstResults.Items.Add ( fetch_softwareVersion.result );
				showCoverage ( fetch_softwareVersion.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_infra_fetchIncomingVersion infra_fetchIncomingVersion = new tst_infra_fetchIncomingVersion( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( infra_fetchIncomingVersion.Test() )	OkTests++; testsExec++; totalTests += infra_fetchIncomingVersion.currentItem;
				if (infra_fetchIncomingVersion.currentItem > 0 ) { lstResults.Items.Add ( infra_fetchIncomingVersion.result );
				showCoverage ( infra_fetchIncomingVersion.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_infra_fetchFile infra_fetchFile = new tst_infra_fetchFile( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( infra_fetchFile.Test() )	OkTests++; testsExec++; totalTests += infra_fetchFile.currentItem;
				if (infra_fetchFile.currentItem > 0 ) { lstResults.Items.Add ( infra_fetchFile.result );
				showCoverage ( infra_fetchFile.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_infra_fetchUpdaterVersion infra_fetchUpdaterVersion = new tst_infra_fetchUpdaterVersion( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( infra_fetchUpdaterVersion.Test() )	OkTests++; testsExec++; totalTests += infra_fetchUpdaterVersion.currentItem;
				if (infra_fetchUpdaterVersion.currentItem > 0 ) { lstResults.Items.Add ( infra_fetchUpdaterVersion.result );
				showCoverage ( infra_fetchUpdaterVersion.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_rel_repEfetivo fetch_rel_repEfetivo = new tst_fetch_rel_repEfetivo( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_rel_repEfetivo.Test() )	OkTests++; testsExec++; totalTests += fetch_rel_repEfetivo.currentItem;
				if (fetch_rel_repEfetivo.currentItem > 0 ) { lstResults.Items.Add ( fetch_rel_repEfetivo.result );
				showCoverage ( fetch_rel_repEfetivo.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_consultaLojista fetch_consultaLojista = new tst_fetch_consultaLojista( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_consultaLojista.Test() )	OkTests++; testsExec++; totalTests += fetch_consultaLojista.currentItem;
				if (fetch_consultaLojista.currentItem > 0 ) { lstResults.Items.Add ( fetch_consultaLojista.result );
				showCoverage ( fetch_consultaLojista.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_rel_fechCaixa fetch_rel_fechCaixa = new tst_fetch_rel_fechCaixa( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_rel_fechCaixa.Test() )	OkTests++; testsExec++; totalTests += fetch_rel_fechCaixa.currentItem;
				if (fetch_rel_fechCaixa.currentItem > 0 ) { lstResults.Items.Add ( fetch_rel_fechCaixa.result );
				showCoverage ( fetch_rel_fechCaixa.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_ins_dependente ins_dependente = new tst_ins_dependente( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( ins_dependente.Test() )	OkTests++; testsExec++; totalTests += ins_dependente.currentItem;
				if (ins_dependente.currentItem > 0 ) { lstResults.Items.Add ( ins_dependente.result );
				showCoverage ( ins_dependente.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_rel_dirCont fetch_rel_dirCont = new tst_fetch_rel_dirCont( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_rel_dirCont.Test() )	OkTests++; testsExec++; totalTests += fetch_rel_dirCont.currentItem;
				if (fetch_rel_dirCont.currentItem > 0 ) { lstResults.Items.Add ( fetch_rel_dirCont.result );
				showCoverage ( fetch_rel_dirCont.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_codLoja fetch_codLoja = new tst_fetch_codLoja( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_codLoja.Test() )	OkTests++; testsExec++; totalTests += fetch_codLoja.currentItem;
				if (fetch_codLoja.currentItem > 0 ) { lstResults.Items.Add ( fetch_codLoja.result );
				showCoverage ( fetch_codLoja.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_reciboRepasse fetch_reciboRepasse = new tst_fetch_reciboRepasse( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_reciboRepasse.Test() )	OkTests++; testsExec++; totalTests += fetch_reciboRepasse.currentItem;
				if (fetch_reciboRepasse.currentItem > 0 ) { lstResults.Items.Add ( fetch_reciboRepasse.result );
				showCoverage ( fetch_reciboRepasse.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_resolvePend exec_resolvePend = new tst_exec_resolvePend( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_resolvePend.Test() )	OkTests++; testsExec++; totalTests += exec_resolvePend.currentItem;
				if (exec_resolvePend.currentItem > 0 ) { lstResults.Items.Add ( exec_resolvePend.result );
				showCoverage ( exec_resolvePend.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_empresasAfiliadas fetch_empresasAfiliadas = new tst_fetch_empresasAfiliadas( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_empresasAfiliadas.Test() )	OkTests++; testsExec++; totalTests += fetch_empresasAfiliadas.currentItem;
				if (fetch_empresasAfiliadas.currentItem > 0 ) { lstResults.Items.Add ( fetch_empresasAfiliadas.result );
				showCoverage ( fetch_empresasAfiliadas.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_pos_buscaCartao exec_pos_buscaCartao = new tst_exec_pos_buscaCartao( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_pos_buscaCartao.Test() )	OkTests++; testsExec++; totalTests += exec_pos_buscaCartao.currentItem;
				if (exec_pos_buscaCartao.currentItem > 0 ) { lstResults.Items.Add ( exec_pos_buscaCartao.result );
				showCoverage ( exec_pos_buscaCartao.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_fat_recManual exec_fat_recManual = new tst_exec_fat_recManual( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_fat_recManual.Test() )	OkTests++; testsExec++; totalTests += exec_fat_recManual.currentItem;
				if (exec_fat_recManual.currentItem > 0 ) { lstResults.Items.Add ( exec_fat_recManual.result );
				showCoverage ( exec_fat_recManual.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_empresasGrafica fetch_empresasGrafica = new tst_fetch_empresasGrafica( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_empresasGrafica.Test() )	OkTests++; testsExec++; totalTests += fetch_empresasGrafica.currentItem;
				if (fetch_empresasGrafica.currentItem > 0 ) { lstResults.Items.Add ( fetch_empresasGrafica.result );
				showCoverage ( fetch_empresasGrafica.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_bloq_loja exec_bloq_loja = new tst_exec_bloq_loja( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_bloq_loja.Test() )	OkTests++; testsExec++; totalTests += exec_bloq_loja.currentItem;
				if (exec_bloq_loja.currentItem > 0 ) { lstResults.Items.Add ( exec_bloq_loja.result );
				showCoverage ( exec_bloq_loja.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_desbloq_loja exec_desbloq_loja = new tst_exec_desbloq_loja( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_desbloq_loja.Test() )	OkTests++; testsExec++; totalTests += exec_desbloq_loja.currentItem;
				if (exec_desbloq_loja.currentItem > 0 ) { lstResults.Items.Add ( exec_desbloq_loja.result );
				showCoverage ( exec_desbloq_loja.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_cancel_Loja exec_cancel_Loja = new tst_exec_cancel_Loja( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_cancel_Loja.Test() )	OkTests++; testsExec++; totalTests += exec_cancel_Loja.currentItem;
				if (exec_cancel_Loja.currentItem > 0 ) { lstResults.Items.Add ( exec_cancel_Loja.result );
				showCoverage ( exec_cancel_Loja.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_web_exec_confirmaBoleto web_exec_confirmaBoleto = new tst_web_exec_confirmaBoleto( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( web_exec_confirmaBoleto.Test() )	OkTests++; testsExec++; totalTests += web_exec_confirmaBoleto.currentItem;
				if (web_exec_confirmaBoleto.currentItem > 0 ) { lstResults.Items.Add ( web_exec_confirmaBoleto.result );
				showCoverage ( web_exec_confirmaBoleto.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_user_lojista fetch_user_lojista = new tst_fetch_user_lojista( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_user_lojista.Test() )	OkTests++; testsExec++; totalTests += fetch_user_lojista.currentItem;
				if (fetch_user_lojista.currentItem > 0 ) { lstResults.Items.Add ( fetch_user_lojista.result );
				showCoverage ( fetch_user_lojista.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_vincula_lojista exec_vincula_lojista = new tst_exec_vincula_lojista( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_vincula_lojista.Test() )	OkTests++; testsExec++; totalTests += exec_vincula_lojista.currentItem;
				if (exec_vincula_lojista.currentItem > 0 ) { lstResults.Items.Add ( exec_vincula_lojista.result );
				showCoverage ( exec_vincula_lojista.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_reciboVendaLojista fetch_reciboVendaLojista = new tst_fetch_reciboVendaLojista( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_reciboVendaLojista.Test() )	OkTests++; testsExec++; totalTests += fetch_reciboVendaLojista.currentItem;
				if (fetch_reciboVendaLojista.currentItem > 0 ) { lstResults.Items.Add ( fetch_reciboVendaLojista.result );
				showCoverage ( fetch_reciboVendaLojista.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_lojistaEmpresas fetch_lojistaEmpresas = new tst_fetch_lojistaEmpresas( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_lojistaEmpresas.Test() )	OkTests++; testsExec++; totalTests += fetch_lojistaEmpresas.currentItem;
				if (fetch_lojistaEmpresas.currentItem > 0 ) { lstResults.Items.Add ( fetch_lojistaEmpresas.result );
				showCoverage ( fetch_lojistaEmpresas.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_rel_prevLojista fetch_rel_prevLojista = new tst_fetch_rel_prevLojista( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_rel_prevLojista.Test() )	OkTests++; testsExec++; totalTests += fetch_rel_prevLojista.currentItem;
				if (fetch_rel_prevLojista.currentItem > 0 ) { lstResults.Items.Add ( fetch_rel_prevLojista.result );
				showCoverage ( fetch_rel_prevLojista.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_rel_tarifas fetch_rel_tarifas = new tst_fetch_rel_tarifas( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_rel_tarifas.Test() )	OkTests++; testsExec++; totalTests += fetch_rel_tarifas.currentItem;
				if (fetch_rel_tarifas.currentItem > 0 ) { lstResults.Items.Add ( fetch_rel_tarifas.result );
				showCoverage ( fetch_rel_tarifas.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_graph_financeiro graph_financeiro = new tst_graph_financeiro( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( graph_financeiro.Test() )	OkTests++; testsExec++; totalTests += graph_financeiro.currentItem;
				if (graph_financeiro.currentItem > 0 ) { lstResults.Items.Add ( graph_financeiro.result );
				showCoverage ( graph_financeiro.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_listaTransacoesLojas fetch_listaTransacoesLojas = new tst_fetch_listaTransacoesLojas( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_listaTransacoesLojas.Test() )	OkTests++; testsExec++; totalTests += fetch_listaTransacoesLojas.currentItem;
				if (fetch_listaTransacoesLojas.currentItem > 0 ) { lstResults.Items.Add ( fetch_listaTransacoesLojas.result );
				showCoverage ( fetch_listaTransacoesLojas.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_graph_transacoes graph_transacoes = new tst_graph_transacoes( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( graph_transacoes.Test() )	OkTests++; testsExec++; totalTests += graph_transacoes.currentItem;
				if (graph_transacoes.currentItem > 0 ) { lstResults.Items.Add ( graph_transacoes.result );
				showCoverage ( graph_transacoes.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_pf_graficoGerencial exec_pf_graficoGerencial = new tst_exec_pf_graficoGerencial( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_pf_graficoGerencial.Test() )	OkTests++; testsExec++; totalTests += exec_pf_graficoGerencial.currentItem;
				if (exec_pf_graficoGerencial.currentItem > 0 ) { lstResults.Items.Add ( exec_pf_graficoGerencial.result );
				showCoverage ( exec_pf_graficoGerencial.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_processaArqConvenio exec_processaArqConvenio = new tst_exec_processaArqConvenio( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_processaArqConvenio.Test() )	OkTests++; testsExec++; totalTests += exec_processaArqConvenio.currentItem;
				if (exec_processaArqConvenio.currentItem > 0 ) { lstResults.Items.Add ( exec_processaArqConvenio.result );
				showCoverage ( exec_processaArqConvenio.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_consultaLojistaRep fetch_consultaLojistaRep = new tst_fetch_consultaLojistaRep( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_consultaLojistaRep.Test() )	OkTests++; testsExec++; totalTests += fetch_consultaLojistaRep.currentItem;
				if (fetch_consultaLojistaRep.currentItem > 0 ) { lstResults.Items.Add ( fetch_consultaLojistaRep.result );
				showCoverage ( fetch_consultaLojistaRep.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_loginLojista exec_loginLojista = new tst_exec_loginLojista( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_loginLojista.Test() )	OkTests++; testsExec++; totalTests += exec_loginLojista.currentItem;
				if (exec_loginLojista.currentItem > 0 ) { lstResults.Items.Add ( exec_loginLojista.result );
				showCoverage ( exec_loginLojista.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_listawebConveniosLoja fetch_listawebConveniosLoja = new tst_fetch_listawebConveniosLoja( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_listawebConveniosLoja.Test() )	OkTests++; testsExec++; totalTests += fetch_listawebConveniosLoja.currentItem;
				if (fetch_listawebConveniosLoja.currentItem > 0 ) { lstResults.Items.Add ( fetch_listawebConveniosLoja.result );
				showCoverage ( fetch_listawebConveniosLoja.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_loginWeb exec_loginWeb = new tst_exec_loginWeb( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_loginWeb.Test() )	OkTests++; testsExec++; totalTests += exec_loginWeb.currentItem;
				if (exec_loginWeb.currentItem > 0 ) { lstResults.Items.Add ( exec_loginWeb.result );
				showCoverage ( exec_loginWeb.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_extratoWeb fetch_extratoWeb = new tst_fetch_extratoWeb( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_extratoWeb.Test() )	OkTests++; testsExec++; totalTests += fetch_extratoWeb.currentItem;
				if (fetch_extratoWeb.currentItem > 0 ) { lstResults.Items.Add ( fetch_extratoWeb.result );
				showCoverage ( fetch_extratoWeb.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_edu_messages fetch_edu_messages = new tst_fetch_edu_messages( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_edu_messages.Test() )	OkTests++; testsExec++; totalTests += fetch_edu_messages.currentItem;
				if (fetch_edu_messages.currentItem > 0 ) { lstResults.Items.Add ( fetch_edu_messages.result );
				showCoverage ( fetch_edu_messages.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_ins_edu_msg ins_edu_msg = new tst_ins_edu_msg( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( ins_edu_msg.Test() )	OkTests++; testsExec++; totalTests += ins_edu_msg.currentItem;
				if (ins_edu_msg.currentItem > 0 ) { lstResults.Items.Add ( ins_edu_msg.result );
				showCoverage ( ins_edu_msg.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_del_edu_msg del_edu_msg = new tst_del_edu_msg( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( del_edu_msg.Test() )	OkTests++; testsExec++; totalTests += del_edu_msg.currentItem;
				if (del_edu_msg.currentItem > 0 ) { lstResults.Items.Add ( del_edu_msg.result );
				showCoverage ( del_edu_msg.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_change_edu_msg exec_change_edu_msg = new tst_exec_change_edu_msg( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_change_edu_msg.Test() )	OkTests++; testsExec++; totalTests += exec_change_edu_msg.currentItem;
				if (exec_change_edu_msg.currentItem > 0 ) { lstResults.Items.Add ( exec_change_edu_msg.result );
				showCoverage ( exec_change_edu_msg.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_rel_residuo_gift fetch_rel_residuo_gift = new tst_fetch_rel_residuo_gift( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_rel_residuo_gift.Test() )	OkTests++; testsExec++; totalTests += fetch_rel_residuo_gift.currentItem;
				if (fetch_rel_residuo_gift.currentItem > 0 ) { lstResults.Items.Add ( fetch_rel_residuo_gift.result );
				showCoverage ( fetch_rel_residuo_gift.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_extratoWebFuturo fetch_extratoWebFuturo = new tst_fetch_extratoWebFuturo( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_extratoWebFuturo.Test() )	OkTests++; testsExec++; totalTests += fetch_extratoWebFuturo.currentItem;
				if (fetch_extratoWebFuturo.currentItem > 0 ) { lstResults.Items.Add ( fetch_extratoWebFuturo.result );
				showCoverage ( fetch_extratoWebFuturo.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_venda_pend_lojista exec_venda_pend_lojista = new tst_exec_venda_pend_lojista( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_venda_pend_lojista.Test() )	OkTests++; testsExec++; totalTests += exec_venda_pend_lojista.currentItem;
				if (exec_venda_pend_lojista.currentItem > 0 ) { lstResults.Items.Add ( exec_venda_pend_lojista.result );
				showCoverage ( exec_venda_pend_lojista.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_canc_dia_lojista fetch_canc_dia_lojista = new tst_fetch_canc_dia_lojista( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_canc_dia_lojista.Test() )	OkTests++; testsExec++; totalTests += fetch_canc_dia_lojista.currentItem;
				if (fetch_canc_dia_lojista.currentItem > 0 ) { lstResults.Items.Add ( fetch_canc_dia_lojista.result );
				showCoverage ( fetch_canc_dia_lojista.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_financ_lojista fetch_financ_lojista = new tst_fetch_financ_lojista( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_financ_lojista.Test() )	OkTests++; testsExec++; totalTests += fetch_financ_lojista.currentItem;
				if (fetch_financ_lojista.currentItem > 0 ) { lstResults.Items.Add ( fetch_financ_lojista.result );
				showCoverage ( fetch_financ_lojista.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_listaFiliais fetch_listaFiliais = new tst_fetch_listaFiliais( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_listaFiliais.Test() )	OkTests++; testsExec++; totalTests += fetch_listaFiliais.currentItem;
				if (fetch_listaFiliais.currentItem > 0 ) { lstResults.Items.Add ( fetch_listaFiliais.result );
				showCoverage ( fetch_listaFiliais.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_rel_edu_movEscola fetch_rel_edu_movEscola = new tst_fetch_rel_edu_movEscola( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_rel_edu_movEscola.Test() )	OkTests++; testsExec++; totalTests += fetch_rel_edu_movEscola.currentItem;
				if (fetch_rel_edu_movEscola.currentItem > 0 ) { lstResults.Items.Add ( fetch_rel_edu_movEscola.result );
				showCoverage ( fetch_rel_edu_movEscola.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_rel_edu_movRedeEscola fetch_rel_edu_movRedeEscola = new tst_fetch_rel_edu_movRedeEscola( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_rel_edu_movRedeEscola.Test() )	OkTests++; testsExec++; totalTests += fetch_rel_edu_movRedeEscola.currentItem;
				if (fetch_rel_edu_movRedeEscola.currentItem > 0 ) { lstResults.Items.Add ( fetch_rel_edu_movRedeEscola.result );
				showCoverage ( fetch_rel_edu_movRedeEscola.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_bloq_empresa exec_bloq_empresa = new tst_exec_bloq_empresa( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_bloq_empresa.Test() )	OkTests++; testsExec++; totalTests += exec_bloq_empresa.currentItem;
				if (exec_bloq_empresa.currentItem > 0 ) { lstResults.Items.Add ( exec_bloq_empresa.result );
				showCoverage ( exec_bloq_empresa.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_desbloq_empresa exec_desbloq_empresa = new tst_exec_desbloq_empresa( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_desbloq_empresa.Test() )	OkTests++; testsExec++; totalTests += exec_desbloq_empresa.currentItem;
				if (exec_desbloq_empresa.currentItem > 0 ) { lstResults.Items.Add ( exec_desbloq_empresa.result );
				showCoverage ( exec_desbloq_empresa.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_cotaExtra_carts fetch_cotaExtra_carts = new tst_fetch_cotaExtra_carts( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_cotaExtra_carts.Test() )	OkTests++; testsExec++; totalTests += fetch_cotaExtra_carts.currentItem;
				if (fetch_cotaExtra_carts.currentItem > 0 ) { lstResults.Items.Add ( fetch_cotaExtra_carts.result );
				showCoverage ( fetch_cotaExtra_carts.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_cotaExtraEmpresa exec_cotaExtraEmpresa = new tst_exec_cotaExtraEmpresa( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_cotaExtraEmpresa.Test() )	OkTests++; testsExec++; totalTests += exec_cotaExtraEmpresa.currentItem;
				if (exec_cotaExtraEmpresa.currentItem > 0 ) { lstResults.Items.Add ( exec_cotaExtraEmpresa.result );
				showCoverage ( exec_cotaExtraEmpresa.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_rel_listaCarts fetch_rel_listaCarts = new tst_fetch_rel_listaCarts( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_rel_listaCarts.Test() )	OkTests++; testsExec++; totalTests += fetch_rel_listaCarts.currentItem;
				if (fetch_rel_listaCarts.currentItem > 0 ) { lstResults.Items.Add ( fetch_rel_listaCarts.result );
				showCoverage ( fetch_rel_listaCarts.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_fetch_rel_listaLojas fetch_rel_listaLojas = new tst_fetch_rel_listaLojas( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( fetch_rel_listaLojas.Test() )	OkTests++; testsExec++; totalTests += fetch_rel_listaLojas.currentItem;
				if (fetch_rel_listaLojas.currentItem > 0 ) { lstResults.Items.Add ( fetch_rel_listaLojas.result );
				showCoverage ( fetch_rel_listaLojas.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			{
				tst_exec_excluiCart exec_excluiCart = new tst_exec_excluiCart( ref m_Log, ref m_Comm, ref m_access, session, demand );
				if ( exec_excluiCart.Test() )	OkTests++; testsExec++; totalTests += exec_excluiCart.currentItem;
				if (exec_excluiCart.currentItem > 0 ) { lstResults.Items.Add ( exec_excluiCart.result );
				showCoverage ( exec_excluiCart.transaction , ref lstResults ); } 
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				Application.DoEvents();
			}
			
			m_totalTests = totalTests;
			m_totalTestsFailed = testsExec - OkTests;
			
			
			lstResults.Items.Add ("");
			lstResults.Items.Add (" ------------------------------------- ");
			lstResults.Items.Add (" Test done.");
			lstResults.Items.Add ("");
			
				lstResults.SelectedIndex = lstResults.Items.Count-1;
				lstResults.SelectedIndex = -1;
			
			m_Log.Close();
			m_log_file.Close();
			m_cpu.StopMonit();
			
		}
	}
	#endif
}
