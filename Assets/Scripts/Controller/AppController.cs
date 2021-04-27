using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppController : MonoBehaviour
{
    public static bool rebuildView = false;
    public RectTransform mainMenuTransform;
    public static WindowTree currentWindow = null;

    void Start()
    {
        JsonFIleInterface.ReadAllFiles();
        OldestDisplay.dirtyBoulders = true;
        OldestDisplay.dirtyTraverses = true;
        currentWindow = new WindowTree();
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
            Back();
        }
    }

    public static void Back()
    {
        currentWindow = currentWindow.Back();
    }
}
