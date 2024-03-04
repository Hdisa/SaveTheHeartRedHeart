using UnityEngine;

public class HealKit : MonoBehaviour
{
    [SerializeField] private float healPoint = 100;

    private void OnTriggerEnter(Collider other)
    {
        var healthEntity = FindObjectOfType<Player>().GetComponent<Health>();
        healthEntity.AddHealth(healPoint);
        Destroy(gameObject);
    }
}
