using UnityEngine;

public class HealKit : MonoBehaviour
{
    [SerializeField] private float healPoint = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>().TryGetComponent(out Health entityHealth))
        {
            entityHealth.AddHealth(healPoint);
            Destroy(gameObject);
        }
    }
}
