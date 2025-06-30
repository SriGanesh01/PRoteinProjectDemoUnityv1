using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Linq;


class Node
{
    string ResName;
    int AtomSerial;
    Node Left;
    Node Right;

    public Node(string ResName, int AtomSerial)
    {
        this.ResName = ResName;
        this.AtomSerial = AtomSerial;
        Left = null;
        Right = null;
    }
}


public class AlternativeApproachToRules : MonoBehaviour
{
    void Start()
    {
        Get();
    }

    public static void Get()
    {
        using (StreamReader reader = new StreamReader(GlobalVars.filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Substring(0, 6).Trim() == "ATOM" || line.Substring(0, 6).Trim() == "HETATM")
                {
                    Atom atom = new Atom
                    {
                        AtomSerial = int.Parse(line.Substring(6, 5).Trim()),
                        AtomName = line.Substring(12, 4).Trim(),
                        AltLoc = line.Substring(16, 1).Trim(),
                        FullAtomName = line.Substring(12, 5).Trim(),
                        ResidueName = line.Substring(17, 3).Trim()
                    };
                }
            }
        }
    }
}
