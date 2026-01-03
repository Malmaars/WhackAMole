using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuModel : IMenuModel
{
    public IEventBus eventBus { get; set; }

    public bool active { get; set; }

    public void StartGame()
    {
        eventBus.Publish(new StartGameEvent());
    }

    public void ShowHighScores()
    {
        eventBus.Publish(new ShowHighScoresEvent());
    }

    public void OnStart() { }

    public void OnUpdate(float _DeltaTime) { }

    public void GetOnBus(IEventBus _bus)
    {
        eventBus = _bus;
    }

    public void Disable()
    {
        active = false;
    }

    public void Enable()
    {
        active = true;
    }
}
