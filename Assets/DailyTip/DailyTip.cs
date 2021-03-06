using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class DailyTip : MonoBehaviour
{
    public enum Change
    {
        Increased,
        Decreased
    }

    [SerializeField]
    private TextMeshProUGUI tipText;
    [SerializeField]
    private Animator _animator;
    private bool _displayAnimationFinished = false;
    private bool _fadeOutFinished = false;

    private Market _market;
    private ItemDatabase _itemDatabase;

    private readonly List<string> _tips = new List<string>()
    {
        "prices will change each day...",
        $"watch out for people{Environment.NewLine}trying to cheat you...",
        $"if you think you are being swindled,{Environment.NewLine}declining early is best",
        $"you can research an item to determine{Environment.NewLine}the fairness of the offer",
        $"researching earlier in the day{Environment.NewLine}is better"
    };

    [Inject]
    public void Construct(Market market, ItemDatabase itemDatabase)
    {
        _market = market;
        _itemDatabase = itemDatabase;
    }

    public IEnumerator DisplayTip()
    {
        if (Day.Number == 1)
        {
            yield return DisplayGeneralTip();
        }
        else
        {
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                yield return DisplayGeneralTip();
            }
            else
            {
                yield return DisplayPriceTip();
            }
        }
    }

    public IEnumerator DisplayGeneralTip()
    {
        string randomTip = _tips[UnityEngine.Random.Range(0, _tips.Count)];
        yield return Display(randomTip);
    }

    public IEnumerator DisplayPriceTip()
    {
        // Get Random item
        Item item = _itemDatabase.GetRandomItem();
        Market.ItemPriceHistory priceHistory = _market.GetItemPriceHistory(item);
        Change change = priceHistory.Price > priceHistory.PreviousPrice ? Change.Increased : Change.Decreased;

        string text = FormatPriceString(item, change);

        yield return Display(text);
    }

    public void DisplayFinished()
    {
        _displayAnimationFinished = true;
    }

    public IEnumerator FadeOut()
    {
        // play animation
        _animator.SetTrigger("FadeOut");

        // wait for animation end message to be received
        yield return new WaitUntil(() => { return _fadeOutFinished == true; });

        _fadeOutFinished = false;
    }

    public void FadeOutFinished()
    {
        _fadeOutFinished = true;
    }

    private IEnumerator Display(string text)
    {
        tipText.text = text;

        // play animation
        _animator.SetTrigger("Display");

        // wait for animation end message to be received
        yield return new WaitUntil(() => { return _displayAnimationFinished == true; });

        _displayAnimationFinished = false;
    }

    private string FormatPriceString(Item item, Change change)
    {
        return $"you hear the price of{Environment.NewLine}" +
            $"{item.Name}{Environment.NewLine}" +
            $"has {change.ToString().ToLower()} recently...";
    }
}
