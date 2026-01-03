using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreModel : IScoreModel
{
    public PointManager pointManager { get; set; }

    public int Score { get { return pointManager.points; } set { score = value; } }
    int score;

    public IEventBus eventBus { get; set; }

    //call this event whenever the score changes
    public event Action<int> ScoreChanged;
    public void OnStart() 
    {
        pointManager = new PointManager();
    }
    public void OnUpdate(float _DeltaTime) { }

    public void AddPoints(int _points)
    {
        pointManager.AddPoints(_points);
        ScoreChanged.Invoke(Score);
    }
    public void SetPoints(int _points)
    {
        pointManager.SetPoints(_points);
        ScoreChanged.Invoke(Score);
    }

    public void RemovePoints(int _points)
    {
        pointManager.RemovePoints(_points);
        ScoreChanged.Invoke(Score);
    }

    public void GetOnBus(IEventBus _bus)
    {
        eventBus = _bus;
        eventBus.Subscribe<HoleHitEvent>(OnHoleHit);
        eventBus.Subscribe<StartGameEvent>(GameStart);
        eventBus.Subscribe<EndGameEvent>(EndGame);
    }

    public void OnHoleHit(HoleHitEvent _event)
    {
        AddPoints(_event.Points);
    }
    public void GameStart(IDomainEvent _event)
    {
        SetPoints(0);
    }

    public void EndGame(IDomainEvent _event)
    {

    }
}
