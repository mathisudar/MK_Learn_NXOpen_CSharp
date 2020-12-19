using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using NXOpen;

public class NXJournal
{
    public static void Main(string[] args)
    {
        Session theSession = Session.GetSession();
        Part workPart = theSession.Parts.Work;
        UI theUI = UI.GetUI();
        //Insert code here

        Point[] newPt1 = new Point[3];
        Point[] newPt2 = new Point[3];
        Point[] newPt3 = new Point[3];

        Point3d myPt1 = new Point3d(101, 0, 0);
        Point3d myPt2 = new Point3d(201, 0, 0);
        Point3d myPt3 = new Point3d(301, 0, 0);


        for (int i = 1; i <= 1; i++)
        {
            newPt1[i] = workPart.Points.CreatePoint(myPt1);
            newPt2[i] = workPart.Points.CreatePoint(myPt2);
            newPt3[i] = workPart.Points.CreatePoint(myPt3);

            newPt1[i].SetVisibility(SmartObject.VisibilityOption.Visible);
            newPt2[i].SetVisibility(SmartObject.VisibilityOption.Visible);
            newPt3[i].SetVisibility(SmartObject.VisibilityOption.Visible);
        }

    }
}
