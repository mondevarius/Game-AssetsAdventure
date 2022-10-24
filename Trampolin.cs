using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    private Animator animTramp;
    private GameObject player;
    private Rigidbody2D rbPlayer;
    public float force;
    private AudioSource sfxTramp;

    
    
    void Start()
    {
        animTramp = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        rbPlayer = player.GetComponent<Rigidbody2D>();
        sfxTramp = GetComponent<AudioSource>();
    }

    
    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animTramp.SetBool("On", true);
            rbPlayer.AddForce(new Vector2(0f, force), ForceMode2D.Impulse);
            sfxTramp.PlayOneShot(sfxTramp.clip);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animTramp.SetBool("On", false);
        }
    }


}
