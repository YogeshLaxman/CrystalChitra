using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsStats : MonoBehaviour {
    public Button playButton;
    public Text levelStatsText;
    public Text levelCompleteStar;
    public Text noLoseStar;
    public Text timeStar;
    public Text highScore;
    public Text levelCompleteStarText;
    public Text noLoseStarText;
    public Text timeStarText;
    public Text highScoreText;
    //color
   
    public Color levelStatsTextColor;
    int levelToLoad;
    const string CURRENT_LEVEL = "currentLevel";
    const string LIVES_LEFT_KEY = "LIVES_REMAINING";
    const string COMPLETE = "C";
    const string TIME = "T";
    const string FLAWLESS = "F";
    const string HIGHSCORE = "H";
    string levelString;
    int temp;
    bool isLevelSelected;
    private void Update()
    {
      temp = PlayerPrefs.GetInt(LIVES_LEFT_KEY, 5);
        if(temp > 0 && isLevelSelected == true)
        {
            playButton.interactable=true;
        }
        else
        {
            playButton.interactable = false;
        }
    }
    public void LevelOneButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 1);
        levelStatsText.text = "level 1";
        SetLevelToLoad(6);
        SetStars();

}
    public void LevelTwoButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 2);
        levelStatsText.text = "level 2";
        SetLevelToLoad(7);
        SetStars();
    }

    public void LevelThreeButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 3);
        levelStatsText.text = "level 3";
        SetLevelToLoad(8);
        SetStars();
    }

    public void LevelFourButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 4);
        levelStatsText.text = "level 4";
        SetLevelToLoad(9);
        SetStars();
    }

    public void LevelFiveButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 5);
        levelStatsText.text = "level 5";
        SetLevelToLoad(10);
        SetStars();
    }

    public void LevelSixButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 6);
        levelStatsText.text = "level 6";
        SetLevelToLoad(11);
        SetStars();
    }

    public void LevelSevenButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 7);
        levelStatsText.text = "level 7";
        SetLevelToLoad(12);
        SetStars();
    }
    public void LevelEightButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 8);
        levelStatsText.text = "level 8";
        SetLevelToLoad(13);
        SetStars();
    }

    public void LevelNineButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 9);
        levelStatsText.text = "level 9";
        SetLevelToLoad(14);
        SetStars();
    }
    public void LevelTenButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 10);
        levelStatsText.text = "level 10";
        SetLevelToLoad(15);
        SetStars();
    }
    public void LevelElevenButtonClick()
    {   
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 11);
        levelStatsText.text = "level 11";
        SetLevelToLoad(16);
        SetStars();
    }
    public void LevelTwelveButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 12);
        levelStatsText.text = "level 12";
        SetLevelToLoad(17);
        SetStars();
    }
    public void LevelThirteenButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 13);
        levelStatsText.text = "level 13";
        SetLevelToLoad(18);
        SetStars();
    }
    public void LevelFourteenButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 14);
        levelStatsText.text = "level 14";
        SetLevelToLoad(19);
        SetStars();
    }

    public void LevelFifteenButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 15);
        levelStatsText.text = "level 15";
        SetLevelToLoad(20);
        SetStars();
    }
    public void LevelSixteenButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 16);
        levelStatsText.text = "level 16";
        SetLevelToLoad(21);
        SetStars();
    }

    public void LevelSeventeenButtonClick()
    {   
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 17);
        levelStatsText.text = "level 17";
        SetLevelToLoad(22);
        SetStars();
    }
    public void LevelEighteenButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 18);
        levelStatsText.text = "level 18";
        SetLevelToLoad(23);
        SetStars();
    }
    public void LevelNineteenButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 19);
        levelStatsText.text = "level 19";
        SetLevelToLoad(24);
        SetStars();
    }
    public void LevelTwentyButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 20);
        levelStatsText.text = "level 20";
        SetLevelToLoad(25);
        SetStars();
    }
    public void LevelTwentyOneButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 21);
        levelStatsText.text = "level 21";
        SetLevelToLoad(26);
        SetStars();
    }
    public void LevelTwentyTwoButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 22);
        levelStatsText.text = "level 22";
        SetLevelToLoad(27);
        SetStars();
    }
    public void LevelTwentyThreeButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 23);
        levelStatsText.text = "level 23";
        SetLevelToLoad(28);
        SetStars();
    }
    public void LevelTwentyFourButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 24);
        levelStatsText.text = "level 24";
        SetLevelToLoad(29);
        SetStars();
    }
    public void LevelTwentyFiveButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 25);
        levelStatsText.text = "level 25";
        SetLevelToLoad(30);
        SetStars();
    }
    public void LevelTwentySixButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 26);
        levelStatsText.text = "level 26";
        SetLevelToLoad(31);
        SetStars();
    }
    public void LevelTwentySevenButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 27);
        levelStatsText.text = "level 27";
        SetLevelToLoad(32);
        SetStars();
    }
    public void LevelTwentyEightButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 28);
        levelStatsText.text = "level 28";
        SetLevelToLoad(33);
        SetStars();
    }
    public void LevelTwentyNineButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 29);
        levelStatsText.text = "level 29";
        SetLevelToLoad(34);
        SetStars();
    }
    public void LevelThirtyButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 30);
        levelStatsText.text = "level 30";
        SetLevelToLoad(35);
        SetStars();
    }
    public void LevelThirtyOneButtonClick()
    {
        isLevelSelected = true;
        PlayerPrefs.SetInt(CURRENT_LEVEL, 30);
        levelStatsText.text = "level 31";
        SetLevelToLoad(36);
        SetStars();
    }

    void SetLevelToLoad(int levelBuildIndex)
    {
        levelToLoad = levelBuildIndex;

    }

    public void LoadLevelNumber()
    {
        if (levelToLoad == 0)
        {
            levelStatsText.text = "select level";
        }
        else
        {
            SceneManager.LoadScene(levelToLoad);
            FindObjectOfType<MenuMusicPlayer>().DestroyMenuPlayer();
        }

    } 
    public void DisplayPanelText(string LEVEL)
    {

        int c = PlayerPrefs.GetInt(COMPLETE+LEVEL, 0);
        if (c == 0)
        {
            levelCompleteStar.color = Color.gray;
            levelCompleteStar.text = "V";
        }
        else
        {
            levelCompleteStar.color = Color.yellow;
            levelCompleteStar.text = "W";
        }
        int t = PlayerPrefs.GetInt(FLAWLESS+LEVEL, 0);
        if (t == 0)
        {
            noLoseStar.color = Color.gray;
            noLoseStar.text = "V";
        }
        else
        {
            noLoseStar.color = Color.yellow;
            noLoseStar.text = "W";
        }
        int f = PlayerPrefs.GetInt(TIME + LEVEL, 0);
        if (f == 0)
        {
            timeStar.color = Color.gray;
            timeStar.text = "V";
        }
        else
        {
            timeStar.color = Color.yellow;
            timeStar.text = "W";
        }
        int h = PlayerPrefs.GetInt(HIGHSCORE+LEVEL, 0);
        highScore.text = h.ToString();
    }

    public void DisplayText()
    {
        levelCompleteStarText.text="level  complete";
        noLoseStarText.text ="perfect  play";
        timeStarText.text ="under  2  minutes";
        highScoreText.text ="highscore";
    }
    public void SetStars()
    {
        int currentLevelNumber = PlayerPrefs.GetInt(CURRENT_LEVEL);
        levelString = currentLevelNumber.ToString();
        DisplayPanelText(levelString);
        DisplayText();
    }

    private void Start()
    {
        isLevelSelected = false;
        
        levelStatsText.transform.position = new Vector3((Screen.width) * 0.45f, (Screen.height) * 0.75f, 0);
        levelCompleteStar.transform.position = new Vector3((Screen.width) * 0.45f, (Screen.height) * 0.6f, 0);
        noLoseStar.transform.position = new Vector3((Screen.width) * 0.45f, (Screen.height) * 0.5f, 0);
        timeStar.transform.position = new Vector3((Screen.width) * 0.45f, (Screen.height) * 0.4f, 0);
        highScore.transform.position = new Vector3((Screen.width) * 0.45f, (Screen.height) * 0.3f, 0);
        levelCompleteStarText.transform.position = new Vector3((Screen.width) * 0.45f, (Screen.height) * 0.6f, 0);
        noLoseStarText.transform.position = new Vector3((Screen.width) * 0.45f, (Screen.height) * 0.5f, 0);
        timeStarText.transform.position = new Vector3((Screen.width) * 0.45f, (Screen.height) * 0.4f, 0);
        highScoreText.transform.position = new Vector3((Screen.width) * 0.45f, (Screen.height) * 0.3f, 0);
    }
}
