using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    public AudioSource buttonClickSound;

    public AudioSource bgm;

    public AudioClip mainMenuBGM;
    public AudioClip winSound;
    public AudioClip levelBGM;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PlayButtonSound()
    {
        buttonClickSound.Play();
    }
}
