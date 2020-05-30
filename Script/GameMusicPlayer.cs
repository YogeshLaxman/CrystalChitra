using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicPlayer : MonoBehaviour {
    AudioSource audioSource;
    const string MUSIC_VOLUME = "musicVolume";
    private void Awake()
    {
        SetUpSingleton();
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat(MUSIC_VOLUME, 0.8f);
    }
    private void SetUpSingleton()
    {
        int MP = FindObjectsOfType(GetType()).Length;
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void DestroyGamePlayer()
    {
        Destroy(gameObject);
    }
}
