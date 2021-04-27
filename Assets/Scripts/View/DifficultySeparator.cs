using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySeparator : MonoBehaviour
{
    public Difficulty boulderDifficulty;

    [SerializeField] private Image difficultyColor = default;
    [SerializeField] private Text difficultyText = default;

    public void Setup(Difficulty difficulty)
    {
        boulderDifficulty = difficulty;
        UpdateVisuals();
    }

    public void UpdateVisuals()
    {
        Color tagColor = boulderDifficulty.TagColor;
        tagColor.a = .6f;
        difficultyColor.color = tagColor;
        difficultyText.text = boulderDifficulty.ToString();
    }
}
