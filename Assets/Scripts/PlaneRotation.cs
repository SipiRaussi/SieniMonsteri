using UnityEngine;

public class PlaneRotation : MonoBehaviour
{
    private GameObject camera;

    void Awake()
    {
        camera = GameObject.FindWithTag("MainCamera");
    }

	void LateUpdate ()
    {
		transform.rotation = camera.transform.rotation;
    }
}
