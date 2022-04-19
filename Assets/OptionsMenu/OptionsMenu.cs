using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class OptionsMenu : MonoBehaviour
{
    public Option BuyOption;
    public Option DeclineOption;
    public Option HaggleOption;
    public Option SheeshOption;

    private Option CurrentOption;

    private AudioSource _audioSource;
    private Settings _mySettings;

    [Inject]
    public void Construct(AudioSource audioSource, Settings settings)
    {
        _audioSource = audioSource;
        _mySettings = settings;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        UnselectAll();
        SetOptions();
        SetCurrentOption(BuyOption);
    }

    public void Display()
    {
        gameObject.SetActive(true);
    }

    public void CloseDisplay()
    {
        gameObject.SetActive(false);
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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (CurrentOption != null)
            {
                CurrentOption.Select();
            }
        }

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

        if (option != null)
        {
            CurrentOption.SetSelected();
            _audioSource.PlayOneShot(_mySettings.OnMoveCursor);
        }
    }

    [Serializable]
    public class Settings
    {
        public AudioClip OnMoveCursor;
    }
}
