using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class OnScreenLevelButtons : MonoBehaviour {

   // [SerializeField] Paddle paddle1;
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Text livesText;
    //state variables
    [SerializeField] int currentScore = 0;
    [SerializeField] int lives = 3;
    int pauseScreenWhenEven = 1;
    string livesTemp;
    //OnScreenButtons
    public Button[] fireButtonsNew;
    public Button[] secFireButtonsNew;
    bool flawless;
    bool timeStar;
    public Button pauseButton;
    public Button pflButton;
    public Button pfrButton;
    public Button sflButton;
    public Button sfrButton;


    public TextMeshProUGUI timerText;
    private float startTime;
    private bool timerOn;

   // [SerializeField] LivesManager myLivesManager;
    int timeScore = 0;

    int startingSceneIndex;

    const string CURRENT_SCORE = "currentScore";
    const string CURRENT_TIME = "currentTime";
    const string CURRENT_LIVES = "currentLives";
    string minutes = null;
    string seconds = null;
    public GameObject OnScreenButtonsCanvas;

    private void Awake()
    {
        int numLevelPersist = FindObjectsOfType<LevelPersist>().Length;
        if (numLevelPersist > 1)
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
        flawless = true;
        timeStar = true;
        timerOn = true;

        startTime = Time.time;
        timerText.color = Color.black; ;
        scoreText.text = currentScore.ToString() + " pts";
        //livesText.text = lives.ToString();
        livesTemp = "";
        for (int i = 1; i < lives; i++)
        {
            livesTemp += "P ";
        }
        livesText.text = livesTemp;
        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;

        OnScreenButtonsCanvas.SetActive(true);
        CanvasButtonAndTextLocation();
    }

    private void CanvasButtonAndTextLocation()
    {
        pauseButton.transform.position = new Vector3((Screen.width) * 0.97f, (Screen.height) * 0.95f, 0);
        timerText.transform.position = new Vector3((Screen.width) * 0.5f, (Screen.height) * 0.95f, 0);
        scoreText.transform.position = new Vector3((Screen.width) * 0.01f, (Screen.height) * 0.97f, 0);
        livesText.transform.position = new Vector3((Screen.width) * 0.01f, (Screen.height), 0);
        pflButton.transform.position = new Vector3((Screen.width) * 0.12f, (Screen.height) * 0.5f, 0);
        pfrButton.transform.position = new Vector3((Screen.width) * 0.88f, (Screen.height) * 0.5f, 0);
        sflButton.transform.position = new Vector3((Screen.width) * 0.05f, (Screen.height) * 0.60f, 0);
        sfrButton.transform.position = new Vector3((Screen.width) * 0.95f, (Screen.height) * 0.60f, 0);
    }

    private void Update()
    {
        if (timerOn)
        {
            float t = Time.time - startTime;
            if (t >= 120)
            {
                timerText.color = Color.yellow;
               
                timeStar = false;
            }
           
          
               timerText.text ="T " + ((int)t / 60).ToString("0") + " : " + (t % 60).ToString("00");
            
        }   
       
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex != startingSceneIndex)
        {
            Destroy(gameObject);
        }
    }
 
    public void EnableFireButtonNew()
    {
        for (int i = 0; i < fireButtonsNew.Length; i++)
        {
            fireButtonsNew[i].interactable = true;
        }
    }
    public void DisableFireButtonNew()
    {
        for (int i = 0; i < fireButtonsNew.Length; i++)
        {
            fireButtonsNew[i].interactable = false;
        }
    }

    public void EnableSecFireButtonNew()
    {
        for (int i = 0; i < secFireButtonsNew.Length; i++)
        {
            secFireButtonsNew[i].interactable = true;
        }
    }
    public void DisableSecFireButtonNew()
    {
        for (int i = 0; i < secFireButtonsNew.Length; i++)
        {
            secFireButtonsNew[i].interactable = false;
        }
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString() + " pts";
    }


    public void ProcessPlayerDeath()
    {   
        if (lives > 1)
        {
            TakeLife();
        }
        else
        {
            FindObjectOfType<Paddle>().TriggerDestroyAnimation();
            LoadLoseScreenOrPanel();
           // myLivesManager.DecreaseLife();
        }
    }


    private void TakeLife()
    {
        lives--;
        flawless = false;
        StartCoroutine(WaitForTime());

    }

    IEnumerator WaitForTime()
    {
        FindObjectOfType<OnScreenLevelButtons>().DisableFireButtonNew();
        FindObjectOfType<OnScreenLevelButtons>().DisableSecFireButtonNew();
        FindObjectOfType<Paddle>().TriggerDestroyAnimation();
        yield return new WaitForSeconds(3);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesTemp = "";
        for (int i = 1; i < lives; i++)
        {
            livesTemp += "P "; 
        }
        livesText.text = livesTemp;
    }
    public void LoadLoseScreenOrPanel()
    {
        StartCoroutine(DelayForLoad());
        
        
    }

    IEnumerator DelayForLoad()
    {
        yield return new WaitForSeconds(2);
        //Set Panel Active
        FindObjectOfType<LosePanelScript>().LoseCanvasEnable();
      //  int currentScore = CalculateScore();
       // SceneManager.LoadScene("Lose Screen");
      //  FindObjectOfType<GameMusicPlayer>().DestroyGamePlayer();
      //  FindObjectOfType<LivesManager>().DecreaseLife();
      //  Destroy(gameObject);
    }

    public void DestroyOnScreenLevelButtons()
    {
        Destroy(gameObject);
    }

    public void IncreaseLife()
    {
        lives++;
        livesTemp = "";
        for (int i = 1; i < lives; i++)
        {
            livesTemp += "P ";
        }
        livesText.text = livesTemp;
        // livesText.text = lives.ToString();
    }

    public bool ReturnFlawless()
    {
        return flawless;
    }

    public void TimerEnd()
    {
        timerOn = false;
    }
    public bool ReturnTimeStar()
    {
        return timeStar;
    }

    public int CalculateScore()
    {
        int score = 0;
        
        float t = Time.time - startTime;
        timeScore = (int)(300.0 - t) * 5;
        if(timeScore<=0)
        {
            timeScore = 0;
        }
        score = currentScore + (lives * 100) + timeScore;
       
        PlayerPrefs.SetInt(CURRENT_SCORE, currentScore);
        PlayerPrefs.SetInt(CURRENT_LIVES, lives);
        PlayerPrefs.SetInt(CURRENT_TIME, timeScore);
        return score;
    }

    public void EnableOSBCanvas()
    {
        OnScreenButtonsCanvas.SetActive(true);
    }
    public void DisableOSBCanvas()
    {
        OnScreenButtonsCanvas.SetActive(false);
    }
}
