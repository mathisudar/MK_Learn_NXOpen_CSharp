using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
// using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NXOpen;
using NXOpen.UF;

namespace NX_ProjectCurve
{

    public class EX_ProjectCurve
    {

        private static UFSession theUFSession;
        private static Session theSession;



        public static void Main(string[] args)
        {


            NXOpen.Session theSession = NXOpen.Session.GetSession();
            NXOpen.Part workPart = theSession.Parts.Work;
            NXOpen.Part displayPart = theSession.Parts.Display;

            theSession = Session.GetSession();
            theUFSession = UFSession.GetUFSession();


            Tag myWCS;

            string strPart_Name = " MK_PART";
            int intUnits = 1;

            Tag tagMathi;

            theUFSession.Part.New(strPart_Name, intUnits, out tagMathi);
            
            /*
             * public void New(string part_name, int units, out NXOpen.Tag part)
                Member of NXOpen.UF.UFPart
             * */



            double[] corner_pt = new double[3] { 0, 0, 0 };
            string[] edge_len = new string[3] { "100", "200", "50" };

            Tag Block;

            theUFSession.Modl.CreateBlock1(FeatureSigns.Nullsign, corner_pt, edge_len, out Block);



            /*
             * public void CreateBlock1(NXOpen.UF.FeatureSigns sign, double[] corner_pt, 
             * string[] edge_len, out NXOpen.Tag blk_obj_id)
             * 
                Member of NXOpen.UF.UFModl
            
             * */



            UFCurve.Line line_coords = new UFCurve.Line();
            NXOpen.Tag[] line = new NXOpen.Tag[2];

            line_coords.start_point = new double[3] { 1, 1, 70 };
            line_coords.end_point = new double[3] { 98, 198, 70 };

            theUFSession.Curve.CreateLine(ref line_coords, out line[0]);

            /*
             * public void CreateLine(ref NXOpen.UF.UFCurve.Line line_coords, out NXOpen.Tag line)
                Member of NXOpen.UF.UFCurve

             * */

            


            // curve_refs 

            int n_curve_refs = 1;
            int n_face_refs = 1;



            NXOpen.Tag[] face_refs = new NXOpen.Tag[1]; ;

            // face_list 

            int copy_flag = 3;

           Tag proj_curve_feature;


            // ref NXOpen.UF.UFCurve.Proj proj_data

            UFCurve.Proj proj_data = new UFCurve.Proj();

            proj_data.proj_type = 3;
            proj_data.multiplicity = 2;

            double[] array3 = new double[3] { 0, 0, -1 };

            proj_data.proj_vec = array3;

            theUFSession.Modl.AskFeatFaces(Block, out face_refs);

            /*
             * public void AskFeatFaces(NXOpen.Tag feature_obj_id, out NXOpen.Tag[] object_list)
                Member of NXOpen.UF.UFModl

             * */


            theUFSession.Curve.CreateProjCurves(n_curve_refs, line, n_face_refs, 
                face_refs, copy_flag, ref proj_data, out proj_curve_feature);

           /* public void CreateProjCurves(int n_curve_refs, NXOpen.Tag[] curve_refs, 
            int n_face_refs, NXOpen.Tag[] face_refs, int copy_flag, 
            * ref NXOpen.UF.UFCurve.Proj proj_data, out NXOpen.Tag proj_curve_feature)
                Member of NXOpen.UF.UFCurve
            */


        }



        public static int GetUnloadOption(string dummy)
        {

            return UFConstants.UF_UNLOAD_IMMEDIATELY;

        }


    }

}
