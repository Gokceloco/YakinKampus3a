using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform fillParent;
    private Transform _mainCamera;
    private Transform _transform;

    private void Start()
    {
        _mainCamera = Camera.main.transform;
        _transform = transform;
    }

    public void SetHealthRatio(float ratio)
    {
        if (ratio >= 1 || ratio <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
        fillParent.localScale = new Vector3(ratio, 1, 1);
    }

    private void Update()
    {
        _transform.LookAt(_mainCamera.position);
    }
}
