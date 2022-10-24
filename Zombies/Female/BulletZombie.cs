using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletZombie : MonoBehaviour
{

    public float speed;
    public GameObject zombieFem;
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
        transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
    
    }
    
    void BulletMove()
    {
        if(zombieFem.transform.localScale.x > 0)
        {
            rbBullet.velocity = new Vector2(speed * 1, rbBullet.velocity.y);

        }
        else
        {
            rbBullet.velocity = new Vector2(speed * -1, rbBullet.velocity.y);

        }

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
