using UnityEngine;

public class AidKit : MonoBehaviour, ICollectable
{
    [SerializeField] private int healPoint = 50;
    [SerializeField] private PlayerSettings playerSettings;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player)) Collect();
        Destroy(gameObject);
    }

    public void Collect() => EventBus.OnAddHealth?.Invoke(healPoint);
}
