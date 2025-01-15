using System;
using UnityEngine;

public class PlaceSpheres : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void InstantiateSpheres(float radius, float x, float y, float z, Color color)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(radius, radius, radius);
        sphere.GetComponent<Renderer>().material.color = color;
        sphere.GetComponent<Renderer>().material.SetFloat("_Smoothness", 0f);
        sphere.transform.position = new Vector3(x, y, z);
        // Instantiate(sphere, new Vector3(x, y, z), Quaternion.identity);
    }
}
