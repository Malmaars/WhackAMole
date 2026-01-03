using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager
{
    public int points { get; private set; }

    public void SetPoints(int _points)
    {
        points = _points;
    }
    public void AddPoints(int _points)
    {
        points += _points;
    }

    public void RemovePoints(int _points)
    {
        points -= _points;
    }
}
