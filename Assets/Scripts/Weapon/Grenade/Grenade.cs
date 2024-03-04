using System;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private int delay = 3;
    [SerializeField] private GameObject explosionPrefab;
    private void OnCollisionEnter(Collision other)
    {
        Invoke("Explosion", delay);
    }

    private void Explosion()
    {
        Destroy(gameObject);
        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
    }
}
