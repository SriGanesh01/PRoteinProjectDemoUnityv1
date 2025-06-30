using Newtonsoft.Json;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

using UnityEngine;

public class APICall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                // Show results as text
                Debug.Log(webRequest.downloadHandler.text);
                
                // Or retrieve results as binary data
                // byte[] results = webRequest.downloadHandler.data;
            }
        }
    }

}
