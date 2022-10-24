using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSliderUpDown : MonoBehaviour
{

    private Rigidbody2D rbStone;
    private Animator animStone;
    private CapsuleCollider2D[] capsules;
    
    void Start()
    {
        rbStone = GetComponent<Rigidbody2D>();
        animStone = GetComponent<Animator>();
        capsules = GetComponents<CapsuleCollider2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            foreach(CapsuleCollider2D cap in capsules)
            {
                cap.enabled = false;
            }
            
            rbStone.gravityScale = 5;
            animStone.SetBool("On", true);

        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Invoke("ReturnPosition", 3f);
        
    }

    void ReturnPosition()
    {
        rbStone.gravityScale = -1;
        animStone.SetBool("On", false);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RespawColliders")
        {
            Invoke("CollidersTimer", 5f);   
        }
        if(collision.gameObject.tag == "Player")
        {
            GameController.instance.ShowGameOver();

        }
    }

    void CollidersTimer()
    {
        foreach (CapsuleCollider2D cap in capsules)
        {
            cap.enabled = true;
        }
    }
}
