using UnityEngine;
using System.Collections.Generic;

public class ReturnCoords : MonoBehaviour
{
    public static float x1;
    public static float y1;
    public static float z1;
    public static float x2;
    public static float y2;
    public static float z2;

    public static void SerialToCoords(int serialVal1, int serialVal2)
    {
        Atom atom1 = ReadTxt.atoms.Find(a => a.AtomSerial == serialVal1);
        Atom atom2 = ReadTxt.atoms.Find(a => a.AtomSerial == serialVal2);

        if (atom1 != null && atom2 != null)
        {
            x1 = atom1.XCoord;
            y1 = atom1.YCoord;
            z1 = atom1.ZCoord;

            x2 = atom2.XCoord;
            y2 = atom2.YCoord;
            z2 = atom2.ZCoord;
        }
        else
        {
            Debug.LogWarning($"SerialToCoords: Could not find one or both atoms with serials {serialVal1}, {serialVal2}");
        }
    }

    public static void LineWithIndex()
    {
        
    }
}
