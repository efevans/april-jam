using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The animator has to be on the same gameobject as the callback method for animation events,
// so I'll use this as a proxy for the script on the parent object
public class ShopKeeperAnimationHelper : MonoBehaviour
{
    [SerializeField]
    private Animator Animator;

    private bool _showItemAnimationFinished = false;

    public IEnumerator ShowItem()
    {
        Animator.SetTrigger("ShowItem");

        // Wait until animation is finished
        yield return new WaitUntil(() => { return _showItemAnimationFinished == true; });

        _showItemAnimationFinished = false;
    }

    public void ShowItemAnimationFinished()
    {
        _showItemAnimationFinished = true;
    }
}
