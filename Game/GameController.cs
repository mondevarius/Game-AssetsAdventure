using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TargetText targetTxt;
    public GameObject checkFruits;
    public GameObject trophySummon;
    public GameObject gameOver;
    public GameObject gameOverScore;
    public AudioSource sfxTrophy;
    public AudioSource diePlayer;
    public int target;
          
      
    public int totalScore;
    public Text scoreText;
    
    private bool sfxActive = true;
    public string nextLevel;
        
    public static GameController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        targetTxt.ChangeText(target);

    }

    // Update is called once per frame
    void Update()
    {
        //if (checkFruits.activeInHierarchy == false)
        if (totalScore == target)
        {
            trophySummon.SetActive(true);
            if (sfxActive == true)
            {
                sfxTrophy.Play();
                sfxActive = false;
            }

        }
        if (totalScore > target)
        {
            trophySummon.SetActive(false);
            ShowGameOverScore();
            Destroy(GameObject.Find("Daniel(Clone)"));
            Destroy(GameObject.Find("Marina(Clone)"));
            Destroy(GameObject.Find("Miguel(Clone)"));
        }
    }
    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
        
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
    
    public void ShowGameOver()
    {
        diePlayer.Play();
        Destroy(GameObject.Find("Daniel(Clone)"));
        Destroy(GameObject.Find("Marina(Clone)"));
        Destroy(GameObject.Find("Miguel(Clone)"));
        gameOver.SetActive(true);
        
    }

    public void ShowGameOverScore()
    {
        gameOverScore.SetActive(true);

    }
    public void RestartGame(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    
}
