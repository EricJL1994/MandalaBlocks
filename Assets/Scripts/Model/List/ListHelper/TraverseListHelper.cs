using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraverseListHelper : ListHelper<Traverse>
{
    private static TraverseListHelper instance;

    public TraverseListHelper(Traverse traverse)
    {
        Add(traverse);
    }

    public override ListHelper<Traverse> GetInstance()
    {
        if (instance == null) instance = this;
        return instance;
    }

    public override ListHelper<Traverse> GetNewList(Traverse traverse)
    {
        TraverseListHelper traverseListHelper = new TraverseListHelper(traverse);
        return traverseListHelper;
    }
}
