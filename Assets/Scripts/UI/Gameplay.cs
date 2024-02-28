using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private RectTransform valueRectTransform;
    private float _maxHealth;

    private void OnEnable()
    {
        EventBus.SetHealth += SetMaxHealth;
        EventBus.UpdateHealthBar += UpdateHealth;
    }

    private void OnDisable()
    {
        EventBus.SetHealth -= SetMaxHealth;
        EventBus.UpdateHealthBar -= UpdateHealth;
    }

    private void SetMaxHealth(float maxHealth) => _maxHealth = maxHealth;
    private void UpdateHealth(float currentHealth)
    {
        valueRectTransform.anchorMax = new Vector2(currentHealth/_maxHealth, 1);
    }
}
