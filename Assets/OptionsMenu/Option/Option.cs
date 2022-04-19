using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField]
    private Image SelectedArrow;

    public Option LeftDestination { get; set; }
    public Option RightDestination { get; set; }
    public Option UpDestination { get; set; }
    public Option DownDestination { get; set; }

    private Action _onSelect;

    public void Select()
    {
        _onSelect();
    }

    public void SetCallback(Action onSelect)
    {
        _onSelect = onSelect;
    }

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
