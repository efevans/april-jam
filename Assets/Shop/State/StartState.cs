using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : ShopState
{
    public StartState(ShopController gameController) : base(gameController)
    {
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartWalkIn();
        }
    }

    private void StartWalkIn()
    {
        _gameController.SetState(new WalkInState(_gameController));
    }
}
