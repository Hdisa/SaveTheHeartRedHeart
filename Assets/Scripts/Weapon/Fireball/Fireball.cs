using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;
    [SerializeField] private int damage = 10;

    private void Start()
    {
        Invoke("DestroyItself", lifetime);
    }

    void FixedUpdate()
    {
        BulletMove();
    }

    void BulletMove() => transform.position += transform.forward * (speed * Time.deltaTime);

    void OnCollisionEnter(Collision other)
    {
        DealDamage(other);
        DestroyItself();
    }

    void DealDamage(Collision enemy)
    {
        var enemyHealth = enemy.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
            enemyHealth.SubtractHealth(damage);
    }

    void DestroyItself() => Destroy(gameObject);
}
