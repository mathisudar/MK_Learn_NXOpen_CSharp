using System;
using System.IO;
using NXOpen;
using NXOpen.UF;

namespace ClassLibrary1_nxo_cs_cylinder1
{
    public class Cylinder1
    {
        public static UFSession theUfSession;
        private static Session theSession;

        public int Execute()
        {
            double[] origin = { 0.0, 0.0, 0.0 };
            string height = "400.0";
            string diam = "20.0";
            double[] direction = { 0.0, 0.0, 1.0 };
            Tag cyl_obj_id;

            theUfSession.Modl.CreateCyl1(FeatureSigns.Nullsign, origin, height, diam,
            direction, out cyl_obj_id);

            return 0;
        }

        public static void Main(string[] args)
        {
            theSession = Session.GetSession();
            theUfSession = UFSession.GetUFSession();

            Cylinder1 createCylinder1 = new Cylinder1();
            createCylinder1.Execute();

        }

        public static int GetUnloadOption(string dummy)
        {
            return UFConstants.UF_UNLOAD_IMMEDIATELY;
        }

    }
}
