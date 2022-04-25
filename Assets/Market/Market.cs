using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market
{
    private Dictionary<Item, int> _dailyPrices = new Dictionary<Item, int>();

    private ItemDatabase _database;

    private float _upperThreshhold = 1.5f;
    private float _lowerThreshhold = 0.6f;

    public Market(ItemDatabase itemDatabase)
    {
        _database = itemDatabase;
    }

    public void RandomizeDailyPrices()
    {
        _dailyPrices.Clear();

        foreach(Item item in _database.GetItems())
        {
            _dailyPrices.Add(item, RandomizePriceForItem(item));
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
