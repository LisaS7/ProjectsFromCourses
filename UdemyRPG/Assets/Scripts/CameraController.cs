using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Tilemap map;
    Vector3 bottomLeftLimit;
    Vector3 topRightLimit;

    void Start()
    {
        target = PlayerController.instance.transform;

        bottomLeftLimit = map.localBounds.min;
        topRightLimit = map.localBounds.max;
    }


    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        // keep the camera inside the map
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),
            Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y),
            transform.position.z);
    }
}
