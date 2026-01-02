using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : IMole
{
    public int Value { get; set; }
    public string ResourcesVisual { get; set; } = "Holeables/Mole";

    public int OnClick()
    {
        //give one point
        return 1;
    }
}
