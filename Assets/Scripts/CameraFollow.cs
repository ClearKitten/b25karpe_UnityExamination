using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private Vector3 offset;

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 desieredPosition = target.position + offset;
        Vector3 smoothed = Vector3.Lerp(transform.position, desieredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothed;
    }
}
