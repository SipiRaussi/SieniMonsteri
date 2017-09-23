using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class timer : MonoBehaviour {

    public float timeLeft = 10;
	public Text text;
	public Text gameOver;
	public Text score;
	public GameObject Restart;
	public GameObject Exit;
	public int shroomValue = 0;
    public int timeIncrease = 5;
	public GameObject pickup_system;
    public static bool timeHasRunOut = false;



	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		

        timeLeft -= Time.deltaTime;

		score.text = "Points: " + shroomValue;

        if (timeLeft <= 0)
        {
			
			Cursor.lockState = CursorLockMode.None;
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;

			gameOver.text = "YOU DIEDED";
			Restart.SetActive (true);
			Exit.SetActive (true);
            timeHasRunOut = true;
			this.GetComponent<FirstPersonController> ().enabled = false;

        }
        else
        {
			text.text = "Time Left: " + Mathf.Round (timeLeft);
           // Debug.Log(text);
        }
	}
		

	void OnTriggerEnter(Collider got)

	{
		if (got.gameObject.tag == "pickup") {
			
			timeLeft += timeIncrease;
			shroomValue = shroomValue + 1;

		} 
			
    }
}
