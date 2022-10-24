using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Language : MonoBehaviour
{
    public void English()
    {
        SceneManager.LoadScene("TitleEUA");
    }

    public void Portuguese()
    {
        SceneManager.LoadScene("Title");
    }
}
