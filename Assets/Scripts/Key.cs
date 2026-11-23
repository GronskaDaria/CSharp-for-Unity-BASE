using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f;

    [SerializeField] private Light glowLight;
    [SerializeField] private float pulseSpeed = 3f;
    [SerializeField] private float pulseAmount = 0.35f;
    private float _baseIntensity;

    void Start()
    {
        if (glowLight != null)
        {
            _baseIntensity = glowLight.intensity;
        }
    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);

        if (glowLight != null)
        {
            glowLight.intensity = _baseIntensity * (1f + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            PickUp();
        }
    }

    public void PickUp()
    {
        DataContainer.HasKey = true;
        Destroy(gameObject);
    }
}