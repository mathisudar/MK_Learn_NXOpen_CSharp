// NX 1899
// Journal created by KRISHMA on Tue Oct  1 09:12:55 2019 India Standard Time
//
using System;
using NXOpen;

public class NXJournal
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


        NXOpen.Point3d cenPt = new NXOpen.Point3d(0, 0, 0);
        NXOpen.NXMatrix arcMatrix = workPart.WCS.CoordinateSystem.Orientation;

        double arcRadius = 1;
        double arcStartAngle = 0;
        double arcEndAngle = 45 * Math.PI / 180;
        double arcIncrement = 45 * Math.PI / 180;

        for (double i = 1; i <= 8; i++)
        {

            arcRadius = i / 2;

            NXOpen.Arc arc1;
            arc1 = workPart.Curves.CreateArc(cenPt, arcMatrix, arcRadius, arcStartAngle, arcEndAngle);

            arcEndAngle = arcEndAngle + arcIncrement;

        }

        /*
         * public NXOpen.Arc CreateArc(NXOpen.Point3d center, NXOpen.NXMatrix matrix, 
         * double radius, double startAngle, double endAngle)
            Member of NXOpen.CurveCollection
         * 
         * */




        NXOpen.Session.UndoMarkId id1;
        id1 = theSession.NewestVisibleUndoMark;

        int nErrs1;
        nErrs1 = theSession.UpdateManager.DoUpdate(id1);

        // ----------------------------------------------
        //   Menu: Tools->Journal->Stop Recording
        // ----------------------------------------------

    }
    public static int GetUnloadOption(string dummy) { return (int)NXOpen.Session.LibraryUnloadOption.Immediately; }
}
