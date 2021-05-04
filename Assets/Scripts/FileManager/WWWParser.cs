using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WWWParser : MonoBehaviour
{

    private static readonly string uri = "http://85.56.183.55:26164";
    private static readonly string addProblemToken = "/addproblem?problem=";

    void Start()
    {
        /*string b = JsonFIleInterface.b.Serialize();
        StartCoroutine(PostToWeb(b));*/
    }

    public static IEnumerator PostToWeb(string json)
    {
        //Debug.Log("Posting: " + json);
        using (UnityWebRequest www = UnityWebRequest.Post(uri + addProblemToken + json, new WWWForm()))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log("Posted");
            }
        }
    }
}
