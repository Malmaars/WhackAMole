using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface IScoreView : IView
{
    public TextMeshProUGUI ScoreTMP { get; set; }
    public void UpdateScoreVisuals(int _points);
}
