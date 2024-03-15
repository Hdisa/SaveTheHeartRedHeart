using UnityEngine;

public class Fireball : Bullet
{
    [SerializeField] private BulletSettings fireball;
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