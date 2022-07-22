using System;
using System.IO;
using NXOpen;
using NXOpen.UF;

namespace NetExample
{
    public class EX_Curve_CreateArc
    {
        private static UFSession theUfSession;
        private static Session theSession;
        
        public static Session s = Session.GetSession();
        public static ListingWindow lw = s.ListingWindow;

        //  Dim lw As ListingWindow = theSession.ListingWindow




        public static int Execute()
        {



            Tag arc_id, wcs_tag;
            double[] box = new double[6];
            const double PI = 3.14;


            // Ref C ---> UF_CURVE_arc_t arc_coords;
            UFCurve.Arc arc_coords = new UFCurve.Arc();

            /* Fill out the data structure */
            arc_coords.start_angle = 0.0;
            arc_coords.end_angle = 270.0 * (PI / 180.0);

            arc_coords.arc_center = new double[3];
            arc_coords.arc_center[0] = 0.0;
            arc_coords.arc_center[1] = 0.0;
            arc_coords.arc_center[2] = 0.0;

            arc_coords.radius = 200.0;

            // Ref C ---> UF_CSYS_ask_wcs(&wcs_tag);
            // Ref C ---> UF_CSYS_ask_matrix_of_object(wcs_tag, &arc_coords.matrix_tag);

            theUfSession.Csys.AskWcs(out wcs_tag);
            theUfSession.Csys.AskMatrixOfObject(wcs_tag, out arc_coords.matrix_tag);

            /* Create arc */

            // Ref C ---> UF_CURVE_create_arc(&arc_coords, &arc_id);

            theUfSession.Curve.CreateArc(ref arc_coords, out arc_id);


            /* Ask bounding box of arc */

            // Ref C ---> UF_MODL_ask_bounding_box(arc_id, box);

            theUfSession.Modl.AskBoundingBox(arc_id, box);

            /* Print bounding box values */

            // Ref C ---> printf("\nMinimum x value: %f\n", box[0]);

            /* lw.Open();
             
             */

            lw.Open();
            lw.WriteLine("\nMinimum x value:" + box[0]);
            lw.WriteLine("\nMaximum x value:" + box[3]);
            lw.WriteLine("\nMinimum y value:" + box[1]);
            lw.WriteLine("\nMaximum y value:" + box[4]);
            lw.WriteLine("\nMinimum z value:" + box[2]);
            lw.WriteLine("\nMaximum z value:" + box[5]);
            lw.Close();

            return 0;
        }

        public static void Main(string[] args)
        {
            theSession = Session.GetSession();
            theUfSession = UFSession.GetUFSession();
            Execute();

        }
        public static int GetUnloadOption(string dummy)
        {
            return UFConstants.UF_UNLOAD_IMMEDIATELY;
        }

    }
}


