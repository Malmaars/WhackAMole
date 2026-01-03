using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMenuButton
{
    public event Action Clicked;
    public void OnClick();
}
