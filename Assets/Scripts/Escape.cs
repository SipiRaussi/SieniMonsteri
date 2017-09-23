using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour {

	public GameObject ShroomPointLoot;
	public float verspe;



	void Update()
	{
		
	}

	void OnTriggerStay(Collider wol)
	{
		if (wol.gameObject.tag == "playerdet") 
		{
			

			ShroomPointLoot.transform.Translate(transform.forward * Time.deltaTime * verspe);

		}
	}
}
