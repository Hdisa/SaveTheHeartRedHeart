using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float healthCount = 100;
    [SerializeField] private RectTransform valueRectTransform;
    private float _maxHealth;
    
    public static Action PlayerIsDead;

    private void Start()
    {
        _maxHealth = healthCount;
        ShowHealthBar();
    }

    public void SubtractHealth(float damage)
    {
        healthCount -= damage;
        if (healthCount <= 0) DestroyEntity();
        ShowHealthBar();
    }

    private void ShowHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(healthCount/_maxHealth, 1);
    }

    private void DestroyEntity()
    {
        var isPlayer = TryGetComponent(out Player player);
        if (isPlayer)
        {
            PlayerIsDead.Invoke();
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<CameraRotation>().enabled = false;
            player.GetComponent<FireballCaster>().enabled = false;
            return;
        }
        Destroy(gameObject);
    }
}
