using UnityEngine;
using UnityEditor;

public class Escape : MonoBehaviour {

	public GameObject ShroomPointLoot;
    private AudioSource audioSource;
    private AudioClip scream;

	public float Speed;
    private bool isPlayed = false;
    public static bool IsRunning = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scream = AudioManager.AudioFX[2];
        audioSource.clip = scream;

        if (Speed == 0)
        {
            Speed = 3;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !isPlayed)
        {
            audioSource.Play();
            isPlayed = true;
        }
    }

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			ShroomPointLoot.transform.Translate(transform.forward * Time.deltaTime * Speed);
            IsRunning = true;
		}
        else
        {
            IsRunning = false;
        }
	}
}
