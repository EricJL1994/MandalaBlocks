using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ListHelper<T> : List<T> where T : Problem
{

    public abstract ListHelper<T> GetInstance();
    public T oldestProblem = null;

    public new bool Add(T problem)
    {
        if (Contains(problem))
        {
            NotificationController.Instance.ShowNotification("--", "Este problema ya ha sido añadido");
            return false;
        }

        CheckOlder(problem);
        base.Add(problem);
        return true;
    }

    public void Edit(T problem)
    {
        if (oldestProblem.Equals(problem)) oldestProblem = null;

        Remove(problem);
        base.Add(problem);

        CheckOldest();
    }

    private void CheckOlder(T problem)
    {
        if (oldestProblem == null || oldestProblem.date > problem.date) oldestProblem = problem;
    }

    private void CheckOldest()
    {
        oldestProblem = null;
        foreach (T problem in this)
        {
            CheckOlder(problem);
        }
    }

    public abstract ListHelper<T> GetNewList(T problem);
}
