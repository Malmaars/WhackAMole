using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HoleHitEvent : IDomainEvent
{
    public int Points { get; set; }

    public HoleHitEvent(int points)
    {
        Points = points;
    }
}