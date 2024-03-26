using UnityEngine;

public class DataResetter : MonoBehaviour
{
    public PlayerStats stats;
    
    private void Awake()
    {
        stats.currentHealth = stats.maxHealth;
    }
}
