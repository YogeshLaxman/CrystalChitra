using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeMaster : MonoBehaviour {

    DateTime currentDTime;
    DateTime oldDTime;

    public string saveLocation;
    public static TimeMaster instance;
    // Use this for initialization
    void Awake () {

        instance = this;
        saveLocation = "LastSavedDate1";
	}
	
	// Update is called once per frame
	public float CheckDate()
    {
        currentDTime = System.DateTime.Now;
        string tempString = PlayerPrefs.GetString(saveLocation, "1");
        long tempLong = Convert.ToInt64(tempString);
        //convert binary ti date time
        DateTime oldDate = DateTime.FromBinary(tempLong);
        Debug.Log("Old DateTime: "+ oldDate);
        TimeSpan difference = currentDTime.Subtract(oldDate);
        print("Difference: " + difference);
        return (float)difference.TotalSeconds;
    }

    public void SaveDate()
    {
        //save current systime
        PlayerPrefs.SetString(saveLocation, System.DateTime.Now.ToString());
        Debug.Log("Save this date to Player prefs"+ System.DateTime.Now);
    }
}
