using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : GameState
{
    public StartState(GameController gameController) : base(gameController)
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
