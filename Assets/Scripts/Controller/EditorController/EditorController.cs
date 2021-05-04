using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EditorController : MonoBehaviour
{
    [SerializeField] internal Text tittle = default;
    [SerializeField] internal Dropdown wallsDropdown = default;
    [SerializeField] internal Dropdown difficultiesDropdown = default;
    [SerializeField] internal Slider numberslider = default;
    [SerializeField] internal Text sliderNumberText = default;
    [SerializeField] internal InputField[] dateInputs = default;
    [SerializeField] internal Text buttonText = default;

    internal Problem editingProblem = null;

    public void OnNumberChanged()
    {
        sliderNumberText.text = numberslider.value.ToString();
    }

    internal void Setup(List<string> difficultyOptions)
    {
        wallsDropdown.AddOptions(new List<string>(Enum.GetNames(typeof(BoulderWall))));
        difficultiesDropdown.AddOptions(difficultyOptions);
        dateInputs[0].text = /*DateTime.Now.ToString("dd")*/"22";
        dateInputs[1].text = /*DateTime.Now.ToString("MM")*/"02";
        OnNumberChanged();
    }

    internal DateTime GetDate()
    {
        DateTime date;
        try
        {
            date = new DateTime(2021, int.Parse(dateInputs[1].text), int.Parse(dateInputs[0].text));

        }
        catch (ArgumentOutOfRangeException e)
        {
            //Fecha no válida
            NotificationController.Instance.ShowNotification("Fecha inválida", "La fecha introducida no es un valor válido");
            //Debug.LogError(e.Message);
            throw (e);
        }
        return date;
    }

    public void OnEdit(Problem problem)
    {
        GetComponent<Animator>().SetBool("showPanel", true);
        SetDisplay(editing: true);
        editingProblem = problem;
        difficultiesDropdown.value = problem.difficulty.Order - 1;
        numberslider.value = problem.number;
        sliderNumberText.text = problem.number.ToString();
        dateInputs[0].text = problem.date.ToString("dd");
        dateInputs[1].text = problem.date.ToString("MM");
        dateInputs[2].text = problem.date.ToString("yyyy");
    }

    public void SetDisplay(bool editing)
    {
        editingProblem = null;
        buttonText.text = editing ? "Editar" : "Crear";
        difficultiesDropdown.interactable = !editing;
        numberslider.interactable = !editing;
    }
}
