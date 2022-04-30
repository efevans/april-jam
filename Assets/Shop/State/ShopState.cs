using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShopState
{
    protected ShopController _gameController;

    public ShopState(ShopController gameController)
    {
        _gameController = gameController;
    }

    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }
}
