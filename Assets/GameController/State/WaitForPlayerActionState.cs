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
        _gameController.OptionsMenu.DeclineOption.SetCallback(DeclineItem);
        _gameController.OptionsMenu.HaggleOption.SetCallback(HagglePrice);
        _gameController.OptionsMenu.SheeshOption.SetCallback(BuyItem);
    }

    private void BuyItem()
    {
        int cost = _gameController.ItemDisplay.CurrentOffer;
        _gameController.PurchaseItem(cost);
        Proceed();
    }

    private void DeclineItem()
    {
        Proceed();
    }

    private void HagglePrice()
    {
        Proceed();
    }
}
