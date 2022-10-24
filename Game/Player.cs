using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private FixedJoystick joyHorizontal;

    private UnityADS unityADS;

    private GameController GameController;
    public Rigidbody2D rbPlayer;
    private Animator anim;
    public AudioSource sfxJump;
        

    public static float speed = 7;
    public float speedPlayer;
    public float jumpForce;
    
    public bool grounded;
    public bool jumping;
    

    void Start()
    {
        GameController = FindObjectOfType(typeof(GameController)) as GameController;
        rbPlayer = FindObjectOfType<Rigidbody2D>();
        anim = GetComponent<Animator>();
        joyHorizontal = FindObjectOfType<FixedJoystick>();
        unityADS = FindObjectOfType<UnityADS>();
    }


    void FixedUpdate()
    {
        Move();
        speedPlayer = speed;

    }

    void Move()
    {
        Vector3 movement = new Vector3(joyHorizontal.Horizontal, 0f, 0f);
        transform.position += movement * Time.deltaTime * speedPlayer;
        if (joyHorizontal.Horizontal > 0 && grounded == true)
        {
            anim.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            grounded = true;
        }
        
        if (joyHorizontal.Horizontal < 0 && grounded == true)
        {
            anim.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            grounded = true;

        }

        if (joyHorizontal.Horizontal == 0)
        {
            anim.SetBool("Run", false);
            grounded = true;
        }
            
    }
        
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            jumping = false;
            anim.SetBool("Jump", false);

        }

        if (collision.gameObject.layer == 8)
        {
            GameController.instance.ShowGameOver();

        }

        if (collision.gameObject.CompareTag("Trophy"))
        {
            unityADS.ShowInterstitial();
            GameController.instance.NextLevel();
        }

        if (collision.gameObject.CompareTag("Trampoline"))
        {
            jumping = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameController.instance.ShowGameOver();

        }

    }

    


}
