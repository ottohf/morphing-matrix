using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void Start()
    {
        SoundManager.instance.bgm.clip = SoundManager.instance.winSound;
        SoundManager.instance.bgm.loop = false;
        SoundManager.instance.bgm.Play();
    }

    public void GotoMainMenu()
    {
        SoundManager.instance.bgm.loop = true;
        SceneManager.LoadScene("MainMenu");
    }
}
