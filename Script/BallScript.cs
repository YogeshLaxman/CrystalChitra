using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class BallScript : MonoBehaviour
{
    //config para
    public Paddle paddle1;
    float xVel = 2f, yVel = 6f;
 
    float randomFactor = 2f;
  
    float ballSpeedMultiplier = 100f;
  
    public float maxSpeed = 20f;
    float minBallSpeed = 20f;
    float maxBallSpeed = 30f;
    //state
    
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    //Cached component references
    Rigidbody2D myRigidBody2D;
    //  AudioSource myAudioSource;
    GameObject[] balls;
    // Use this for initialization
    void Start()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");
        if (balls.Length == 1)
        {
            paddleToBallVector = transform.position - paddle1.transform.position;
        }
        foreach (GameObject b in balls)
        {
         //   myAudioSource = GetComponent<AudioSource>();
            myRigidBody2D = GetComponent<Rigidbody2D>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!hasStarted)
        {
            LaunchOnMouseClick();
            LockBallToPaddle();
        }
      

    }

    public void LaunchOnMouseClick()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");
        bool doubleball = FindObjectOfType<Paddle>().IsDoubleBall();
        if (balls.Length == 1 && doubleball == false)
        {

            if (CrossPlatformInputManager.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.LeftAlt))
            {
                hasStarted = true;
                myRigidBody2D.velocity = new Vector2(Random.Range(-1,1)* xVel * Time.deltaTime * ballSpeedMultiplier, yVel * Time.deltaTime * ballSpeedMultiplier);
                FindObjectOfType<OnScreenLevelButtons>().DisableFireButtonNew();
            }
        }
    }

    public void LockBallToPaddle()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");
        bool doubleball = FindObjectOfType<Paddle>().IsDoubleBall();
        if (balls.Length == 1 && doubleball == false )
        {
            Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            transform.position = paddlePos + paddleToBallVector;
        }
        
    }

    public Vector2 ClampMagnitude(Vector2 v, float max, float min)
    {
      
        double sm = v.sqrMagnitude;
        if (sm > (double)max * (double)max)
        {  return v.normalized * max; }
        else if (sm < (double)min * (double)min)
        {  return v.normalized * min; }
       
        return v;
        }

    public void SpeedUp()
    {
        myRigidBody2D.velocity *= 2f;
    }

    public void SlowDown()
    {
        myRigidBody2D.velocity *= 0.5f;
    }
}