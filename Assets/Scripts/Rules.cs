using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NUnit.Framework.Internal;
using Unity.VisualScripting;

public class Rules : MonoBehaviour
{

    public static string ChainId;
    public static int AminoAcids;


    public static string line;
    public static Dictionary<int, string> links = new Dictionary<int, string>() { { 1, "A" }, { 2, "B" }, { 3, "G" }, { 4, "D" }, { 5, "E" }, { 6, "Z" }, { 7, "H" } };

    [SerializeField]
    public static List<string> GreekOrder = new List<string>() { "A", "B", "G", "D", "E", "Z", "H" };

    [SerializeField]
    public static List<string> AminoSequence = new List<string>();
    public static List<string> ChainAmino = new List<string>();
    public static List<string> AminoAtomResOrder = new List<string>();
    public static List<int> ID = new List<int>();
    public static List<string> GreekOrderList = new List<string>();
    public static List<string> AminoActualUniqueOrder = new List<string>();
    public static List<string> GreekActualUniqueOrder = new List<string>();
    public static List<Dictionary<int, string>> ListOfDictOfRGroup = new List<Dictionary<int, string>>();
    public static List<Dictionary<int, string>> TempSortedListOfDictOfRGroup = new List<Dictionary<int, string>>();
    public static List<Dictionary<int, string>> JustCChain = new List<Dictionary<int, string>>();


    void Start()
    {
        GetListOfUniqueAmino();
        // test();
        Debug.Log(string.Compare("a", "b") > 0);
    }

    public static void GetListOfUniqueAmino()
    {
        using (StreamReader reader = new StreamReader(GlobalVars.filePath))
        {
            string line;
            string lastResidueName = null;
            Dictionary<int, string> rGroup = new Dictionary<int, string>();

            while ((line = reader.ReadLine()) != null)
            {
                if (line.Substring(0, 6).Trim() == "ATOM" || line.Substring(0, 6).Trim() == "HETATM")
                {
                    Atom atom = new Atom
                    {
                        AtomSerial = int.Parse(line.Substring(6, 5).Trim()),
                        FullAtomName = line.Substring(12, 5).Trim(),
                        ResidueName = line.Substring(17, 3).Trim()
                    };

                    IfNotInList(AminoSequence, atom.ResidueName);
                    AminoAtomResOrder.Add(atom.ResidueName);
                    GreekOrderList.Add(atom.FullAtomName);
                    ID.Add(atom.AtomSerial);

                    if (AminoActualUniqueOrder.Count != 0 && atom.ResidueName != lastResidueName)
                    {
                        ListOfDictOfRGroup.Add(rGroup);
                        rGroup = new Dictionary<int, string>();
                    }

                    rGroup[atom.AtomSerial] = atom.FullAtomName;

                    if (AminoActualUniqueOrder.Count == 0 || atom.ResidueName != lastResidueName)
                    {
                        AminoActualUniqueOrder.Add(atom.ResidueName);
                        GreekActualUniqueOrder.Add(atom.FullAtomName);
                    }

                    lastResidueName = atom.ResidueName;
                }
            }

            if (rGroup.Count > 0)
            {
                ListOfDictOfRGroup.Add(rGroup);
            }
        }
    }


    public static void test()
    {
        Dictionary<string, string> greekMapping = new Dictionary<string, string>
        {
            { "A", "a" }, { "B", "b" }, { "G", "c" }, { "D", "d" }, { "E", "e" }, { "Z", "f" }, { "H", "g" }, { "I", "h" }
        };

        Dictionary<string, string> reverseGreekMapping = new Dictionary<string, string>
        {
            { "a", "A" }, { "b", "B" }, { "c", "G" }, { "d", "D" }, { "e", "E" }, { "f", "Z" }, { "g", "H" }, { "h", "I" }
        };

        TempSortedListOfDictOfRGroup = ListOfDictOfRGroup;

        


        // Change to Better
        foreach (var links in ListOfDictOfRGroup)
        {

            foreach (var key in links.Keys.ToList())
            {
                string value = links[key];
                foreach (var kvp in greekMapping)
                {
                    value = value.Replace(kvp.Key, kvp.Value);
                }

                links[key] = value;
            }
        }


        ListOfDictOfRGroup = ListOfDictOfRGroup
            .Select(dict => dict.OrderBy(pair => pair.Value.Length > 1 ? pair.Value[1] : pair.Value[0]) // Sort by second letter if possible, otherwise by first letter
            .ToDictionary(pair => pair.Key, pair => pair.Value))
            .ToList();

        JustCChain = ListOfDictOfRGroup;

        foreach (var dict in JustCChain)
        {
            var keysToRemove = dict.Where(kv => !kv.Value.StartsWith("C"))
                                .Select(kv => kv.Key)
                                .ToList();

            foreach (var key in keysToRemove)
            {
                dict.Remove(key);
            }
        }

        foreach (var links in JustCChain)
        {
            Debug.Log("New Dictionary:");
            foreach (var key in links)
            {
                Debug.Log($"Key: {key.Key}, Value: {key.Value}");
            }
        }

    

        // Draw Lines Among atoms

        // foreach (var links in TempSortedListOfDictOfRGroup)
        // {
        //     foreach (var key in links.Keys.ToList())
        //     {
        //         List<List<string>> temp = new List<List<string>>();
        //     }
        // }


        // Change back to Original

        // foreach (var links in ListOfDictOfRGroup)
        // {

        //     foreach (var key in links.Keys.ToList())
        //     {
        //         string value = links[key];
        //         foreach (var kvp in reverseGreekMapping)
        //         {
        //             value = value.Replace(kvp.Key, kvp.Value);
        //         }

        //         links[key] = value;
        //     }
        // }

        // Debug.Log("Changed Back Dictionary:");

        // foreach (var links in ListOfDictOfRGroup)
        // {
        //     Debug.Log("New Dictionary:");
        //     foreach (var link in links)
        //     {
        //         Debug.Log($"Key: {link.Key}, Value: {link.Value}");
        //     }
        // }



        



    }


    public static void IfNotInList(List<string> l1, string item)
    {
        if (!l1.Contains(item))
        {
            l1.Add(item);
        }
    }
}

public class Sequence
{
    public string ChainId { get; set; }
    public string ChainName { get; set; }
    public List<string> AminoAcids { get; set; }
}