using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface ITimerView: IActive, IBusListener
{
    public GameObject[] Visuals {get;set;}

    public TextMeshProUGUI TimerText { get; set; }

    public void UpdateTimerVisual(float _currentTime);

}
