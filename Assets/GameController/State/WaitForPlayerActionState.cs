using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForPlayerActionState : GameState
{
    public WaitForPlayerActionState(GameController gameController) : base(gameController)
    {
    }

    public override void Start()
    {
        Debug.Log("waiting");
        SetupOptionsCallbacks();
    }

    private void Proceed()
    {
        _gameController.OptionsMenu.CloseDisplay();
        _gameController.ItemDisplay.CloseDisplay();
        _gameController.SetState(new WalkOutState(_gameController));
    }

    private void SetupOptionsCallbacks()
    {
        _gameController.OptionsMenu.BuyOption.SetCallback(BuyItem);
    }

    private void BuyItem()
    {
        Debug.Log("Buy");
        _gameController.PurchaseItem(80);
        Proceed();
    }
}
