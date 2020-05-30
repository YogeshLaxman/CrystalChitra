using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTimeCounter : MonoBehaviour {
    public float timer;
	// Use this for initialization
	void Start () {
		timer = 300;
        timer -= TimeMaster.instance.CheckDate();
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
	}


    void ResetClock()
    {
        TimeMaster.instance.SaveDate();
        timer = 300;
        timer -= TimeMaster.instance.CheckDate();
    }
}
