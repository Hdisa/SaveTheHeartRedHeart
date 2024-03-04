using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float size = 5;
    [SerializeField] private float speed = 5;
    [SerializeField] private int damage = 50;
    
    void Start()
    {
        transform.localScale = Vector3.zero;
    }
    
    void Update()
    {
        transform.localScale += Vector3.one * (Time.deltaTime * speed);
        if (transform.localScale.x > size) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.transform.root.TryGetComponent(out Health entityHealth))
            entityHealth.SubtractHealth(damage);
    }
}
