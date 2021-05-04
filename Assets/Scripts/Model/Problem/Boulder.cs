using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Model for a boulder problem
/// </summary>
public class Boulder : Problem, IEquatable<Boulder>, IComparable
{
    public BoulderWall wall;

    #region CONSTRUCTOR

    /// <summary>
    /// Constructor with all params
    /// </summary>
    /// <param name="difficulty"></param>
    /// <param name="number"></param>
    /// <param name="date"></param>
    /// <param name="wall"></param>
    public Boulder(Difficulty difficulty, int number, DateTime date, BoulderWall wall, ClimbingHold hold)
    {
        this.difficulty = difficulty;
        this.number = number;
        this.date = date;
        this.wall = wall;
        this.hold = hold;
        //this.intersections = new List<Problem>();
    }


    public Boulder(Difficulty difficulty, int number, DateTime date, BoulderWall wall) : this(
        difficulty, number, date, wall, AssetsLibrary.Instance.GetClimbingHold("Verde")) { }
    
    
    /// <summary>
    /// Constructor for a boulder created now
    /// </summary>
    /// <param name="difficulty"></param>
    /// <param name="number"></param>
    /// <param name="wall"></param>
    public Boulder(Difficulty difficulty, int number, BoulderWall wall) : this(
        difficulty, number, DateTime.Now, wall) { }


    /// <summary>
    /// Constructor from json
    /// </summary>
    /// <param name="json"></param>
    public Boulder(string json)
    {
        Deserialize(json);
    }
    
    /// <summary>
    /// Constructor to create a copy
    /// </summary>
    /// <param name="boulder"></param>
    //public Boulder(Boulder boulder) : this(boulder.difficulty, boulder.number, boulder.date, boulder.wall) { }

    #endregion

    #region HELPERS

    public new int CompareTo(object obj)
    {
        return obj is Boulder other ?
            base.CompareTo(other) :
            0;
    }

    public bool Equals(Boulder other)
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
        difficulty = AssetsLibrary.Instance.GetBoulderDifficulty(dificultyName);
    }

    #endregion
}
