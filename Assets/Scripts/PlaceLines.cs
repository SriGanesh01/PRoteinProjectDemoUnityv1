using UnityEngine;

public class PlaceLines : MonoBehaviour
{
    // Material lineMaterial;
    public static int numberOfLines = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void InstantiateLines(float x1, float y1, float z1, float x2, float y2, float z2)
    {
        GameObject line = new GameObject();
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.1f;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(x1, y1, z1));
        lineRenderer.SetPosition(1, new Vector3(x2, y2, z2));
    }
}
