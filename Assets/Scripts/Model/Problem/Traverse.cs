using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traverse : Problem, IEquatable<Traverse>, IComparable
{
    public List<BoulderWall> walls;

    #region CONSTRUCTOR

    /// <summary>
    /// Constructor with all params
    /// </summary>
    /// <param name="difficulty"></param>
    /// <param name="number"></param>
    /// <param name="date"></param>
    /// <param name="walls"></param>
    public Traverse(Difficulty difficulty, int number, DateTime date, List<BoulderWall> walls, ClimbingHold hold)
    {
        this.difficulty = difficulty;
        this.number = number;
        this.date = date;
        this.walls = walls;
        this.hold = hold;
        //intersections = new List<Problem>();
    }

    /// <summary>
    /// Constructor for a traverse created now
    /// </summary>
    /// <param name="difficulty"></param>
    /// <param name="number"></param>
    /// <param name="wall"></param>
    public Traverse(Difficulty difficulty, int number, List<BoulderWall> wall) : this(
        difficulty, number, DateTime.Now, wall)
    { }

    /// <summary>
    /// Constructor from json
    /// </summary>
    /// <param name="json"></param>
    public Traverse(string json)
    {
        Deserialize(json);
    }

    public Traverse(Difficulty difficulty, int number, DateTime date, List<BoulderWall> wall) : this(
        difficulty, number, date, wall, AssetsLibrary.Instance.GetClimbingHold("Azul"))
    { }

    #endregion

    #region HELPERS

    public new int CompareTo(object obj)
    {
        return obj is Traverse other ?
            base.CompareTo(other) :
            0;
    }

    public bool Equals(Traverse other)
    {
        return difficulty.Equals(other.difficulty) && number.Equals(other.number);
    }

    public override int GetHashCode()
    {
        return difficulty.GetHashCode() + number.GetHashCode();
    }

    public override string ToString()
    {
        return difficulty + "_" + number /*+ "_" + date.ToString("F")*/;
    }

    #endregion

    #region JSON

    public new void Deserialize(string json)
    {
        base.Deserialize(json);
        difficulty = AssetsLibrary.Instance.GetTraverseDifficulty(dificultyName);
    }

    #endregion
}
