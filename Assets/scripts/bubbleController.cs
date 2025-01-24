using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float radius;
    private float angle;

    private void Update()
    {
        angle += rotationSpeed * Time.deltaTime;

        angle = angle % 360;

        float radians = Mathf.Deg2Rad * angle;
        Vector3 newPos = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians)) * radius;
        transform.position = player.transform.position + newPos;

        transform.rotation = Quaternion.Euler(0,0, angle);
    }
}
