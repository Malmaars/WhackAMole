using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The GameManager solely handles the interactions between subsystems
public class GameManager : MonoBehaviour
{
    //Menu
    [Header("Menu Components")]
    [SerializeField]
    MenuController menuController;
    [SerializeField]
    MenuView menuView;
    [SerializeReference]
    BasicMenuButton startButton;
    [SerializeReference]
    BasicMenuButton highScoreButton;
    IMenuModel menuModel;


    //Score
    [Header("Score Components")]
    [SerializeField]
    ScoreController scoreController;
    [SerializeField]
    ScoreView scoreView;
    IScoreModel scoreModel;
    
    //Timer
    [Header("Timer Components")]
    [SerializeField]
    TimerController timerController;
    [SerializeField]
    TimerView timerView;
    ITimerModel timerModel;

    //Holes
    [Header("Hole Components")]
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
        holeController.GetOnBus(bus);

        //Initializing score system
        scoreModel = new ScoreModel();
        scoreModel.GetOnBus(bus);
        scoreView.GetOnBus(bus);

        scoreController.Initialize(scoreView, scoreModel);

        //Initializing Timer system
        timerModel = new TimerModel(new CountDownTimer());
        timerModel.GetOnBus(bus);
        timerView.GetOnBus(bus);

        timerController.Initialize(timerView, timerModel);


        //Initializing menu system
        menuModel = new MenuModel();
        menuModel.GetOnBus(bus);

        menuController.Initialize(menuView, menuModel, startButton, highScoreButton);

        bus.Publish(new ShowMenuEvent());

        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
