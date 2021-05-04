using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public void OnShowPanel(Animator animator)
    {
        AppController.Front(animator);
    }

    public void OnHidePanel(Animator animator)
    {
        AppController.Back();
        /*if (AppController.currentWindow.current == animator)
        {
            return;
        }
        animator.SetBool("showPanel", false);*/
    }
}
