using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverModel : IGameOverModel
{
    public IEventBus eventBus { get; set; }
    public string PlayerName { get; set; }
    public int PlayerScore { get; set; }

    public void ReceiveScore(EchoScoreEvent _event)
    {
        PlayerScore = _event.Score;
    }
    public void ReceiveName(string _name)
    {
        PlayerName = _name;   
    }
    public void SubmitScore()
    {
        eventBus.Publish(new SubmitScoreEvent(PlayerScore, PlayerName));
        eventBus.Publish(new ShowHighScoresEvent());
    }

    public void GetOnBus(IEventBus _bus)
    {
        eventBus = _bus;
        eventBus.Subscribe<EchoScoreEvent>(ReceiveScore);
    }
}
