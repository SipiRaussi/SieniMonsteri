using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLost : MonoBehaviour
{

    private Rigidbody body;

    // Use this for initialization
    void Start()
    {

        body = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(timer.timeHasRunOut);
        if (timer.timeHasRunOut)
        {
            body.constraints = RigidbodyConstraints.FreezePosition;
        }
    }
}

