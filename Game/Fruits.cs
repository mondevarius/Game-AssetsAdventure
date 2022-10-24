using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    private SpriteRenderer   srFruit;
    private CircleCollider2D circleFruit;
    public AudioSource sfxCollected;

    public int score;

    public GameObject collected;

    // Start is called before the first frame update
    void Start()
    {
        srFruit     = GetComponent<SpriteRenderer>();
        circleFruit = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            srFruit.enabled = false;
            circleFruit.enabled = false;
            collected.SetActive(true);
            GameController.instance.totalScore += score;
            GameController.instance.UpdateScoreText();
            sfxCollected.Play();
            Destroy(gameObject, 0.3f);
        }
    }

}
