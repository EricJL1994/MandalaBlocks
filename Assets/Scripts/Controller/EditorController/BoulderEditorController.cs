using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoulderEditorController : EditorController
{
    public static BoulderEditorController instance;
    [SerializeField] private Transform intersectionsList = default;
    private List<Problem> intersections;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        Setup(AssetsLibrary.Instance.BoulderDifficultiesNames());

        intersections = new List<Problem>();
    }

    public void AddIntersection(Problem problem)
    {
        if (intersections.Contains(problem)) return;
        intersections.Add(problem);
    }

    public void OnCreate()
    {
        DateTime date;
        try
        {
            date = GetDate();
        }
        catch (ArgumentOutOfRangeException)
        {
            return;
        }

        Boulder boulder = new Boulder(
                      AssetsLibrary.Instance.GetBoulderDifficulty(
                          difficultiesDropdown.options[difficultiesDropdown.value].text),
                      (int)numberslider.value,
                      date,
                      (BoulderWall)wallsDropdown.value);
        //boulder.SetIntersections(intersections);
        if (editingProblem != null)
        {
            BoulderListController.Instance.UpdateBoulder(boulder);
        }
        else
        {
            BoulderListController.Instance.CreateBoulderDisplay(boulder);
        }

        SetDisplay(false);
    }

    public void OnEdit(Boulder boulder)
    {
        wallsDropdown.value = (int)boulder.wall;

        base.OnEdit(boulder);

        OnRefresh();
    }

    public void OnRefresh()
    {
        foreach (Transform child in intersectionsList)
        {
            if (child.gameObject.name == "NoBouldersText") continue;
            Destroy(child.gameObject);
        }

        foreach (Traverse traverse in StaticTraverseList.Instance.GetAll())
        {
            BoulderEntryDisplay.InstanciateIntersectionObject(traverse, intersectionsList);
        }
    }

    public new void SetDisplay(bool editing)
    {
        OldestDisplay.dirtyTraverses = true;
        tittle.text = editing ? "Edit Boulder" : "Create Boulder";
        base.SetDisplay(editing);
    }
}
