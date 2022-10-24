using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMaleAttack : MonoBehaviour
{
    public static bool attacking = false;
    public GameObject attack;
    public GameObject deadZone;

        
    void Start()
    {
        
    }

    void Update()
    {
       if(deadZone.activeInHierarchy == false)
        {
            Destroy(gameObject);
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            attacking = true;
            attack.SetActive(false);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("AttackReload", 1f);
        }
    }

    void AttackReload()
    {
        attacking = false;
        attack.SetActive(true);
    }

    
}
