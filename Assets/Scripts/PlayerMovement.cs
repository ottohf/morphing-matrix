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
    PlayerColor playerColor = PlayerColor.Blue;
    PlayerSize playerSize = PlayerSize.Small;
    Vector2 movementInput;

    Rigidbody2D body;
    BoxCollider2D collider;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        jumpSpeed = smallJumpSpeed;
    }

    void FixedUpdate()
    {
        body.velocityX = movementInput.x * speed * Time.fixedDeltaTime;
        // uncomment this for auto run
        // body.velocityX = speed * Time.fixedDeltaTime;

        if (transform.position.y < -20)
            Die();
    }

    enum PlayerColor
    {
        Red,
        Blue,
    }
    enum PlayerSize
    {
        Big,
        Small,
    }

    void Die()
    {
        transform.position = new Vector3(0, 0, 0);
        SetColor(PlayerColor.Blue);
        SetSize(PlayerSize.Small);
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
            SetSize(playerSize == PlayerSize.Small ? PlayerSize.Big : PlayerSize.Small);
        }
    }

    bool ObjectHasRightTag(Component component)
    {
        if (!component.CompareTag("Red") && !component.CompareTag("Blue"))
            return true;

        return component.CompareTag(playerColor == PlayerColor.Red ? "Red" : "Blue");
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (!ObjectHasRightTag(collider))
            Die();
    }

    void SetSize(PlayerSize size)
    {
        playerSize = size;
        float newSize = playerSize == PlayerSize.Small ? 1.0f : 1.4f;
        collider.size = spriteRenderer.transform.localScale = new Vector3(newSize, newSize, 1);
        jumpSpeed = playerSize == PlayerSize.Small ? smallJumpSpeed : bigJumpSpeed;
    }

    void SetColor(PlayerColor color)
    {
        spriteRenderer.color = color == PlayerColor.Red ? Color.red : Color.blue;

        foreach (var obj in GameObject.FindGameObjectsWithTag("Red"))
        {
            var collider = obj.GetComponent<BoxCollider2D>();
            if (collider != null)
                collider.enabled = color == PlayerColor.Red;
        }
        foreach (var obj in GameObject.FindGameObjectsWithTag("Blue"))
        {
            var collider = obj.GetComponent<BoxCollider2D>();
            if (collider != null)
                collider.enabled = color == PlayerColor.Blue;
        }
        playerColor = color;
    }

    public void OnSwitchColor(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetColor(playerColor == PlayerColor.Red ? PlayerColor.Blue : PlayerColor.Red);
        }
    }
}
