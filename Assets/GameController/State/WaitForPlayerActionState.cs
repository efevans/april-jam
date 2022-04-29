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
        ShowOptions();
        SetupOptionsCallbacks();
    }

    private void Proceed()
    {
        HideOptions();
        _gameController.ItemDisplay.CloseDisplay();
        _gameController.SetState(new WalkOutState(_gameController));
    }

    private void ShowOptions()
    {
        _gameController.OptionsMenu.Display();
    }

    private void HideOptions()
    {
        _gameController.OptionsMenu.CloseDisplay();
    }

    private void SetupOptionsCallbacks()
    {
        _gameController.OptionsMenu.BuyOption.SetCallback(BuyItem);
        _gameController.OptionsMenu.DeclineOption.SetCallback(DeclineItem);
        _gameController.OptionsMenu.ResearchOption.SetCallback(Research);
        _gameController.OptionsMenu.SheeshOption.SetCallback(BuyItem);
    }

    private void BuyItem()
    {
        _gameController.ShopKeeper.SpendEnergy();
        int cost = _gameController.ItemDisplay.CurrentOffer;
        _gameController.PurchaseItem(_gameController.ItemDisplay.CurrentItem, cost);
        Proceed();
    }

    private void DeclineItem()
    {
        _gameController.ShopKeeper.SpendEnergy();
        Proceed();
    }

    private void Research()
    {
        _gameController.ShopKeeper.SpendEnergy();
        _gameController.ShopKeeper.StartCoroutine(PlayoutResearch());
    }

    private IEnumerator PlayoutResearch()
    {
        HideOptions();
        yield return _gameController.ShopKeeper.Research();
        ShowOptions();
    }
}
