﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {

    public float timeLeft = 10;
    public string text;
    public string gameOver;
    public int timeIncrease = 5;
    public static bool timeHasRunOut = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {


        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            gameOver = ("Game over");
            Debug.Log(gameOver);
            timeHasRunOut = true;
        }
        else
        {
            text = ("You have " + timeLeft + "seconds left");
            Debug.Log(text);
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "pickup")
        {
            timeLeft += timeIncrease;
            Destroy(other.gameObject);
        }
    }
}