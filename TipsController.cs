using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsController : MonoBehaviour
{
    public GameObject collectibleTips;
    public GameObject moveTips;
    public GameObject gameoverTips;
    public GameObject trophyTips;
    public GameObject trophy;
    
    
    void Start()
    {
        
    }

    void Update()
    {
        if(trophy.activeInHierarchy == true)
        {
            collectibleTips.SetActive(false);
            gameoverTips.SetActive(false);
            trophyTips.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moveTips.SetActive(false);
            collectibleTips.SetActive(true);
            gameoverTips.SetActive(true);

            
        }
    }

    
}
