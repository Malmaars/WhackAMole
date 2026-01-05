using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public interface IHighScoreView: IActive, IVisualManager
{
    public RectTransform Content { get; set; }
    public HighScoreVisualView HighScoreVisualPrefab { get; set; }

    public void ClearHighScoreVisuals();

    public void AddHighScoreVisual(HighScoreData _highScore);
}
