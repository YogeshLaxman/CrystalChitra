using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class WinScreenDisplay : MonoBehaviour
{
    int currentScore = 0;
    int lives = 0;
    int timeScore = 0;
    int score=0;
    int levelCoins = 0;
    public TextMeshProUGUI levelText;
      public TextMeshProUGUI crystalText;
      public TextMeshProUGUI livesText;
      public TextMeshProUGUI timeText;
      public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsEarnedText;
    public TextMeshProUGUI crystalOneText;
    public TextMeshProUGUI livesOneText;
    public TextMeshProUGUI timeOneText;
    public TextMeshProUGUI scoreOneText;
    public TextMeshProUGUI coinsEarnedOneText;
    public TextMeshProUGUI[] AllText;
    public GameObject rocket;
    public GameObject rocketSec;



    /* public Text levelText;
     public Text crystalText;
     public Text livesText;
     public Text timeText;
     public Text scoreText;*/

    const string CURRENT_SCORE = "currentScore";
    const string CURRENT_TIME = "currentTime";
    const string CURRENT_LIVES = "currentLives";
    const string CURRENT_LEVEL = "currentLevel";
    const string COINS = "coins";

    public AudioSource audioSource;
    const string MUSIC_VOLUME = "musicVolume";

    void Start()
    {

        levelText.transform.position = new Vector3((Screen.width) * 0.5f, (Screen.height) * 0.85f, 0);
        crystalText.transform.position = new Vector3((Screen.width) * 0.5f, (Screen.height) * 0.7f, 0);
        livesText.transform.position = new Vector3((Screen.width) * 0.5f, (Screen.height) * 0.6f, 0);
        timeText.transform.position = new Vector3((Screen.width) * 0.5f, (Screen.height) * 0.5f, 0);
        scoreText.transform.position = new Vector3((Screen.width) * 0.5f, (Screen.height) * 0.4f, 0);
        coinsEarnedText.transform.position = new Vector3((Screen.width) * 0.5f, (Screen.height) * 0.3f, 0);
        crystalOneText.transform.position = new Vector3((Screen.width) * 0.5f, (Screen.height) * 0.7f, 0);
        livesOneText.transform.position = new Vector3((Screen.width) * 0.5f, (Screen.height) * 0.6f, 0);
        timeOneText.transform.position = new Vector3((Screen.width) * 0.5f, (Screen.height) * 0.5f, 0);
        scoreOneText.transform.position = new Vector3((Screen.width) * 0.5f, (Screen.height) * 0.4f, 0);
        coinsEarnedOneText.transform.position = new Vector3((Screen.width) * 0.5f, (Screen.height) * 0.3f, 0);
        //  audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat(MUSIC_VOLUME, 0.8f);

        ColorAndAlphaText();
      
        int currentLevelNumber = PlayerPrefs.GetInt(CURRENT_LEVEL);
         string levelString = currentLevelNumber.ToString();
         levelText.text = "level " + levelString+ "  passed";

         currentScore= PlayerPrefs.GetInt(CURRENT_SCORE);
         currentScore = currentScore/10;
       
        lives = PlayerPrefs.GetInt(CURRENT_LIVES);
         timeScore= PlayerPrefs.GetInt(CURRENT_TIME);
         timeScore /= 5;

         score = (currentScore * 10) + (lives * 100) + (timeScore * 5);
        levelCoins = score / 1000;
         crystalText.text= currentScore.ToString() +"  x 10";
         livesText.text = lives.ToString() + "  x 100";
         timeText.text = timeScore.ToString() + "  x 5";
        scoreText.text = score.ToString();
        int coins = PlayerPrefs.GetInt(COINS, 0);
        coins += levelCoins;
        PlayerPrefs.SetInt(COINS,coins);
        FindObjectOfType<LivesManager>().SetCoinsText();
        coinsEarnedText.text = levelCoins.ToString();
        GameObject rocketOne = Instantiate(rocket, new Vector3(16, -1, -3), Quaternion.Euler(270, 0, 0)) as GameObject;
        GameObject rocketTwo = Instantiate(rocketSec, new Vector3(16, 1, -3), Quaternion.Euler(270, 0, 0)) as GameObject;
    }

    public void ColorAndAlphaText()
    {
        for (int i = 0; i < AllText.Length; i++)
        {
            AllText[i].faceColor = new Color32(10, 10, 10, 180);
        }
    }

}
