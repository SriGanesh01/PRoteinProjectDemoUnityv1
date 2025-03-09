using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    public static string filePath = Application.dataPath + "/Datas" + "/test3.pdb";

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        ReturnCoords.SerialToCoords(1, 2);
        Debug.Log(ReturnCoords.x1);
        Debug.Log(ReturnCoords.y1);
        Debug.Log(ReturnCoords.z1);
        Debug.Log(ReturnCoords.x2);
        Debug.Log(ReturnCoords.y2);
        Debug.Log(ReturnCoords.z2);

        ReturnCoords.SerialToCoords(2, 3);
        Debug.Log(ReturnCoords.x1);
        Debug.Log(ReturnCoords.y1);
        Debug.Log(ReturnCoords.z1);
        Debug.Log(ReturnCoords.x2);
        Debug.Log(ReturnCoords.y2);
        Debug.Log(ReturnCoords.z2);
        
    }
}
