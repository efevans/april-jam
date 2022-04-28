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

    private ProfitSummary _profits;

    [Inject]
    public void Construct(ProfitSummary profitSummary)
    {
        _profits = profitSummary;
    }

    private void OnEnable()
    {
        _itemImage.sprite = _profits.Item.Sprite;
        _itemCountText.text = _profits.Count.ToString();
        _profitsText.text = $"{(_profits.Profit > 0 ? "+" : "")}{_profits.Profit}";
    }

    public class Factory : PlaceholderFactory<ProfitSummary, ResultLine> { }
}
