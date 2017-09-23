using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sienestäjä_turnaround : MonoBehaviour {

    private Material material;
    public Sprite Sp;
    public Sprite Sp2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
        void Update()
    {
            if (Escape.IsRunning && (material.mainTexture == Sp))
            {
                Sp = Sp2;
            }
    }
}
