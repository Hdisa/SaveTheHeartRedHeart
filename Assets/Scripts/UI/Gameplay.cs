using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private RectTransform valueRectTransform;
    [SerializeField] private PlayerStats playerStats;

    private void Update()
    {
        valueRectTransform.anchorMax = new Vector2(playerStats.GetHealthUI(), 1);
    }
}
