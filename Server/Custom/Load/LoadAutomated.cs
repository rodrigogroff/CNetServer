using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections;
using System.Windows.Forms;

namespace SyCrafEngine
{
	#if LOAD
	public class LoadAutomated 
	{
		public LoadAutomated ( string connString, ref ListViewItem lstResults, int pos, string transact )
		{
			LockArea 		m_lockArea = new LockArea();
			CPU_Monitor     m_cpu = new CPU_Monitor();
			DB_Access 		m_access   = new DB_Access ( connString, ref m_lockArea, ref m_cpu );
			
			string path = "Log" + pos.ToString() + ".txt";
			
			FileStream 		m_log_file;
			
			if (File.Exists(path)) 
				m_log_file = new FileStream ( path, FileMode.Truncate, FileAccess.Write);
			else
				m_log_file = new FileStream ( path, FileMode.Create, FileAccess.Write);
			
			StreamWriter 	m_Log 	   = new StreamWriter ( m_log_file );
			Communication 	m_Comm     = new Communication();
			
			string session = "session";
			
			DateTime  work_time = new DateTime();
			double lowest  		= 0;
			double percent 		= (double) 100 / 42;
			double percent_done = 0;
			double tim_result   = 0;
			
			{
				Thread.Sleep(1);
				tst_type_base type_base = new tst_type_base( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				type_base.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_cadastros fetch_cadastros = new tst_fetch_cadastros( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_cadastros.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_ins_cartaoProprietario ins_cartaoProprietario = new tst_ins_cartaoProprietario( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				ins_cartaoProprietario.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_proprietario fetch_proprietario = new tst_fetch_proprietario( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_proprietario.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_exec_login exec_login = new tst_exec_login( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				exec_login.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_exec_logoff exec_logoff = new tst_exec_logoff( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				exec_logoff.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_exec_trocaSenha exec_trocaSenha = new tst_exec_trocaSenha( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				exec_trocaSenha.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_ins_usuario ins_usuario = new tst_ins_usuario( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				ins_usuario.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_listaUsuarios fetch_listaUsuarios = new tst_fetch_listaUsuarios( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_listaUsuarios.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_usuarios fetch_usuarios = new tst_fetch_usuarios( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_usuarios.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_exec_alteraUsuario exec_alteraUsuario = new tst_exec_alteraUsuario( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				exec_alteraUsuario.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_ins_empresa ins_empresa = new tst_ins_empresa( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				ins_empresa.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_ins_loja ins_loja = new tst_ins_loja( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				ins_loja.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_dadosEmpresa fetch_dadosEmpresa = new tst_fetch_dadosEmpresa( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_dadosEmpresa.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_dadosLoja fetch_dadosLoja = new tst_fetch_dadosLoja( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_dadosLoja.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_exec_loginWeb exec_loginWeb = new tst_exec_loginWeb( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				exec_loginWeb.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_codEmpresa fetch_codEmpresa = new tst_fetch_codEmpresa( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_codEmpresa.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_exec_alteraEmpresa exec_alteraEmpresa = new tst_exec_alteraEmpresa( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				exec_alteraEmpresa.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_exec_alteraLoja exec_alteraLoja = new tst_exec_alteraLoja( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				exec_alteraLoja.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_codTerminal fetch_codTerminal = new tst_fetch_codTerminal( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_codTerminal.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_nomeEmpresa fetch_nomeEmpresa = new tst_fetch_nomeEmpresa( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_nomeEmpresa.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_validaEmpresa fetch_validaEmpresa = new tst_fetch_validaEmpresa( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_validaEmpresa.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_ins_terminal ins_terminal = new tst_ins_terminal( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				ins_terminal.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_terminais fetch_terminais = new tst_fetch_terminais( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_terminais.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_listaTerminais fetch_listaTerminais = new tst_fetch_listaTerminais( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_listaTerminais.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_codLoja fetch_codLoja = new tst_fetch_codLoja( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_codLoja.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_listaEmpresas fetch_listaEmpresas = new tst_fetch_listaEmpresas( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_listaEmpresas.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_terminalLoja fetch_terminalLoja = new tst_fetch_terminalLoja( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_terminalLoja.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_del_Terminal del_Terminal = new tst_del_Terminal( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				del_Terminal.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_consultaLoja fetch_consultaLoja = new tst_fetch_consultaLoja( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_consultaLoja.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_listaLoja fetch_listaLoja = new tst_fetch_listaLoja( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_listaLoja.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_consultaEmpresa fetch_consultaEmpresa = new tst_fetch_consultaEmpresa( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_consultaEmpresa.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_consultaAuditoria fetch_consultaAuditoria = new tst_fetch_consultaAuditoria( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_consultaAuditoria.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_listaAuditoria fetch_listaAuditoria = new tst_fetch_listaAuditoria( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_listaAuditoria.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_exec_alteraTerminal exec_alteraTerminal = new tst_exec_alteraTerminal( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				exec_alteraTerminal.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_limitesCartao fetch_limitesCartao = new tst_fetch_limitesCartao( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_limitesCartao.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_listaCartoes fetch_listaCartoes = new tst_fetch_listaCartoes( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_listaCartoes.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_exec_alteraCartao exec_alteraCartao = new tst_exec_alteraCartao( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				exec_alteraCartao.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_fetch_consultaCartao fetch_consultaCartao = new tst_fetch_consultaCartao( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				fetch_consultaCartao.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_infra_SchedulerDispatcher infra_SchedulerDispatcher = new tst_infra_SchedulerDispatcher( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				infra_SchedulerDispatcher.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_schedule_tst schedule_tst = new tst_schedule_tst( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				schedule_tst.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			{
				Thread.Sleep(1);
				tst_schedule_base schedule_base = new tst_schedule_base( ref m_Log, ref m_Comm, ref m_access, session, transact );
				work_time = DateTime.Now;
				schedule_base.Test();
				tim_result = -work_time.Subtract ( DateTime.Now ).TotalMilliseconds;
				if ( tim_result > lowest )	lowest = tim_result;
				percent_done += percent;
				lstResults.Tag = lowest;
				lstResults.SubItems[1].Text = String.Format( "{0:n}", percent_done ) + " %";
				lstResults.SubItems[2].Text = String.Format( "{0:n}", lowest       );
				Application.DoEvents();
			}
			
			
			m_Log.Flush();
			m_Log.Close();
			m_log_file.Close();
			m_cpu.StopMonit();
			
		}
	}
	#endif
}
