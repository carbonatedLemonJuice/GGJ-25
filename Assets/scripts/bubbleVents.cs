using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleVents : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float yVelocity;
    private float changedVelocity;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("trigger collision detected");
        if (collision.CompareTag("bubblePlayer"))
        {
            Debug.Log("player in unpstream");
            increaseYvelocity();
        }
    }

    private void increaseYvelocity()
    {
        changedVelocity = Time.deltaTime * yVelocity;
        rb.velocity = new Vector2(rb.velocity.x, changedVelocity);
    }
}
