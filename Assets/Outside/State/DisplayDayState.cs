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
        if (Day.Number <= 5)
        {
            _controller.Message.StartCoroutine(DisplayDay());
        }
        else
        {
            _controller.Message.StartCoroutine(DisplayEndResult());
        }
    }

    private IEnumerator DisplayDay()
    {
        yield return new WaitForSeconds(1);
        yield return _controller.Message.DisplayDay();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Shop", LoadSceneMode.Single);
    }

    private IEnumerator DisplayEndResult()
    {
        yield return new WaitForSeconds(1);
        yield return _controller.Message.DisplayEndResult();
    }
}
