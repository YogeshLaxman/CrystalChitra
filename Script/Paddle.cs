using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Paddle : MonoBehaviour {
    //configuration Parameters
  // [SerializeField] float minX = 1f, maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float moveSpeed = 18f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] GameObject actualShieldPrefab;
    [SerializeField] GameObject actualLaserSPrefab;
    [SerializeField] GameObject BombPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] AudioClip paddleDestroySound;
    [SerializeField] AudioClip laserSmallSound;
    [SerializeField] AudioClip laserBigSound;
    [SerializeField] AudioClip paddleContractSound;
    [SerializeField] AudioClip paddleExpandSound;
    [SerializeField] AudioClip doubleBallSound;
    [SerializeField] AudioClip shieldActiveSound;
    [SerializeField] AudioClip fastBallSound;
    [SerializeField] AudioClip slowBallSound; 
    [SerializeField] AudioClip lifePowerSound; 
    [SerializeField] AudioClip laserPowerSound;
    [SerializeField] AudioClip laserSPowerSound;

    float soundVolume;
    const string VFX_VOLUME = "VFXVolume";
    bool firing;
     float projectileFiringPeriod =0.3f;
    float scoreBoardLength =8/3; 
    public float halfPaddleLength = 2f;
    float expandFactor;
    bool shootingPower = false, laserPower= false, bombPower = false;
    //  bool    expandPower= false;
    int paddleSize;
    int paddleSpeedScale;
    //Fire Buttons
    [SerializeField] AudioClip[] paddleBounce;

    //DoubleBall test
    GameObject[] balls;

    Coroutine firingCoroutine;
   // Coroutine expandCoroutine;
    float xMin, xMax;
    //cached Ref
    GameStatus myGameStatus;
    BallScript myBallScript;
   // Power myPower;
    private Animator myAnimator;
    bool doubleBall;

   // private Rigidbody2D characterBody;
    private float screenWidth,screenHeight;
    bool isAlive;
    // Use this for initialization
    void Start () {
        
        myGameStatus = FindObjectOfType<GameStatus>();
        myBallScript = FindObjectOfType<BallScript>();
        //myPower = FindObjectOfType<Power>();
        myAnimator = this.gameObject.GetComponent<Animator>();
        SetUpMoveBoundaries();
        isAlive = true;
           screenWidth = Screen.width;
            screenHeight = Screen.height;
    //   characterBody = GetComponent<Rigidbody2D>();
        paddleSize = 0;
        paddleSpeedScale = 0;
       // FindObjectOfType<GameStatus>().EnableFireButton();
       // FindObjectOfType<GameStatus>().DisableSecFireButton();
        FindObjectOfType<OnScreenLevelButtons>().EnableFireButtonNew();
        FindObjectOfType<OnScreenLevelButtons>().DisableSecFireButtonNew();
        doubleBall = false;
        soundVolume = PlayerPrefs.GetFloat(VFX_VOLUME, 0.8f);
    }

    // Update is called once per frame
    void Update () {
        if (isAlive == true)
        {
            int i = 0;
            while (i < Input.touchCount)
            {
                if (Input.GetTouch(i).position.x > screenWidth / 2 && Input.GetTouch(i).position.y < screenHeight/2)
                {   
                    
                        MovePaddle(1f);
                    
                   
                }
                if (Input.GetTouch(i).position.x < screenWidth / 2 && Input.GetTouch(i).position.y < screenHeight/2)
                {
                    
                        MovePaddle(-1f);
                    
                }
                ++i;
            }

            //  Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
            // paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
            // transform.position = paddlePos;
            //  Move();
            if (shootingPower)
            {
                Fire();
            }
            if (laserPower)
            {
                FireLaser();
            }
            if (bombPower)
            {
                FireBomb();
            }

        }
    }

    private void MovePaddle(float horizontalInput)
    {
        if (isAlive == true)
        {
            var deltaX = horizontalInput * Time.deltaTime * moveSpeed;
            var newXPos = Mathf.Clamp((transform.position.x + deltaX), xMin, xMax);
            transform.position = new Vector2(newXPos, transform.position.y);

        }
    }

  //  private void Expand()
  //  {
        //    expandCoroutine = StartCoroutine(expandContinuously());
        
  //  }
  //  IEnumerator expandContinuously()
   // {   while(true)
   //     {
           
   //        yield return new WaitForSeconds(projectileFiringPeriod);
    //    }
        
   // }

    private void Fire()
    {   if (isAlive == true)
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.LeftAlt))
            {
                firingCoroutine = StartCoroutine(FireContinuously());
                firing = true;
            }
            if (CrossPlatformInputManager.GetButtonUp("Fire1") || Input.GetKeyUp(KeyCode.LeftAlt))
            {
                StopCoroutine(firingCoroutine);
                firing = false;
            }
        }
    }

    public void StopFiring()
    {
        StopCoroutine(firingCoroutine);
    }

    private void FireLaser()
    {
        if (isAlive == true)
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire3") || Input.GetKeyDown(KeyCode.Space))
            {
                GameObject laserS = Instantiate(actualLaserSPrefab, transform.position + new Vector3(0, -5, 0), Quaternion.identity) as GameObject;
                laserS.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 30);
                AudioSource.PlayClipAtPoint(laserBigSound, Camera.main.transform.position, soundVolume);
                laserPower = false;
                //FindObjectOfType<GameStatus>().DisableSecFireButton();
                FindObjectOfType<OnScreenLevelButtons>().DisableSecFireButtonNew();
            }
        }
    }

    private void FireBomb()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire3") || Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bomb = Instantiate(BombPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            bomb.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 30);
            bombPower = false;
        }
    }

    IEnumerator FireContinuously()
    {
        if (isAlive == true)
        {
            while (true)
            {
                GameObject laserL = Instantiate(laserPrefab, transform.position + new Vector3(-halfPaddleLength, 0, 0), Quaternion.identity) as GameObject;
                laserL.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
                AudioSource.PlayClipAtPoint(laserSmallSound, Camera.main.transform.position, soundVolume);
                GameObject laserR = Instantiate(laserPrefab, transform.position + new Vector3(halfPaddleLength, 0, 0), Quaternion.identity) as GameObject;
                laserR.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
                AudioSource.PlayClipAtPoint(laserSmallSound, Camera.main.transform.position, soundVolume);
                yield return new WaitForSeconds(projectileFiringPeriod);
            }
        }
    }
    
    // Setting move boundaries
      private void SetUpMoveBoundaries()
      {
          Camera gameCamera = Camera.main;
        xMin = 0 + halfPaddleLength;
        xMax = 32 - halfPaddleLength;
      }

  /*  private void Move()
    {
      
        var deltaXP = CrossPlatformInputManager.GetAxis("Fire3") * Time.deltaTime * moveSpeed;
       
        var deltaXN = CrossPlatformInputManager.GetAxis("Jump") * Time.deltaTime * moveSpeed;

    }*/

    void FixedUpdate()
    {
#if UNITY_EDITOR
        MovePaddle(Input.GetAxis("Horizontal"));
            #endif  
    }
    //Auto Test
    /*  private float GetXPos()
       {
           if (myGameStatus.IsAutoPlayEnabled())
           {
               return myBallScript.transform.position.x;
           }
           else
           {
               return Input.mousePosition.x / Screen.width * screenWidthInUnits;
           }
       }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAlive == true)
        {
            var temp = collision.gameObject.tag;
            if (temp == "Ball")
            {
                int random = UnityEngine.Random.Range(0, paddleBounce.Length);
                AudioClip clip = paddleBounce[random];
                AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, soundVolume);
            }
            if (temp == "ShootingPower")
            {
                AudioSource.PlayClipAtPoint(laserPowerSound, Camera.main.transform.position, soundVolume);
                myAnimator.SetBool("Shooting", true);
                shootingPower = true;
                //FindObjectOfType<GameStatus>().EnableFireButton();
                FindObjectOfType<OnScreenLevelButtons>().EnableFireButtonNew();
            }
            else if (temp == "ExpandPower")
            {
                if (paddleSize <= 1)
                {
                    AudioSource.PlayClipAtPoint(paddleExpandSound, Camera.main.transform.position, soundVolume);
                    halfPaddleLength += 0.5f;
                    transform.localScale += new Vector3(0.5f, 0, 0);
                    xMin += 1f;
                    xMax -= 1f;
                    paddleSize += 1;
                }
            }

            else if (temp == "Contract")
            {
                if (paddleSize >= 0)
                {
                    AudioSource.PlayClipAtPoint(paddleContractSound, Camera.main.transform.position, soundVolume);
                    halfPaddleLength -= 0.5f;
                    transform.localScale -= new Vector3(0.5f, 0, 0);
                    xMin -= 1f;
                    xMax += 1f;
                    paddleSize -= 1;
                }
            }
            else if (temp == "DoubleBall")
            {
                doubleBall = true;
                AudioSource.PlayClipAtPoint(doubleBallSound, Camera.main.transform.position, soundVolume);
                balls = GameObject.FindGameObjectsWithTag("Ball");
                foreach (GameObject b in balls)
                {
                    GameObject ball = Instantiate(ballPrefab, b.transform.position, Quaternion.identity) as GameObject;
                    ball.GetComponent<Rigidbody2D>().velocity = new Vector2(-(b.GetComponent<Rigidbody2D>().velocity.x), b.GetComponent<Rigidbody2D>().velocity.y);
                }

            }

            else if (temp == "Shield")
            {
                AudioSource.PlayClipAtPoint(shieldActiveSound, Camera.main.transform.position, soundVolume);
                GameObject shield = Instantiate(actualShieldPrefab, new Vector3(16, -0.25F, 0), Quaternion.identity) as GameObject;

            }
            else if (temp == "Life")
            {
                AudioSource.PlayClipAtPoint(lifePowerSound, Camera.main.transform.position, soundVolume);
                FindObjectOfType<OnScreenLevelButtons>().IncreaseLife();
            }
            else if (temp == "Fast")
            {
                if (paddleSpeedScale <= 1)
                {
                    AudioSource.PlayClipAtPoint(fastBallSound, Camera.main.transform.position, soundVolume);
                    paddleSpeedScale += 1;

                    balls = GameObject.FindGameObjectsWithTag("Ball");
                    foreach (GameObject b in balls)
                    {
                        b.GetComponent<Rigidbody2D>().velocity *= 1.5f;
                    }
                }

            }
            else if (temp == "Slow")
            {
                if (paddleSpeedScale >= -1)
                {
                    AudioSource.PlayClipAtPoint(slowBallSound, Camera.main.transform.position, soundVolume);
                    paddleSpeedScale -= 1;
                    balls = GameObject.FindGameObjectsWithTag("Ball");
                    foreach (GameObject b in balls)
                    {
                        b.GetComponent<Rigidbody2D>().velocity *= 0.5f;
                    }
                }
            }
            else if (temp == "LaserS")
            {
                AudioSource.PlayClipAtPoint(laserSPowerSound, Camera.main.transform.position, soundVolume);
                laserPower = true; bombPower = false;
                FindObjectOfType<OnScreenLevelButtons>().EnableSecFireButtonNew();
            }
            else if (temp == "Bomb")
            {
                bombPower = true; laserPower = false;
            }
        }
    }
    
    public void TriggerDestroyAnimation()
    {   

        isAlive = false;
        AudioSource.PlayClipAtPoint(paddleDestroySound, Camera.main.transform.position, soundVolume);
        myAnimator.SetTrigger("Destroy");
        if (shootingPower == true && firing== true)
        {
            StopCoroutine(firingCoroutine);
        }
        
        
    }

    public bool AliveStatus()
      {
        return isAlive;
    }

    public bool IsDoubleBall()
    {
        return doubleBall;
    }

    public bool IsFiring()
    {
        return firing;
    }



}
