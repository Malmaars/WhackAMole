using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBusListener
{
    public IEventBus eventBus { get; set; }
    public void GetOnBus(IEventBus _bus);
}
