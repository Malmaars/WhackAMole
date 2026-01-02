using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : IHole
{
    public bool active { get; private set; }
    
    public int Id { get; }
    public Hole(int _id)
    {
        Id = _id;
    }

    public IHoleable CurrentHoleEntity { get; set; }

    public void Enable() 
    {

    }
    public void Disable() 
    {

    }

    public int OnClick() 
    {
        int points = 1;
        //click on the thing in the hole, and maybe activate something special depending on the type of hole
        if (CurrentHoleEntity != null)
            points += CurrentHoleEntity.OnClick();

        return points;
    }

    public void SpawnEntity(IHoleable _entity)
    {
        CurrentHoleEntity = _entity;
    }
}
