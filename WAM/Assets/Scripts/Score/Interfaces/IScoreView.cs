using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface IScoreView : IActive
{
    public GameObject[] Visuals { get; set; }
    public TextMeshProUGUI ScoreTMP { get; set; }
    public void UpdateScoreVisuals(int _points);
}
