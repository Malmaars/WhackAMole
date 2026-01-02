using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHole: IActive, IClickable
{
    int Id { get; }
    IHoleable CurrentHoleEntity { get; set; }

    public void SpawnEntity(IHoleable _entity);
}
