using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player has reached the flag
            if (SceneManager.GetActiveScene().name == "Tutorial")
            {
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
        }
        else
        {
            Debug.LogError("Something that wasnt a player entered the objective");
        }
    }
}
