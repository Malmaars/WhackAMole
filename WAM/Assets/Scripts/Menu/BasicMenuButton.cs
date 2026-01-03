using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMenuButton : MonoBehaviour, IMenuButton
{
    public event Action Clicked;

    public void OnClick()
    {
        Clicked.Invoke();
    }
}
