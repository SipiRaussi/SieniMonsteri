using UnityEngine;

public class Escape : MonoBehaviour {

	public GameObject ShroomPointLoot;

    private Sprite sp;
    private AudioSource audioSource;
    private AudioClip scream;

	public float Speed;
    private bool isPlayed = false;
    public static bool IsRunning = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scream = AudioManager.AudioFX[2];

        sp = GetComponentInParent<SpriteRenderer>().sprite;
        if(sp.name == "Mummo_0" || sp.name == "Mummo_1")
        {
            audioSource.pitch = 1.5f;
        }
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
       
	}

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsRunning = false;
        }

   }
}
