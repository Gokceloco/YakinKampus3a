using UnityEngine;

public class MiniMapCameraHolder : MonoBehaviour
{
    public Transform objectToFollow;

    private void FixedUpdate()
    {
        transform.position = objectToFollow.position;
    }
}
