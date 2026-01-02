using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is an interface for anything that is able to appear in a hole
public interface IHoleable: IClickable
{
    //a string for the path within the resource folder that contains the visual
    public string ResourcesVisual { get; set; }

    //the amount of points something in the hole is worth
    public int Value { get; set; }
}
