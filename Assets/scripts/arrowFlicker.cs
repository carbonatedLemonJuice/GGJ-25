using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class arrowFlicker : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    private SpriteRenderer arrowSprite;
    private Color alpha1, alpha2, alpha3, alpha4, ogColor;
    private bool coroutineRunning;

    private void Start()
    {
        coroutineRunning = false;
        arrowSprite = arrow.GetComponent<SpriteRenderer>();
        ogColor = arrowSprite.color;
        alpha2.a = 0.35f;
        alpha4.a = 0;
        alpha3.a = 0.68f;
        alpha1.a = 0.5f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("bubblePlayer") && !coroutineRunning)
        {
            StartCoroutine(flickerOnStay());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    private IEnumerator flickerOnStay()
    {
        Debug.Log("coroutine called");
        coroutineRunning = true;
        arrowSprite.color = alpha1;
        yield return new WaitForSeconds(Random.Range(0.15f, 0.25f));
        arrowSprite.color = alpha2;
        yield return new WaitForSeconds(Random.Range(0.35f, 0.40f));
        arrowSprite.color = alpha3;
        yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));
        arrowSprite.color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(Random.Range(0.85f, 1.45f));
        arrowSprite.color = alpha4;
        coroutineRunning = false;
    }

    private IEnumerator flickerOnExit()
    {
        coroutineRunning = true;
        arrowSprite.color = alpha1;
        yield return new WaitForSeconds(Random.Range(0.15f, 0.25f));
        arrowSprite.color = alpha2;
        yield return new WaitForSeconds(Random.Range(0.35f, 0.40f));
        arrowSprite.color = alpha3;
        yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));
        arrowSprite.color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(Random.Range(0.85f, 1.45f));
        arrowSprite.color = alpha4;
    }
}
