using SyCrafEngine;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var trans = new Transaction();

            
            
            var IsTerm = false;
            string stResp = "", Msg= "";

            /*
            Translator tr = new Translator();
            IServAppHandle app_handle = new IServAppHandle("C:\\teste", ref tr);

            app_handle.m_connectionString = IServAppHandle.getConnString(@"WIN-VC8RCO6KBEK\SQLEXPRESS",
                                                                                 InfraSoftwareServer.db_schema,
                                                                                 "sa",
                                                                                 "zxcv1092@",
                                                                                 2000,
                                                                                 2001);
                                                                                 */

            /*
             * ======================================================== 
            Registro Iso : codigo       =0200
            Bits preenchidos :          =1,3,4,7,11,12,13,22,35,41,42,52,62
            bit( 3  ) - Codigo Proc.    =002800
            bit( 4  ) - valor           =000000018859
            bit( 7  ) - datahora        =0104103819
            bit( 11 ) - NSU Origem      =040955
            bit( 13 ) - data            =0104
            bit( 22 ) - modo captura    =011
            bit( 35 ) - trilha          =826766001401000998011651018          
            bit( 37 ) - nsu alternativo =
            bit( 39 ) - codResposta     =00
            bit( 41 ) - terminal        =00000005
            bit( 42 ) - codigoLoja      =000000000006319
            bit( 49 ) - codigo moeda    =
            bit( 52 ) - Senha           =B1E7A88A545880F7
            bit( 62 ) - Dados transacao =06000000006287000000006286000000006286000000006286000000006286000000006286
            bit( 63 ) - Dados transacao =
            bit( 64 ) - Dados transacao =
            bit( 90 ) - dados original  =
            bit( 125 )- NSU original    =
            bit( 127 )- NSU             =
            ======================================================== 

                        05CECE00006324826766001401000998011651018B1E7A88A545880F700000001885906000000003144000000003143000000003143000000003143000000003143000000003143

            */

            Msg = "05CECE10006319826766001401000998011651018B1E7A88A545880F700000001885906000000003144000000003143000000003143000000003143000000003143000000003143";
            
            Msg = Msg.PadRight(200, '*');
            Msg += "00000005"; // terminal
            Msg += "040955"; // nsuOrigem

            exec_pos_vendaEmpresarialSITEF srv = new exec_pos_vendaEmpresarialSITEF();
        }
    }
}
