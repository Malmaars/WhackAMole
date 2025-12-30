using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour
{
    IHoleView view;
    IHoleModel model;

    public void Initialize(IHoleView _view, IHoleModel _model)
    {
        view = _view;
        model = _model;
    }
    private void Update()
    {
        List<Vector2> touches = InputHandler.CheckForInputs();
        if(touches.Count > 0 ) 
        {
            model.TouchHoles(touches);
        }
    }
}
