using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public string gameplaySceneName;
    public static bool gameIsPaused;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(gameplaySceneName))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!gameIsPaused)
                {
                    SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
                    gameIsPaused = true;
                    toggleTimeScale();
                }
                else
                {
                    startGame();
                }
            }
        }
    }
    public void startGame()
    {
        if (gameIsPaused)
        {
            toggleTimeScale();
            SceneManager.UnloadSceneAsync("MainMenu");
            gameIsPaused = false;
        }
        else
        {
            SceneManager.LoadScene(gameplaySceneName);
        }
        return;
    }
    public void exitGame()
    {
        Debug.Log("Exiting the Game");
        Application.Quit();
    }
    [Button]
    public void toggleTimeScale()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
