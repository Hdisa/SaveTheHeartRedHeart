using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    [SerializeField] private Fireball fireball;
    [SerializeField] private Transform bulletShot;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    void Shoot() => Instantiate(fireball, bulletShot.transform.position, bulletShot.transform.rotation);
}
