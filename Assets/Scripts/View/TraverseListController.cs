using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(VerticalLayoutGroup))]
public class TraverseListController : MonoBehaviour
{
    public static TraverseListController Instance = null;

    private readonly Dictionary<Difficulty, TraverseDifficultyDisplay> traverseObjects = new Dictionary<Difficulty, TraverseDifficultyDisplay>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void CreateTraverseDisplay(Traverse traverse)
    {
        if (!traverseObjects.ContainsKey(traverse.difficulty))
            traverseObjects.Add(traverse.difficulty, TraverseDifficultyDisplay.InstantiateObject(traverse.difficulty, Instance.transform));

        traverseObjects[traverse.difficulty].AddTraverse(traverse);

        SortDifficultiesDisplays();
    }

    public void UpdateTraverse(Traverse traverse)
    {
        traverseObjects[traverse.difficulty].EditTraverse(traverse);
    }

    private void SortDifficultiesDisplays()
    {
        List<Difficulty> difficulties = new List<Difficulty>(traverseObjects.Keys);
        difficulties.Sort();
        for (int i = 0; i < difficulties.Count; i++)
        {
            traverseObjects.TryGetValue(difficulties[i], out TraverseDifficultyDisplay traverseList);
            if (traverseList == null) continue;
            traverseList.gameObject.transform.SetSiblingIndex(i + 1);
        }

    }

    /*public Dictionary<Difficulty, List<Traverse>> GetAllBoulders()
    {
        Dictionary<Difficulty, List<Traverse>> allTraverse = new Dictionary<Difficulty, List<Traverse>>();
        foreach (Difficulty difficulty in traverseObjects.Keys)
        {
            allTraverse.Add(difficulty, traverseObjects[difficulty].GetTraverses());
        }

        return allTraverse;
    }*/
}
