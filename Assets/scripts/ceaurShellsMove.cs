using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ceaurShellsMove : MonoBehaviour
{

    [SerializeField] private float floatStrength, floatSpeed, 
        randomDriftStrength, randomDriftSpeed;

    private Vector3 initialPos;

    private void Start()
    {
        initialPos = transform.position;
    }

    private void Update()
    {
        float yOffSet = Mathf.Sin(Time.time * floatSpeed) * floatStrength;

        float xOffset = Mathf.PerlinNoise(Time.time * randomDriftSpeed, 0) * randomDriftStrength - randomDriftSpeed / 2;
        float zOffset = Mathf.PerlinNoise(0, Time.time * randomDriftSpeed) * randomDriftStrength - randomDriftStrength / 2;

        transform.position = new Vector3(initialPos.x + xOffset, initialPos.y + yOffSet, initialPos.z + zOffset);
    }
}
