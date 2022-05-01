using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Message : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private TextMeshProUGUI _textObj;

    private bool _isAnimating = false;

    public IEnumerator DisplayDay()
    {
        _animator.SetTrigger("Display");

        if (Day.Number < 5)
        {
            _textObj.text = $"Day {Day.Number}";
        }
        else
        {
            _textObj.text = "Final Day";
        }

        // Wait until animation is finished
        yield return new WaitUntil(() => { return _isAnimating == true; });

        _isAnimating = false;
    }

    public IEnumerator DisplayEndResult()
    {
        _animator.SetTrigger("FadeIn");
        _textObj.text = $"Ending Gold Count:{Environment.NewLine} ";

        // Wait until animation is finished
        yield return new WaitUntil(() => { return _isAnimating == true; });
        yield return new WaitForSeconds(2f);
        _textObj.text = $"Ending Gold Count:{Environment.NewLine}{PlayerStats.Gold}";

        _isAnimating = false;
    }

    public void DoneAnimating()
    {
        _isAnimating = true;
    }
}
