using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private float _coinRotationSpeed;

    void Start()
    {
        _coinRotationSpeed = Random.Range(100, 200);
    }

    void Update()
    {
        transform.Rotate(0, _coinRotationSpeed * Time.deltaTime,0);
    }
}