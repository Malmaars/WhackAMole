using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour, IBusListener, IActive
{
    public bool active { get; set; }
    public IEventBus eventBus { get; set; }

    public IGameOverView view;
    public IGameOverModel model;

    public IMenuButton submitScoreButton;
    
    public void Initialize(IGameOverView _view, IGameOverModel _model, IMenuButton _submitScoreButton)
    {
        view = _view;
        model = _model;
        submitScoreButton = _submitScoreButton;

        submitScoreButton.Clicked += model.SubmitScore;

        view.OnNameChange += model.ReceiveName;
    }

    public void GetOnBus(IEventBus _bus)
    {
        eventBus = _bus;

        eventBus.Subscribe<ShowHighScoresEvent>(DisableOnEvent);
        eventBus.Subscribe<EndGameEvent>(EnableOnEvent);
        eventBus.Subscribe<ShowMenuEvent>(DisableOnEvent);
        eventBus.Subscribe<EchoScoreEvent>(UpdateScore);
    }

    void UpdateScore(EchoScoreEvent _event)
    {
        view.UpdateScoreVisuals(_event.Score);
    }

    public void EnableOnEvent(IDomainEvent _event)
    {
        Enable();
    }
    public void DisableOnEvent(IDomainEvent _event)
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
