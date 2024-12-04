using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Button pauseButton;
    public GameObject pauseUI;

    bool inPause = false;

    void Start()
    {
        ResumeGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        print("Pause");
        Time.timeScale = 0.0f;
        pauseButton.gameObject.SetActive(false);
        pauseUI.SetActive(true);
        inPause = true;
    }

    public void ResumeGame()
    {
        print("Resume");
        Time.timeScale = 1.0f;
        pauseButton.gameObject.SetActive(true);
        pauseUI.SetActive(false);
        inPause = false;
    }

    public void TogglePause()
    {
        print("Toggle");
        if (inPause)
            ResumeGame();
        else
            PauseGame();
    }
}
