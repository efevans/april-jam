using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField]
    private Option BuyOption;

    [SerializeField]
    private Option DeclineOption;

    [SerializeField]
    private Option HaggleOption;

    [SerializeField]
    private Option SheeshOption;

    private Option CurrentOption;


    // Start is called before the first frame update
    void Start()
    {
        CurrentOption = null;
        SetOptions();
        UnselectAll();
    }

    private void SetOptions()
    {
        BuyOption.LeftDestination = BuyOption.RightDestination = DeclineOption;
        BuyOption.DownDestination = BuyOption.UpDestination = HaggleOption;

        DeclineOption.LeftDestination = DeclineOption.RightDestination = BuyOption;
        DeclineOption.DownDestination = DeclineOption.UpDestination = SheeshOption;

        HaggleOption.LeftDestination = HaggleOption.RightDestination = SheeshOption;
        HaggleOption.DownDestination = HaggleOption.UpDestination = BuyOption;

        SheeshOption.LeftDestination = SheeshOption.RightDestination = HaggleOption;
        SheeshOption.DownDestination = SheeshOption.UpDestination = DeclineOption;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (CurrentOption == null)
            {
                SetCurrentOption(BuyOption);
            }
            else
            {
                SetCurrentOption(CurrentOption.RightDestination);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (CurrentOption == null)
            {
                SetCurrentOption(BuyOption);
            }
            else
            {
                SetCurrentOption(CurrentOption.LeftDestination);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (CurrentOption == null)
            {
                SetCurrentOption(BuyOption);
            }
            else
            {
                SetCurrentOption(CurrentOption.UpDestination);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (CurrentOption == null)
            {
                SetCurrentOption(BuyOption);
            }
            else
            {
                SetCurrentOption(CurrentOption.DownDestination);
            }
        }
    }

    private void UnselectAll()
    {
        BuyOption.SetUnselected();
        DeclineOption.SetUnselected();
        HaggleOption.SetUnselected();
        SheeshOption.SetUnselected();
    }

    private void SetCurrentOption(Option option)
    {
        UnselectAll();
        CurrentOption = option;
        CurrentOption.SetSelected();
    }
}
