using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighScoreModel : IHighScoreModel
{
    //a Highscore will contain 3 values:
    //  - The score
    //  - The name
    //  - The rank

    //The biggest problem with saving is that there needs to be a possibility that there can be duplicate names and scores
    //To solve this, I'll give each score a unique key. To make sure there is absolutely no possibility of a duplicate key, I'll make it the year, day, and time

    public HighScoreData LoadHighScore(int _highScoreRank)
    {
        //Current plan: Save all highscores as an array that is ordered by score

        HighScoreDataCollection saveData;
        string saveContent = File.ReadAllText(SaveFileName());


        saveData = JsonUtility.FromJson<HighScoreDataCollection>(saveContent);
        return saveData.scores[_highScoreRank];
    }
    public void SaveHighScore(HighScoreData _data)
    {
        if (!File.Exists(SaveFileName()))
        {
            File.WriteAllText(SaveFileName(), JsonUtility.ToJson(new HighScoreDataCollection(new HighScoreData[] {_data}), true));
            return;
        }
        HighScoreDataCollection saveData;

        string saveContent = File.ReadAllText(SaveFileName());
        saveData = JsonUtility.FromJson<HighScoreDataCollection>(saveContent);

        HighScoreData[] newSaveData;
        if (saveData == null || saveData.scores == null || saveData.scores.Length == 0)
        {
            newSaveData = new HighScoreData[] { _data };
        }
        else
        {
            newSaveData = AddHighScoreAtCorrectPlace(saveData.scores, _data);
        }
        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(new HighScoreDataCollection(newSaveData), true));
    }

    HighScoreData[] AddHighScoreAtCorrectPlace(HighScoreData[] _data, HighScoreData _toPlace)
    {
        //+1 because we're adding a new highscore
        HighScoreData[] newData = new HighScoreData[_data.Length + 1];

        int placeScore = _toPlace.score;

        bool dataPlaced = false;
        for(int i =  0; i < _data.Length; i++)
        {
            //>= because I give priority to the same score achieved earlier, Guinness world record style
            if (_data[i].score >= placeScore)
            {
                //just order the array like usual
                newData[i] = _data[i];
            }

            else if(!dataPlaced)
            {
                //fit the new data into place
                newData[i] = _toPlace;
                dataPlaced = true;

                //go back to the previous index to continue filling the array with old data
                i--;
            }

            //data has been placed, finish the rest of the array
            else if (dataPlaced)
            {
                newData[i + 1] = _data[i];
            }
        }

        //if the data has not been placed at all, that means it belongs at the end of the list, place it there now
        if(!dataPlaced)
            newData[newData.Length - 1] = _toPlace;

        return newData;
    }

    public void DeleteAllHighScores()
    {
        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(new HighScoreDataCollection(new HighScoreData[0]), true));
    }


    public string SaveFileName()
    {
        string saveFile = Application.persistentDataPath + "/highscores" + ".save";
        return saveFile;
    }
}
