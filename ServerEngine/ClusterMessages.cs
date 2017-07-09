// Decompiled with JetBrains decompiler
// Type: SyCrafEngine.ClusterMessages
// Assembly: ServerEngine, Version=1.0.3507.20044, Culture=neutral, PublicKeyToken=null
// MVID: EC7EDE91-ACD5-4AC9-965B-15794E796DFE
// Assembly location: C:\Users\Administrator\Source\Repos\CNETServer\Server\bin\Debug\ServerEngine.dll

namespace SyCrafEngine
{
  public class ClusterMessages
  {
    public const string command_join = "JOINCLUSTER";
    public const string command_quit = "QUITCLUSTER";
    public const string command_stat = "STATNODE";
    public const string msg_diff_version = "ERROR_NODE_DIFF_VERSION_TRANSACTIONS";
    public const string msg_diff_engine = "ERROR_NODE_DIFF_VERSION_ENGINE";
    public const string msg_diff_database = "ERROR_DIFF_DATABASE";
    public const string msg_diff_database_schema = "ERROR_DIFF_DATABASE_SCHEMA";
    public const string msg_incomp_address = "ERROR_ADDRESS_INCOMPLETE";
    public const string success_join_accepted = "SUCCESS_JOIN_ACCEPTED";
    public const string error_join_request = "ERROR_JOIN_REQUEST";
    public const string success_quit_accepted = "SUCCESS_QUIT_ACCEPTED";
    public const string error_quit_request = "ERROR_QUIT_REQUEST";
    public const string success_stat_accepted = "SUCCESS_STAT_ACCEPTED";
    public const string error_stat_request = "ERROR_STAT_REQUEST";
  }
}
