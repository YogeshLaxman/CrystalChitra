using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour {

    const string MUSIC_VOLUME = "musicVolume";
    const string VFX_VOLUME = "VFXVolume";
    public Slider volumeSlider;
    public Slider volumeSliderB;
    public Button[] oButtons;
    public TextMeshProUGUI[] AllText;
  

    public GameObject SettingsPanelUI;
    public Button playButton;
    // Use this for initialization
    void Start () {

        SettingsPanelUI.SetActive(false);
        volumeSlider.value = PlayerPrefs.GetFloat(MUSIC_VOLUME, 0.8f);
        volumeSliderB.value = PlayerPrefs.GetFloat(VFX_VOLUME, 0.8f);
        ColorAndAlphaText();
    }
	
	// Update is called once per frame
	void Update ()
    {
      var musicPlayer = FindObjectOfType<MenuMusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        
	}

    public void SettingsCanvasEnable()
    {
        SettingsPanelUI.SetActive(true);
        FindObjectOfType<MaterialEditor>().BlurIn();
        for (int i = 0; i < oButtons.Length; i++)
        {
            oButtons[i].interactable = false;
        }
    }

    public void SettingsCanvasDisable()
    {
        PlayerPrefs.SetFloat(MUSIC_VOLUME, volumeSlider.value);
        PlayerPrefs.SetFloat(VFX_VOLUME, volumeSliderB.value);
        SettingsPanelUI.SetActive(false);
        FindObjectOfType<MaterialEditor>().BlurOut();
        for (int i = 0; i < oButtons.Length; i++)
        {
            oButtons[i].interactable = true;
        }
    }

    public void ResetButton()
    {
        volumeSlider.value = 0.8f;
        volumeSliderB.value = 0.8f;
        PlayerPrefs.DeleteAll();
    }

    public void ColorAndAlphaText()
    {
        for (int i = 0; i < AllText.Length; i++)
        {
            AllText[i].faceColor = new Color32(10, 10, 10, 180);
        }
    }
}
