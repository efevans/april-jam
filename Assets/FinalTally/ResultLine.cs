using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

using ProfitSummary = ResultsList.Purchases.ProfitSummary;

public class ResultLine : MonoBehaviour
{
    [SerializeField]
    private Image _itemImage;
    [SerializeField]
    private TextMeshProUGUI _itemCountText;
    [SerializeField]
    private TextMeshProUGUI _profitsText;

    public ProfitSummary ProfitSummary { get; private set; }

    [Inject]
    public void Construct(ProfitSummary profitSummary)
    {
        ProfitSummary = profitSummary;
    }

    private void OnEnable()
    {
        _itemImage.sprite = ProfitSummary.Item.Sprite;
        _itemCountText.text = $"x{ProfitSummary.Count}";
        _profitsText.text = $"{(ProfitSummary.Profit > 0 ? "+" : "")}{ProfitSummary.Profit}";
    }

    public class Factory : PlaceholderFactory<ProfitSummary, ResultLine> { }
}
