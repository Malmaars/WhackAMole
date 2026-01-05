using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreController : MonoBehaviour
{
    public IHighScoreView view;
    public IHighScoreModel model;

    public void Initialize(IHighScoreView _view, IHighScoreModel _model)
    {
        view = _view;
        model = _model;
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
}
