using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class arrowFlicker : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    private SpriteRenderer arrowSprite;
    private Color alpha1, alpha2, alpha3, alpha4, ogColor, noAlpha;
    private bool coroutineRunning;

    private void Start()
    {
        coroutineRunning = false;
        arrowSprite = arrow.GetComponent<SpriteRenderer>();
        ogColor = arrowSprite.color;
        noAlpha.a = 0;
        alpha2.a = 0.35f;
        alpha4.a = 0;
        alpha3.a = 0.18f;
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
        arrowSprite.color = ogColor;
    }

    private IEnumerator flickerOnStay()
    {
        Debug.Log("coroutine called");
        coroutineRunning = true;
        /*arrowSprite.color = alpha1;
        yield return new WaitForSeconds(Random.Range(0.15f, 0.25f));
        arrowSprite.color = alpha2;
        yield return new WaitForSeconds(Random.Range(0.35f, 0.40f));
        arrowSprite.color = alpha3;
        yield return new WaitForSeconds(Random.Range(0.1f, 0.2f));*/
        Debug.Log("aplha value changed");
        arrowSprite.color = alpha3; 
        yield return new WaitForSeconds(Random.Range(12.5f, 13.45f));
        arrowSprite.color = ogColor;
        Debug.Log("coroutine ran successfully");
        //arrowSprite.color = alpha4;
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
        arrowSprite.color = noAlpha;
        yield return new WaitForSeconds(Random.Range(0.85f, 1.45f));
        arrowSprite.color = alpha4;
    }
}
