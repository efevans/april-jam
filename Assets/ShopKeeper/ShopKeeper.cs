using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField]
    private Animator Animator;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private ShopKeeperAnimationHelper AnimationHelper;

    private ItemDisplay _itemDisplay;
    protected Market _market;

    [Inject]
    public void Construct(ItemDisplay itemDisplay, Market market)
    {
        _itemDisplay = itemDisplay;
        _market = market;
    }

    public IEnumerator MoveToPoint(Vector2 point)
    {
        Animator.SetTrigger("StartWalking");
        SetFacedDirection(point);
        while (true)
        {
            float speed = Speed * Time.deltaTime;
            gameObject.transform.Translate(new Vector2(point.x - transform.position.x, point.y - transform.position.y).normalized * speed, Space.World);

            if (Vector2.Distance(transform.position, point) < 1)
            {
                break;
            }

            yield return null;
        }
        Animator.SetTrigger("StopWalking");
    }

    public IEnumerator ShowItem()
    {
        yield return AnimationHelper.ShowItem();
    }

    public IEnumerator Research()
    {
        yield return AnimationHelper.Research();
        int currentOffer = _itemDisplay.CurrentOffer;
        int dailyValue = _market.GetDailyPriceForItem(_itemDisplay.CurrentItem);

        // Display an emotion depending on the offer relative to the real value
        if (currentOffer > dailyValue * 1.1f)
        {
            // Sweat
            yield return AnimationHelper.Sweat();
        }
        else if(currentOffer < dailyValue * 0.9f)
        {
            // Exclamation
            yield return AnimationHelper.Exclamation();
        }
        else
        {
            // Nod
            yield return AnimationHelper.Nod();
        }
    }

    private void SetFacedDirection(Vector2 point)
    {
        bool forward = transform.position.x < point.x;

        transform.rotation = Quaternion.Euler(new Vector3(0f, forward ? 0f : 180f, 0f));
    }
}
