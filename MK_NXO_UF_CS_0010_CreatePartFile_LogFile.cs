using System;
using System.IO;
using NXOpen;
using NXOpen.UF;



namespace ClassLibrary_nxo_uf_cs_new_file
{
    public class EX_Modl_Create
    {
        private static FileStream fs;
        private static StreamWriter w;

        public static UFSession theUfSession;
        private static Session theSession;

        public int Execute()
        {

            string part_name = "EX_Modl_Create";
            string name;

            int units = 2;
            Tag UFPart;

            theUfSession.Part.New(part_name, units, out UFPart);
            theUfSession.Part.AskPartName(UFPart, out name);
           


            theUfSession.Part.Save();
            w.WriteLine("Created and Saved: " + name);
            
            return 0;
        }


        public static void Main(string[] args)
        {
            theSession = Session.GetSession();
            theUfSession = UFSession.GetUFSession();

            

            fs = new FileStream("EX_Modl_Create.log", FileMode.Create, FileAccess.Write);
            w = new StreamWriter(fs); // create a stream writer 
            w.Write("Log Entry : \r\n");
            w.WriteLine("--Log entry goes here--");
            w.Flush(); // update underlying file


            EX_Modl_Create createPart = new EX_Modl_Create();
            createPart.Execute();


            w.WriteLine("End of Log File");
            w.Close();


        }

        public static int GetUnloadOption(string dummy)
        {
            return UFConstants.UF_UNLOAD_IMMEDIATELY;
        }



        

    }
}
