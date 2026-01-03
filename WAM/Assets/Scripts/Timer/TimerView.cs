using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour, ITimerView
{
    public IEventBus eventBus { get; set; }

    public GameObject[] Visuals { get { return visuals; } set { visuals = value; } }
    public GameObject[] visuals;

    public TextMeshProUGUI TimerText { get { return timerText; } set { timerText = value; } }
    public TextMeshProUGUI timerText;
    
    public bool active { get; set; }

    public void UpdateTimerVisual(float _currentTime)
    {
        TimerText.text = (Mathf.Ceil(_currentTime)).ToString();
    }

    public void GetOnBus(IEventBus _bus)
    {
        eventBus = _bus;
        eventBus.Subscribe<StartGameEvent>(EnableOnEvent);
        eventBus.Subscribe<EndGameEvent>(DisableOnEvent);
        eventBus.Subscribe<ShowMenuEvent>(DisableOnEvent);
    }

    void DisableOnEvent(IDomainEvent _event)
    {
        Disable();
    }

    void EnableOnEvent(IDomainEvent _event)
    {
        Enable();
    }

    public void Disable()
    {
        active = false;
        foreach (GameObject ob in visuals)
        {
            ob.SetActive(false);
        }
    }

    public void Enable()
    {
        active = true;
        foreach (GameObject ob in visuals)
        {
            ob.SetActive(true);
        }
    }
}
