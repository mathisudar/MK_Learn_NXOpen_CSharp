using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NXOpen;


public class Program
{

            public static void Main(string[] args)
        {

            NXOpen.Session theSession = NXOpen.Session.GetSession();
            NXOpen.Part workPart = theSession.Parts.Work;
            NXOpen.Part displayPart = theSession.Parts.Display;
			
            // ----------------------------------------------
            //   Menu: Insert->Curve->Basic Curves (Legacy)...
            // ----------------------------------------------
			
            NXOpen.Session.UndoMarkId markId1;
            markId1 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Basic Curves");


            for (int i = 1; i < 10; i++)
            {

                NXOpen.Point3d startPoint1 = new NXOpen.Point3d(i, 0, 0);
                NXOpen.Point3d pointOn1 = new NXOpen.Point3d(0, i, 0);
                NXOpen.Point3d endPoint1 = new NXOpen.Point3d(-i, 0, 0);

                bool startAndEndGotFlipped1;

                NXOpen.Arc arc1;

                arc1 = workPart.Curves.CreateArc(startPoint1, pointOn1,
                    endPoint1, false, out startAndEndGotFlipped1);


                /*
                 * 
                 * public NXOpen.Arc CreateArc(NXOpen.Point3d startPoint, 
                 * NXOpen.Point3d pointOn, NXOpen.Point3d endPoint, 
                 * bool alternateSolution, out bool startAndEndGotFlipped)
                 
                 * Member of NXOpen.CurveCollection

                 * */

            }

            NXOpen.Session.UndoMarkId id1;
            id1 = theSession.NewestVisibleUndoMark;

            int nErrs1;
            nErrs1 = theSession.UpdateManager.DoUpdate(id1);

           
        }
        public static int GetUnloadOption(string dummy)
        {
            return (int)NXOpen.Session.LibraryUnloadOption.Immediately;
        }
    }
