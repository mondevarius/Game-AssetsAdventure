using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Rigidbody2D rbZombie;
    private Animator animZombie;
    private CapsuleCollider2D zombieCollider;
    public AudioSource dieZombieSFX;
    
    
    public GameObject player;
    public GameObject deadZone;
    
    public float speed;
    public float direction;
    public float distance;
    private float forcePush = 10;

    public bool foward = true;
    private bool moveController = true;
    private bool isRight = true;
    
    

    void Start()
    {
        rbZombie = GetComponent <Rigidbody2D>();
        animZombie = GetComponent<Animator>();
        zombieCollider = GetComponent<CapsuleCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");        
    }

    void Update()
    {
        MoveZombie();
        DieZombie();
        if(ZombieMaleAttack.attacking == true)
        {
            animZombie.SetBool("Attack", true);
            speed = 0;
            if(isRight == true)
            {
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcePush, 0));
                ZombieMaleAttack.attacking = false;
            }
            else
            {
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcePush * -1, 0));
                ZombieMaleAttack.attacking = false;

            }
            GameController.instance.ShowGameOver();
        }

    }

    void MoveZombie()
    {
        if(moveController == true)
        {
            rbZombie.velocity = new Vector2(speed * direction, rbZombie.velocity.y);
            animZombie.SetBool("Walk", true);
        }
        
    }

    IEnumerator ActiveMove()
    {
        
        moveController = false;
        animZombie.SetBool("Walk", false);
        animZombie.SetBool("Idle", true);
        yield return new WaitForSecondsRealtime(2f);
        if (isRight == true)
        {
            moveController = true;
            direction *= -1;
            rbZombie.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            animZombie.SetBool("Idle", false);
            animZombie.SetBool("Walk", true);
            isRight = false;
        }
        else
        {
            moveController = true;
            direction *= -1;
            rbZombie.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            animZombie.SetBool("Idle", false);
            animZombie.SetBool("Walk", true);
            isRight = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("ZombieLimit") && foward == true)
        {
            foward = false;
            StartCoroutine(ActiveMove());
            Invoke("FowardActive", 5f);
        }
        
    
    }
       
    
    void FowardActive()
    {
        foward = true;
    }
    
    void DieZombie()
    {
        if(deadZone.activeInHierarchy == false)
        {
            speed = 0;
            animZombie.SetBool("Hit", true);
            Destroy(zombieCollider);
            rbZombie.gravityScale = 0f;
        }
        
    }
    
    void DieSFXActive()
    {
        dieZombieSFX.PlayOneShot(dieZombieSFX.clip);
    }
  
}
