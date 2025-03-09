using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;

public class ReadTxt : MonoBehaviour
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
    public static List<Atom> atoms = new List<Atom>();
    public static List<string> conects = new List<string>();
    public static List<int> lines = new List<int>();
    public static List<List<int>> AllLines = new List<List<int>>();
    public static List<int> FirstLine = new List<int>();


    private void Awake()
    {
        Read();
    }

    void Start()
    {
        ReadSpheres();
        ReadLines();
    }

    public static void Read()
    {
        using (StreamReader reader = new StreamReader(GlobalVars.filePath))
        {
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Substring(0, 6).Trim() == "ATOM" || line.Substring(0, 6).Trim() == "HETATM")
                {
                    Atom atom = new Atom
                    {
                        RecordName = line.Substring(0, 6).Trim(),
                        AtomSerial = int.Parse(line.Substring(6, 5).Trim()),
                        AtomName = line.Substring(12, 4).Trim(),
                        AltLoc = line.Substring(16, 1).Trim(),
                        ResidueName = line.Substring(17, 3).Trim(),
                        ChainId = line.Substring(21, 1).Trim(),
                        ResidueSeq = int.Parse(line.Substring(22, 4).Trim()),
                        InsertionCode = line.Substring(26, 1).Trim(),
                        XCoord = float.Parse(line.Substring(30, 8).Trim()),
                        YCoord = float.Parse(line.Substring(38, 8).Trim()),
                        ZCoord = float.Parse(line.Substring(46, 8).Trim()),
                        Occupancy = float.Parse(line.Substring(54, 6).Trim()),
                        TempFactor = float.Parse(line.Substring(60, 6).Trim()),
                        Element = line.Length >= 78 ? line.Substring(76, 2).Trim() : "",
                        Charge = line.Length >= 80 ? line.Substring(78, 2).Trim() : ""
                    };
                    atoms.Add(atom);
                    if (atom.AtomSerial == 1)
                    {
                        
                    }
                }

                if (line.Substring(0, 6).Trim() == "CONECT")
                {
                    conects.Add(line);
                }

            }
        }
    }

    public static void ReadSpheres()
    {
        foreach (var atom in atoms)
        {
            PlaceSpheres.InstantiateSpheres(atom.Occupancy, atom.XCoord, atom.YCoord, atom.ZCoord, Color.red);
        }
    }

    public static void ReadLines()
    {
        int val;
        foreach (var conect in conects)
        {
            string[] numbers = conect.Substring(6).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 1; i < numbers.Length; i++)
            {
                lines.Add(int.Parse(numbers[i]));
            }
            FirstLine.Add(int.Parse(numbers[0]));
            AllLines.Add(lines);
            lines = new List<int>();

        }

        foreach (var line in AllLines)
        {
            for (int i = 0; i < 1; i++)
            {
                val = line[i];
                foreach (var each in line)
                {
                    ReturnCoords.SerialToCoords(val, each);
                    PlaceLines.InstantiateLines(ReturnCoords.x1, ReturnCoords.y1, ReturnCoords.z1, ReturnCoords.x2, ReturnCoords.y2, ReturnCoords.z2);
                }
                i = 0;
            }
        }
    }
}

public class Atom
{
    public string RecordName { get; set; }
    public int AtomSerial { get; set; }
    public string AtomName { get; set; }
    public string AltLoc { get; set; }
    public string ResidueName { get; set; }
    public string ChainId { get; set; }
    public int ResidueSeq { get; set; }
    public string InsertionCode { get; set; }
    public float XCoord { get; set; }
    public float YCoord { get; set; }
    public float ZCoord { get; set; }
    public float Occupancy { get; set; }
    public float TempFactor { get; set; }
    public string Element { get; set; }
    public string Charge { get; set; }
}