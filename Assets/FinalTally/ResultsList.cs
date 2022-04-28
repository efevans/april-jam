using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class ResultsList : MonoBehaviour
{
    private Purchases _purchases = new Purchases();
    private ResultLine.Factory _resultLineFactory;

    [Inject]
    public void Construct(ResultLine.Factory factory)
    {
        _resultLineFactory = factory;
    }

    public void Display()
    {
        PopulateList();
        gameObject.SetActive(true);
    }

    private void PopulateList()
    {
        foreach (var itemProfit in _purchases.ItemProfits)
        {
            _resultLineFactory.Create(itemProfit);
        }
    }

    public void LogPurchase(Item item, int purchasePrice, int marketPrice)
    {
        _purchases.LogPurchase(item, purchasePrice, marketPrice);
    }

    public class Purchases
    {
        private readonly Dictionary<Item, ProfitSummary> _itemProfits = new Dictionary<Item, ProfitSummary>();
        public IReadOnlyList<ProfitSummary> ItemProfits => _itemProfits.Values.ToList().AsReadOnly();

        public class ProfitSummary
        {
            public Item Item { get; private set; }
            public int Count { get; private set; }
            public int Profit { get; private set; }

            public ProfitSummary(Item item)
            {
                Item = item;
                Count = 0;
                Profit = 0;
            }

            public void LogPurchase(int profits)
            {
                Count++;
                Profit += profits;
            }
        }

        public void LogPurchase(Item item, int purchasePrice, int marketPrice)
        {
            if (false == _itemProfits.ContainsKey(item))
            {
                _itemProfits.Add(item, new ProfitSummary(item));
            }

            _itemProfits[item].LogPurchase(marketPrice - purchasePrice);
        }
    }
}
