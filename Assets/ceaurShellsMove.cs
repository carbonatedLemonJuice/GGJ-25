using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceaurShellsMove : MonoBehaviour
{
    [SerializeField] private int maxRotation, minRotation;
    [SerializeField] private float maxRotationStrength, minRotationStrength;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rb.AddForce(Vector2.up * 8);
        transform.Rotate(Random.Range(minRotationStrength, maxRotationStrength), Random.Range(minRotationStrength, maxRotationStrength), Random.Range(minRotationStrength, maxRotationStrength));
    }
}
