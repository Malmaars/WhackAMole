using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuView : MonoBehaviour, IMenuView
{
    public GameObject[] Visuals { get { return visuals; } set { visuals = value; } }
    public GameObject[] visuals;

    public bool active { get; set; }

    public void Disable()
    {
        active = false;

        foreach (GameObject ob in Visuals)
        {
            ob.SetActive(false);
        }
    }

    public void Enable()
    {
        active = true;
        foreach (GameObject ob in Visuals)
        {
            ob.SetActive(true);
        }
    }
}
