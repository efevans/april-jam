using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Market : IInitializable
{
    private readonly Dictionary<Item, ItemPriceHistory> _itemPrices = new Dictionary<Item, ItemPriceHistory>();

    private readonly ItemDatabase _database;

    private readonly float _upperThreshhold = 1.2f;
    private readonly float _lowerThreshhold = 0.8f;

    public class ItemPriceHistory
    {
        public Item Item;
        public int Price;
        public int PreviousPrice;

        public ItemPriceHistory(Item item, int price, int previousPrice)
        {
            Item = item;
            Price = price;
            PreviousPrice = previousPrice;
        }

        public void SetNewPrice(int price)
        {
            PreviousPrice = Price;
            Price = price;
        }
    }

    public Market(ItemDatabase itemDatabase)
    {
        _database = itemDatabase;
    }

    public void Initialize()
    {
        foreach (Item item in _database.GetItems())
        {
            _itemPrices.Add(item, new ItemPriceHistory(item, RandomizePriceForItem(item), RandomizePriceForItem(item)));
        }
    }

    public void RandomizeDailyPrices()
    {
        foreach (var itemPrice in _itemPrices.Values)
        {
            itemPrice.SetNewPrice(RandomizePriceForItem(itemPrice.Item));
        }
    }

    public int GetDailyPriceForItem(Item item)
    {
        return _itemPrices.ContainsKey(item) ? _itemPrices[item].Price : 0;
    }

    public ItemPriceHistory GetItemPriceHistory(Item item)
    {
        return _itemPrices[item];
    }

    private int RandomizePriceForItem(Item item)
    {
        return (int)(item.Value * Random.Range(_lowerThreshhold, _upperThreshhold));
    }
}
