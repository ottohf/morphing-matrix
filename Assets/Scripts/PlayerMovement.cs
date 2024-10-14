using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float smallJumpSpeed;
    public float bigJumpSpeed;
    public SpriteRenderer spriteRenderer;

    public LayerMask groundLayer;

    float jumpSpeed;
    bool isSmall = true;
    bool isRed = true;
    Vector2 movementInput;

    Rigidbody2D body;
    BoxCollider2D collider;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        jumpSpeed = smallJumpSpeed;
    }

    void Update()
    {
        body.velocityX = movementInput.x * speed * Time.deltaTime;

        if (transform.position.y < -10)
            Die();
    }

    void Die()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    bool IsOnGround()
    {
        return Physics2D.OverlapBox(transform.position, spriteRenderer.transform.localScale, 0, groundLayer);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (IsOnGround() && context.started)
            body.velocityY = jumpSpeed;
    }
    public void OnSwitchSize(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isSmall = !isSmall;
            float newSize = isSmall ? 1.0f : 1.4f;
            collider.size = spriteRenderer.transform.localScale = new Vector3(newSize, newSize, 1);
            jumpSpeed = isSmall ? smallJumpSpeed : bigJumpSpeed;
        }
    }

    bool ObjectHasRightTag(Component component)
    {
        return component.CompareTag(isRed ? "Red" : "Blue");
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (!ObjectHasRightTag(collider))
            Die();
    }

    public void OnSwitchColor(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isRed = !isRed;
            spriteRenderer.color = isRed ? Color.red : Color.blue;

            foreach (var obj in GameObject.FindGameObjectsWithTag("Red"))
            {
                var collider = obj.GetComponent<BoxCollider2D>();
                if (collider != null)
                    collider.enabled = isRed;
            }
            foreach (var obj in GameObject.FindGameObjectsWithTag("Blue"))
            {
                var collider = obj.GetComponent<BoxCollider2D>();
                if (collider != null)
                    collider.enabled = !isRed;
            }
        }
    }
}
