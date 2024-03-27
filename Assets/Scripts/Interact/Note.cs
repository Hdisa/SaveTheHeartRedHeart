using UnityEngine;

public class Note : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject popupNote;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            popupNote.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            popupNote.SetActive(false);
    }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }
}
