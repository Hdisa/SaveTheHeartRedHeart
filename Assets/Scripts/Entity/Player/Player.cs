using UnityEngine;

public class Player : MonoBehaviour
{
    private Health _health;
    private float _maxHealth;

    private void Start()
    {
        _health = GetComponent<Health>();
        _maxHealth = _health.MaxHealth;
        EventBus.SetHealth?.Invoke(_maxHealth);
    }

    private void OnDestroy()
    {
        EventBus.IsDead?.Invoke();
    }
}