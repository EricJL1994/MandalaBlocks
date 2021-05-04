using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Problem : IEquatable<Problem>
{
    [NonSerialized] public Difficulty difficulty;
    [SerializeField] protected string dificultyName;
    public int number;
    public DateTime date;
    [NonSerialized] public ClimbingHold hold;
    [SerializeField] protected string holdColor = "Azul";
    [SerializeField] protected long dateValue;
    public bool pending = false;
    //public List<Problem> intersections;
    [SerializeField] protected string[] intersectionsName;

    public int CompareTo(object obj)
    {
        int result = obj is Problem other ?
            (!difficulty.Equals(other.difficulty) ?
            difficulty.CompareTo(other.difficulty)
            : number.CompareTo(other.number)) :
            0;
        return result;
    }

    /*public void AddIntersecion(Problem problem)
    {
        if (intersections.Contains(problem)) return;
        intersections.Add(problem);
    }

    public void SetIntersections(List<Problem> intersections)
    {
        this.intersections = intersections;
    }*/

    private string ToJSON()
    {
        return JsonUtility.ToJson(this);
    }

    public string Serialize()
    {
        dateValue = date.Ticks;
        dificultyName = difficulty.ToString();
        holdColor = hold.ToString();

        List<string> names = new List<string>();
        /*foreach (Problem problem in intersections)
        {
            names.Add(problem.ToString());
        }*/
        intersectionsName = names.ToArray();
        return ToJSON();
    }

    public void Deserialize(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
        hold = AssetsLibrary.Instance.GetClimbingHold(holdColor);
        date = new DateTime(dateValue);
    }

    public override string ToString()
    {
        return difficulty + "_" + number;
    }

    public bool Equals(Problem other)
    {
        return difficulty.Equals(other.difficulty) && number.Equals(other.number);
    }

    public string GetFileName()
    {
        return GetType().Name + "/" + ToString() + ".json";
    }
}
