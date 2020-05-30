using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseCollider : MonoBehaviour
{
    int numberOfBalls;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        int numberOfBalls = FindObjectsOfType<BallScript>().Length;
      //  Debug.Log("Balls left: "+ numberOfBalls);
        if (numberOfBalls <= 1)
        {
            FindObjectOfType<OnScreenLevelButtons>().ProcessPlayerDeath();
                     
        }
        CheckAgain();
    }

    public void CheckAgain()
    {
        Debug.Log("InsideCheckAgain");
        StartCoroutine(Check());
    }

    IEnumerator Check()
    {
        Debug.Log("Inside IE");
        yield return new WaitForSeconds(1f);
        if (FindObjectOfType<Paddle>().AliveStatus())
        {
            int numberOfCheckBalls = FindObjectsOfType<BallScript>().Length;
            if (numberOfCheckBalls < 1)
            {
                // FindObjectOfType<GameStatus>().ProcessPlayerDeath();
                FindObjectOfType<OnScreenLevelButtons>().ProcessPlayerDeath();
               
            }

        }
    }
    public void DestroyLoseCollider()
    {
        Destroy(gameObject);
    }
   
}
