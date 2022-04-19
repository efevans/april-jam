using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{
    protected GameController _gameController;

    public GameState(GameController gameController)
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
