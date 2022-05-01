using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayStartState : ShopState
{
    public DayStartState(ShopController gameController) : base(gameController)
    {
    }

    public override void Start()
    {
        _gameController.ShopKeeper.StartCoroutine(StartDay());
    }

    public IEnumerator StartDay()
    {
        _gameController.Market.RandomizeDailyPrices();
        yield return DisplayTipOfTheDay();
        _gameController.SetState(new WalkInState(_gameController));
    }

    private IEnumerator DisplayTipOfTheDay()
    {
        yield return _gameController.DailyTip.DisplayTip();
    }
}
