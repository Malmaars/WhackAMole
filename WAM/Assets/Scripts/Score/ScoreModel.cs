using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreModel : IScoreModel
{
    public PointManager pointManager { get; set; }

    public int Score { get { return pointManager.points; }
        set { score = value; }
    }

    public IEventBus EventBus { get; set; }

    int score;

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

    public void RemovePoints(int _points)
    {
        pointManager.RemovePoints(_points);
        ScoreChanged.Invoke(Score);
    }

    public void GetOnBus(IEventBus _bus)
    {
        EventBus = _bus;
        EventBus.Subscribe<HoleHitEvent>(OnHoleHit);
    }

    public void OnHoleHit(HoleHitEvent _event)
    {
        AddPoints(_event.Points);
    }
}
