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
        pauseUI.SetActive(false);
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
        SoundManager.instance.PlayButtonSound();
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        SoundManager.instance.PlayButtonSound();
        Time.timeScale = 0.0f;
        pauseButton.gameObject.SetActive(false);
        pauseUI.SetActive(true);
        inPause = true;
    }

    public void ResumeGame()
    {
        SoundManager.instance.PlayButtonSound();
        Time.timeScale = 1.0f;
        pauseButton.gameObject.SetActive(true);
        pauseUI.SetActive(false);
        inPause = false;
    }

    public void TogglePause()
    {
        if (inPause)
            ResumeGame();
        else
            PauseGame();
    }
}
