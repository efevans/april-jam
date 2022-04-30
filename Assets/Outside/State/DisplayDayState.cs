using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayDayState : OutsideState
{
    public DisplayDayState(OutsideController outsideController) : base(outsideController)
    {
    }

    public override void Start()
    {
        _controller.Message.StartCoroutine(DisplayDay());
    }

    private IEnumerator DisplayDay()
    {
        yield return new WaitForSeconds(1);
        yield return _controller.Message.DisplayDay();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Shop", LoadSceneMode.Single);
    }
}
