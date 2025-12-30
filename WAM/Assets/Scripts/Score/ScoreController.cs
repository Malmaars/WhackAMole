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
        model = new ScoreModel();

        model.OnStart();
        model.ScoreChanged += OnScoreChange;
    }

    private void Update()
    {
        model.OnUpdate(Time.deltaTime);

        if(Input.GetKey(KeyCode.F))
            model.AddPoints(1);
        
    }

    public void OnScoreChange(int _score)
    {
        view.UpdateScoreVisuals(_score);
    }
}
