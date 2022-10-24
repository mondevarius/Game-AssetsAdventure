using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateArrow : MonoBehaviour
{

    public GameObject arrowPrefab;
    public Transform arrowTransform;
    
    void Start()
    {
        StartCoroutine(InstArrow());
    }

    void Update()
    {
        
    }

    IEnumerator InstArrow()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1.5f);
            Instantiate(arrowPrefab, arrowTransform.position, arrowTransform.rotation);
        }
        
    }
}
