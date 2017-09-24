﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class timer : MonoBehaviour
{

    public float TimeLeft = 10;
    private Text TimeLeftText;
    private Text GameOverText;
    private Text Score;
    private GameObject Restart;
    private GameObject Exit;
    private GameObject BLACK;
    private GameObject Hands;

    public int ShroomValue = 0;
    public int TimeIncrease = 5;
    public static bool TimeHasRunOut = false;

    void Start()
    {
        GetComponents();
    }

    // Update is called once per frame
    void Update()
    {


        TimeLeft -= Time.deltaTime;

        Score.text = "Points: " + ShroomValue;

        if (TimeLeft <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            GameOverText.text = "YOU DIEDED";
            Restart.SetActive(true);
            Exit.SetActive(true);
            BLACK.SetActive(true);
            Hands.SetActive(false);
            TimeHasRunOut = true;
            GetComponent<FirstPersonController>().enabled = false;
        }
        else
        {
            TimeLeftText.text = "Time Left: " + Mathf.Round(TimeLeft);
            // Debug.Log(text);
        }
    }


    void OnTriggerEnter(Collider got)
    {
        if (got.gameObject.tag == "pickup")
        {
            TimeLeft += TimeIncrease;
            ShroomValue = ShroomValue + 1;
        }
        else if (got.gameObject.tag == "hirvi")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            GameOverText.text = "YOU DIEDED";
            Restart.SetActive(true);
            Exit.SetActive(true);
            BLACK.SetActive(true);
            Hands.SetActive(false);
            TimeHasRunOut = true;
            GetComponent<FirstPersonController>().enabled = false;
        }
    }

    // Get all components
    void GetComponents()
    {
        if (TimeLeftText == null)
        {
            TimeLeftText = GameObject.FindWithTag("timeText").GetComponent<Text>();
        }

        if (GameOverText == null)
        {
            GameOverText = GameObject.FindWithTag("failText").GetComponent<Text>();
        }

        if (Score == null)
        {
            Score = GameObject.FindWithTag("scoreText").GetComponent<Text>();
        }

        if (Restart == null)
        {
            Restart = GameObject.FindWithTag("Restart");
            Restart.SetActive(false);
        }

        if (Exit == null)
        {
            Exit = GameObject.FindWithTag("Exit");
            Exit.SetActive(false);
        }

        if (BLACK == null)
        {
            BLACK = GameObject.FindWithTag("black");
            BLACK.SetActive(false);
        }

        if (Hands == null)
        {
            Hands = GameObject.FindWithTag("hands");
            
        }
        
    }
}