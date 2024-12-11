using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        SoundManager.instance.bgm.clip = SoundManager.instance.mainMenuBGM;
        SoundManager.instance.bgm.Play();
    }

    public void OnStartGame()
    {
        SoundManager.instance.PlayButtonSound();

        SoundManager.instance.bgm.clip = SoundManager.instance.levelBGM;
        SoundManager.instance.bgm.Play();

        SceneManager.LoadScene("Level 1");
    }

    public void OnGotoTutorial()
    {
        SoundManager.instance.PlayButtonSound();

        SoundManager.instance.bgm.clip = SoundManager.instance.levelBGM;
        SoundManager.instance.bgm.Play();

        SceneManager.LoadScene("Tutorial");
    }

    public void OnQuitGame()
    {
        SoundManager.instance.PlayButtonSound();
        Application.Quit();
    }

    public void OnGotoShop()
    {
        SoundManager.instance.PlayButtonSound();
        SceneManager.LoadScene("Shop");
    }
}
