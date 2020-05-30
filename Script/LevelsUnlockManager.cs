using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsUnlockManager : MonoBehaviour {

    public Button[] levelButtons;
    const string LEVEL_UNLOCKED_NUMBER = "levelUnlockedNumber";
    int levelUnlockedNumber;

  

    void Start ()
    {
        levelUnlockedNumber = PlayerPrefs.GetInt(LEVEL_UNLOCKED_NUMBER, 1);
       
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelUnlockedNumber)
            {
                levelButtons[i].interactable = false;
            }

        }
    }

    
}
