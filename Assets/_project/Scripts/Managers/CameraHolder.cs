using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    public Transform objectToFollow;
    public float offsetByLookDirection;

    private Vector3 _vel;
    public float smoothTime;

    private void FixedUpdate()
    {
        var pos = objectToFollow.position;
        pos = pos + objectToFollow.forward * offsetByLookDirection;        
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref _vel, smoothTime);
    }
}