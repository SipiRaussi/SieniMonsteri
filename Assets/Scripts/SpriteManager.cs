using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public static Sprite[] Sprites;

    void Start()
    {
        LoadSprites();
    }

    void LoadSprites()
    {
        // Load all files
        Object[] sprites = Resources.LoadAll("Sprites", typeof(Sprite));
        Sprites = new Sprite[sprites.Length];

        // Convert files to sprites
        for (int sprite = 0; sprite < sprites.Length; sprite++)
        {
            Sprites[sprite] = (Sprite)sprites[sprite];

            if(Sprites[sprite] == null)
            {
                Debug.Log("Sprite[" + sprite + "] is null.");
            }
        }
    }
}
