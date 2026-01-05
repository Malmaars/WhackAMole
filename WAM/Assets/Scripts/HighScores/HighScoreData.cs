using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public struct HighScoreData 
{
    public HighScoreData(int _score, string _name)
    {
        score = _score;
        name = _name;
    }

    public int score;
    public string name;
}


//JSON can't save loose arrays, so I need to contain it in a struct for it to be able to save
[System.Serializable]
public class HighScoreDataCollection
{

    public HighScoreDataCollection(HighScoreData[] _scores)
    {
        scores = _scores;
    }
    public HighScoreData[] scores;
}
