using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float healthCount = 100;
    public float MaxHealth { get; private set; }

    private void Start()
    {
        MaxHealth = healthCount;
    }

    private void Update()
    {
        if (healthCount <= 0) Destroy(gameObject);
    }

    public void SubtractHealth(float damage)
    {
        healthCount -= damage;
        if (TryGetComponent(out Player player))
            EventBus.UpdateHealthBar?.Invoke(healthCount);
    }

    public void AddHealth(float amount)
    {
        healthCount += amount;
        healthCount = Mathf.Clamp(healthCount, 0, MaxHealth);
        EventBus.UpdateHealthBar?.Invoke(healthCount);
    }
}
