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
    
    //High Scores
    [Header("Highscore Components")]
    [SerializeField]
    HighScoreController highScoreController;
    [SerializeField]
    HighScoreView highScoreView;
    IHighScoreModel highScoreModel;
    [SerializeField]
    BasicMenuButton highScoreToMenuButton;
    
    //Game Over Screen
    [Header("GameOver Components")]
    [SerializeField]
    GameOverController gameOverController;
    [SerializeField]
    GameOverView gameOverView;
    IGameOverModel gameOverModel;
    [SerializeField]
    BasicMenuButton submitScoreButton;

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
        
        //Initializing Highscore system
        highScoreModel = new HighScoreModel();
        highScoreModel.GetOnBus(bus);

        highScoreController.Initialize(highScoreView, highScoreModel, highScoreToMenuButton);
        highScoreController.GetOnBus(bus);
       
        //Initializing Game Over Screen System
        gameOverModel = new GameOverModel();
        gameOverModel.GetOnBus(bus);

        gameOverController.Initialize(gameOverView, gameOverModel, submitScoreButton);
        gameOverController.GetOnBus(bus);
        gameOverView.GetOnBus(bus);



        //Initializing menu system
        menuModel = new MenuModel();
        menuModel.GetOnBus(bus);

        menuController.Initialize(menuView, menuModel, startButton, highScoreButton);
        menuController.GetOnBus(bus);

        bus.Publish(new ShowMenuEvent());

        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
