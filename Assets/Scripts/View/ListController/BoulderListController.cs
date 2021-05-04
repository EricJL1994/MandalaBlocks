using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Object to hold the list of boulders for each difficulty
/// </summary>
[RequireComponent(typeof(VerticalLayoutGroup))]
public class BoulderListController : MonoBehaviour
{
    public static BoulderListController Instance = null;

    private readonly Dictionary<Difficulty, BoulderDifficultyDisplay> bouldersObjects = new Dictionary<Difficulty, BoulderDifficultyDisplay>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    /// <summary>
    /// Create a display for the boulder and for its difficulty
    /// </summary>
    /// <param name="boulder">Boulder to add</param>
    public void CreateBoulderDisplay(Boulder boulder)
    {
        //If difficulty doesn't exist, create a new one (don't mind if boulder exists, it doesn't)
        if (!bouldersObjects.ContainsKey(boulder.difficulty))
            bouldersObjects.Add(boulder.difficulty, BoulderDifficultyDisplay.InstantiateObject(boulder.difficulty, Instance.transform));

        bouldersObjects[boulder.difficulty].AddBoulder(boulder);

        SortDifficultiesDisplays();
    }

    /// <summary>
    /// Update the boulder's data
    /// </summary>
    /// <param name="boulder">Boulder to update</param>
    public void UpdateBoulder(Boulder boulder)
    {
        bouldersObjects[boulder.difficulty].EditBoulder(boulder);
    }

    /// <summary>
    /// Sort the difficulties displays in order
    /// </summary>
    private void SortDifficultiesDisplays()
    {
        List<Difficulty> difficulties = new List<Difficulty>(bouldersObjects.Keys);
        difficulties.Sort();
        for (int i = 0; i < difficulties.Count; i++)
        {
            bouldersObjects.TryGetValue(difficulties[i], out BoulderDifficultyDisplay boulderList);
            if (boulderList == null) continue;
            boulderList.gameObject.transform.SetSiblingIndex(i + 1);
        }
    }

    /*public Dictionary<Difficulty, List<Boulder>> GetAllBoulders()
    {
        Dictionary<Difficulty, List<Boulder>> allBoulders = new Dictionary<Difficulty, List<Boulder>>();
        foreach (Difficulty difficulty in bouldersObjects.Keys)
        {
            allBoulders.Add(difficulty, bouldersObjects[difficulty].GetBoulders());
        }

        return allBoulders;
    }*/
}