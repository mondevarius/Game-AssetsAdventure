using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Sword : MonoBehaviour
{
    private Transform player;
    private float speed = 3f;
    private float step;
    private Animator swAnim;
    public AudioSource swordSpin;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        swAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if(player != null)
        {
            Invoke("ThrowSword", 1f);

        }
        if (HitPirate.activeSword == true)
        {
            Invoke("ThrowSword", 1f);
        }
        if(HitPirate.destroySword == true)
        {
            Destroy(gameObject);
            HitPirate.destroySword = false;
        }
    }

    void ThrowSword()
    {
        step = speed * Time.deltaTime;
        swAnim.SetBool("Attack", true);
        transform.position = Vector2.MoveTowards(transform.position, player.position, step);
        HitPirate.activeSword = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);

        }
    }

    void SwordSFX()
    {
        swordSpin.Play();

    }
}
