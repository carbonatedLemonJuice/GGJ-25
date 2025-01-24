using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeIncrease : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float decreaseRate;
    private float localX, localY;
    private bool decreasing, increasing;
    private SpriteRenderer sprite;
    private Color noAlpha;

    private void Start()
    {
        noAlpha.a = 0f;
        sprite = GetComponent<SpriteRenderer>();
        localX = player.transform.localScale.x;
        localY = player.transform.localScale.y;
    }

    private void Update()
    {
        if (decreasing)
        {
            if (localX > 0.45f && localY > 0.45f)
            {
                decreaseSize();
            }
        }

        if (localX <= 0.45f && localY <= 0.45f)
        {
            decreasing = false;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bubblePlayer"))
        {

            decreasing = true;
            sprite.color = noAlpha;
        }
    }

    private void decreaseSize()
    {
        localX -= decreaseRate * Time.deltaTime;
        localY -= decreaseRate * Time.deltaTime;
        player.transform.localScale = new Vector2(localX, localY);
        Debug.Log("decreasing value");
    }

    private void increaseSize()
    {

    }
}
