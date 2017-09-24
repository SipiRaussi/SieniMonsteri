using UnityEngine;

public class SienestäjäBehaviour : MonoBehaviour {

    private Sprite[] sP = new Sprite[2];
    private SpriteRenderer sR;
    private new GameObject camera;
    private LayerMask layerMask;

    private float vectorLenght = 10f;

    // Use this for initialization
    void Start()
    {
        layerMask = LayerMask.GetMask("Terrain");
        camera = GameObject.FindWithTag("MainCamera");
        sR = GetComponent<SpriteRenderer>();
        GetSprites();
    }

    // Check that sienestäjä is on the terrain
    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit, vectorLenght, layerMask.value) ||
            Physics.Raycast(transform.position, Vector3.up, out hit, vectorLenght, layerMask.value))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SwitchSpriteWhenRunning();
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, camera.transform.eulerAngles.y, 0));
    }

    // Switch sprites when running
    void SwitchSpriteWhenRunning()
    {
        if (Escape.IsRunning)
        {
            sR.sprite = sP[1];
        }
        else
        {
            sR.sprite = sP[0];
        }
    }

    // Get needed sprites
    void GetSprites()
    {       
        // Get sprite for Sienestäjä(M) & Sienestäjä(F)
        if(gameObject.name == "Sienestäjä(M)(Clone)")
        {
            for (int sprite = 0; sprite < 2; sprite++)
            {
                sP[sprite] = SpriteManager.Sprites[sprite + 2];
                if(sP[sprite] == null)
                {
                    Debug.Log("Couldn't get sprite!");
                }
            }
        }
        else if(gameObject.name == "Sienestäjä(F)(Clone)")
        {
            for (int sprite = 0; sprite < 2; sprite++)
            {
                sP[sprite] = SpriteManager.Sprites[sprite];
                if (sP[sprite] == null)
                {
                    Debug.Log("Couldn't get sprite!");
                }
            }
        }
        else
        {
            Debug.Log("Gameobject name does not match! " + gameObject.name);
        }
    }


}
