using UnityEngine;

public class PlaneRotation : MonoBehaviour
{
    private new GameObject camera;

    void Awake()
    {
        camera = GameObject.FindWithTag("MainCamera");
    }

	void LateUpdate ()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, camera.transform.eulerAngles.y, 0));
    }
}
