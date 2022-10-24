using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeadZone : MonoBehaviour
{
    private float jumpForce = 400;
    private BoxCollider2D zoneCollider;
    
    void Start()
    {
        zoneCollider = GetComponent<BoxCollider2D>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            gameObject.SetActive(false);
            zoneCollider.isTrigger = true;
            
        }
    }

}    
