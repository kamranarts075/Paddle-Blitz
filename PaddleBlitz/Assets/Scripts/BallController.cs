using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rbBall;
    public float ballBounceForce;
    private bool gameStarted;

    private void Awake()
    {
        rbBall = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.anyKeyDown)
            {
                BallBounce();
                
                gameStarted = true;
            }
        }
    }

    void BallBounce()
    {
        Vector2 randomDir = new Vector2(Random.Range(-1, 1), 1);
        
        rbBall.AddForce(randomDir * ballBounceForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("FallCheck"))
        {
            GameManager.instance.Restart();
        }
        
        else if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.ScoreUp();
        }
    }
}