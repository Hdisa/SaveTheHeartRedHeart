using UnityEngine;

public class AidKit : MonoBehaviour, ICollectable
{
    [SerializeField] private int healPoint = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health)) Collect();
        Destroy(gameObject);
    }

    public void Collect() => EventBus.OnAddHealth?.Invoke(healPoint);
}
