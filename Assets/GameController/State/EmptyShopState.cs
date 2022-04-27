using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyShopState : GameState
{
    public EmptyShopState(GameController gameController) : base(gameController)
    {
    }

    public override void Start()
    {
        if (_gameController.ShopKeeper.HasEnergy())
        {
            _gameController.SetState(new WalkInState(_gameController));
        }
    }
}
