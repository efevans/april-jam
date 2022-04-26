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
        if (_gameController.Energy > 0)
        {
            _gameController.SetState(new WalkInState(_gameController));
        }
    }
}
