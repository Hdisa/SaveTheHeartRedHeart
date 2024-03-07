using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private PlayerStats playerStats;


    private void OnEnable()
    {
        EventBus.OnAddHealth += AddHealth;
        EventBus.OnTookDamage += RemoveHealth;
    }

    private void Update()
    {
        if (playerStats.currentHealth <= 0) Destroy(gameObject);
    }

    private void RemoveHealth(int dmg)
    {
        playerStats.currentHealth -= dmg;
    }
    private void AddHealth(int hp)
    {
        playerStats.currentHealth += hp;
        playerStats.currentHealth = Mathf.Clamp(playerStats.currentHealth, 0, playerStats.maxHealth);
    }
    
    private void OnDisable()
    {
        EventBus.OnAddHealth -= AddHealth;
        EventBus.OnTookDamage -= RemoveHealth;
    }
    
    private void OnDestroy()
    {
        EventBus.IsDead?.Invoke();
    }
}