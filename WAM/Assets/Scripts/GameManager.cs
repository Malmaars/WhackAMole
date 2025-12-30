using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The GameManager solely handles the interactions between subsystems
public class GameManager : MonoBehaviour
{
    //Score
    [SerializeField]
    ScoreController scoreController;
    [SerializeField]
    ScoreView scoreView;
    IScoreModel scoreModel;

    //Holes
    [SerializeField]
    HoleController holeController;
    [SerializeField]
    HoleView holeView;
    IHoleModel holeModel;


    private void Awake()
    {
        //Initializing score system
        scoreModel = new ScoreModel();

        scoreController.Initialize(scoreView, scoreModel);

        //initialize hole system
        holeModel = new HoleModel();

        holeController.Initialize(holeView, holeModel);
    }
}
