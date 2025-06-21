using DG.Tweening;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    public Transform cameraTransform;

    public Transform objectToFollow;
    public float offsetByLookDirection;

    private Vector3 _vel;
    public float smoothTime;

    private Vector3 _originalPos;

    private void Start()
    {
        _originalPos = cameraTransform.localPosition;
    }

    private void FixedUpdate()
    {
        var pos = objectToFollow.position;
        pos = pos + objectToFollow.forward * offsetByLookDirection;        
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref _vel, smoothTime);
    }

    public void ShakeCamera(float magnitude, float duration)
    {
        cameraTransform.DOKill();
        cameraTransform.localPosition = _originalPos;
        cameraTransform.DOShakePosition(duration, magnitude);
    }
}