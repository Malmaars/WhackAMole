using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour, IScoreView
{
    public TextMeshProUGUI ScoreTMP { get { return scoreTMP; } set { scoreTMP = value; } }

    [SerializeField]
    TextMeshProUGUI scoreTMP;
    public void ResetVisuals()
    {
        scoreTMP.text = "0";
    }

    public void UpdateScoreVisuals(int _points)
    {
        scoreTMP.text = _points.ToString();
    }
}
