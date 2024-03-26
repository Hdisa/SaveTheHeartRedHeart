using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Transform cameraAxisTransform;
    [SerializeField] private AudioClip[] clips;
    
    public static AudioClip[] Clips { get; private set; }
    private Animator _animator;
    private AudioSource _audioSource;
    private static readonly int OnAttack = Animator.StringToHash("OnAttack");

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _audioSource = GetComponent<AudioSource>();
        Clips = clips;
    }

    private void OnEnable()
    {
        EventBus.OnAddHealth += AddHealth;
        EventBus.OnTookDamage += RemoveHealth;
        EventBus.CastBulletAnim += AttackAnim;
    }

    private void Update()
    {
        if (playerStats.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnDisable()
    {
        EventBus.OnAddHealth -= AddHealth;
        EventBus.OnTookDamage -= RemoveHealth;
        EventBus.CastBulletAnim -= AttackAnim;
    }
    
    private void OnDestroy()
    {
        cameraAxisTransform.parent = null;
        EventBus.IsDead?.Invoke();
    }
    
    private void RemoveHealth(int dmg)
    {
        _audioSource.PlayOneShot(clips[3]);
        playerStats.currentHealth -= dmg;
    }
    private void AddHealth(int hp)
    {
        playerStats.currentHealth += hp;
        playerStats.currentHealth = Mathf.Clamp(playerStats.currentHealth, 0, playerStats.maxHealth);
    }

    private void AttackAnim() => _animator.SetTrigger(OnAttack);
}