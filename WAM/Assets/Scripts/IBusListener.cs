using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBusListener
{
    public IEventBus EventBus { get; set; }
    public void GetOnBus(IEventBus _bus);
}
