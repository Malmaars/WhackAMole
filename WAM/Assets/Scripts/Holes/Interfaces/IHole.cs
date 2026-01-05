using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHole : IActive, IClickable, IUpdate
{
    float timeUntilSpawn { get; set; }
    float timeUntilDeSpawn { get; set; }
    int Id { get; }
    IHoleable CurrentHoleEntity { get; set; }

    IHoleable[] possibleSpawns { get; set; }

    public Action<IHoleable> SpawnHoleable { get; set; }
    public Action DeSpawnHoleable { get; set; }
    public void SpawnEntity(IHoleable _entity);

    public void RemoveEntity();
}
