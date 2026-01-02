using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : IEventBus
{
    private readonly Dictionary<Type, Delegate> handlers = new();

    public void Publish<T>(T domainEvent) where T : IDomainEvent
    {
        if (handlers.TryGetValue(typeof(T), out var handler))
        {
            ((Action<T>)handler)?.Invoke(domainEvent);
        }
    }

    public void Subscribe<T>(Action<T> handler) where T : IDomainEvent
    {
        if (handlers.TryGetValue(typeof(T), out var existing))
            handlers[typeof(T)] = (Action<T>)existing + handler;
        else
            handlers[typeof(T)] = handler;
    }

    public void Unsubscribe<T>(Action<T> handler) where T : IDomainEvent
    {
        if (handlers.TryGetValue(typeof(T), out var existing))
            handlers[typeof(T)] = (Action<T>)existing - handler;
    }
}
