using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] AudioClip[] ballSounds;
    
    float soundVolume;
    const string VFX_VOLUME = "VFXVolume";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int random = UnityEngine.Random.Range(0, ballSounds.Length);
            AudioClip clip = ballSounds[random];
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, soundVolume);
            
    }

    private void Start()
    {
        soundVolume = PlayerPrefs.GetFloat(VFX_VOLUME, 0.8f);
    }
}

