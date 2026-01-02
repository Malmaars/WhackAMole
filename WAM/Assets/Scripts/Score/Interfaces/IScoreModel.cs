using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreModel : IModel, IBusListener
{
    public PointManager pointManager { get; set; }
    public int Score { get; set; }
    public event Action<int> ScoreChanged;

    public void AddPoints(int _points);
    public void RemovePoints(int _points);
}
