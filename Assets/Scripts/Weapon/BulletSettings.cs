using UnityEngine;

[CreateAssetMenu (menuName = "Hdisa Tools/Bullet Settings")]
public class BulletSettings : ScriptableObject
{
    public int bulletLifetime = 5;
    
    [Header("Fireball")] 
    public int fireballDmg = 30;
    public int fireballSpd = 10;
    public int fireballCost = 15;

    [Header("Snowball")] 
    public int snowballDmg = 15;
    public int snowballSpd = 15;
    public int snowballCost = 10;
}
