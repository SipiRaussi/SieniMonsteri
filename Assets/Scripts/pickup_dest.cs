using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_dest : MonoBehaviour {

	public float destroyTime = 3.0f;
	private float rotateSpeed = 800f;

	private pickup_sys SystemCall;
	public Transform mySpawnPoint;


	void Start () 

	{
		SystemCall = GameObject.Find ("Pickup_Spawns").GetComponent<pickup_sys> ();
		StartCoroutine(DestroyMe());
	}
	
	void Update ()
	{
		transform.Rotate (Vector3.forward * Time.deltaTime * rotateSpeed);
		
	}


	//Timed pickup destruction

	IEnumerator DestroyMe()

	{
		yield return new WaitForSeconds (destroyTime);
		for (int i = 0; i < SystemCall.spawnPoints.Length; i++) 
		{
			if (SystemCall.spawnPoints [i] == mySpawnPoint) 
				
			{
				SystemCall.possibleSpawns.Add (SystemCall.spawnPoints [i]);
			}
		}

		Destroy (gameObject);
	}

	//Player pickup destruction and score

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") 
			
		{
			//Yeah, I use SendMessage, sue me :)
			this.gameObject.SendMessage ("PlayerDestroy");
		}

		
	}

    void PlayerDestroy()
	{
		
		for (int i = 0; i < SystemCall.spawnPoints.Length; i++) 
		{
			if (SystemCall.spawnPoints [i] == mySpawnPoint) 

			{
				SystemCall.possibleSpawns.Add (SystemCall.spawnPoints [i]);
			}
		}

		Destroy (gameObject);
		Debug.Log ("jep");
	}

}
