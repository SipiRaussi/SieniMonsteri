using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hirvi_trigger : MonoBehaviour

{

    private Chase chase;
    public GameObject Hirirv;

    void Start()
    {
        chase = GameObject.Find("Hirvi").GetComponent<Chase>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Hirirv.GetComponent<Chase>().enabled = true;
            Hirirv.GetComponent<Animator>().enabled = true;
        }
    }

    void OnTriggerExit(Collider othertoo)
    {
        if (othertoo.gameObject.tag == "Player")
        {
            Hirirv.SendMessage("change");
            Hirirv.GetComponent<Chase>().enabled = false;
            Hirirv.GetComponent<Animator>().enabled = false;

        }
    }
}
