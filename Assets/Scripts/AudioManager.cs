using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // Arrays of audio files
    public static AudioClip[] Music;
    public static AudioClip[] AudioFX;

    private AudioSource audioSource;
    private Scene currentScene;

    static bool created = false;
    bool isChanged = false;
    private string sceneName;

    void Awake()
    {
        if(!created)
        {
            DontDestroyOnLoad(gameObject);
            created = true;
        }
        else
        {
            Destroy(gameObject);
        }

        LoadAudio();

        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        PlayMusic(sceneName);
    }

    void LateUpdate()
    {
        if(currentScene.name != SceneManager.GetActiveScene().name && !isChanged)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            PlayMusic(sceneName);
            isChanged = true;
        }
    }

    /// <summary>
    ///  Checks what scene is runnin and puts wanted track to play it on loop
    /// </summary>
    /// <param name="sceneName"> Scene name </param>
    void PlayMusic(string sceneName)
    {
        if (sceneName == "MainMenu")
        {
            audioSource.clip = Music[0];
        }
        else if (sceneName == "SieniMonsteri")
        {
            audioSource.clip = Music[1];
        }

        if(audioSource.clip != null)
        {
            audioSource.Play();

            if(!audioSource.loop)
            {
                audioSource.loop = true;
            }
        }
    }

    /// <summary>
    /// Handles of loading all audio files
    /// </summary>
    void LoadAudio()
    {
        Object[] music = Resources.LoadAll("Audio/Music", typeof(AudioClip));
        Music = new AudioClip[music.Length];

        // Check if couldn't find audio track
        for(int tune = 0; tune < Music.Length; tune++)
        {
            Music[tune] = (AudioClip)music[tune];

            if(Music[tune] == null)
            {
                Debug.Log("Couldn't find audio track for Music[" + tune + "].");
            }
        }

        Object[] audioFX = Resources.LoadAll("Audio/FX", typeof(AudioClip));
        AudioFX = new AudioClip[audioFX.Length];

        // Check if couldn't find audio track
        for (int effect = 0; effect < AudioFX.Length; effect++)
        {
            AudioFX[effect] = (AudioClip)audioFX[effect]; 

            if (AudioFX[effect] == null)
            {
                Debug.Log("Couldn't find audio track for Music[" + effect + "].");
            }
        }
    }
}
