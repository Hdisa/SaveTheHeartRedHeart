using System;
using UnityEngine;

namespace ScriptableObjectArchitecture.Base
{
public abstract class GenericVariable<T> : GenericEvent<T>
{
    [SerializeField] private T variable;

    public void Raise() => Raise(variable);

    public T Value
    {
        get => variable;
        set
        {
            variable = value;
            Raise(value);
        }
    }

    public void Link(IGenericEventListener<T> listener)
    { 
        Subscribe(listener);
        listener.OnEventRaised(Value);
    }

    public void Link(Action<T> method)
    {
        Subscribe(method);
        method(variable);
    }

    public void Unlink(Action<T> method) => Unsubscribe(method);

    public static implicit operator T(GenericVariable<T> so) => so.variable;
}
}