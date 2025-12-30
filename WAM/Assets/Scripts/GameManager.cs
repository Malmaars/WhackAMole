using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The GameManager solely handles the interactions between subsystems
public class GameManager : MonoBehaviour
{
    [SerializeField]
    ScoreController scoreController;

    [SerializeField]
    ScoreView scoreView;

    IScoreModel scoreModel;

    private void Awake()
    {
        //Initializing score system
        scoreModel = new ScoreModel();

        scoreController.Initialize(scoreView, scoreModel);
    }
}
