using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleModel : IHoleModel
{
    public IEventBus EventBus { get; set; }

    public void OnStart() { }

    public void OnUpdate(float _DeltaTime) { }

    public void TryHitHole(int _ID, IHole _hole)
    {
        EventBus.Publish(new HoleHitEvent(_hole.OnClick()));
    }

    public void GetOnBus(IEventBus _bus)
    {
        EventBus = _bus;
    }
}
