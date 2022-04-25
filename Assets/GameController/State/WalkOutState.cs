using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkOutState : GameState
{
    public WalkOutState(GameController gameController) : base(gameController)
    {

    }

    public override void Start()
    {
        _gameController.Patron.StartCoroutine(WalkOut());
        
    }

    private IEnumerator WalkOut()
    {
        yield return _gameController.Patron.MoveToPoint(_gameController.SceneLocations.PatronOffScreenPosition.position);
        //_gameController.SetState(new StartState(_gameController));
        _gameController.SetState(new WalkInState(_gameController));
    }
}
