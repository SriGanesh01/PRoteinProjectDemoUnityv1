using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class Rules : MonoBehaviour
{
    public static string line;
    public static void dime(){
        using (StreamReader reader = new StreamReader(GlobalVars.filePath))
        {
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Substring(0, 6).Trim() == "ATOM" || line.Substring(0, 6).Trim() == "HETATM")
                {
                    Atom atom = new Atom
                    {
                        // RecordName = line.Substring(0, 6).Trim(),
                        AtomSerial = int.Parse(line.Substring(6, 5).Trim())
                    };
                }

            }
        }
    }
}
