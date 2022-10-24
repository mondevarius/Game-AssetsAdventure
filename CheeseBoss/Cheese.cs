using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    public float speed;
    private bool isRight = false;
    private bool walking = true;
    private Rigidbody2D rbCheese;
    private Animator animCheese;
    public CapsuleCollider2D capCollider;
    public Transform pointCheeseBall;
    public GameObject cheeseBallRight;
    public GameObject cheeseBallLeft;
    public GameObject cannonTips;
    public GameObject cheeseName;
    public AudioSource hit;
    public AudioSource die;
    
    private int fullLife = 6;

    
    
    void Start()
    {
        rbCheese = GetComponent<Rigidbody2D>();
        animCheese = GetComponent<Animator>();
        cheeseBallLeft.SetActive(true);
        cheeseBallRight.SetActive(true);
        Invoke("HideCheeseTips", 5f);
    }


    void Update()
    {
        if(fullLife <= 0)
        {
            StopCoroutine(RoutineCheese());
            GameController.instance.trophySummon.SetActive(true);
        }
        
    }
    void FixedUpdate()
    {
        Invoke("MoveCheese", 6f);

    }

    void MoveCheese()
    {
        if(walking == true)
        {
            if (isRight == false)
            {
                rbCheese.velocity = new Vector2(-speed, 0);
                animCheese.SetBool("Run", true);
            }
            else

                if (isRight == true)
            {
                rbCheese.velocity = new Vector2(speed, 0);
                animCheese.SetBool("Run", true);

            }
        }
        
    }
    
    
    void flip()
    {
        if (isRight == false)
        {
            speed = 5;
            isRight = true;
            walking = true;
        }
        else
        if (isRight == true)
        {
            speed = 5;
            isRight = false;
            walking = true;
        }
    }

    void BackIdle()
    {
        animCheese.SetBool("Attack", false);

    }

    void ShootCheeseBall()
    {
        if(isRight == true)
        {
            animCheese.SetBool("Attack", true);
            Instantiate(cheeseBallRight, pointCheeseBall.position, pointCheeseBall.rotation = Quaternion.Euler(0, 0, 0));

        }
        else
        if(isRight == false)
        {
            animCheese.SetBool("Attack", true);
            Instantiate(cheeseBallLeft, pointCheeseBall.position, pointCheeseBall.rotation = Quaternion.Euler(0, 0, 0));

        }
    }

    IEnumerator RoutineCheese()
    {
        speed = 0;
        walking = false;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        animCheese.SetBool("Run", false);
        yield return new WaitForSecondsRealtime(1f);
        ShootCheeseBall();
        yield return new WaitForSecondsRealtime(0f);
        BackIdle();
        yield return new WaitForSecondsRealtime(1.5f);
        ShootCheeseBall();
        yield return new WaitForSecondsRealtime(0f);
        BackIdle();
        yield return new WaitForSecondsRealtime(1.5f);
        ShootCheeseBall();
        yield return new WaitForSecondsRealtime(0f);
        BackIdle();
        if (fullLife > 0)
        {
            yield return new WaitForSecondsRealtime(2f);
            flip();
        }
        

    }

    IEnumerator CheeseHit()
    {
        if(fullLife > 1)
        {
            animCheese.SetBool("Hit", true);
            hit.Play();
            
        }
        fullLife -= 1;
        Debug.Log(fullLife);
        yield return new WaitForSecondsRealtime(0.5f);
        animCheese.SetBool("Hit", false);

        if (fullLife <= 0)
        {
            animCheese.SetBool("Die", true);
            die.PlayOneShot(die.clip);
            speed = 0;
            cheeseBallLeft.SetActive(false);
            cheeseBallRight.SetActive(false);
            capCollider.isTrigger = true;
            rbCheese.gravityScale = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("CheesePoints"))
        {
            StartCoroutine(RoutineCheese());
          
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BulletCannon"))
        {
            StartCoroutine(CheeseHit());
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.instance.ShowGameOver();
        }

    }

    void HideCheeseTips()
    {
        cannonTips.SetActive(false);
        cheeseName.SetActive(false);
    }
}
