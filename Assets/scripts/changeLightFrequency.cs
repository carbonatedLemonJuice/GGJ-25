using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class changeLightFrequency : MonoBehaviour
{
    private Light2D redLight;

    [SerializeField] private float changingSpeed, changingStrength;

    private float calculatedIntensity;

    private void Start()
    {
        redLight = GetComponent<Light2D>();
    }

    private void Update()
    {
        redLight.intensity = Mathf.PerlinNoise(Time.time * changingSpeed, 0) * (9 - 0.5f) + 0.5f;
    }
}
