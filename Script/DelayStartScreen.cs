using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayStartScreen : MonoBehaviour {
    float delayTime = 9.0f;
    public float fadeTime = 1.0f;
    // Use this for initialization
    IEnumerator Start()
    {
        //StartCoroutine(SplashScreenWait());
        yield return new WaitForSeconds(delayTime);

        SceneManager.LoadScene(1);
    }
    
}
