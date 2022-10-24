using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour
{

    private Rigidbody2D rbObject;
    public float speed;
    private float direction = 1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rbObject = GetComponent<Rigidbody2D>();



    }

    // Update is called once per frame
    void Update()
    {
        moveUpDown();
    }

    void moveUpDown()
    {
        rbObject.velocity = new Vector2(rbObject.velocity.x, direction * speed);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        direction *= -1;

    }

}
