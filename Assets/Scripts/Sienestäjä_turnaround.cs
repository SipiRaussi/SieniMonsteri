using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sienestäjä_turnaround : MonoBehaviour {

    public Sprite Sp;
    public Sprite Sp2;
    private SpriteRenderer sR;

    // Use this for initialization
    void Start ()
    {

        sR = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
    void Update()
    {        
        if (Escape.IsRunning)
        {
            sR.sprite = Sp2;
        }
        else
        {
            sR.sprite = Sp;
        }
    }
}
