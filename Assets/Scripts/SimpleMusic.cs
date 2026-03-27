using UnityEngine;

public class SimpleMusic : MonoBehaviour
{
    private AudioSource audioSource;
    private static SimpleMusic instance;

    void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (audioSource == null) return;
        
        if (GameSettings.soundOn) 
        {
            if (!audioSource.isPlaying) audioSource.Play();
        }
        else 
        {
            if (audioSource.isPlaying) audioSource.Stop();
        }
    }
}
