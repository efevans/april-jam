using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class OutsideState
{
    protected OutsideController _controller;

    public OutsideState(OutsideController outsideController)
    {
        _controller = outsideController;
    }

    public virtual void Start() { }
    public virtual void Update() { }
}
