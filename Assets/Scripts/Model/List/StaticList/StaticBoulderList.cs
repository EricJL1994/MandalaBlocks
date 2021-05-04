using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// List of all the boulders, organized by difficulty
/// </summary>
public class StaticBoulderList : StaticList<Boulder, BoulderListHelper>
{
    private static StaticBoulderList i;

    public StaticBoulderList()
    {
        dictionary = new Dictionary<Difficulty, BoulderListHelper>();
    }

    public static StaticBoulderList Instance
    {
        get
        {
            if (i == null) i = new StaticBoulderList();
            return i;
        }
    }

    public override bool Add(Boulder boulder)
    {
        if (dictionary.ContainsKey(boulder.difficulty))
            return dictionary[boulder.difficulty].Add(boulder);

        dictionary.Add(boulder.difficulty, new BoulderListHelper(boulder));
        return true;
    }

    public override List<Boulder> GetAll()
    {
        List<Boulder> boulders = new List<Boulder>();
        foreach (Difficulty difficulty in dictionary.Keys)
        {
            boulders.AddRange(dictionary[difficulty]);
        }
        return boulders;
    }
}
