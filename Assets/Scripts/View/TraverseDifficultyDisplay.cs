using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraverseDifficultyDisplay : MonoBehaviour
{
    private Difficulty difficulty;
    [SerializeField] private DifficultySeparator separator = default;

    public readonly Dictionary<Traverse, GameObject> traverses = new Dictionary<Traverse, GameObject>();

    private bool toogled = true;

    public void Setup(Difficulty difficulty)
    {
        this.difficulty = difficulty;
        separator.Setup(difficulty);
    }

    /// <summary>
    /// Adds a traverse to the list and the display
    /// </summary>
    /// <param name="boulder"></param>
    public void AddTraverse(Traverse traverse)
    {
        if (!StaticTraverseList.Instance.Add(traverse)) return;
        GameObject traverseObject = BoulderEntryDisplay.InstanciateListObject(traverse, transform);
        traverseObject.SetActive(toogled);
        traverses.Add(traverse, traverseObject);

        SortTraverseEntriesDisplays();
        OldestDisplay.dirtyTraverses = true;
    }

    /// <summary>
    /// Sort the list of traverses for a difficulty
    /// </summary>
    private void SortTraverseEntriesDisplays()
    {
        TraverseListHelper sortedTraverses = (TraverseListHelper)StaticTraverseList.GetByDifficulty(difficulty);

        for (int i = 0; i < sortedTraverses.Count; i++)
        {
            traverses.TryGetValue(sortedTraverses[i], out GameObject traverseObject);
            if (traverseObject == null) continue;
            traverseObject.transform.SetSiblingIndex(i + 1);
        }
    }

    /// <summary>
    /// Update the traverse data and displays
    /// </summary>
    /// <param name="boulder"></param>
    public void EditTraverse(Traverse traverse)
    {
        StaticTraverseList.Edit(traverse);
        GameObject traverseObject = traverses[traverse];
        traverses.Remove(traverse);
        traverses.Add(traverse, traverseObject);

        traverseObject.GetComponent<BoulderEntryDisplay>().Setup(traverse);
        OldestDisplay.dirtyTraverses = true;
    }

    /// <summary>
    /// Toogle the difficulty display
    /// </summary>
    public void OnClickedCategory()
    {
        toogled = !toogled;
        foreach (GameObject o in traverses.Values)
        {
            o.SetActive(toogled);
        }
    }

    /// <summary>
    /// Instanciate a difficulty display
    /// </summary>
    /// <param name="difficulty"></param>
    /// <param name="parent"></param>
    /// <returns></returns>
    public static TraverseDifficultyDisplay InstantiateObject(Difficulty difficulty, Transform parent)
    {
        GameObject categoryObject = Instantiate(AssetsLibrary.Instance.traverseDifficultyDisplay, parent);

        TraverseDifficultyDisplay traverseListCategory = categoryObject.GetComponent<TraverseDifficultyDisplay>();
        traverseListCategory.Setup(difficulty);
        return traverseListCategory;
    }

    public List<Traverse> GetTraverses()
    {
        return StaticTraverseList.GetByDifficulty(difficulty);
    }
}
