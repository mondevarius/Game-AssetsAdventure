using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlayer : MonoBehaviour
{
    
    public GameObject[] characters;
    private void Awake()
    {
        Instantiate(characters[PlayerPrefs.GetInt("playerSelected")], transform.position, transform.rotation);
        
    }
}
