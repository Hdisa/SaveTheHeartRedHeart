using UnityEngine;

public class AidKit : MonoBehaviour, ICollectable
{
    [SerializeField] private int healPoint = 100;
    [SerializeField] private PlayerStats playerStats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player)) Collect();
        Destroy(gameObject);
    }

    public void Collect() => EventBus.OnAddHealth?.Invoke(healPoint);
}
