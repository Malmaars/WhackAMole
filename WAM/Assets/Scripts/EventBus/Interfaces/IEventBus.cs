using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IEventBus
{
    void Publish<T>(T domainEvent) where T : IDomainEvent;
    void Subscribe<T>(Action<T> handler) where T : IDomainEvent;
    void Unsubscribe<T>(Action<T> handler) where T : IDomainEvent;
}