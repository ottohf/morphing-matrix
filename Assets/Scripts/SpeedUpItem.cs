using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : MonoBehaviour
{
    float startTime = -1.0f;
    void OnTriggerEnter2D(Collider2D collider)
    {
        startTime = Time.time;
        // Time.timeScale = 2f;
        // Invoke(nameof(ResetTimeScale), 5.0f);
    }

    // void ResetTimeScale()
    // {
    //     Time.timeScale = 1.0f;
    // }

    public void ResetSpeedUp()
    {
        startTime = -1.0f;
    }

    void Update()
    {
        if (Time.timeScale == 0)
            return;
        if (startTime >= 0 && Time.time - startTime < 3.0f)
        {
            Time.timeScale = 2.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}
