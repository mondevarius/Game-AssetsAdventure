using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseBallRight : MonoBehaviour
{
    private Rigidbody2D rbBall;
    private Animator animBallRight;
    public AudioSource explode;

    
    void Start()
    {
        rbBall = GetComponent<Rigidbody2D>();
        animBallRight = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            rbBall.AddForce(new Vector2(-3f, 10f), ForceMode2D.Impulse);
            
        }
        
        if (collision.gameObject.CompareTag("Player"))
        {
            animBallRight.SetBool("Explosion", true);
            Invoke("BallDestroy", 0.5f);
            explode.Play();
            Invoke("GameOver", 0.5f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DestroyCheeseBall"))
        {
            animBallRight.SetBool("Explosion", true);
            explode.Play();
            Invoke("BallDestroy", 0.5f);
        }
    }

    void BallDestroy()
    {
        Destroy(gameObject);

    }

    void GameOver()
    {
        GameController.instance.ShowGameOver();

    }


}
