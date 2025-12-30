using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSpawner
{
    public List<IHole> SpawnHoles(int _amountOfHoles)
    {
        if(_amountOfHoles <= 0)
        {
            Debug.LogError("Can't spawn less than 1 hole");
            return null;
        }

        //TODO spawn holes at varying locations based on the amount of holes
        List<IHole> spawnedHoles = new List<IHole>();
        for(int i = 0; i < _amountOfHoles; i++)
        {
            IHole h = new Hole(Vector2.zero);
            spawnedHoles.Add(h);
        }
        return spawnedHoles;
    }
}
