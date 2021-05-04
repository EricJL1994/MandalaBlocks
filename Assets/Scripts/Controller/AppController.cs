using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppController : MonoBehaviour
{
    public static bool rebuildView = false;
    public RectTransform mainMenuTransform;
    public static WindowTree currentWindow = null;
    public Animator exitMenu;

    void Start()
    {
        Invoke(nameof(ReadAll), .5f);
        //Invoke(nameof(PostAll), 2f);
        //currentWindow = new WindowTree();
        //Debug.Log(JsonFIleInterface.b.Serialize());
    }

    public void PostAll()
    {
        //Debug.Log("PostAll: " + boulders.Count);
        foreach (Boulder boulder in StaticBoulderList.GetOlderThan(System.DateTime.Now))
        {
            //Debug.Log(boulder);
            StartCoroutine(WWWParser.PostToWeb(boulder.Serialize()));
        }
    }

    private void ReadAll()
    {
        JsonFIleInterface.ReadAllFiles();
        OldestDisplay.dirtyBoulders = true;
        OldestDisplay.dirtyTraverses = true;
    }

    public void OnSaveProblems()
    {
        foreach (Boulder boulder in StaticBoulderList.Instance.GetAll())
        {
            JsonFIleInterface.StoreProblem(boulder);
        }

        foreach (Traverse traverse in StaticTraverseList.Instance.GetAll())
        {
            JsonFIleInterface.StoreProblem(traverse);
        }
    }

    private void Update()
    {
        if (rebuildView)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(mainMenuTransform);
            rebuildView = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Backing");
            Back();
        }
    }

    public static void Back()
    {
        //Debug.Log("Back: " + currentWindow.current.gameObject.name);
        if (currentWindow == null)
        {
            Debug.Log("null");
            Front(GameObject.Find("ExitMenu").GetComponent<Animator>());
            return;
        }
        currentWindow = currentWindow.Back();
    }

    public static void Front(Animator animator)
    {
        Debug.Log("Front: " + animator.gameObject.name);
        currentWindow = new WindowTree(currentWindow, animator);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
//Ask for the saved files
        Application.Quit();
#endif
    }

    public void SaveAndQuit()
    {
        OnSaveProblems();
        Quit();
    }
}
