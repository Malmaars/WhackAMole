using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMenuModel : IModel, IBusListener, IActive
{
    public void StartGame();
    public void ShowHighScores();
}
