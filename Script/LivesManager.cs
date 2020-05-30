using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LivesManager : MonoBehaviour {

    float msToWait = 120000.0f;
    //private Button LivesButton;
    private ulong lastLivesUpdateDateTime;
   // private ulong currentGameSession;
    bool counterRunning;
    bool buttonInteractable;

    const string LIVES_LEFT_KEY = "LIVES_REMAINING";
    const string LAST_LIVES_UPDATE_KEY = "LAST_LIVES_UPDATE";
    const string COINS = "coins";

    public Text livesLeft;
    public Text coundownTimer;
    public Text coinsText;
    int addVal;
    bool newGameSession;
    public GameObject LivesManagerCanvas;
    GameObject[] CanvasActivator;
    
    private void Awake()
    {
        int livesManagerCount = FindObjectsOfType<LivesManager>().Length;
        if (livesManagerCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    void Start ()
    {
        
        newGameSession = true;
        SetCoinsText();
        //Setting default value to lives key
       livesLeft.text=PlayerPrefs.GetInt(LIVES_LEFT_KEY, 5).ToString() +"/10 H";
        
        //Timer
        lastLivesUpdateDateTime = ulong.Parse(PlayerPrefs.GetString(LAST_LIVES_UPDATE_KEY));

        ulong diff = ((ulong)DateTime.Now.Ticks - lastLivesUpdateDateTime);
        ulong m = diff / TimeSpan.TicksPerMillisecond;
        float secondsPassed = (float)m / 1000.0f;
        if(secondsPassed > 1200)
        {
            IncreaseLife(10);
        }
        else if (secondsPassed <= 1200 && secondsPassed > 0)
        {   
            int temp = (int)secondsPassed / 120;
            IncreaseLife(temp);
        }

       // TriggerLiveCountdown();
        if(isCounterTimeUp() == false)
        {
            buttonInteractable = false;
        }
        StartCoroutine(ChangeGameSession());
    }
    IEnumerator ChangeGameSession()
    {

        yield return new WaitForSeconds(3);
        newGameSession = false;

    }
    void Update ()
    {
        CanvasActivator = GameObject.FindGameObjectsWithTag("Activator");
        if (CanvasActivator.Length == 1)
        {
            LivesManagerCanvas.SetActive(true);
        }
        else
        {
            LivesManagerCanvas.SetActive(false);
        }

        if (buttonInteractable == false)
            {
                if (isCounterTimeUp())
                {
                    buttonInteractable = true;
                    coundownTimer.text = "max H";
                    if (PlayerPrefs.GetInt(LIVES_LEFT_KEY) < 10)
                    {
                        TriggerLiveCountdown();
                    }
                    return;

                }

                DisplayCountdownTimer();

            }

        if (Input.GetKeyDown(KeyCode.I))
        {

            IncreaseLife(1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {

            DecreaseLife();
        }

    }
    
    public void TriggerLiveCountdown()
    {
        lastLivesUpdateDateTime = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString(LAST_LIVES_UPDATE_KEY, lastLivesUpdateDateTime.ToString());
        buttonInteractable = false;
        counterRunning = false;
        
    }
    private bool isCounterTimeUp()
    {

        //divide into if else condition for 
        float secondsLeft = CalculateSecondsLeft();
        
        if (secondsLeft < 0.0f)
        {
            if (newGameSession == false)
            {
                IncreaseLife(1);
            }
            return true;
        }
        else
        {
            return false;
        }
            
    }
    public void IncreaseLife(int addValue)
    {

            int temp = PlayerPrefs.GetInt(LIVES_LEFT_KEY,5);
            temp = temp+addValue;
            if(temp>= 10)
            {
            temp = 10;
            }
            else if(temp<=0)
            {
            temp = 1;
            }
            PlayerPrefs.SetInt(LIVES_LEFT_KEY, temp);
            livesLeft.text = PlayerPrefs.GetInt(LIVES_LEFT_KEY).ToString()+"/10 H";  
    }
    public void DecreaseLife()
    {
       
        int temp = PlayerPrefs.GetInt(LIVES_LEFT_KEY);
        if(temp>0)
        {
            temp -= 1;
            PlayerPrefs.SetInt(LIVES_LEFT_KEY, temp);
            livesLeft.text = PlayerPrefs.GetInt(LIVES_LEFT_KEY).ToString() + "/10 H";
            PlayerPrefs.GetInt(LIVES_LEFT_KEY).ToString();
            if (buttonInteractable == true)
            {
                TriggerLiveCountdown();
            }

        }
        
    }

    public float CalculateSecondsLeft()
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastLivesUpdateDateTime);
        ulong m = diff / TimeSpan.TicksPerMillisecond;
        float secondsLeft = (float)(msToWait - m) / 1000.0f;

        return secondsLeft;
    }

    public void DisplayCountdownTimer()
    {
        //Setting the timer
        float secondsLeft = CalculateSecondsLeft();
        string r = "";
      /*  //Hours
        r += ((int)secondsLeft / 3600).ToString() + "h ";
        secondsLeft -= ((int)secondsLeft / 3600) * 3600; */
        //Minutes
        r += ((int)secondsLeft / 60).ToString("0") + "X ";
        //Seconds
        r += ((int)secondsLeft % 60).ToString("00") + "S T ";
        coundownTimer.text = r;
    }

    public void SetCoinsText()
    {
        coinsText.text = PlayerPrefs.GetInt(COINS, 0).ToString();
    }
    
}
