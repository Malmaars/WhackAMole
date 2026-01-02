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
    HoleFactory holeViewFactory;
    IHoleModel holeModel;


    private void Awake()
    {
        IEventBus bus = new EventBus();
        //initialize hole system
        holeModel = new HoleModel();
        holeModel.GetOnBus(bus);

        holeController.Initialize(holeModel, holeViewFactory);
        
        //Initializing score system
        scoreModel = new ScoreModel();
        scoreModel.GetOnBus(bus);

        scoreController.Initialize(scoreView, scoreModel);

        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
