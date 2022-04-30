using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDayState : ShopState
{
    public EndDayState(ShopController gameController) : base(gameController)
    {
    }

    public override void Start()
    {
        _gameController.ShopKeeper.StartCoroutine(DisplayEndResults());
    }

    public IEnumerator DisplayEndResults()
    {
        yield return _gameController.ResultsList.Display();
        _gameController.ShopKeeper.SaveGold();
        _gameController.ResultsList.Hide();
        yield return new WaitForSeconds(1);
        yield return _gameController.DailyTip.FadeOut();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Outside");
    }
}
