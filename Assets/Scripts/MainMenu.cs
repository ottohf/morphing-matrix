using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnStartGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void OnQuitGame()
    {
        Application.Quit();
    }

    public void OnGotoShop()
    {
        SceneManager.LoadScene("Shop");
    }
}
