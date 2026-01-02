using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour
{
    IHoleModel model;
    HoleFactory factory;

    public int holeAmount;
    List<HoleView> holes;

    public void Initialize(IHoleModel _model, HoleFactory _factory)
    {
        model = _model;
        factory = _factory;
        SpawnHoles(6);

    }

    private void Update()
    {

    }

    public void SpawnHoles(int _amount)
    {
        if(holes != null && holes.Count > 0)
        {
            //remove all current holes, and put down new ones]
            for(int i = 0; i < holes.Count; i++)
            {
                holes[i].DestroyHole();
            }
        }

        holes = new List<HoleView>();
        factory.DefineAmountOfHoles(_amount);
        for (int i = 0; i < _amount; i++)
        {
            IHole spawnedHole = new Hole(i);
            HoleView view = factory.Create(i, spawnedHole);
            holes.Add(view);
            view.Clicked += OnHoleClicked;
        }
    }

    public void SpawnSomethingInHole(int _holeID, IHoleable _ToSpawn)
    {
        holes[_holeID].SpawnEntity(_ToSpawn);
    }

    void OnHoleClicked(int _ID, IHole _hole)
    {
        model.TryHitHole(_ID, _hole);
    }
}
