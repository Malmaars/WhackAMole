using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour, IActive, IBusListener
{
    IHoleModel model;
    HoleFactory factory;

    public int holeAmount;
    List<HoleView> holes;

    public bool active { get; set; }
    public IEventBus eventBus { get; set; }


    public void Initialize(IHoleModel _model, HoleFactory _factory)
    {
        model = _model;
        factory = _factory;
    }

    public void SpawnHoles(int _amount)
    {
        DestroyHoles();

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

    //removes and destroys all current holes
    void DestroyHoles()
    {
        if (holes != null && holes.Count > 0)
        {
            //remove all current holes, and put down new ones]
            for (int i = 0; i < holes.Count; i++)
            {
                holes[i].DestroyHole();
            }
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

    void InitializeGame(IDomainEvent _event)
    {
        Enable();
        SpawnHoles(6);
    }

    public void EndGame(IDomainEvent _event)
    {
        RemoveAndDisable();
    }


    public void GetOnBus(IEventBus _bus)
    {
        eventBus = _bus;
        eventBus.Subscribe<StartGameEvent>(InitializeGame);
        eventBus.Subscribe<EndGameEvent>(EndGame);
    }

    public void Enable()
    {
        model.Enable();
        active = true;
    }

    public void Disable()
    {
        model.Disable();
        active = false;
    }

    //First destroy all holes, then disable the controller and model
    public void RemoveAndDisable()
    {
        DestroyHoles();
        Disable();
    }
}
