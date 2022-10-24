using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : MonoBehaviour
{
    private Animator animPirate;
    private bool isRight = false;

    public GameObject pirateTip;
    public GameObject pirateName;
    
    void Start()
    {
        animPirate = GetComponent<Animator>();
        Invoke("HidePirateTips", 5f);
    }

    void Update()
    {
        PositionInit();


    }


    void PositionInit()
    {
        if (transform.position.x > 0 && isRight == false)
        {
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
            isRight = true;
        }
        
        if (transform.position.x < 0 && isRight == true)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            isRight = false;
        }
        
    }

    void AnimHitFalse()
    {
        animPirate.SetBool("Hit", false);

    }

    void HidePirateTips()
    {
        pirateName.SetActive(false);
        pirateTip.SetActive(false);
    }
}
