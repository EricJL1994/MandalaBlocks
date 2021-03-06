using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsLibrary : MonoBehaviour
{
    private static AssetsLibrary _i;

    public static AssetsLibrary Instance
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<AssetsLibrary>("AssetsLibrary"));
            return _i;
        }
    }
    
    /***********
     * PREFABS *
     ***********/

    [SerializeField] public List<Difficulty> boulderDifficulties;
    [SerializeField] public List<Difficulty> traverseDifficulties;
    [SerializeField] public GameObject boulderObject;
    [SerializeField] public GameObject intersectionObject;
    [SerializeField] public GameObject difficultySeparator;
    [SerializeField] public GameObject boulderDifficultyDisplay;
    [SerializeField] public GameObject traverseDifficultyDisplay;




    private Dictionary<string, Difficulty> boulderDictionary;
    private Dictionary<string, Difficulty> traverseDictionary;

    public List<string> BoulderDifficultiesNames()
    {
        return new List<string>(boulderDictionary.Keys);
    }
    public List<string> TraverseDifficultiesNames()
    {
        return new List<string>(traverseDictionary.Keys);
    }


    private void Awake()
    {
        boulderDifficulties.Sort();
        traverseDifficulties.Sort();
        boulderDictionary = new Dictionary<string, Difficulty>();
        traverseDictionary = new Dictionary<string, Difficulty>();

        foreach (Difficulty item in boulderDifficulties)
        {
            boulderDictionary.Add(item.ToString(), item);
        }

        foreach (Difficulty item in traverseDifficulties)
        {
            traverseDictionary.Add(item.ToString(), item);
        }
        
    }

    public Difficulty GetBoulderDifficulty (string name)
    {
        return boulderDictionary[name];
    }
    
    public Difficulty GetTraverseDifficulty(string name)
    {
        return traverseDictionary[name];
    }
}
