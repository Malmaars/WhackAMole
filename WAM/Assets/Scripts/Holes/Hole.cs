using System;
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

        timeUntilSpawn = UnityEngine.Random.Range(1f, 4f);
        timeUntilDeSpawn = UnityEngine.Random.Range(1f, 2f);

        timer = new CountDownTimer();
        timer.ResetTimer(timeUntilSpawn);
        spawned = false;
        timer.timerEnd += SpawnOrDespawn;
        timer.Enable();
    }

    public Action<IHoleable> SpawnHoleable { get; set; }
    public Action DeSpawnHoleable { get; set; }

    bool spawned;
    public float timeUntilSpawn { get; set; }
    public float timeUntilDeSpawn { get; set; }

    ITimer timer;

    public IHoleable CurrentHoleEntity { get; set; }

    public IHoleable[] possibleSpawns { get;set; } = new IHoleable[] { new Mole(), new RedMole(), new BlueMole() };

    public void OnUpdate(float deltaTime)
    {
        timer.AdvanceTimer(deltaTime);

    }
    public void Enable() 
    {

    }
    public void Disable() 
    {

    }

    public int OnClick() 
    {
        int points = 0;
        //click on the thing in the hole, and maybe activate something special depending on the type of hole
        if (CurrentHoleEntity != null)
        {
            points += CurrentHoleEntity.OnClick();
            if (CurrentHoleEntity.Health <= 0)
                SpawnOrDespawn();
        }

        //give a penalty when hitting a hole that does not have a mole in it
        else
            points += -1;

        return points;
    }

    void SpawnOrDespawn()
    {
        if (spawned)
        {
            RemoveEntity();
            spawned = false;
            timer.ResetTimer(timeUntilSpawn);
            DeSpawnHoleable.Invoke();
            return;
        }

        IHoleable holeSpawn = possibleSpawns[UnityEngine.Random.Range(0, possibleSpawns.Length)];
        SpawnEntity(holeSpawn);
        timer.ResetTimer(timeUntilDeSpawn);
        SpawnHoleable.Invoke(holeSpawn);
        spawned = true;
    }

    public void SpawnEntity(IHoleable _entity)
    {
        CurrentHoleEntity = _entity;
    }

    public void RemoveEntity()
    {
        CurrentHoleEntity = null;
    }
}
