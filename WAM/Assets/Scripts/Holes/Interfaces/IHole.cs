using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHole: IActive
{
    Vector2 Location { get; set; }

    GameObject Visual { get; set; }
    IHoleable CurrentHoleEntity { get; set; }
}
