using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class ResultsList : MonoBehaviour
{
    private readonly Purchases _purchases = new Purchases();
    private readonly Stack<ResultLine> _results = new Stack<ResultLine>();

    private ResultLine.Factory _resultLineFactory;
    private ShopKeeper _shopKeeper;
    private Market _market;
    private AudioSource _audioSource;
    private Settings _settings;

    [Inject]
    public void Construct(
        ResultLine.Factory factory,
        AudioSource audioSource,
        Settings settings,
        ShopKeeper shopKeeper,
        Market market)
    {
        _resultLineFactory = factory;
        _audioSource = audioSource;
        _settings = settings;
        _shopKeeper = shopKeeper;
        _market = market;
    }

    public IEnumerator Display()
    {
        gameObject.SetActive(true);
        yield return PopulateList();
        yield return new WaitForSeconds(2);
        yield return AddListItemsToGold();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
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

    private IEnumerator PopulateList()
    {
        foreach (var itemProfit in _purchases.ItemProfits)
        {
            yield return new WaitForSeconds(1f);
            _audioSource.PlayOneShot(_settings.OnDisplayLine);
            _results.Push(_resultLineFactory.Create(itemProfit));
        }
    }
    private IEnumerator AddListItemsToGold()
    {
        while (_results.Count > 0)
        {
            yield return new WaitForSeconds(0.6f);
            var line = _results.Pop();
            int dailyPrice = _market.GetDailyPriceForItem(line.ProfitSummary.Item);
            int total = line.ProfitSummary.Count * dailyPrice;
            _shopKeeper.AddGold(total);
            _audioSource.PlayOneShot(_settings.OnAddProfitsToPlayer);
            Destroy(line.gameObject);
        }
    }

    [Serializable]
    public class Settings
    {
        public AudioClip OnDisplayLine;
        public AudioClip OnAddProfitsToPlayer;
    }
}
