using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : IHole
{
    public bool active { get; private set; }
    public Hole(Vector2 _location)
    {
        Location = _location;
    }

    public Vector2 Location { get; set; }
    public GameObject Visual { get; set; }
    public IHoleable CurrentHoleEntity { get; set; }

    public void Enable() { }
    public void Disable() { }
}
