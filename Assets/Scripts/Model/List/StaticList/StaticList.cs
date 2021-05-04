using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StaticList<T, Helper> where T : Problem where Helper : ListHelper<T>
{
    protected static Dictionary<Difficulty, Helper> dictionary;

    public abstract bool Add(T problem);
    public abstract List<T> GetAll();

    public static void Edit(T problem)
    {
        dictionary[problem.difficulty].Edit(problem);
    }

    public static ListHelper<T> GetByDifficulty(Difficulty difficulty)
    {
        dictionary[difficulty].Sort();
        return dictionary[difficulty];
    }

    public static T GetOldest()
    {
        T older = null;
        foreach (Difficulty difficulty in dictionary.Keys)
        {
            if (older == null || older.date > dictionary[difficulty].oldestProblem.date)
            {
                older = dictionary[difficulty].oldestProblem;
            }
        }
        return older;
    }

    public static List<T> GetLastDate()
    {
        List<T> oldestList = new List<T>();
        T older = null;
        foreach (Difficulty difficulty in dictionary.Keys)
        {
            if (older == null || older.date > dictionary[difficulty].oldestProblem.date)
            {
                oldestList = new List<T>();
                older = dictionary[difficulty].oldestProblem;
            }

            foreach (T item in dictionary[difficulty])
            {
                if (item.date == older.date)
                {
                    oldestList.Add(item);
                }
            }
        }
        oldestList.Sort();
        return oldestList;
    }

    public static List<T> GetOlderThan(DateTime date)
    {
        List<T> olderList = new List<T>();

        foreach (Difficulty difficulty in dictionary.Keys)
            foreach (T item in dictionary[difficulty])
                if (item.date <= date) olderList.Add(item);

        return olderList;
    }

}
