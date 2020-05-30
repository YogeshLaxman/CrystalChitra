using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public Camera mainCam;

    float shakeAmount = 0;

    void Awake()
    {
        if(mainCam== null)
        {
            mainCam = Camera.main;
        }
    }

    public void Shake(float amt, float length)
    {
        shakeAmount = amt;
        InvokeRepeating("StartShake", 0, 0.01f);
        Invoke("StopShake", length);
    }
    void StartShake()
    {
        if(shakeAmount> 0)
        {
            Vector3 camPos= mainCam.transform.position;

            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;

            camPos.x += offsetX;
            camPos.y += offsetY;

            mainCam.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("StartShake");
        mainCam.transform.localPosition = Vector3.zero;
    }

	// Use this for initialization
	void Start () {
        ScreenAdjust();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ScreenAdjust()
    {
        Camera.main.aspect = 1920f / 1080f;
    }
}
