using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputHandler
{
    public static List<Vector2> CheckForInputs()
    {
        List<Vector2> touchLocations = new List<Vector2>();
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
                touchLocations.Add(touch.position);
        }
        return touchLocations;
    }
}
