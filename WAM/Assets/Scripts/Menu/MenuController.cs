using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour, IActive, IBusListener
{
    IMenuView view;
    IMenuButton StartButton;
    IMenuButton HighScoreButton;
    IMenuModel model;

    public bool active { get; set; }
    public IEventBus eventBus { get;  set ; }

    private void Start()
    {
        model.OnStart();
    }

    private void Update()
    {
        model.OnUpdate(Time.deltaTime);
    }

    public void Initialize(IMenuView _view, IMenuModel _model, IMenuButton _startButton, IMenuButton _highScoreButton)
    {
        view = _view;
        model = _model;
        StartButton = _startButton;
        HighScoreButton = _highScoreButton;

        StartButton.Clicked += StartGame;
        HighScoreButton.Clicked += ShowHighScores;
    }

    void StartGame()
    {
        model.StartGame();
    }

    void ShowHighScores()
    {
        model.ShowHighScores();
    }


    public void GetOnBus(IEventBus _bus)
    {
        eventBus = _bus;
        eventBus.Subscribe<ShowMenuEvent>(EnableOnEvent);
        eventBus.Subscribe<StartGameEvent>(DisableOnEvent);
        eventBus.Subscribe<ShowHighScoresEvent>(DisableOnEvent);
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
        model.Enable();
        view.Enable();
    }

    public void Disable() 
    {
        active = false;
        model.Disable();
        view.Disable();
    }

}
