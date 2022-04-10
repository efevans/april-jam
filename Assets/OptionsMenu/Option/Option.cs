using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField]
    private Image SelectedArrow;

    public void SetSelected()
    {
        var transparentColor = SelectedArrow.color;
        transparentColor.a = 1f;
        SelectedArrow.color = transparentColor;
    }

    public void SetUnselected()
    {
        var transparentColor = SelectedArrow.color;
        transparentColor.a = 0f;
        SelectedArrow.color = transparentColor;
    }
}
