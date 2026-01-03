using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownTimer : ITimer
{
    public Action timerEnd { get; set; }

    public bool active { get; set; }
    public float CurrentTime { get; set; }

    public void ResetTimer(float startTime)
    {
        CurrentTime = startTime;
    }
    public void AdvanceTimer(float deltaTime)
    {
        if (!active)
            return;

        CurrentTime -= deltaTime;

        if(CurrentTime < 0)
            timerEnd.Invoke();
    }

    public void Enable()
    {
        active = true;
    }

    public void Disable()
    {
        active = false;
    }
}
