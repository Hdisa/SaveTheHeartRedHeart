using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    [SerializeField] private Rigidbody grenadePrefab;
    [SerializeField] private Transform bulletSource;

    [SerializeField] private float force = 10;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var grenade = Instantiate(grenadePrefab);
            grenade.transform.position = bulletSource.position;
            grenade.AddForce(bulletSource.forward * force);
        }
    }
}
