using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ItemDisplay : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _itemImage;

    [SerializeField]
    private TextMeshProUGUI _priceTextObject;

    private AudioSource _audioSource;
    private Settings _mySettings;

    [SerializeField]
    private Item _defaultItem;

    public Item CurrentItem { get; private set; }
    public int CurrentOffer { get; private set; }

    [Inject]
    public void Construct(AudioSource audioSource, Settings settings)
    {
        _audioSource = audioSource;
        _mySettings = settings;
    }

    public void Display()
    {
        Display(_defaultItem, _defaultItem.Value);
    }

    public void Display(Item item, int price)
    {
        CurrentItem = item;
        CurrentOffer = price;
        UpdateDisplay();
        gameObject.SetActive(true);
        _audioSource.PlayOneShot(_mySettings.OnDisplay);
    }

    private void UpdateDisplay()
    {
        _itemImage.sprite = CurrentItem.Sprite;
        _priceTextObject.text = $"{CurrentOffer}G";
    }

    public void CloseDisplay()
    {
        gameObject.SetActive(false);
    }

    [Serializable]
    public class Settings
    {
        public AudioClip OnDisplay;
    }
}
