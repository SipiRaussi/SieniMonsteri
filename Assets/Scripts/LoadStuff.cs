using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStuff : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Restart () {

		SceneManager.LoadScene ("SieniMonsteri");
		
	}

    public void Quic() {

        Application.Quit();
    }
}
