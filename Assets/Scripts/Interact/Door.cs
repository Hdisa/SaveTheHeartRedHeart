using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isLocked = false;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void Interact()
    {
        if (!isLocked)
        {
            
        }
    }

    private void UnlockDoor()
    {
        isLocked = false;
    }
}
