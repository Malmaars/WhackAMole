using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimer : IActive
{
    public Action timerEnd { get; set; }
    public float CurrentTime { get; set; }

    public void AdvanceTimer(float deltaTime);

    public void ResetTimer(float startTime);

}
