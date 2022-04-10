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
        UnselectAll();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (CurrentOption == BuyOption)
            {
                CurrentOption = DeclineOption;
            }
            else if (CurrentOption == DeclineOption)
            {
                CurrentOption = HaggleOption;
            }
            else if (CurrentOption == HaggleOption)
            {
                CurrentOption = SheeshOption;
            }
            else if (CurrentOption == SheeshOption)
            {
                CurrentOption = BuyOption;
            }
            else
            {
                CurrentOption = BuyOption;
            }
            UnselectAll();
            CurrentOption.SetSelected();
        }
    }

    private void UnselectAll()
    {
        BuyOption.SetUnselected();
        DeclineOption.SetUnselected();
        HaggleOption.SetUnselected();
        SheeshOption.SetUnselected();
    }
}
