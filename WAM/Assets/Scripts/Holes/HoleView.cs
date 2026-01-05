using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoleView : MonoBehaviour
{
    public int ID;
    public event Action<int, IHole> Clicked;
    public IHole myHole { get; private set; }

    public Image holeAbleSprite;

    public void Bind(int _ID,IHole _hole)
    {
        ID = _ID;
        myHole = _hole;

        myHole.SpawnHoleable += SetHoleAbleVisual;
        myHole.DeSpawnHoleable += RemoveHoleAbleVisual;
    }

    public void Update()
    {
        myHole.OnUpdate(Time.deltaTime);
    }

    public void OnClick()
    {
        //TODO: add an animation if I have the time

        Clicked.Invoke(ID, myHole);
    }

    public void DestroyHole()
    {
        Destroy(this.gameObject);
    }

    void SetHoleAbleVisual(IHoleable _toSpawn)
    {
        Debug.Log(_toSpawn.ResourcesVisual);
        holeAbleSprite.sprite = Resources.Load<Sprite>(_toSpawn.ResourcesVisual);
        holeAbleSprite.gameObject.SetActive(true);
    }

    void RemoveHoleAbleVisual()
    {
        holeAbleSprite.sprite = null;
        holeAbleSprite.gameObject.SetActive(false);
    }
}
