using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market
{
    private Dictionary<Item, int> _dailyPrices = new Dictionary<Item, int>();

    private readonly ItemDatabase _database;

    private readonly float _upperThreshhold = 1.2f;
    private readonly float _lowerThreshhold = 0.8f;

    public Market(ItemDatabase itemDatabase)
    {
        _database = itemDatabase;
    }

    public void RandomizeDailyPrices()
    {
        _dailyPrices.Clear();
        Debug.Log($"Randomizing {_database.GetItems().Count} prices");

        foreach (Item item in _database.GetItems())
        {
            _dailyPrices.Add(item, ScreenPrinter.Debug(item.Name, RandomizePriceForItem(item)));
        }
    }

    public int GetDailyPriceForItem(Item item)
    {
        return _dailyPrices.ContainsKey(item) ? _dailyPrices[item] : 0;
    }

    private int RandomizePriceForItem(Item item)
    {
        return (int)(item.Value * Random.Range(_lowerThreshhold, _upperThreshhold));
    }
}
