using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    public static AudioManagement Instance { get; private set; }

    [SerializeField] private AudioClip bg_music;
    [SerializeField] private AudioClip collect;
    [SerializeField] private AudioClip fail;
    [SerializeField] private AudioClip gameover;

    private AudioSource oneShotSource;
    private AudioSource musicSource;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {

            Destroy(gameObject);

        }
        
        Instance = this;

        oneShotSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();

        musicSource.loop = true;
        musicSource.playOnAwake = false;
        musicSource.volume = .1f;
    }
    public void PlayCollect() => oneShotSource.PlayOneShot(collect);
    public void Playfail() => oneShotSource.PlayOneShot(fail);
    public void Playgameover() => oneShotSource.PlayOneShot(gameover);
    public void PlayBackgroundMusic()
    {
        if (musicSource.clip == bg_music && musicSource.isPlaying)
            return;

        musicSource.clip = bg_music;
        musicSource.Play();
    }

    public void StopBackgroundMusic()
    {
        musicSource.Stop();
    }
}
