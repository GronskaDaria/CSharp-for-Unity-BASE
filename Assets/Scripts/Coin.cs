using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coin : MonoBehaviour
{
    private float _coinRotationSpeed;
    private RewardSystem _rewardSystem;

    void Start()
    {
        _rewardSystem = GetComponentInParent<RewardSystem>();
        _coinRotationSpeed = Random.Range(100, 200);
    }

    void Update()
    {
        transform.Rotate(0, _coinRotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            _rewardSystem.AddCoin();
            Destroy(gameObject);
        }
    }
}