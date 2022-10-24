using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRight : MonoBehaviour
{
    private Rigidbody2D rbObject;
    public float speed;
    public float direction;
    public GameObject prefab;
    public AudioSource diePlayer;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rbObject = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        objectMove();
    }
    void Update()
    {
        
    }

    void objectMove()
    {
        rbObject.velocity = new Vector2(speed * direction, rbObject.velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.instance.ShowGameOver();
        }
    }


}
