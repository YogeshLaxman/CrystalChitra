using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
   public bool gamePaused = false;
    public GameObject pauseMenuCanvas;
    
    private float fixedDeltaTime;

    public TextMeshProUGUI resumeText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI homeText;

    // Update is called once per frame
    void Start()
    {
        fixedDeltaTime = Time.fixedDeltaTime;
        pauseMenuCanvas.SetActive(false);
        resumeText.color = Color.white;
        restartText.color = Color.white;
        homeText.color = Color.white;
    }
    void Update ()
    {
		if(CrossPlatformInputManager.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.Escape))
        {   
            if(!(FindObjectOfType<LosePanelScript>().ReturnLPSEnable() || FindObjectOfType<WinPanel>().ReturnWPSEnable()))
            {
                if (gamePaused)
                {
                    Resume();

                }
                else
                {
                    Pause();

                }

            }
            
        }
	}

    public void Resume()
    {
        Time.timeScale = FindObjectOfType<GameStatus>().ReturnGameSpeed();
        Time.fixedDeltaTime = fixedDeltaTime;
        pauseMenuCanvas.SetActive(false);
        gamePaused = false;
        FindObjectOfType<MaterialEditor>().BlurOut();
        FindObjectOfType<OnScreenLevelButtons>().EnableOSBCanvas();
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0f;
        pauseMenuCanvas.SetActive(true);
        gamePaused=true;
        FindObjectOfType<MaterialEditor>().BlurIn();
        FindObjectOfType<OnScreenLevelButtons>().DisableOSBCanvas();

    }
    public void Home()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<SceneLoader>().LoadStartScene();
        FindObjectOfType<GameMusicPlayer>().DestroyGamePlayer();
        Resume();

    }

        public void Restart()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            FindObjectOfType<OnScreenLevelButtons>().DestroyOnScreenLevelButtons();
            SceneManager.LoadScene(currentSceneIndex);
            Resume();
            Destroy(FindObjectOfType<LevelPersist>().gameObject);
        }
    public void Quit()
    {
        Resume();
        Application.Quit();
    }

    public void DestroyPauseMenu()
    {
        Destroy(gameObject);
    }
}
