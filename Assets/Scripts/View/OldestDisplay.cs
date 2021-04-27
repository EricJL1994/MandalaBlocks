using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OldestDisplay : MonoBehaviour
{
    /*[SerializeField] private BoulderEntryDisplay display = default;
    [SerializeField] private Text noProblemsText = default;
    //[SerializeField] private bool boulders = true;*/
    [SerializeField] private GameObject oldestList = default;
    [SerializeField] private UnityEvent action = default;
    public static bool dirtyBoulders = false;
    public static bool dirtyTraverses = false;

    void Update()
    {
        /*if (boulders)
        {
            if (dirtyBoulders) DirtyBoulders();
        }
        else
        {
            if (dirtyTraverses) DirtyTraverses();
        }*/

        if (dirtyTraverses || dirtyBoulders)
        {
            action.Invoke();
            AppController.rebuildView = true;
        }
    }
    public void DirtyBoulders()
    {
        foreach (Transform transform in oldestList.transform)
        {
            Destroy(transform.gameObject);
        }

        foreach (Boulder boulder in StaticBoulderList.GetLastDate())
        {
            BoulderEntryDisplay.InstanciateListObject(boulder, oldestList.transform).GetComponent<Button>().interactable = false;
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(oldestList.GetComponent<RectTransform>());
        dirtyBoulders = false;
    }

    public void DirtyTraverses()
    {
        foreach (Transform transform in oldestList.transform)
        {
            Destroy(transform.gameObject);
        }

        foreach (Traverse traverse in StaticTraverseList.GetLastDate())
        {
            BoulderEntryDisplay.InstanciateListObject(traverse, oldestList.transform).GetComponent<Button>().interactable = false;
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(oldestList.GetComponent<RectTransform>());
        dirtyTraverses = false;
    }
}
