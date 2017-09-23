using UnityEngine;

public class PlaneRotation : MonoBehaviour
{
    private new GameObject camera;
    private Material material;
    public Sprite Sp;
    public Sprite Sp2;

    void Awake()
    {
        camera = GameObject.FindWithTag("MainCamera");
        material = GetComponent<Material>();
    }

    void Update()
    {
        if (Escape.IsRunning && (material.mainTexture == Sp))
        {
            Sp = Sp2;
        }
    }

	void LateUpdate ()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, camera.transform.eulerAngles.y, 0));
    }
}
