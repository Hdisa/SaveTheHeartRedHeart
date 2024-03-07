using UnityEngine;

public class ManaKit : MonoBehaviour, ICollectable
{
    [SerializeField] private int manaPoint = 50;
    [SerializeField] private PlayerSettings playerSettings;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health)) Collect();
        Destroy(gameObject);
    }

    public void Collect() => EventBus.OnAddMana?.Invoke(manaPoint);
}
