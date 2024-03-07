using UnityEngine;

[CreateAssetMenu (menuName = "Hdisa Tools/Player Stats")]
public class PlayerStats : ScriptableObject
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public int maxMana = 100;
    public int currentMana = 100;
    public int coins;

    public float GetHealthUI() => (float)currentHealth / maxHealth;
    public float GetManaUI() => (float)currentMana / maxMana;
}