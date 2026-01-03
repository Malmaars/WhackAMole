using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuView : MonoBehaviour, IMenuView
{
    public GameObject[] MenuVisuals { get { return menuVisuals; } set { menuVisuals = value; } }
    public GameObject[] menuVisuals;

    public bool active { get; set; }

    public void Disable()
    {
        active = false;

        foreach (GameObject ob in MenuVisuals)
        {
            ob.SetActive(false);
        }
    }

    public void Enable()
    {
        active = true;
        foreach (GameObject ob in MenuVisuals)
        {
            ob.SetActive(true);
        }
    }

    public void ResetVisuals()
    {
    }
}
