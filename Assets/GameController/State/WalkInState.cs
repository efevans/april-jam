using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkInState : GameState
{
    public WalkInState(GameController gameController) : base(gameController)
    {
    }

    public override void Start()
    {
        _gameController.Patron.StartCoroutine(WalkIn());
    }

    private IEnumerator WalkIn()
    {
        yield return _gameController.Patron.MoveToPoint(_gameController.SceneLocations.PatronStandPosition.position);
        yield return _gameController.Patron.ShowItem();
        _gameController.ItemDisplay.Display();
        yield return new WaitForSeconds(1f);
        _gameController.OptionsMenu.Display();
        _gameController.SetState(new WaitForPlayerActionState(_gameController));
    }
}
