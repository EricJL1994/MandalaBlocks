using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoulderEntryDisplay : MonoBehaviour
{
    [SerializeField] private Image difficultyColor = default;
    [SerializeField] private Text numberText = default;
    [SerializeField] private Text wallText = default;
    [SerializeField] private Text dateText = default;

    public Problem problem;
    public void Setup(Problem problem)
    {
        this.problem = problem;
        UpdateVisuals();
    }

    public void UpdateVisuals()
    {
        difficultyColor.color = problem.difficulty.TagColor;
        numberText.text = problem.number.ToString();
        if (problem is Boulder b) wallText.text = b.wall.ToString();
        if (problem is Traverse t) wallText.text = t.walls[0].ToString();
        dateText.text = problem.date.ToString("d");
    }

    public static GameObject InstanciateListObject(Problem problem, Transform parent)
    {
        GameObject boulderObject = Instantiate(AssetsLibrary.Instance.boulderObject, parent);
        boulderObject.GetComponent<BoulderEntryDisplay>().Setup(problem);
        return boulderObject;
    }
    
    public static GameObject InstanciateIntersectionObject(Problem problem, Transform parent)
    {
        GameObject boulderObject = Instantiate(AssetsLibrary.Instance.intersectionObject, parent);
        boulderObject.GetComponent<BoulderEntryDisplay>().Setup(problem);
        return boulderObject;
    }

    public void OnEditBoulder()
    {
        if (problem is Boulder b) BoulderEditorController.instance.OnEdit(b);
        if (problem is Traverse t) TraverseEditorController.instance.OnEdit(t);
    }

    public void OnAddIntersection()
    {
        //if (problem is Boulder b) BoulderEditorController.instance.OnEditBoulder(b);
        if (problem is Traverse t) BoulderEditorController.instance.AddIntersection(t);
    }
}
