using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHighScoreModel
{
    public HighScoreData LoadHighScore(int _highScoreRank);
    public void SaveHighScore(HighScoreData _data);

}
