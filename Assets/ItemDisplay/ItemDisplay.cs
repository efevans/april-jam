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

    [Inject]
    public void Construct(AudioSource audioSource, Settings settings)
    {
        _audioSource = audioSource;
        _mySettings = settings;
    }

    public void Display()
    {
        Display(_defaultItem, 0);
    }

    private void Display(Item item, int price)
    {
        _itemImage.sprite = item.Sprite;
        _priceTextObject.text = $"{price}G";
        gameObject.SetActive(true);
        _audioSource.PlayOneShot(_mySettings.OnDisplay);
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
