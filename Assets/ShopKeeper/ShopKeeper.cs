using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private ShopKeeperAnimationHelper _animationHelper;
    [SerializeField]
    private EnergyFill _energyFill;

    private ItemDisplay _itemDisplay;
    private GoldDisplay _goldDisplay;
    protected Market _market;

    private readonly int DailyEnergy = 10;

    public void SaveGold()
    {
        PlayerStats.Gold = Gold;
    }

    public int Gold { get; private set; }

    [Inject]
    public void Construct(ItemDisplay itemDisplay, GoldDisplay goldDisplay, Market market)
    {
        _itemDisplay = itemDisplay;
        _goldDisplay = goldDisplay;
        _market = market;
    }

    public void Initialize()
    {
        Gold = PlayerStats.Gold;
        _goldDisplay.SetGold(Gold);
        _energyFill.SetFillMax(DailyEnergy);
    }

    public bool HasGold()
    {
        return Gold > 0;
    }

    public void SpendGold(int amount)
    {
        AddGold(-amount);
    }

    public void AddGold(int amount)
    {
        Gold += amount;
        _goldDisplay.SetGold(Gold);
    }

    public bool HasEnergy()
    {
        return _energyFill.CurrentAmount > 0;
    }

    public void SpendEnergy()
    {
        SpendEnergy(1);
    }

    public void SpendEnergy(int amount)
    {
        _energyFill.Deduct(amount);
    }

    public IEnumerator MoveToPoint(Vector2 point)
    {
        _animator.SetTrigger("StartWalking");
        SetFacedDirection(point);
        while (true)
        {
            float speed = _speed * Time.deltaTime;
            gameObject.transform.Translate(new Vector2(point.x - transform.position.x, point.y - transform.position.y).normalized * speed, Space.World);

            if (Vector2.Distance(transform.position, point) < 1)
            {
                break;
            }

            yield return null;
        }
        _animator.SetTrigger("StopWalking");
    }

    public IEnumerator ShowItem()
    {
        yield return _animationHelper.ShowItem();
    }

    public IEnumerator Research()
    {
        yield return _animationHelper.Research();
        int currentOffer = _itemDisplay.CurrentOffer;
        int dailyValue = _market.GetDailyPriceForItem(_itemDisplay.CurrentItem);

        // Display an emotion depending on the offer relative to the real value
        if (currentOffer > dailyValue * 1.1f)
        {
            // Sweat
            yield return _animationHelper.Sweat();
        }
        else if(currentOffer < dailyValue * 0.9f)
        {
            // Exclamation
            yield return _animationHelper.Exclamation();
        }
        else
        {
            // Nod
            yield return _animationHelper.Nod();
        }
    }

    private void SetFacedDirection(Vector2 point)
    {
        bool forward = transform.position.x < point.x;

        transform.rotation = Quaternion.Euler(new Vector3(0f, forward ? 0f : 180f, 0f));
    }
}
