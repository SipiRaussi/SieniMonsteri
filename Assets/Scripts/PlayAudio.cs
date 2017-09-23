using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip chomp;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        chomp = AudioManager.AudioFX[0];
        audioSource.clip = chomp;
    }

    private void LateUpdate()
    {
        if (chomp == null)
        {
            chomp = AudioManager.AudioFX[0];
            audioSource.clip = chomp;
            Debug.Log(chomp.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "pickup")
        {
            audioSource.Play();
        }
    }
}
