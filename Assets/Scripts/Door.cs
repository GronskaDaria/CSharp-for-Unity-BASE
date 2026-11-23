using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform doorPanel;
    [SerializeField] private Collider doorBlocker;
    [SerializeField] private float openAngle = -100f;
    [SerializeField] private float openSpeed = 2f;

    private bool _isOpen;
    private float _openProgress;
    private Quaternion _closedRotation;
    private Quaternion _openRotation;

    public bool IsOpen => _isOpen;

    void Start()
    {
        _closedRotation = doorPanel.localRotation;
        _openRotation = _closedRotation * Quaternion.Euler(0, openAngle, 0);
    }

    void Update()
    {
        if (_isOpen && _openProgress < 1f)
        {
            _openProgress = Mathf.Min(1f, _openProgress + openSpeed * Time.deltaTime);
            doorPanel.localRotation = Quaternion.Slerp(_closedRotation, _openRotation, _openProgress);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            TryOpen();
        }
    }

    public bool CanOpen()
    {
        if (!DataContainer.HasKey)
        {
            return false;
        }

        RewardSystem rewards = FindFirstObjectByType<RewardSystem>();
        return rewards == null || rewards.AllCoinsCollected;
    }

    public bool TryOpen()
    {
        if (_isOpen || !CanOpen())
        {
            return false;
        }

        _isOpen = true;
        if (doorBlocker != null)
        {
            doorBlocker.enabled = false;
        }

        return true;
    }
}