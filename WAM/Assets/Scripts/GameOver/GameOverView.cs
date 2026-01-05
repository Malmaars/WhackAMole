using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System;

public class GameOverView : MonoBehaviour, IGameOverView
{
    public IEventBus eventBus { get; set; }

    public GameObject[] Visuals { get { return visuals; } set { visuals = value; } }
    public GameObject[] visuals;

    public TMP_InputField nameInput;

    public Action<string> OnNameChange { get; set; }

    public bool active { get; set; }
    public TextMeshProUGUI ScoreTMP { get { return scoreTMP; } set { scoreTMP = value; } }

    [SerializeField]
    TextMeshProUGUI scoreTMP;

    private void Start()
    {
        nameInput.onValueChanged.AddListener(OnInputChanged);
    }

    public void UpdateScoreVisuals(int _score)
    {
        ScoreTMP.text = _score.ToString();
    }

    void OnInputChanged(string _text)
    {
        OnNameChange.Invoke(_text);
    }

    public void GetOnBus(IEventBus _bus)
    {
        eventBus = _bus;
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
