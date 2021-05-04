using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderListHelper : ListHelper<Boulder>/*List<Boulder>*/
{
    private static BoulderListHelper instance;

    public BoulderListHelper(Boulder boulder)
    {
        Add(boulder);
    }

    public override ListHelper<Boulder> GetInstance()
    {
        if (instance == null) instance = this;
        return instance;
    }

    public override ListHelper<Boulder> GetNewList(Boulder boulder)
    {
        BoulderListHelper boulderListHelper = new BoulderListHelper(boulder);
        return boulderListHelper;
    }
    /*public Boulder oldestBoulder = null;

    public new bool Add(Boulder boulder)
    {
        if (Contains(boulder)) return false;

        CheckOlder(boulder);
        base.Add(boulder);
        return true;
    }

    public void EditBoulder(Boulder boulder)
    {
        if (oldestBoulder.Equals(boulder)) oldestBoulder = null;

        Remove(boulder);
        base.Add(boulder);

        CheckOldest();
    }

    private void CheckOlder(Boulder boulder)
    {
        if (oldestBoulder == null || oldestBoulder.date > boulder.date)
        {
            oldestBoulder = boulder;
        }
    }

    private void CheckOldest()
    {
        foreach (Boulder boulder in this)
        {
            CheckOlder(boulder);
        }
    }*/
}
