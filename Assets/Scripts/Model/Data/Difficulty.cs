using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Difficulty/Difficulty Data", fileName = "Difficulty_")]
public class Difficulty : ScriptableObject, IComparable, IEquatable<Difficulty>
{
    [SerializeField] private string minDifficulty;
    [SerializeField] private string maxDifficulty;
    [SerializeField] private Color tagColor = default;
    [SerializeField] private int order = 0;

    public Color TagColor => tagColor;
    public int Order => order;
    public int CompareTo(object obj)
    {
        return obj is Difficulty other ? order.CompareTo(other.order) : 0;
    }

    public bool Equals(Difficulty other)
    {
        return name.Equals(other.name);
    }

    public override string ToString()
    {
        return name.Split('_')[1];
    }
}
