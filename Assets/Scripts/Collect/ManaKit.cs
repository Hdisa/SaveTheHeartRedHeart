using UnityEngine;

public class ManaKit : MonoBehaviour, ICollectable
{
    [SerializeField] private int manaPoint = 50;
    
    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void Collect()
    {
        
    }
}
