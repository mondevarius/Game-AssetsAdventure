using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour
{
    public string levelName;
    
    public void playerSelect(int idPlayer)
    {
        PlayerPrefs.SetInt("playerSelected", idPlayer);
        PlayerPrefs.Save();
        SceneManager.LoadScene(levelName);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
