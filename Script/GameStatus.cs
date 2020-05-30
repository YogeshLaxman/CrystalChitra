using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;



public class GameStatus : MonoBehaviour
{   //config status

    [Range(0.1f,5f)][SerializeField] float gameSpeed=1f;
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Text livesText;
    //state variables
    [SerializeField] int currentScore = 0;
    [SerializeField] bool autoPlay;
    int lives;
     int pauseScreenWhenEven = 1;
    private float fixedDeltaTime;

    public int levelToUnlock = 2;
  
    public float ReturnGameSpeed()
    {
        return gameSpeed;
    }


    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1 )
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        Time.timeScale = gameSpeed;// shifted from update to start while designing Pause menu
   
        fixedDeltaTime = Time.fixedDeltaTime;
       
    }
    
    

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

   
    public bool IsAutoPlayEnabled()
    {
        return autoPlay;
    }

    public void ProcessPlayerLivesLeft()
    {
        Debug.Log("Inside Process Player Lives");
        if (lives > 1)
        {
            lives--;
            PlayerPrefs.GetInt("livesLeft", lives);
            livesText.text = lives.ToString();
        }
        else if (lives <= 0)
        {
            DisplayNoMoreLivesLeft();
            livesText.text = lives.ToString();
        }
    }

    public void DisplayNoMoreLivesLeft()
    {
        Debug.Log("No more lives Left");
    }

    public void IncreaseLife()
    {
        lives++;
        livesText.text = lives.ToString();
    }



}
