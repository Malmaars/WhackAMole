using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleView : MonoBehaviour
{
    public int ID;
    public event Action<int, IHole> Clicked;
    public IHole myHole { get; private set; }

    public void Bind(int _ID,IHole _hole)
    {
        ID = _ID;
        myHole = _hole;
    }

    public void OnClick()
    {
        //TODO: add an animation if I have the time

        Clicked.Invoke(ID, myHole);
    }

    public void SpawnEntity(IHoleable _toSpawn)
    {
        //spawn visual, and let the hole know what has spawned
        myHole.SpawnEntity(_toSpawn);
    }

    public void DestroyHole()
    {
        Destroy(this.gameObject);
    }
}
