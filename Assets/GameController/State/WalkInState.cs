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
        Item item = _gameController.ItemDatabase.GetRandomItem();
        _gameController.ItemDisplay.Display(item, item.Value + 10);
        yield return new WaitForSeconds(1f);
        _gameController.SetState(new WaitForPlayerActionState(_gameController));
    }
}
