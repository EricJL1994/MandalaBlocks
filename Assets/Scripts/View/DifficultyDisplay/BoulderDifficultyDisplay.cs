using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Displays for each difficulty
/// </summary>
public class BoulderDifficultyDisplay : MonoBehaviour
{
    private Difficulty difficulty;
    [SerializeField] private DifficultySeparator separator = default;

    public readonly Dictionary<Boulder, GameObject> boulders = new Dictionary<Boulder, GameObject>();

    private bool toogled = true;

    public void Setup(Difficulty difficulty)
    {
        this.difficulty = difficulty;
        separator.Setup(difficulty);
    }

    /// <summary>
    /// Adds a boulder to the list and the display
    /// </summary>
    /// <param name="boulder"></param>
    public void AddBoulder(Boulder boulder)
    {
        if (!StaticBoulderList.Instance.Add(boulder)) return;
        GameObject boulderObject = BoulderEntryDisplay.InstanciateListObject(boulder, transform);
        boulderObject.SetActive(toogled && !boulder.pending);
        boulders.Add(boulder, boulderObject);
        OldestDisplay.dirtyBoulders = true;

        SortBoulderEntriesDisplays();
    }

    /// <summary>
    /// Sort the list of boulders for a difficulty
    /// </summary>
    private void SortBoulderEntriesDisplays()
    {
        BoulderListHelper sortedBoulders = (BoulderListHelper)StaticBoulderList.GetByDifficulty(difficulty);

        for (int i = 0; i < sortedBoulders.Count; i++)
        {
            boulders.TryGetValue(sortedBoulders[i], out GameObject boulderObject);
            if (boulderObject == null) continue;
            boulderObject.transform.SetSiblingIndex(i + 1);
        }
    }

    /// <summary>
    /// Update the boulder data and displays
    /// </summary>
    /// <param name="boulder"></param>
    public void EditBoulder(Boulder boulder)
    {
        StaticBoulderList.Edit(boulder);
        GameObject boulderObject = boulders[boulder];
        boulders.Remove(boulder);
        boulders.Add(boulder, boulderObject);

        boulderObject.GetComponent<BoulderEntryDisplay>().Setup(boulder);
        OldestDisplay.dirtyBoulders = true;
    }

    /// <summary>
    /// Toogle the difficulty display
    /// </summary>
    public void OnClickedCategory()
    {
        toogled = !toogled;
        foreach (GameObject o in boulders.Values)
        {
            o.SetActive(toogled && !o.GetComponent<BoulderEntryDisplay>().problem.pending);
        }
    }

    /// <summary>
    /// Instanciate a difficulty display
    /// </summary>
    /// <param name="difficulty"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public static BoulderDifficultyDisplay InstantiateObject(Difficulty difficulty, Transform parent)
    {
        GameObject categoryObject = Instantiate(AssetsLibrary.Instance.boulderDifficultyDisplay, parent);

        BoulderDifficultyDisplay boulderListCategory = categoryObject.GetComponent<BoulderDifficultyDisplay>();
        boulderListCategory.Setup(difficulty);
        return boulderListCategory;
    }

    public List<Boulder> GetBoulders()
    {
        return StaticBoulderList.GetByDifficulty(difficulty);
    }

}
