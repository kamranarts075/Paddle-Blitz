using System;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    Rigidbody2D rbPaddle;
    public float moveSpeed;

    private void Awake()
    {
        rbPaddle = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        TouchMove();
    }

    void TouchMove()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (touchPos.x < 0)
            {
                rbPaddle.linearVelocity = Vector2.left * moveSpeed;
            }
            else
            {
                rbPaddle.linearVelocity = Vector2.right * moveSpeed;
            }
        }
        else
        {
            rbPaddle.linearVelocity = Vector2.zero;
        }
    }
}
