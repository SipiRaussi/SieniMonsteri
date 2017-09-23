using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sienestäjä_turnaround : MonoBehaviour {

    public Sprite Sp;
    public Sprite Sp2;
    private SpriteRenderer SR;

    // Use this for initialization
    void Start () {

        SR = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
        void Update()
    {
            if (Escape.IsRunning)
            {
              SR.sprite = Sp2;
            }
    }
}
