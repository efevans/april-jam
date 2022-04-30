using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class OutsideController : IInitializable
{
    private OutsideState _state;
    public readonly Message Message;

    private OutsideState DefaultState => new DisplayDayState(this);

    public OutsideController(Message message)
    {
        Message = message;
    }

    public void Initialize()
    {
        Day.Number++;
        SetState(DefaultState);
    }

    public void SetState(OutsideState outsideState)
    {
        _state = outsideState;
        _state.Start();
    }
}
