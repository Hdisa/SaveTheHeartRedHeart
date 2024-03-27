using UnityEngine;

public class BulletCaster : MonoBehaviour
{
    [SerializeField] private Fireball fireballPrefab;
    [SerializeField] private Transform bulletSource;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        EventBus.CastBullet += PullBullet;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EventBus.CastBulletAnim?.Invoke();
        }
    }

    private void OnDisable()
    {
        EventBus.CastBullet -= PullBullet;
    }

    private void PullBullet()
    {
        Fireball fireball = Instantiate(fireballPrefab, bulletSource.position, transform.rotation); 
        fireball.Direction = bulletSource.forward;
        _audioSource.PlayOneShot(SoundEvent.Clips[2]);
    }
}
