using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkInState : ShopState
{
    public WalkInState(ShopController gameController) : base(gameController)
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

        _gameController.Patron.Randomize();
        _gameController.ItemDisplay.Display(_gameController.Patron.ItemForSale, _gameController.Patron.Offer);

        yield return new WaitForSeconds(1f);
        _gameController.SetState(new WaitForPlayerActionState(_gameController));
    }
}
