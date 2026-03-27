using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip music;
    private AudioSource audioSource;
    private static MusicController instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);
        
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = music;
        audioSource.loop = true;
        audioSource.volume = 1f;
        
        if (GameSettings.soundOn)
            audioSource.Play();
    }

    void Update()
    {
        if (GameSettings.soundOn && !audioSource.isPlaying)
            audioSource.Play();
        else if (!GameSettings.soundOn && audioSource.isPlaying)
            audioSource.Pause();
    }
}
