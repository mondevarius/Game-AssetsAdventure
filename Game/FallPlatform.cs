using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{
    private BoxCollider2D boxPlatform;

    // Start is called before the first frame update
    void Start()
    {
        boxPlatform = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ActivePlatform());
        }

    }

    IEnumerator ActivePlatform()
    {
        yield return new WaitForSecondsRealtime(1f);
        transform.eulerAngles = new Vector3(0, 0, 90);
        boxPlatform.isTrigger = true;
        yield return new WaitForSecondsRealtime(1.5f);
        transform.eulerAngles = new Vector3(0, 0, 0);
        boxPlatform.isTrigger = false;
    }

    
}
