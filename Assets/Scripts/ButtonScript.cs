using UnityEngine.UI;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // Public objects
    public Sprite sprite1;
    public Sprite sprite2;

    //Private objects/variables
    private Image buttonImage;
    public int spriteIndex;

    void Start()
    {
        buttonImage = GetComponent<Image>(); // Get the image component of your button
        spriteIndex = 0; // Set the index to 0
        buttonImage.sprite = sprite1; // Set the image to the first image in your sprite array
    }

    public void SwitchSprite()
    {
        if (spriteIndex == 0)
        {
            buttonImage.sprite = sprite2;
            spriteIndex = 1;
        }
        else
        {
            buttonImage.sprite = sprite1;
            spriteIndex = 0;
        }
    }
}