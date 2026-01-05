using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreVisualView : MonoBehaviour
{
    public TextMeshProUGUI rank, score, playerName;

    public void SetRank(int _rank)
    {
        rank.text = _rank.ToString();
    }

    public void SetScore(int _score)
    {
        score.text = _score.ToString();
    }

    public void SetName(string _playerName)
    {
        playerName.text = _playerName;
    }
}
