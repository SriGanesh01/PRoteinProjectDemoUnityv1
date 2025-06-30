using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    public static string fileName = "1crn";
    public static string filePath => Application.dataPath + "/Datas/" + fileName + ".pdb";

    public static bool isPanelOpen = false;

    public static void SetFile(string name)
    {
        fileName = name;
        Debug.Log("Selected File: " + fileName);
        Debug.Log("Full Path: " + filePath);
    }
}
