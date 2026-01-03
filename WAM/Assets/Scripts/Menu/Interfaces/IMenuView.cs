using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMenuView: IActive
{
    public GameObject[] MenuVisuals { get; set; }
}
