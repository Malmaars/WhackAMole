using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoScoreEvent : IDomainEvent
{
    public int Score { get; set; }

    public EchoScoreEvent(int score)
    {
        Score = score;
    }
}
