using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;

public class ReturnCoords : MonoBehaviour
{
    public static string recordName;
    public static int atomSerial;
    public static string atomName;
    public static string altLoc;
    public static string residueName;
    public static string chainId;
    public static int residueSeq;
    public static string insertionCode;
    public static float xCoord;
    public static float yCoord;
    public static float zCoord;
    public static float occupancy;
    public static float tempFactor;
    public static string element;
    public static string charge;

    public static string line;
    public static string filePath = Application.dataPath + "/Datas" + "/test2.ent";
    public static List<Atom> atoms = new List<Atom>();

    public static float x1;
    public static float y1;
    public static float z1;
    public static float x2;
    public static float y2;
    public static float z2;


    public static void SerialToCoords(int serialVal1, int serialVal2)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Substring(0, 6).Trim() == "ATOM" || line.Substring(0, 6).Trim() == "HETATM")
                {
                    Atom atom = new Atom
                    {
                        // RecordName = line.Substring(0, 6).Trim(),
                        AtomSerial = int.Parse(line.Substring(6, 5).Trim()),
                        // AtomName = line.Substring(12, 4).Trim(),
                        // AltLoc = line.Substring(16, 1).Trim(),
                        // ResidueName = line.Substring(17, 3).Trim(),
                        // ChainId = line.Substring(21, 1).Trim(),
                        // ResidueSeq = int.Parse(line.Substring(22, 4).Trim()),
                        // InsertionCode = line.Substring(26, 1).Trim(),
                        XCoord = float.Parse(line.Substring(30, 8).Trim()),
                        YCoord = float.Parse(line.Substring(38, 8).Trim()),
                        ZCoord = float.Parse(line.Substring(46, 8).Trim()),
                        // Occupancy = float.Parse(line.Substring(54, 6).Trim()),
                        // TempFactor = float.Parse(line.Substring(60, 6).Trim()),
                        // Element = line.Length >= 78 ? line.Substring(76, 2).Trim() : "",
                        // Charge = line.Length >= 80 ? line.Substring(78, 2).Trim() : ""
                    };
                    atoms.Add(atom);
                    if (atom.AtomSerial == serialVal1)
                    {
                        x1 = atom.XCoord;
                        y1 = atom.YCoord;
                        z1 = atom.ZCoord;
                    }
                    if (atom.AtomSerial == serialVal2)
                    {
                        x2 = atom.XCoord;
                        y2 = atom.YCoord;
                        z2 = atom.ZCoord;
                    }
                }
            }
        }
    }

    public static void LineWithIndex(){
        
    }
}
