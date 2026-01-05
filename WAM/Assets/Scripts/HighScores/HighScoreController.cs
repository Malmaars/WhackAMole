using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreController : MonoBehaviour, IBusListener, IActive
{
    public bool active { get; set; }
    public IEventBus eventBus { get; set; }

    public IHighScoreView view;
    public IHighScoreModel model;

    public IMenuButton continueButton;

    public void Initialize(IHighScoreView _view, IHighScoreModel _model, IMenuButton _continueButton)
    {
        view = _view;
        model = _model;
        continueButton = _continueButton;

        continueButton.Clicked += ContinueToMenu;
    }

    public void GetOnBus(IEventBus _bus)
    {
        eventBus = _bus;
        eventBus.Subscribe<ShowHighScoresEvent>(SetVisuals);
        eventBus.Subscribe<ShowHighScoresEvent>(EnableOnEvent);
        eventBus.Subscribe<ShowMenuEvent>(DisableOnEvent);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            model.SaveHighScore(new HighScoreData(100, "SMOS"));
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            model.SaveHighScore(new HighScoreData(299, "SLAK"));
        }
    }

    public void ContinueToMenu()
    {
        eventBus.Publish(new ShowMenuEvent());
    }

    public void SetVisuals(IDomainEvent _event)
    {
        view.ClearHighScoreVisuals();
        HighScoreData[] data = model.LoadHighScores();

        for(int i = 0; i < data.Length; i++)
        {
            view.AddHighScoreVisual(data[i]);
        }
    }

    void EnableOnEvent(IDomainEvent _event)
    {
        Enable();
    }

    void DisableOnEvent(IDomainEvent _event)
    {
        Disable();
    }

    public void Enable()
    {
        active = true;
        view.Enable();
    }
    public void Disable()
    {
        active = false;
        view.Disable();
    }
}
