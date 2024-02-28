using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;
    [SerializeField] private int damage = 10;
    public Vector3 Direction { get; set; }

    private void Start()
    {
        Invoke("DestroyItself", lifetime);
    }

    void FixedUpdate()
    {
        transform.position += Direction * (speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.root.TryGetComponent(out Health entityHealth))
            entityHealth.SubtractHealth(damage);
        
        Destroy(gameObject);
    }

    private void DestroyItself() => Destroy(gameObject);
}
