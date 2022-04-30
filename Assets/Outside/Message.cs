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
        _textObj.text = $"Day {Day.Number}";

        // Wait until animation is finished
        yield return new WaitUntil(() => { return _isAnimating == true; });

        _isAnimating = false;
    }

    public void DisplayDone()
    {
        _isAnimating = true;
    }
}
