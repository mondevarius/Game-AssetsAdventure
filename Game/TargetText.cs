using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetText : MonoBehaviour
{
    public Text targetText;
    
       
    // Start is called before the first frame update
    void Start()
    {
        targetText = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeText(int newText)
    {
        targetText.text = newText.ToString();
    }
}
