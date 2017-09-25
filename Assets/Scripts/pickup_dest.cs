using System.Collections;
using UnityEngine;

public class pickup_dest : MonoBehaviour {

	//public float DestroyTime = 3.0f;
	private float rotateSpeed = 0f;

	private pickup_sys SystemCall;
	public Transform MySpawnPoint;

	void Start () 
	{
		SystemCall = GameObject.Find ("Pickup_system").GetComponent<pickup_sys> ();
		//StartCoroutine(DestroyMe());
	}
	
	void Update ()
	{
        transform.Rotate (Vector3.forward * Time.deltaTime * rotateSpeed);	
	}

	//Timed pickup destruction
	/*IEnumerator DestroyMe()
	{
		yield return new WaitForSeconds (DestroyTime);
		for (int spawnPoint = 0; spawnPoint < SystemCall.spawnPoints.Length; spawnPoint++) 
		{
			if (SystemCall.spawnPoints [spawnPoint] == MySpawnPoint) 			
			{
				SystemCall.possibleSpawns.Add (SystemCall.spawnPoints [spawnPoint]);
			}
		}
		Destroy (gameObject);
	}*/

	//Player pickup detection, destruction and score
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") 			
		{
            //Yeah, I use SendMessage, sue me :)
            gameObject.SendMessage ("PlayerDestroy");
		}	
	}

	//Once triggered, go through the same code as DestroyMe() function
    void PlayerDestroy()
	{		
		for (int spawnPoint = 0; spawnPoint < SystemCall.spawnPoints.Length; spawnPoint++) 
		{
			if (SystemCall.spawnPoints [spawnPoint] == MySpawnPoint) 
			{
				SystemCall.possibleSpawns.Add (SystemCall.spawnPoints [spawnPoint]);
			}
		}
		Destroy (gameObject);
	}
}
