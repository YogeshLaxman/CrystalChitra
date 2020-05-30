using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class WinPanel : MonoBehaviour {

    // Use this for initialization
    public static bool WinCanvasActive = false;
    public GameObject WinPanelUI;
    SceneLoader sceneloader;
    const string SHOW_AD = "showAd";
    bool WinPanelEnable;
    [SerializeField] GameObject starCPrefab;
    [SerializeField] GameObject starLPrefab;
    [SerializeField] GameObject starRPrefab;
    float soundVolume;
    const string VFX_VOLUME = "VFXVolume";
    [SerializeField] AudioClip starSound;
    public Button okayButton;
    public TextMeshProUGUI tmpText;
   
    public GameObject rocketSec;
   
    const string CURRENT_LEVEL = "currentLevel";
    const string COMPLETE = "C";
    const string TIME = "T";
    const string FLAWLESS = "F";
    const string HIGHSCORE = "H";
    string levelString;

    
        
    // Update is called once per frame
    void Start()
    {
        WinPanelEnable=false;

        sceneloader = FindObjectOfType<SceneLoader>();
        WinPanelUI.SetActive(false);
        tmpText.text = "";

        okayButton.interactable = false;
        tmpText.color = Color.black;
        //okayText.color = Color.black;
        soundVolume = PlayerPrefs.GetFloat(VFX_VOLUME, 0.8f);
        okayButton.transform.position = new Vector3((Screen.width) * 0.5f, (Screen.height) * 0.1f, 0);
        tmpText.transform.position = new Vector3((Screen.width) * 0.5f, (Screen.height) * 0.9f, 0);
        
    }
    void Update () {
       if (Input.GetKeyDown(KeyCode.T))
      {

            WinCanvasEnable();
      }
        
    }

    public void WinCanvasEnable()
    {
        WinPanelEnable = true;
        WinPanelUI.SetActive(true);
        SetStars();
        FindObjectOfType<OnScreenLevelButtons>().DisableOSBCanvas();
        if(FindObjectOfType<Paddle>().IsFiring())
        {
            FindObjectOfType<Paddle>().StopFiring();
        }
        
    }

    public void WinCanvasDisable()
    {
        WinPanelEnable = false;
        WinPanelUI.SetActive(false);
        FindObjectOfType<GameMusicPlayer>().DestroyGamePlayer();
        PlayerPrefs.SetInt(SHOW_AD, 1);
        sceneloader.LoadWinScreen();
    }

    public void SetStars()
    {
        int currentLevelNumber = PlayerPrefs.GetInt(CURRENT_LEVEL);
        levelString = currentLevelNumber.ToString();
        DisplayWinStars(levelString, 1);
    }

    public void DisplayWinStars(string LEVEL, int num)
    {
        
        GameObject rocketTwo = Instantiate(rocketSec, new Vector3(16, 1, -3), Quaternion.Euler(270,0,0)) as GameObject;
        if (num ==1)
        {   

            int c = PlayerPrefs.GetInt(COMPLETE + LEVEL, 0);
            if (c == 0)
            {
                num = 2;
            }
            else
            {
                GameObject starC = Instantiate(starCPrefab, new Vector3(16, 9, -5), Quaternion.identity) as GameObject;
                StartCoroutine(ShakeAndSound(1));
            }
        }
       
        if (num == 2)
        {
            int t = PlayerPrefs.GetInt(FLAWLESS + LEVEL, 0);
            if (t == 0)
            {
                num = 3;
            }
            else
            {
                GameObject starL = Instantiate(starLPrefab, new Vector3(16, 9, -5), Quaternion.identity) as GameObject;
                StartCoroutine(ShakeAndSound(2));
            }
        }


        if (num == 3)
        {
            int f = PlayerPrefs.GetInt(TIME + LEVEL, 0);
            if (f == 0)
            {
                
            }
            else
            {
                GameObject starR = Instantiate(starRPrefab, new Vector3(16, 9, -5), Quaternion.identity) as GameObject;
                StartCoroutine(ShakeAndSound(3));
            }

            StartCoroutine(YouWinText());
        }
        
    }

    IEnumerator ShakeAndSound(int num)
    {
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<CameraShake>().Shake(0.1f, 0.2f);
        AudioSource.PlayClipAtPoint(starSound, Camera.main.transform.position, soundVolume);
        if (num < 3)
        {
            num += 1;
            DisplayWinStars(levelString, num);
        }
    }
    IEnumerator YouWinText()
    {
        yield return new WaitForSeconds(1f);
        // FindObjectOfType<MaterialEditor>().BlurIn();
        tmpText.text = "you win";
        okayButton.interactable = true;
    }
    public bool ReturnWPSEnable()
    {
        return WinPanelEnable;
    }
}
