using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isLocked = false;
    void Update()
    {
        if (EnemyStates.enemyCount == 0)
            Destroy(gameObject);
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
