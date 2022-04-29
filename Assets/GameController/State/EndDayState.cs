using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDayState : GameState
{
    public EndDayState(GameController gameController) : base(gameController)
    {
    }

    public override void Start()
    {
        _gameController.ShopKeeper.StartCoroutine(DisplayEndResults());
    }

    public IEnumerator DisplayEndResults()
    {
        yield return _gameController.ResultsList.Display();
    }
}
