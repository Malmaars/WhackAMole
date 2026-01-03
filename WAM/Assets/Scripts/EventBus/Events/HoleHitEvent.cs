using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleHitEvent : IDomainEvent
{
    public int Points { get; set; }

    public HoleHitEvent(int points)
    {
        Points = points;
    }
}