using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class NotificationController : MonoBehaviour
{
    private static NotificationController i;
    public static NotificationController Instance => i;


    [SerializeField] private Text tittle = default;
    [SerializeField] private Text content = default;
    private Animator animator;

    private void Awake()
    {
        if (Instance == null)
        {
            i = this;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void ShowNotification(string tittleText, string contentText)
    {
        tittle.text = tittleText;
        content.text = contentText;
        animator.SetBool("showPanel", true);
        Invoke(nameof(HideNotification), 3f);
    }

    public IEnumerator HideNotification()
    {
        animator.SetBool("showPanel", false);
        return null;
    }
}
