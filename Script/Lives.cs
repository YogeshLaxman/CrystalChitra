using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

    public Text livesTimer;
    public float msToWait = 10000;
    private Button LivesButton;
    private ulong lastLivesUpdate;

    

    private void Start()
    {
        

        LivesButton = GetComponent<Button>();
        lastLivesUpdate = ulong.Parse(PlayerPrefs.GetString("LastLivesClick"));

        if(!isLivesReady())
        {
            LivesButton.interactable = false;
        }
    }

        private void Update()
    {
        if (!LivesButton.IsInteractable())
        {
           if(isLivesReady())
            {
                LivesButton.interactable = true;
             
                return;
            }

            //Setting the timer
            ulong diff = ((ulong)DateTime.Now.Ticks - lastLivesUpdate);
            ulong m = diff / TimeSpan.TicksPerMillisecond;
            float secondsLeft = (float)((msToWait - m) / 1000.0f);

            string r = "";
            //Hours
            r += ((int)secondsLeft / 3600).ToString() + "h ";
            secondsLeft -= ((int)secondsLeft / 3600) * 3600;
            //Minutes
            r += ((int)secondsLeft / 60).ToString("00") + "m ";
            //Seconds
            r += ((int)secondsLeft % 60).ToString("00") + "s ";
            livesTimer.text = r;
        }
    }

   /* public static void SetLives(int lives)
    {
        if (lives >= 0 && lives <= 5)
        {
            PlayerPrefs.SetInt(LIVES_LEFT_KEY, lives);
        }
        else
        {
            Debug.LogError("Lives out of range");
        }
    }
    public static int GetLives()
    {
        PlayerPrefs.GetInt(LIVES_LEFT_KEY);
    }*/



    public void LivesClick()
    {
        lastLivesUpdate = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString("LastLivesClick", lastLivesUpdate.ToString());
       
        LivesButton.interactable = false;
    }
    private bool isLivesReady()
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastLivesUpdate);
        ulong m = diff / TimeSpan.TicksPerMillisecond;

        float secondsLeft = (float)((msToWait - m) / 1000.0f);

        if (secondsLeft < 0)
        {   
            
            livesTimer.text = "Ready";
            return true;
        }
        else
        {
            return false;
        }
    }

   
}
