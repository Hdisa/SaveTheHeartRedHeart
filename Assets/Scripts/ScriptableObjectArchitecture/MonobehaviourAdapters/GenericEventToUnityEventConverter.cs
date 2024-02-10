using ScriptableObjectArchitecture.Base;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture.MonobehaviourAdapters
{
public abstract class GenericEventToUnityEventConverter<T> : MonoBehaviour, IGenericEventListener<T>
{
    [SerializeField] private GenericEvent<T> @event;

    public UnityEvent<T> response;

    private void OnEnable() => @event.Subscribe(this);

    private void OnDisable() => @event.Unsubscribe(this);

    public void OnEventRaised(T value) => response.Invoke(value);
}
}