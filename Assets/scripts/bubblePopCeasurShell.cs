using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubblePopCeasurShell : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bubblePlayer"))
        {
            Debug.Log("player died");
        }
    }
}
