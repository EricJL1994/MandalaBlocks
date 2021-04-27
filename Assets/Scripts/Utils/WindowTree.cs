using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowTree
{
    public WindowTree previous = null;
    public GameObject current;

    public WindowTree(WindowTree previous, GameObject gameObject)
    {
        this.previous = previous;
        current = gameObject;
    }

    public WindowTree()
    {
    }

    public WindowTree Back()
    {
        if (previous != null)
        {
            current.GetComponent<Animator>().SetBool("showPanel", false);
            return previous;
        }
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
//Ask for the saved files
        Application.Quit();
#endif
        return null;
    }
}
