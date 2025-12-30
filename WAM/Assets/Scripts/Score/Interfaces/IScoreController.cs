using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreController : IController
{
    public IScoreView view { get; set; }
    public IScoreModel model { get; set; }

    public void OnScoreChange(int _score);
}
