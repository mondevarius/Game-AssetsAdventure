using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverRight : MonoBehaviour
{
    public FixedJoystick joyVertical;
    private Animator animLever;
    public Transform bulletPointRight;
    public GameObject prefabBullet;
    private bool testButton = false;
    public AudioSource cannon;
    

    void Start()
    {
        animLever = GetComponent<Animator>();
    }

    void Update()
    {
               
        if (joyVertical.Vertical < 0 && testButton == true)
        {
            animLever.SetBool("Active", true);
            cannon.Play();
            Instantiate(prefabBullet, bulletPointRight.position, bulletPointRight.rotation = Quaternion.Euler(0, 0, 0));
            testButton = false;

        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            testButton = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animLever.SetBool("Active", false);
            testButton = false;
        }

    }
}
