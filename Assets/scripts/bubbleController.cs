using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bubbleController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float rotationSpeed;
    private float _rotateSpeed;
    [SerializeField] private float radius, depletionRate, increaseRate, dampingVelocity;
    [SerializeField] private Slider powerBar;
    private float _angle;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private bool decreaseOnHold;

    private Color noAlpha, originalColor;

    private Vector2 previousPosition;

    private bool spaceBarReleased;

    private SpriteRenderer sprite;

    private void Start()
    {
        noAlpha.a = 0f;
        sprite = GetComponent<SpriteRenderer>();
        originalColor = sprite.color;
        spaceBarReleased = true;
        _rotateSpeed = rotationSpeed;
        decreaseOnHold = false;
        
    }

    private void Update()
    {
        spaceBarControl();

        velocityChecker();

        rotateArrow();

        arrowRemover();
    }
    
    private void spaceBarControl()
    {
        Debug.Log("function called");
        if (Input.GetKey(KeyCode.Space) && !decreaseOnHold)
        {
            _rotateSpeed = 0;
            sliderIncrease();
            spaceBarReleased = false;
        }

        if (powerBar.value == powerBar.maxValue && !decreaseOnHold)
        {
            Debug.Log("bool value toggled");
            powerBar.value = powerBar.maxValue;
            decreaseOnHold = true;
        }

        else if (Input.GetKey(KeyCode.Space) && decreaseOnHold)
        {
            Debug.Log("conditional code called.");
            decreaseOnHold = true;
            sliderDecrease();

            if (powerBar.value == powerBar.minValue || powerBar.value < powerBar.minValue)
            {
                decreaseOnHold = false;
            }
        }

        if (!Input.GetKey(KeyCode.Space)) 
        {
            if (!spaceBarReleased)
            {
                movePlayerinArrowDirection();
                spaceBarReleased = true;
            }

            _rotateSpeed = rotationSpeed;
            if (powerBar.value > 0)
            {
                sliderDecrease();
                decreaseOnHold = false;
            }
        }
    }

    private void sliderIncrease()
    {
        powerBar.value += Time.deltaTime * increaseRate;
        Debug.Log("value increasing");
    }

    private void sliderDecrease()
    {
        powerBar.value -= Time.deltaTime * depletionRate;
        Debug.Log("value decreasing");
    }

    private void movePlayerinArrowDirection()
    {
        float radians2 = Mathf.Deg2Rad * _angle;
        Vector2 direction = new Vector2(MathF.Cos(radians2), MathF.Sin(radians2)) * radius;

        float power = powerBar.value;

        rb.velocity = direction * power;

        Debug.Log("player moved in arrow direction");
    }

    private void rotateArrow()
    {
        _angle += _rotateSpeed * Time.deltaTime;

        _angle = _angle % 360;

        float radians = Mathf.Deg2Rad * _angle;
        Vector3 newPos = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)) * radius;
        transform.position = player.transform.position + newPos;

        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }

    private void velocityChecker()
    {
        if (rb.velocity.magnitude > 0.09f)
        {
            _rotateSpeed = 0;
            Debug.Log("decreasing speed");
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, dampingVelocity * Time.deltaTime);
        }

        else if (!Input.GetKey(KeyCode.Space) && _rotateSpeed == 0) 
        {
            _rotateSpeed = rotationSpeed; 
            rb.velocity = Vector2.zero;
        }
    }

    private void arrowRemover()
    {
        
        if (_rotateSpeed == 0 && !Input.GetKey(KeyCode.Space))
        {
            Debug.Log("setting alpha to zero");
            sprite.color = noAlpha;
            Debug.Log("alpha value: " +  sprite.color.a);
        }
        
        else
        {
            sprite.color = originalColor;
        }
    }
}
