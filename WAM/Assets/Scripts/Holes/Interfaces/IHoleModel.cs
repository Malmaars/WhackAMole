using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHoleModel : IModel
{
    List<IHole> Holes { get; }
    public void TouchHoles(List<Vector2> _touches);
}
