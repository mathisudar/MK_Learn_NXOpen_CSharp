using System;
using System.IO;
using NXOpen;
using NXOpen.UF;


namespace ClassLibrary1_NXO_UF_CS_RectGroove
{
    public class RectGroove
    {
        public static UFSession theUfSession;
        private static Session theSession;

        public int Execute()
        {
            double[] origin = { 0.0, 0.0, 0.0 };
            double[] direction = { 0.0, 0.0, 1.0 };
            double[] center = new double[3];
            double[] dir = new double[3];
            double[] box = new double[6];
            
            double[] location = { 0.0, 0.0, 200.0 };
            double radius;
            double rad_data;


            int count;
            int i;
            int type;
            int norm_dir;


            string height = "400.0";
            string diam = "20.0";
            string gr_diam = "5.0";
            string width = "3.0";


            Tag cyl_obj_id;
            Tag body;
            Tag[] face_list;
            Tag face;
            Tag face_id = Tag.Null;
            Tag feature_id;


            theUfSession.Modl.CreateCyl1(FeatureSigns.Nullsign, origin, height, diam,
            direction, out cyl_obj_id);

            theUfSession.Modl.AskFeatBody(cyl_obj_id, out body);
            theUfSession.Modl.AskBodyFaces(body, out face_list);
            theUfSession.Modl.AskListCount(face_list, out count);

            for (i = 0; i < count; i++)
            {
                theUfSession.Modl.AskListItem(face_list, i, out face);
                theUfSession.Modl.AskFaceData(face, out type, center, dir, box, out radius,
                out rad_data, out norm_dir);

                if (type == UFConstants.UF_cylinder_type) face_id = face;

            }

            theUfSession.Modl.CreateRectGroove(location, direction, gr_diam, width,
            face_id, out feature_id);

            return 0;
        }


        public static void Main(string[] args)
        {
            theSession = Session.GetSession();
            theUfSession = UFSession.GetUFSession();

            RectGroove createGroove = new RectGroove();
            createGroove.Execute();

        }

        public static int GetUnloadOption(string dummy)
        {
            return UFConstants.UF_UNLOAD_IMMEDIATELY;
        }


    }
}
