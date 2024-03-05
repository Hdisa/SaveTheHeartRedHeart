using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float healthCount = 100;
    public float MaxHealth { get; private set; }

    private void OnEnable()
    {
        EventBus.OnAddHealth += AddHealth;
    }

    private void Start()
    {
        MaxHealth = healthCount;
    }

    private void Update()
    {
        if (healthCount <= 0) Destroy(gameObject);
    }
    
    private void OnDisable()
    {
        EventBus.OnAddHealth -= AddHealth;
    }

    public void SubtractHealth(float damage)
    {
        healthCount -= damage;
        if (TryGetComponent(out Player player))
            EventBus.UpdateHealthBar?.Invoke(healthCount);
    }

    public void AddHealth(int hp)
    {
        healthCount += hp;
        healthCount = Mathf.Clamp(healthCount, 0, MaxHealth);
        if (TryGetComponent(out Player player))
            EventBus.UpdateHealthBar?.Invoke(healthCount);
    }
}
