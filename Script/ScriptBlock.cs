using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBlock : MonoBehaviour
{   
    //Config params
    [SerializeField] AudioClip[] breaksound;
    float soundVolume;
    const string VFX_VOLUME = "VFXVolume";

    Level level;

   [SerializeField] GameObject CrysExpPS;
   // [SerializeField] Sprite[] hitSprites;
    [SerializeField] GameObject shootingPowerPrefab;
    [SerializeField] GameObject paddleExpandPrefab;
    [SerializeField] GameObject paddleContractPrefab;
    [SerializeField] GameObject doubleBallPrefab;
    [SerializeField] GameObject shieldPowerPrefab;
    [SerializeField] GameObject lifePowerPrefab;
    [SerializeField] GameObject fastBallPrefab;
    [SerializeField] GameObject slowBallPrefab;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] GameObject bombPrefab;
    public float dropSpeed = 5f;
    int random = 0;
    

    public int comboHits = 0;
  //  String temp;

    //random power generation
   int randomZeroToNine;
    //  int[] buffer=new int [100];
    //   int dropRandomPowerNumber;

    //       bool found = false;
    //cached reference

    //State variables
    //   [SerializeField] int timesHit; //Only for debug
    /*
        private void OnCollisionEnter2D(Collision2D collision)
        {
            temp = collision.gameObject.tag;
            if (tag == "Breakable")
            {
                HandleHit();
            }

        }





        private void HandleHit()
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
            {   
                Destroyblock();
            }
            else
            {
                ShowNextHitSprites();
            }
        }
         private void OnCollisionEnter2D(Collision2D collision)
        {
            temp = collision.gameObject.tag;
            if (tag == "Breakable")
            {
                HandleHit();
            }

        }


        private void ShowNextHitSprites()
        {
            int spriteIndex = timesHit - 1;
            if (hitSprites[spriteIndex] != null)
            {
                GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
            }
            else
            {
                Debug.LogError("Block sprite is missing from array" + gameObject.name );
            }
        }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroyblock();

    }
    private void Destroyblock()
    {
        int random = UnityEngine.Random.Range(0, breaksound.Length);
        AudioClip clip = breaksound[random];
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, soundVolume);

        Destroy(gameObject);
        level.BlockDestroyed();
      
        FindObjectOfType<OnScreenLevelButtons>().AddToScore();
        TriggerSparklesVFX();

       
          randomZeroToNine = UnityEngine.Random.Range(0,10);
        if (randomZeroToNine % 4 == 0)
        {
            DropRandomPower();
        }
    }

    private void DropRandomPower()
    {
        random = level.ReturnSwitchValue();
        switch (random)
        {
            case 0:
                DropShootingPower();
                break;
            case 1:
                DropShootingPower();
                break;
            case 2:
                DropExpandPower();
                break;
            case 3:
                DropLifePower();
                break;
            case 4:
                DropDoubleBallPower();
                break;
            case 5:
                DropShieldPower();
                break;
            case 6:
                DropContractPower();
                break;
            case 7:
                DropSlowBallPower();
                break;
            case 8:
                DropFastBallPower();
                break;
            case 9:
                DropLaserPower();
                break;
            case 10:
                DropShieldPower();
                break;
            case 11:
                DropLaserPower();
                break;
            case 12:
                DropFastBallPower();
                break;
            case 13:
                DropExpandPower();
                break;
            case 14:
                DropDoubleBallPower();
                break;
            case 15:
                DropDoubleBallPower();
                break;
            case 16:
                DropLifePower();
                break;
            case 17:
                DropShieldPower();
                break;
            case 18:
                DropLifePower();
                break;
            case 19:
                DropShootingPower();
                break;
            case 20:
                DropLaserPower();
                break;
        }

    }

    private void DropLifePower()
    {
        GameObject lifePower = Instantiate(lifePowerPrefab, transform.position, Quaternion.identity) as GameObject;
        lifePower.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -dropSpeed);
    }

    private void DropShieldPower()
    {
        GameObject shieldPower = Instantiate(shieldPowerPrefab, transform.position, Quaternion.identity) as GameObject;
        shieldPower.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -dropSpeed);
    }

    private void DropDoubleBallPower()
    {
        GameObject doubleBallPower = Instantiate(doubleBallPrefab, transform.position, Quaternion.identity) as GameObject;
        doubleBallPower.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -dropSpeed);
    }

    private void DropExpandPower()
    {
        GameObject expandPower = Instantiate(paddleExpandPrefab, transform.position, Quaternion.identity) as GameObject;
        expandPower.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -dropSpeed);
    }
    private void DropContractPower()
    {
        GameObject contractPower = Instantiate(paddleContractPrefab, transform.position, Quaternion.identity) as GameObject;
        contractPower.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -dropSpeed);
    }

    private void DropShootingPower()
    {
        GameObject shootingPower = Instantiate(shootingPowerPrefab, transform.position, Quaternion.identity) as GameObject;
        shootingPower.GetComponent<Rigidbody2D>().velocity = new Vector2(0,- dropSpeed);
    }

    private void DropFastBallPower()
    {
        GameObject fastBallPower = Instantiate(fastBallPrefab, transform.position, Quaternion.identity) as GameObject;
        fastBallPower.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -dropSpeed);
    }

    private void DropSlowBallPower()
    {
        GameObject slowBallPower = Instantiate(slowBallPrefab, transform.position, Quaternion.identity) as GameObject;
        slowBallPower.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -dropSpeed);
    }

    private void DropLaserPower()
    {
        GameObject laserPower = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laserPower.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -dropSpeed);
    }

    private void DropBombPower()
    {
        GameObject bombPower = Instantiate(bombPrefab, transform.position, Quaternion.identity) as GameObject;
        bombPower.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -dropSpeed);
    }
    private void TriggerSparklesVFX()
    {
        GameObject CEPS = Instantiate(CrysExpPS, transform.position, transform.rotation);
        Destroy(CEPS, 1f);
    }

    private void Start()
    {
        CountBreakableBlocks();
       
       soundVolume = PlayerPrefs.GetFloat(VFX_VOLUME, 0.8f);
      
       

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
            
        }
    }

  
}
