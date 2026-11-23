using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _ghostTransform;

    [Header("Framing")] [SerializeField] private float height = 5f;
    [SerializeField] private float pitch = 65f;
    [SerializeField] private float yaw = 180f;

    [Header("Smoothing")] [SerializeField] private float smoothTime = 0.2f;
    [SerializeField] private float snapDistance = 6f;

    [Header("Look-ahead")] [SerializeField]
    private float lookAheadDistance = 1.5f;

    [SerializeField] private float lookAheadSmoothTime = 0.5f;

    private Vector3 _velocity;
    private Vector3 _lookAhead;
    private Vector3 _lookAheadVelocity;
    private Vector3 _lastGhostPosition;

    void Start()
    {
        GhostScript ghost = FindFirstObjectByType<GhostScript>();
        if (ghost == null)
        {
            enabled = false;
            return;
        }

        _ghostTransform = ghost.transform;
        _lastGhostPosition = _ghostTransform.position;
        transform.rotation = Quaternion.Euler(pitch, yaw, 0);
        transform.position = GetTargetPosition();
    }

    void LateUpdate()
    {
        UpdateLookAhead();
        Vector3 target = GetTargetPosition();

        if (Vector3.Distance(transform.position, target) > snapDistance)
        {
            transform.position = target;
            _velocity = Vector3.zero;
            _lookAhead = Vector3.zero;
            return;
        }

        transform.position = Vector3.SmoothDamp(transform.position, target, ref _velocity, smoothTime);
    }

    private void UpdateLookAhead()
    {
        Vector3 moved = _ghostTransform.position - _lastGhostPosition;
        _lastGhostPosition = _ghostTransform.position;
        moved.y = 0;

        Vector3 desired = Vector3.zero;
        if (moved.sqrMagnitude > 0.0001f && moved.magnitude < 1f)
        {
            desired = moved.normalized * lookAheadDistance;
        }

        _lookAhead = Vector3.SmoothDamp(_lookAhead, desired, ref _lookAheadVelocity, lookAheadSmoothTime);
    }

    public Vector3 GetTargetPosition()
    {
        Vector3 focus = _ghostTransform.position + _lookAhead;
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        float distance = height / Mathf.Sin(pitch * Mathf.Deg2Rad);
        return focus - rotation * Vector3.forward * distance;
    }
}