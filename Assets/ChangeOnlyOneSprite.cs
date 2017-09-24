using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOnlyOneSprite : MonoBehaviour {

    public Sprite idle;
    private SpriteRenderer rer;
    //you can actually sue me now


    void Start()
    {

        rer = GetComponent<SpriteRenderer>();

    }


    void change () {

        rer.sprite = idle;

	}
}
