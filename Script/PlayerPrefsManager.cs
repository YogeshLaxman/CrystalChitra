using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {
    const string LEVEL_KEY = "level_unlocked_";
    const string LIVES_KEY = "lives_key";

    public static void SetLives(int lives)
    {
        if (lives >= 0 && lives<=10 )
        {
            PlayerPrefs.SetInt(LIVES_KEY, lives);
        }
        else
        {
            Debug.LogError("Lives key error");
        }
    } 
    public static int GetLives()
    {
        return PlayerPrefs.GetInt(LIVES_KEY);
    }
}
