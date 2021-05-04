using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraverseEditorController : EditorController
{
    public static TraverseEditorController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        Setup(AssetsLibrary.Instance.TraverseDifficultiesNames());
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

        /***************************
         *TODO Get all walls*
         ***************************/
        List<BoulderWall> walls = new List<BoulderWall>()
        {
            (BoulderWall)wallsDropdown.value
        };

        Traverse traverse = new Traverse(
                      AssetsLibrary.Instance.GetTraverseDifficulty(
                          difficultiesDropdown.options[difficultiesDropdown.value].text),
                      (int)numberslider.value,
                      date,
                      walls);
        if (editingProblem != null)
        {
            TraverseListController.Instance.UpdateTraverse(traverse);
        }
        else
        {
            TraverseListController.Instance.CreateTraverseDisplay(traverse);
        }

        SetDisplay(editing: false);
    }



    public void OnEdit(Traverse traverse)
    {
        wallsDropdown.value = (int)traverse.walls[0];

        base.OnEdit(traverse);
    }

    public new void SetDisplay(bool editing)
    {
        OldestDisplay.dirtyTraverses = true;
        tittle.text = editing ? "Editar travesía" : "Crear travesía";
        base.SetDisplay(editing);
    }
}
