using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int healthCount = 100;

    public void SubtractHealth(int damage)
    {
        healthCount -= damage;
        if (healthCount <= 0)
            Destroy(gameObject);
    }
}
