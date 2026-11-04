using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _ghostTransform;
    [SerializeField] private float ghostSpeed = 0.03f;

    void Start()
    {
        _ghostTransform = GameObject.FindFirstObjectByType<GhostScript>().transform;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(_ghostTransform.position.x, transform.position.y, (_ghostTransform.position.z + 0.9f)),
            ghostSpeed);
    }
}