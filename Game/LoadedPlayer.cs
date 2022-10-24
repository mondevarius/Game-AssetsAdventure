using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadedPlayer : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rbPlayer;
    private float jumpForce = 13;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rbPlayer = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump()
    {

        if (rbPlayer.velocity.y == 0)
        {
            rbPlayer.velocity = Vector2.up * jumpForce;
        }
        /*if (joyHorizontal.Vertical > 0 && !jumping)
        {
            rbPlayer.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("Jump", true);
            sfxJump.Play();
            jumping = true;
        }*/

    }
}
