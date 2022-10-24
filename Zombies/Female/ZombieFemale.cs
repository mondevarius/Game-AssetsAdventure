using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieFemale : MonoBehaviour
{
    private CapsuleCollider2D zombieCollider;
    private Rigidbody2D rbZombie;
    private Animator animZombie;
    private BoxCollider2D boxZombie;
    public AudioSource zombieDieSFX;

    //Variáveis de tiro
    public GameObject shootPrefab;
    public GameObject shootPrefab2;
    public GameObject shootPoint;
    public Transform shootTransform;

    //Variáveis de conferência de Hit
    public GameObject deadZone;

    public float directionZombie;
    public Vector3 rotZombie;
    
    
    

    
    void Start()
    {
        animZombie = GetComponent<Animator>();
        zombieCollider = GetComponent<CapsuleCollider2D>();
        rbZombie = GetComponent<Rigidbody2D>();
        boxZombie = GetComponent<BoxCollider2D>();
        PositionInit();
        
    }

    
    void Update()
    {
        if (deadZone.activeInHierarchy == false)
        {
            DieZombie();
        }

        
    }


    void PositionInit()
    {
        if(directionZombie > 0)
        {
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);

        }
        else
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            
        }
    }

    void DieZombie()
    {
        animZombie.SetBool("Hit", true);
        rbZombie.gravityScale = 0;
        Destroy(zombieCollider);
        boxZombie.enabled = false;
        
    }

    void DieSFXActive()
    {
        zombieDieSFX.PlayOneShot(zombieDieSFX.clip);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (directionZombie > 0)
            {
                animZombie.SetBool("Attack", true);
                Instantiate(shootPrefab, shootTransform.position, shootTransform.rotation);
            }
            else
        if (directionZombie < 0)
            {
                animZombie.SetBool("Attack", true);
                Instantiate(shootPrefab2, shootTransform.position, shootTransform.rotation = Quaternion.Euler(rotZombie));
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animZombie.SetBool("Attack", false);

        }
    }

}
