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
    [SerializeField] private float radius, depletionRate, increaseRate, moveSpeed;
    [SerializeField] private Slider powerBar;
    private float _angle;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private bool decreaseOnHold;

    private Vector2 previousPosition;

    private void Start()
    {
        _rotateSpeed = rotationSpeed;
        decreaseOnHold = false;
    }

    private void Update()
    {
        spaceBarControl();

        velocityChecker();

        rotateArrow();
    }
    
    private void spaceBarControl()
    {
        Debug.Log("function called");
        if (Input.GetKey(KeyCode.Space) && !decreaseOnHold)
        {
            _rotateSpeed = 0;
            sliderIncrease();
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
            movePlayerinArrowDirection();
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

        rb.velocity = direction * powerBar.value;
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
        if (rb.velocity.magnitude > 0.01f)
        {
            _rotateSpeed = 0;
        }

        else if (!Input.GetKey(KeyCode.Space) && _rotateSpeed == 0) 
        {
            _rotateSpeed = rotationSpeed; 
        }
    }
}
