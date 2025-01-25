using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeGreen : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Color color;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bubblePlayer"))
        {
            spriteRenderer.color = color;
            player.layer = LayerMask.NameToLayer("greenPlayer");
            gameObject.SetActive(false);
        }
    }
}
