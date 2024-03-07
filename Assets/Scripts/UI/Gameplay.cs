using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private RectTransform valueRectTransform;
    [SerializeField] private PlayerStats playerSettings;

    private void Update()
    {
        valueRectTransform.anchorMax = new Vector2(playerSettings.GetHealthUI(), 1);
    }
}
