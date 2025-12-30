using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActive
{
    public bool active { get; }

    public void Enable();
    public void Disable();
}
