using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallGround : MonoBehaviour
{
    private Rigidbody2D rbGround;
    private BoxCollider2D boxGround;



    void Start()
    {
        rbGround = GetComponent<Rigidbody2D>();
        boxGround = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rbGround.gravityScale = 2;
            Invoke("Destroy", 0.3f);
        }
    }
}
