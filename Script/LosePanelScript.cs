using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Monetization;

public class LosePanelScript : MonoBehaviour {

    public static bool LoseCanvasActive = false;
    public GameObject LosePanelUI;
     SceneLoader sceneloader;
    private string storeId="3024098";
    private string videoAd = "video";
    private string placementIDRewardedVideo = "rewardedVideo";
    const string SHOW_AD = "showAd";
    public TextMeshProUGUI tmpText;
   
    const string COINS = "coins";
    bool losePanelEnable;
    public TextMeshProUGUI[] AllText;

    public TextMeshProUGUI TextOne;
    public TextMeshProUGUI TextTwo;
    public TextMeshProUGUI TextThree;
    public TextMeshProUGUI coinsText;
    public Button coinButton;
    public Button videoButton;
    public GameObject stormPrefab;

    // Use this for initialization
    void Start () {
        losePanelEnable = false;
        ColorAndAlphaText();
        sceneloader = FindObjectOfType<SceneLoader>();
        LosePanelUI.SetActive(false);
        Monetization.Initialize(storeId, true);
        tmpText.text = "";
        coinsText.text = PlayerPrefs.GetInt(COINS, 0).ToString();

        TextOne.transform.position = new Vector3((Screen.width) * 0.5f, (Screen.height) * 0.8f, 0);
        TextTwo.transform.position = new Vector3((Screen.width) * 0.5f, (Screen.height) * 0.6f, 0);
        TextThree.transform.position = new Vector3((Screen.width) * 0.5f, (Screen.height) * 0.2f, 0);
        coinButton.transform.position = new Vector3((Screen.width) * 0.4f, (Screen.height) * 0.4f, 0);
        videoButton.transform.position = new Vector3((Screen.width) * 0.6f, (Screen.height) * 0.4f, 0);
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Y))
        {

            LoseCanvasEnable();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            int coins = PlayerPrefs.GetInt(COINS, 0);
            coins += 5;
          
            PlayerPrefs.SetInt(COINS, coins);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {

            int coins = PlayerPrefs.GetInt(COINS, 0);
            coins -= 5;
           
            PlayerPrefs.SetInt(COINS, coins);
        }

    }

    public void LoseCanvasEnable()
    {
        losePanelEnable = true;
        int c = PlayerPrefs.GetInt(SHOW_AD, 1);
        if (c == 1)
        {
            LosePanelUI.SetActive(true);
            PlayerPrefs.SetInt(SHOW_AD, 0);
        }
        else
        {
            LoseCanvasDisable();
        }
        FindObjectOfType<OnScreenLevelButtons>().DisableOSBCanvas();
        GameObject stormOne = Instantiate(stormPrefab, new Vector3(40, 18, -2), Quaternion.Euler(140, 90, 90)) as GameObject;
        GameObject stormTwo = Instantiate(stormPrefab, new Vector3(32, 30, -2), Quaternion.Euler(140, 90, 90)) as GameObject;
    }

    public void LoseCanvasDisable()
    {
        losePanelEnable = false;
        LosePanelUI.SetActive(false);
        PlayerPrefs.SetInt(SHOW_AD,1);
        // sceneloader.LoadLoseScreen();
        SceneManager.LoadScene("Lose Screen");
        FindObjectOfType<GameMusicPlayer>().DestroyGamePlayer();
        FindObjectOfType<LivesManager>().DecreaseLife();
        FindObjectOfType<OnScreenLevelButtons>().DestroyOnScreenLevelButtons();
       
    }

    public void ExtraLife()
    {
        
        FindObjectOfType<OnScreenLevelButtons>().DisableFireButtonNew();
        FindObjectOfType<OnScreenLevelButtons>().DisableSecFireButtonNew();
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        FindObjectOfType<OnScreenLevelButtons>().EnableOSBCanvas();
    }

    public void ShowAd()
    {
        StartCoroutine(WaitForAd());
    }

    IEnumerator WaitForAd()
    {
        while (!Monetization.IsReady(placementIDRewardedVideo))
        {
            yield return null;
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent(placementIDRewardedVideo) as ShowAdPlacementContent;

        if (ad != null)
        {
            ad.Show(AdFinished);
        }
    }

    void AdFinished(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            ExtraLife();
            
        }
        else if (result == ShowResult.Skipped)
        {
            LoseCanvasDisable();
        }
        else if (result == ShowResult.Failed)
        {
            tmpText.text = "try again later";
        }
    }

    public void CoinsButton()
    {
        int coins = PlayerPrefs.GetInt(COINS, 0);
        if (coins >= 10)
        {
            coins -= 10;
            PlayerPrefs.SetInt(COINS, coins);
            PlayerPrefs.SetInt(SHOW_AD, 0);
            ExtraLife();
        }
        else
        {
            tmpText.text = "insufficient coins";
        }

    }
    public void ColorAndAlphaText()
    {
        for (int i = 0; i < AllText.Length; i++)
        {
            AllText[i].faceColor = new Color32(10, 10, 10, 180);
        }
    }

    public bool ReturnLPSEnable()
    {
        return losePanelEnable;
    }

}
