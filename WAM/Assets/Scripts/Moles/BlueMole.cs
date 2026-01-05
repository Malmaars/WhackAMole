using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMole : IHoleable
{
    public int Value { get; set; }
    public int Health { get; set; } = 10;
    public string ResourcesVisual { get; set; } = "Holeables/BlueMole";
    public string holeableName { get; set; } = "Blue Mole";

    public int OnClick()
    {
        //the blue mole doesn't lose health, spam that button!!
        //give one point
        return 1;
    }
}
