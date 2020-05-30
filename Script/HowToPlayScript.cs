using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HowToPlayScript : MonoBehaviour {

    public GameObject HTPPanelUI;
    public GameObject[] PanelUI;
    public Button[] playButton;
    public Button[] oButtons;
    int currentPanel;
    const string STARTMENU_NORMAL = "firstPlay";
    public TextMeshProUGUI[] AllText;
    public MaterialEditor MatEd;
    // Use this for initialization
    void Start()
    {
        currentPanel = 0;
        ColorAndAlphaText();

        int temp = PlayerPrefs.GetInt(STARTMENU_NORMAL, 0);
        if (temp == 1)
        {
            HTPPanelUI.SetActive(false);
            for (int i = 0; i < PanelUI.Length; i++)
            {
                PanelUI[i].SetActive(false);
            }
            currentPanel = 0;
            ColorAndAlphaText();
        }
        else
        {
            HTPPanelUI.SetActive(false);
            for (int i = 0; i < PanelUI.Length; i++)
            {
                PanelUI[i].SetActive(false);
            }
            currentPanel = 0;
            ColorAndAlphaText();
           
            PlayerPrefs.SetInt(STARTMENU_NORMAL, 1);
            //enablehowtoplay
            SettingsCanvasEnable();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SettingsCanvasEnable() //EnableHowtoPlay typo
    {
        HTPPanelUI.SetActive(true);
      
        for (int i = 0; i < playButton.Length; i++)
        {
            playButton[i].interactable = true;
        }
        for (int i = 0; i < oButtons.Length; i++)
        {
            oButtons[i].interactable = false;
        }
        PanelUI[currentPanel].SetActive(true);
        MatEd.BlurIn();
    }

    public void SettingsCanvasDisable()
    {
        HTPPanelUI.SetActive(false);
       
        for (int i = 0; i < playButton.Length; i++)
        {
            playButton[i].interactable = false;
        }
        for (int i = 0; i < oButtons.Length; i++)
        {
            oButtons[i].interactable = true;
        }
        MatEd.BlurOut();
    }
    
    public void LeftArrow()
    {
        currentPanel -= 1;
        if(currentPanel < 0)
        {
            currentPanel = PanelUI.Length - 1;
        }
        for (int i = 0; i < PanelUI.Length; i++)
        {
            PanelUI[i].SetActive(false);
        }
        PanelUI[currentPanel].SetActive(true);
    }

    public void RightArrow()
    {
        currentPanel += 1;
        if (currentPanel > PanelUI.Length - 1)
        {
            currentPanel = 0;
        }
        for (int i = 0; i < PanelUI.Length; i++)
        {
            PanelUI[i].SetActive(false);
        }
        PanelUI[currentPanel].SetActive(true);
    }

    public void ColorAndAlphaText()
    {
        for (int i = 0; i < AllText.Length; i++)
        {
            AllText[i].faceColor = new Color32(10, 10, 10, 180);
        }
    }
}

