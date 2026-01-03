using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{

    IScoreView view;
    IScoreModel model;

    public void Initialize(IScoreView _view, IScoreModel _model)
    {
        model = _model;
        view = _view;
    }

    private void Start()
    {
        model.OnStart();
        model.ScoreChanged += OnScoreChange;
    }

    private void Update()
    {
        model.OnUpdate(Time.deltaTime);
    }

    public void ChangePoints(int _points)
    {
        if (_points == 0) 
            return;
        else if (_points > 0) 
            model.AddPoints(_points);
        else 
            model.RemovePoints(_points);
    }

    public void OnScoreChange(int _score)
    {
        view.UpdateScoreVisuals(_score);
    }

    
}
