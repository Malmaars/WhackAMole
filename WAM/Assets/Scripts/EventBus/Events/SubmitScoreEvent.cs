using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitScoreEvent : IDomainEvent
{
    public int Score { get; set; }
    public string Name { get; set; }

    public SubmitScoreEvent(int _score, string _name)
    {
        Score = _score;
        Name = _name;
    }       
}
