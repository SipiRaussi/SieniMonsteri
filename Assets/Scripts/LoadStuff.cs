using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStuff : MonoBehaviour
{
	// Update is called once per frame
	public void Restart () {

		SceneManager.LoadScene ("SieniMonsteri");
		
	}

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit() {

        Application.Quit();
    }
}
