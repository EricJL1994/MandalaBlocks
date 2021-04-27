using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTraverseList : StaticList<Traverse, TraverseListHelper>
{
    private static StaticTraverseList i;

    public StaticTraverseList()
    {
        dictionary = new Dictionary<Difficulty, TraverseListHelper>();
    }

    public static StaticTraverseList Instance
    {
        get
        {
            if (i == null) i = new StaticTraverseList();
            return i;
        }
    }

    public override bool Add(Traverse traverse)
    {
        if (dictionary.ContainsKey(traverse.difficulty))
            return dictionary[traverse.difficulty].Add(traverse);

        dictionary.Add(traverse.difficulty, new TraverseListHelper(traverse));
        return true;
    }

    public override List<Traverse> GetAll()
    {
        List<Traverse> all = new List<Traverse>();
        foreach (Difficulty difficulty in dictionary.Keys)
        {
            all.AddRange(dictionary[difficulty]);
        }
        return all;
    }
}
