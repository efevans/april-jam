using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayStartState : GameState
{
    public DayStartState(GameController gameController) : base(gameController)
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
        // If this is the first day, always display a general tip, otherwise randomize between general and price
        yield return _gameController.DailyTip.DisplayGeneralTip();
    }
}
