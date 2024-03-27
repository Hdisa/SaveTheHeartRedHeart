using System;
using UnityEngine;

public class Fireball : Bullet
{
    [SerializeField] private BulletSettings fireball;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        BulletLifetime();
    }

    void FixedUpdate()
    {
        BulletDirection(fireball.fireballSpd);
    }

    void OnCollisionEnter(Collision other)
    {
        BulletDamage(other, fireball.fireballDmg);
    }

    internal override void DestroyItself() => Destroy(gameObject);
}