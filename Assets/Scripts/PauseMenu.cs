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
        Time.timeScale = 1.0f;
        SoundManager.instance.PlayButtonSound();
        SceneManager.LoadScene("MainMenu");

    }

    float oldTimeScale = 0;
    public void PauseGame()
    {
        SoundManager.instance.PlayButtonSound();
        oldTimeScale = Time.timeScale;
        Time.timeScale = 0.0f;
        pauseButton.gameObject.SetActive(false);
        pauseUI.SetActive(true);
        inPause = true;
    }

    public void ResumeGame()
    {
        SoundManager.instance.PlayButtonSound();
        Time.timeScale = oldTimeScale;
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
