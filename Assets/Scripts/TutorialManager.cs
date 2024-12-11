using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Image arrowJumpImage;
    public Image arrowSizeImage;
    public Image arrowColorImage;
    public Button jumpButton;
    public Button colorButton;
    public Button sizeButton;
    public TextMeshProUGUI tutorialText;

    public enum Action
    {
        Jump,
        ChangeSize,
        ChangeColor,
    };

    struct TutorialStep
    {
        public Action actionToDo;
        public string text;
    };

    static TutorialStep[] steps = new TutorialStep[]
    {
        new (){actionToDo = Action.Jump, text = "Press the jump button to avoid falling!"},
        new (){actionToDo = Action.ChangeColor, text = "Press the color button to avoid falling!"},
        new (){actionToDo = Action.ChangeSize, text = "The next platform is far away.\nPress the size button to become bigger!"},
        new (){actionToDo = Action.Jump, text = "When you're big, you can jump further!\nPress jump to see the difference!"},
        new (){actionToDo = Action.ChangeSize, text = "Some obstacles only hit you when you're big!\nChange your size back to avoid them!"},
    };


    public int pendingStep = 0;
    bool hasPendingStep = false;

    void Start()
    {
        tutorialText.enabled = false;
        arrowJumpImage.enabled = false;
        arrowSizeImage.enabled = false;
        arrowColorImage.enabled = false;
        sizeButton.interactable = false;
        colorButton.interactable = false;
        jumpButton.interactable = false;
    }

    public void OnPressJump()
    {
        OnPressButton(Action.Jump);
    }

    public void OnPressColor()
    {
        OnPressButton(Action.ChangeColor);
    }

    public void OnPressSize()
    {
        OnPressButton(Action.ChangeSize);
    }

    void OnPressButton(Action action)
    {
        if (hasPendingStep && steps[pendingStep].actionToDo == action)
        {
            tutorialText.enabled = false;
            arrowJumpImage.enabled = false;
            arrowSizeImage.enabled = false;
            arrowColorImage.enabled = false;
            sizeButton.interactable = false;
            colorButton.interactable = false;
            jumpButton.interactable = false;
            pendingStep++;
            hasPendingStep = false;
            Time.timeScale = 1.0f;
        }
    }

    public void StepTutorial()
    {
        Time.timeScale = 0.0f;
        tutorialText.enabled = true;
        tutorialText.text = steps[pendingStep].text;
        arrowJumpImage.enabled = steps[pendingStep].actionToDo == Action.Jump;
        jumpButton.interactable = steps[pendingStep].actionToDo == Action.Jump;
        arrowColorImage.enabled = steps[pendingStep].actionToDo == Action.ChangeColor;
        colorButton.interactable = steps[pendingStep].actionToDo == Action.ChangeColor;
        arrowSizeImage.enabled = steps[pendingStep].actionToDo == Action.ChangeSize;
        sizeButton.interactable = steps[pendingStep].actionToDo == Action.ChangeSize;
        hasPendingStep = true;
    }
}
