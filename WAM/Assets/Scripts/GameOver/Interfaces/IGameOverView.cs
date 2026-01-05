using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameOverView : IBusListener, IActive, IScoreView
{
    public Action<string> OnNameChange { get; set; }
}
