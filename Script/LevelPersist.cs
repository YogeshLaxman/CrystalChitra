using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPersist : MonoBehaviour {

    int startingSceneIndex;
    private void Awake()
    {
        int numLevelPersist = FindObjectsOfType<LevelPersist>().Length;
        if (numLevelPersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex != startingSceneIndex)
        {
            Destroy(gameObject);
        }
    }
}
