using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public void OnShowPanel(Animator animator)
    {
        animator.SetBool("showPanel", true);
        AppController.currentWindow = new WindowTree(AppController.currentWindow, animator.gameObject);
    }

    public void OnHidePanel(Animator animator)
    {
        if (AppController.currentWindow.current == animator.gameObject)
        {
            AppController.Back();
            return;
        }
        animator.SetBool("showPanel", false);
    }
}
