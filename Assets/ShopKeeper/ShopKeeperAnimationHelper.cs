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
    private bool _researchAnimationFinished = false;
    private bool _sweatAnimationFinished = false;
    private bool _exclamationAnimationFinished = false;
    private bool _nodAnimationFinished = false;

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

    public IEnumerator Research()
    {
        Animator.SetTrigger("Research");

        // Wait until animation is finished
        yield return new WaitUntil(() => { return _researchAnimationFinished == true; });

        _researchAnimationFinished = false;
    }

    public void ResearchAnimationFinished()
    {
        _researchAnimationFinished = true;
    }

    public IEnumerator Sweat()
    {
        Animator.SetTrigger("Sweat");

        // Wait until animation is finished
        yield return new WaitUntil(() => { return _sweatAnimationFinished == true; });

        _sweatAnimationFinished = false;
    }

    public void SweatAnimationFinished()
    {
        _sweatAnimationFinished = true;
    }

    public IEnumerator Exclamation()
    {
        Animator.SetTrigger("Exclamation");

        // Wait until animation is finished
        yield return new WaitUntil(() => { return _exclamationAnimationFinished == true; });

        _exclamationAnimationFinished = false;
    }

    public void ExclamationAnimationFinished()
    {
        _exclamationAnimationFinished = true;
    }

    public IEnumerator Nod()
    {
        Animator.SetTrigger("Nod");

        // Wait until animation is finished
        yield return new WaitUntil(() => { return _nodAnimationFinished == true; });

        _nodAnimationFinished = false;
    }

    public void NodAnimationFinished()
    {
        _nodAnimationFinished = true;
    }
}
