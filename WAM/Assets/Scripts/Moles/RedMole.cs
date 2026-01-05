using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMole : IHoleable
{
    public int Value { get; set; }
    public int Health { get; set; } = 1;
    public string ResourcesVisual { get; set; } = "Holeables/RedMole";
    public string holeableName { get; set; } = "Red Mole";

    public int OnClick()
    {
        Health--;
        //give one point
        return -1;
    }
}
