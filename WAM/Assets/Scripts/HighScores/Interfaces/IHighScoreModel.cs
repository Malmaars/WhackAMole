using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHighScoreModel : IBusListener
{
    public HighScoreData[] LoadHighScores();
    public HighScoreData LoadHighScore(int _highScoreRank);
    public void SaveHighScore(HighScoreData _data);

}
