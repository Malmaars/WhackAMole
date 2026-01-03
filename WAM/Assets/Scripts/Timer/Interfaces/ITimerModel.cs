using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimerModel : IModel, IBusListener
{
    public Action<float> OnTimeChanged { get; set; }
    public ITimer timer { get; set; }
}
