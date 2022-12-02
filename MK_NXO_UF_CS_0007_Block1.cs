using System;
using System.IO;
using NXOpen;
using NXOpen.UF;



namespace ClassLibrary1_nxo_cs_uf_block1
{
    public class Block1
    {
        public static UFSession theUfSession;
        private static Session theSession;

        public int Execute()
        {
            double[] corner_pt = { 0.0, 0.0, 0.0 };
            string[] edge_len = { "200","300","400"};
            Tag blk_obj_id;

            theUfSession.Modl.CreateBlock1(FeatureSigns.Nullsign, corner_pt, edge_len,
                out blk_obj_id);

            return 0;
        }

        public static void Main(string[] args)
        {
            theSession = Session.GetSession();
            theUfSession = UFSession.GetUFSession();


            Block1 block1 = new Block1();
            block1.Execute();  


        }

        public static int GetUnloadOption(string dummy)
        {
            return UFConstants.UF_UNLOAD_IMMEDIATELY;
        }
    }

}
