using UnityEngine;

public class SoundEvent : MonoBehaviour
{
    [SerializeField] private AudioSource calmBGM;
    [SerializeField] private AudioSource emptyBGM;
    [SerializeField] private AudioClip[] clips;
    
    public static AudioClip[] Clips { get; private set; }

    private void Awake()
    {
        Clips = clips;
    }

    void Update()
    {
        if (EnemyStates.enemyCount == 0)
            ChangeMusic();
    }

    void ChangeMusic()
    {
        calmBGM.gameObject.SetActive(false);
        emptyBGM.gameObject.SetActive(true);
    }
}
