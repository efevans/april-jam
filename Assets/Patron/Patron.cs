using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Patron : ShopKeeper
{
    private ItemDatabase _database;
    public Item ItemForSale { get; private set; }
    public int Offer { get; private set; }

    private readonly float _upperThreshhold = 1.2f;
    private readonly float _lowerThreshhold = 0.8f;

    [Inject]
    public void Construct(ItemDatabase database)
    {
        _database = database;
    }

    // Randomize the Patron's parameters for reuse as a new seller
    public void Randomize()
    {
        ItemForSale = _database.GetRandomItem();
        Offer = (int)(_market.GetDailyPriceForItem(ItemForSale) * Random.Range(_lowerThreshhold, _upperThreshhold));
    }
}
