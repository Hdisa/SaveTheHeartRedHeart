using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture.Base
{
public abstract class GenericEvent<T> : ScriptableObject
{
    // [SerializeField] private bool clearOnEnable;
    // [SerializeField] private bool clearOnDisable;
    
    private List<IGenericEventListener<T>> _listeners = new();
    private Action<T> Invoked;
    
    // private void OnEnable()
    // {
    //     if(clearOnEnable) Clear();
    // }

    // private void OnDisable()
    // {
    //     if(clearOnDisable) Clear();
    // }

    public void Raise(T value)
    {
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            if(ReferenceEquals(_listeners[i], null)) _listeners.RemoveAt(i);
            else _listeners[i].OnEventRaised(value);
        }
        Invoked?.Invoke(value);
    }

    public void Clear()
    {
        Invoked = null;
        _listeners.Clear();
    }
    
    public void Subscribe(Action<T> method) => Invoked += method;

    public void Subscribe(IGenericEventListener<T> listener)
    {
        if(!_listeners.Contains(listener)) _listeners.Add(listener);
    } 
    
    public void Unsubscribe(IGenericEventListener<T> listener) => _listeners.Remove(listener);
    public void Unsubscribe(Action<T> method) => Invoked -= method;

}

}