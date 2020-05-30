using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    int randomZeroToNine, bufferTop;
    int[] buffer = new int[20];
    int dropRandomPowerNumber;
    bool found = false;
    const string LEVEL_UNLOCKED_NUMBER = "levelUnlockedNumber";
    const string CURRENT_LEVEL = "currentLevel";
    const string COMPLETE = "C";
    const string TIME = "T";
    const string FLAWLESS = "F";
    const string HIGHSCORE = "H";
    // public GameStatus gameStatus;

    SceneLoader sceneloader;
    int breakableBlocks;// for debugging purposes
    public int combo=0;
    int random;
    int tempOne;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
        bufferTop = 0;
        dropRandomPowerNumber = 0;
        buffer[0] = 100;
       
    }
    
    public int ReturnSwitchValue()
    {   if(bufferTop == 16)
        {
            bufferTop = 0;
        }
       
        random = UnityEngine.Random.Range(0, 21);
      
        found = false;
        for (int i = 0; i <= bufferTop; i++)
        {
            if (buffer[i] == random)
            {
                found = true;

            }
        }
        

        
        if (found == false)
        {
            bufferTop += 1;
            buffer[bufferTop] = random;
         
        }
        else if (found == true)
        {
            ReturnSwitchValue(); 
        }
        

        return buffer[bufferTop];
    }

    public void CountBlocks()
        {   
            breakableBlocks++;
        }

    public int GetComboHits()
    {
        return combo;
    }
    public void IncreaseCombo()
    {
        combo++;
       
    }
    public void ComboReset()
    {
        combo = 0;
      
    }
        public void BlockDestroyed()
    {

        tempOne = FindObjectsOfType<ScriptBlock>().Length;
        breakableBlocks--;
        if (breakableBlocks<=0 && tempOne<=1)
        {
            Destroy(FindObjectOfType<LevelPersist>().gameObject);
            //stars
            bool temp = FindObjectOfType<OnScreenLevelButtons>().ReturnFlawless();
            
            if (temp==true)
            {
                int currentLevelNumber = PlayerPrefs.GetInt(CURRENT_LEVEL);
                string currentLN = currentLevelNumber.ToString();
                PlayerPrefs.SetInt(FLAWLESS + currentLN, 1);

            }

            FindObjectOfType<OnScreenLevelButtons>().TimerEnd();
            bool tempTwo = FindObjectOfType<OnScreenLevelButtons>().ReturnTimeStar();
            if (tempTwo == true)
            {
                int currentLevelNumber = PlayerPrefs.GetInt(CURRENT_LEVEL);
                string currentLN = currentLevelNumber.ToString();
                PlayerPrefs.SetInt(TIME + currentLN, 1);

            }

            int currentLeNu = PlayerPrefs.GetInt(CURRENT_LEVEL);
            string currentLeNum = currentLeNu.ToString();
            //HighScore
            int currentScore = FindObjectOfType<OnScreenLevelButtons>().CalculateScore();
            int currentHScore = PlayerPrefs.GetInt(HIGHSCORE+ currentLeNum);
            if(currentScore > currentHScore)
            {
                PlayerPrefs.SetInt(HIGHSCORE + currentLeNum, currentScore);
            }

            //LevelComplete

            PlayerPrefs.SetInt(COMPLETE + currentLeNum, 1);
            FindObjectOfType<LoseCollider>().DestroyLoseCollider();
            FindObjectOfType<WinPanel>().WinCanvasEnable();
            UnlockNextLevel();
        }
    }
    

    public void UnlockNextLevel()
    {
        int levelUnlockedNumber = PlayerPrefs.GetInt(LEVEL_UNLOCKED_NUMBER);
        
        int currentLevelNumber = PlayerPrefs.GetInt(CURRENT_LEVEL);
      
        if (levelUnlockedNumber == 0)
        {
            levelUnlockedNumber = 2;
        }
        else if(levelUnlockedNumber ==currentLevelNumber)
        {
            levelUnlockedNumber += 1;
        }
        PlayerPrefs.SetInt(LEVEL_UNLOCKED_NUMBER, levelUnlockedNumber);
      
    }
}
