using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ceaurShellsMove : MonoBehaviour
{
    [SerializeField]
    private float floatStrength, floatSpeed,
        randomDriftStrength, randomDriftSpeed;

    private Vector3 initialPos;
    private float randomSeedX, randomSeedZ, randomSeedY;

    private void Start()
    {
        initialPos = transform.position;

        // Initialize random seeds for Perlin noise
        randomSeedX = Random.Range(0f, 25f);
        randomSeedZ = Random.Range(0f, 25f);
        randomSeedY = Random.Range(0f, 25f);
    }

    private void Update()
    {
        float yOffSet = Mathf.Sin(Time.time * floatSpeed + randomSeedY) * floatStrength * 2f; 
        yOffSet += Mathf.PerlinNoise(Time.time * randomDriftSpeed + randomSeedY, 0) * 0.5f;


        float xOffset = Mathf.PerlinNoise(Time.time * randomDriftSpeed + randomSeedX, 0) * randomDriftStrength - randomDriftStrength / 2;
        float zOffset = Mathf.PerlinNoise(0, Time.time * randomDriftSpeed + randomSeedZ) * randomDriftStrength - randomDriftStrength / 2;

        transform.position = new Vector3(initialPos.x + xOffset, initialPos.y + yOffSet, initialPos.z + zOffset);
    }
}
