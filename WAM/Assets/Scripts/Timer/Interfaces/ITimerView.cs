using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface ITimerView: IActive, IBusListener, IVisualManager
{
    public TextMeshProUGUI TimerText { get; set; }

    public void UpdateTimerVisual(float _currentTime);

}
