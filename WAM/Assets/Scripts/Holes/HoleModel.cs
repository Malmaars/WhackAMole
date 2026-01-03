using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleModel : IHoleModel
{
    public IEventBus eventBus { get; set; }

    public bool active { get; set; }

    public void OnStart() { }

    public void OnUpdate(float _DeltaTime) { }


    //Function to call whenever a hole is hit
    public void TryHitHole(int _ID, IHole _hole)
    {
        if (!active)
            return;

        eventBus.Publish(new HoleHitEvent(_hole.OnClick()));
    }

    public void GetOnBus(IEventBus _bus)
    {
        eventBus = _bus;
    }
    public void Enable()
    {
        active = true;
    }

    public void Disable()
    {
        active = false;
    }
}
