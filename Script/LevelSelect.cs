using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelSelect : MonoBehaviour {
    public Text timerText;
    public Text timerTextTwo;
    private float startTime;

    //Countdown
    public float timer;

    //level Buttons
    public Button[] levelButtons;
    public Text livesText;
    int lives=10;
    // [SerializeField] int lives = 5;
    //Display lives and lives timer
  //  const string LIVES_LEFT_KEY = "LIVES_REMAINING";
  //  const string LAST_LIVES_UPDATE_KEY = "LAST_LIVES_UPDATE";
  //  public Text livesLeft;
  //  public Text coundownTimer;

    private void Start()
    {
        //livesLeft.text = PlayerPrefs.GetInt(LIVES_LEFT_KEY, 5).ToString();
    }

    private void Update()
    {
        /*  float t = Time.time - startTime;
          string minutes = ((int)t / 60).ToString();
          string seconds = (t % 60).ToString("f2");


          timerText.text = minutes + " : " + seconds;

          timer -= Time.deltaTime;
          timerTextTwo.text = TimeMaster.instance.CheckDate().ToString(); */
      }

      /*public void ProcessPlayerLivesLeft()
      {
          Debug.Log("Inside Process Player Lives");
          if (lives > 1)
          {
              lives--;
              PlayerPrefs.GetInt("livesLeft", lives);
              livesText.text = lives.ToString();
          }
          else if(lives<=0)
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
      */

        //  void ResetClock()
        //  {
        //     TimeMaster.instance.SaveDate();
        //     timer = 300;
        //     timer -= TimeMaster.instance.CheckDate();
        //  }

    }
