using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHoleModel : IModel, IBusListener
{
    public void TryHitHole(int _ID, IHole _hole);
}
