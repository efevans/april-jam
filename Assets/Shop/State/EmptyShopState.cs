using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyShopState : ShopState
{
    public EmptyShopState(ShopController gameController) : base(gameController)
    {
    }

    public override void Start()
    {
        if (DayCanContinue())
        {
            _gameController.SetState(new WalkInState(_gameController));
        }
        else
        {
            _gameController.SetState(new EndDayState(_gameController));
        }
    }

    private bool DayCanContinue()
    {
        return _gameController.ShopKeeper.HasEnergy() && _gameController.ShopKeeper.HasGold();
    }
}
