using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletZombieLeft : MonoBehaviour
{

    public float speed;
    private float direction = -1;
    private Rigidbody2D rbBullet;
    


    void Start()
    {
        rbBullet = GetComponent<Rigidbody2D>();
        BulletDirection();

    }

    private void FixedUpdate()
    {
        BulletMove();
    }
    void Update()
    {

    }
    
    void BulletDirection()
    {
        transform.localScale = new Vector2(transform.localScale.x * 1, transform.localScale.y);

        
    }

    void BulletMove()
    {
        rbBullet.velocity = new Vector2(speed * direction, rbBullet.velocity.y);
         
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        
        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.instance.ShowGameOver();

        }
    }

    
}

