using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerModel : ITimerModel
{
    public Action<float> OnTimeChanged { get; set; }
    public IEventBus eventBus { get; set; }
    public ITimer timer { get; set; }

    public TimerModel(ITimer _timer)
    {
        timer = _timer;
        timer.timerEnd += EndGame;
    }

    public void OnStart() { }

    public void OnUpdate(float _DeltaTime)
    {
        timer.AdvanceTimer(_DeltaTime);
        OnTimeChanged.Invoke(timer.CurrentTime);
    }

    void InitializeTimer(IDomainEvent _event)
    {
        //for now I seet this to 60 seconds, but it's possible to set a different time
        timer.ResetTimer(60);
        timer.Enable();
    }

    void EndGame()
    {
        eventBus.Publish(new EndGameEvent());
    }

    void EndTimer(IDomainEvent _event)
    {
        timer.Disable();
    }

    public void GetOnBus(IEventBus _bus)
    {
        eventBus = _bus;
        eventBus.Subscribe<StartGameEvent>(InitializeTimer);
        eventBus.Subscribe<EndGameEvent>(EndTimer);
    }
}
