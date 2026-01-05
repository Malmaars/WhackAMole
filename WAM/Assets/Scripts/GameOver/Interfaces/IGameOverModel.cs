using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameOverModel : IBusListener
{
    public string PlayerName { get; set; }
    public int PlayerScore { get; set; }


    public void ReceiveName(string _name);
    public void SubmitScore();
}
