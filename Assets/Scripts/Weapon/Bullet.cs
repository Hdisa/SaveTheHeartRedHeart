using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private BulletSettings bulletSettings;
    public Vector3 Direction { get; set; }

    internal void BulletLifetime()
    {
        Invoke(nameof(DestroyItself), bulletSettings.bulletLifetime);
    }

    internal void BulletDirection(int bulletSpd)
    {
        transform.position += Direction * (bulletSpd * Time.deltaTime);
    }

    internal void BulletDamage(Collision other, int bulletDmg)
    {
        if (other.transform.root.TryGetComponent(out Health entityHealth))
            entityHealth.SubtractHealth(bulletDmg);

        Destroy(gameObject);
    }
        
    internal virtual void DestroyItself() => Destroy(gameObject);
}