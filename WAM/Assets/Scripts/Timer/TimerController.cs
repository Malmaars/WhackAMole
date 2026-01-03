using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimerController : MonoBehaviour
{
    ITimerView view;
    ITimerModel model;

    // Update is called once per frame
    void Update()
    {
        model.OnUpdate(Time.deltaTime);
    }

    public void Initialize(ITimerView _view, ITimerModel _model)
    {
        view = _view;
        model = _model;
        model.OnTimeChanged += view.UpdateTimerVisual;
    }
}
