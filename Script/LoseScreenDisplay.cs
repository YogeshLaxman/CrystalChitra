using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LoseScreenDisplay : MonoBehaviour {

    int currentScore = 0;
    int lives = 0;
    int timeScore = 0;
    int score = 0;

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
    const string HIGHSCORE = "H";
    const string COINS = "coins";
    public GameObject stormPrefab;

    /* public Text levelText;
     public Text crystalText;
     public Text livesText;
     public Text timeText;
     public Text scoreText;*/

    const string CURRENT_SCORE = "currentScore";
    const string CURRENT_TIME = "currentTime";
    const string CURRENT_LIVES = "currentLives";
    const string CURRENT_LEVEL = "currentLevel";

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
        //audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat(MUSIC_VOLUME, 0.8f);
        ColorAndAlphaText();
        SetValues();

        

    }

    private void SetValues()
    {
        GameObject stormOne = Instantiate(stormPrefab, new Vector3(40, 18, -2), Quaternion.Euler(140, 90, 90)) as GameObject;
        GameObject stormTwo = Instantiate(stormPrefab, new Vector3(32, 30, -2), Quaternion.Euler(140, 90, 90)) as GameObject;
        int currentLevelNumber = PlayerPrefs.GetInt(CURRENT_LEVEL);
        string levelString = currentLevelNumber.ToString();
        levelText.text = "level " + levelString + "  failed";

        currentScore = PlayerPrefs.GetInt(CURRENT_SCORE);
        currentScore = currentScore / 10;
        Debug.Log("current Score " + currentScore);
        lives = 0;
        timeScore = 0;

        score = (currentScore * 10) + (lives * 100) + (timeScore * 5);
        int temp = PlayerPrefs.GetInt(COINS, 0) + (score / 1000);
        PlayerPrefs.GetInt(COINS, temp);
        coinsEarnedText.text = (score / 1000).ToString();
        crystalText.text = currentScore.ToString() + "  x 10";
        livesText.text = lives.ToString() + "  x 100";
        timeText.text = timeScore.ToString() + "  x 5";
        scoreText.text = score.ToString();
        FindObjectOfType<LivesManager>().SetCoinsText();

        int currentLeNu = PlayerPrefs.GetInt(CURRENT_LEVEL);
        string currentLeNum = currentLeNu.ToString();
        //HighScore

        int currentHScore = PlayerPrefs.GetInt(HIGHSCORE + currentLeNum);
        if (score > currentHScore)
        {
            PlayerPrefs.SetInt(HIGHSCORE + currentLeNum, score);
        }
    }

    public void ColorAndAlphaText()
    {
        for (int i = 0; i < AllText.Length; i++)
        {
            AllText[i].faceColor = new Color32(10, 10, 10, 180);
        }
    }
    
}
