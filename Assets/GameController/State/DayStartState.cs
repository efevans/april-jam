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
        _gameController.Market.RandomizeDailyPrices();
        //_gameController.SetState(new StartState(_gameController));
        _gameController.SetState(new WalkInState(_gameController));
    }
}
