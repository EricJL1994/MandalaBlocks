using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[ExecuteInEditMode]
public class ColorChanger : MonoBehaviour
{
    public enum FlexibleUIType
    {
        Base,
        Dialog,
        Editor,
        Button,
        Aux
    }
    //public UIColor UIColor;
    public FlaxibleUI skin;
    public FlexibleUIType type;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    void Start()
    {
        OnSkinUI();
    }

    protected virtual void OnSkinUI()
    {
        switch (type)
        {
            case FlexibleUIType.Base:
                image.color = skin.baseColor;
                break;
            case FlexibleUIType.Dialog:
                image.color = skin.dialogColor;
                break;
            case FlexibleUIType.Editor:
                image.color = skin.editorColor;
                break;
            case FlexibleUIType.Button:
                image.color = skin.buttonColor;
                break;
            case FlexibleUIType.Aux:
                image.color = skin.auxColor;
                break;
            default:
                break;
        }
    }

    //ELIMINAR CUANDO ESTÉ TERMINADO
    private void Update()
    {
        if (Application.isEditor)
        {
            OnSkinUI();
        }
    }
}
