using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coin : MonoBehaviour
{
    private float _coinRotationSpeed;

    void Start()
    {
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
            DataContainer.Coins++;
            Destroy(gameObject);
        }
    }
}