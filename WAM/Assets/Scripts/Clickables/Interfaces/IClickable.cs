using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClickable
{
    //the function will return an int, because I want everything clickable to have an inherit point value
    public int OnClick();
}
