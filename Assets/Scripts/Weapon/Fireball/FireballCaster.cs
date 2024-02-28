using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    [SerializeField] private Fireball fireballPrefab;
    [SerializeField] private Transform bulletSource;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fireball fireball = Instantiate(fireballPrefab, bulletSource.position, transform.rotation); 
            fireball.Direction = bulletSource.forward;
        }
            
    }
}
