using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector2 movementInput; // Store movement input
    
    void Awake()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector2 moveDirection = new Vector2(movementInput.x, movementInput.y);
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.Self);
    }

    // Input methods for the new Input System using CallbackContext
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
       
    }
}