using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCannon : MonoBehaviour
{
    private Animator animBullet;
    private Rigidbody2D rbBullet;
    
    
    void Start()
    {
        animBullet = GetComponent<Animator>();
        rbBullet = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        rbBullet.velocity = new Vector2(rbBullet.velocity.x, -2);
    }
    
    void BulletDestroy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            animBullet.SetBool("Fire", true);
            Invoke("BulletDestroy", 0.5f);
        }

        if (collision.gameObject.layer == 10)
        {
            animBullet.SetBool("Fire", true);
            Invoke("BulletDestroy", 0.5f);
        }
    }

    
}
