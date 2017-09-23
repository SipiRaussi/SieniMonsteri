using UnityEngine;

public class CheckYPosition : MonoBehaviour
{
    float vectorLenght = 10f;
    private LayerMask layerMask;

    void Start()
    {
        layerMask = LayerMask.GetMask("Terrain");
    }

    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit, vectorLenght, layerMask.value) || 
            Physics.Raycast(transform.position, Vector3.up, out hit, vectorLenght, layerMask.value))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }
    }

}
