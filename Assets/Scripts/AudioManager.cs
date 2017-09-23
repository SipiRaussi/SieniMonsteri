using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // Arrays of audio files
    public static AudioClip[] Music = new AudioClip[2];
    public static AudioClip[] AudioFX = new AudioClip[3];

    private AudioSource audioSource;

    void Awake()
    {
        LoadAudio();

        audioSource = GetComponent<AudioSource>();

        Scene currenScene = SceneManager.GetActiveScene();
        string sceneName = currenScene.name;

        PlayMusic(sceneName);
    }

    /// <summary>
    ///  Checks what scene is runnin and puts wanted track to play it on loop
    /// </summary>
    /// <param name="sceneName"> Scene name </param>
    void PlayMusic(string sceneName)
    {
        if (sceneName == "Menu")
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
        Music[0] = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets/Music/SieniMonsteri - Menu.ogg", typeof(AudioClip));
        Music[1] = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets/Music/SieniMonsteri - The Hunt.ogg", typeof(AudioClip));

        // Check if couldn't find audio track
        for(int tune = 0; tune < Music.Length; tune++)
        {
            if(Music[tune] == null)
            {
                Debug.Log("Couldn't find audio track for Music[" + tune + "].");
            }
        }

        AudioFX[0] = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets/Music/SieniMonsteri - Chomp.ogg", typeof(AudioClip));
        AudioFX[1] = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets/Music/SieniMonsteri - Reward.ogg", typeof(AudioClip));
        AudioFX[2] = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets/Music/SieniMonsteri - Scream.ogg", typeof(AudioClip));

        // Check if couldn't find audio track
        for (int effect = 0; effect < AudioFX.Length; effect++)
        {
            if (AudioFX[effect] == null)
            {
                Debug.Log("Couldn't find audio track for Music[" + effect + "].");
            }
        }
    }
}
