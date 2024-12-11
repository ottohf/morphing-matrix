using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStep : MonoBehaviour
{

    public TutorialManager tutorial;
    private void OnTriggerEnter2D(Collider2D other)
    {
        tutorial.StepTutorial();
    }
}
