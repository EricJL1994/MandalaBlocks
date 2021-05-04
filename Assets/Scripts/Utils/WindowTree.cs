using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowTree
{
    public WindowTree previous = null;
    public Animator current;

    public WindowTree(WindowTree previous, Animator animator)
    {
        this.previous = previous;
        current = animator;
        current.SetBool("showPanel", true);
    }

    public WindowTree()
    {
    }

    public WindowTree Back()
    {
        /*if (previous != null)
        {*/
            current.SetBool("showPanel", false);
            return previous;
        /*}
        return null;*/
    }
}
