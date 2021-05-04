using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Climbing Holds/Color", fileName = "ClimbingHolds_")]
public class ClimbingHold : ScriptableObject, IComparable
{
    public Color color;

    public int CompareTo(object obj)
    {
        return obj is ClimbingHold other ? ToString().CompareTo(other.ToString()) : 0;
    }

    public override string ToString()
    {
        return name.Split('_')[1];
    }
}
