using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float smallJumpSpeed;
    public float bigJumpSpeed;
    public SpriteRenderer spriteRenderer;

    public GameObject canvasPrefab;
    public GameObject canvasX;

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

        canvasX = Instantiate(canvasPrefab);

        //collider.transform.position = new Vector2(collider.transform.position.x - 6f, collider.transform.position.y);
        //spriteRenderer.transform.position = new Vector2(spriteRenderer.transform.position.x - 6f, spriteRenderer.transform.position.y);
    }
    private void Start()
    {
        SetColor(PlayerColor.Blue);
        SetSize(PlayerSize.Small);
        //spriteRenderer.transform.position = new Vector2(spriteRenderer.transform.position.x, spriteRenderer.transform.position.y + 0.24f); // this "evens out" the misplacement from subracting .24 the first time a size is set
    }
    void FixedUpdate()
    {
        body.velocityX = movementInput.x * speed * Time.fixedDeltaTime;
        // uncomment this for auto run
        body.velocityX = speed * Time.fixedDeltaTime;

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
        Destroy(canvasX);
        canvasX = Instantiate(canvasPrefab);
        //spriteRenderer.transform.position = new Vector2(spriteRenderer.transform.position.x, spriteRenderer.transform.position.y + 0.24f); // this "evens out" the misplacement from subracting .24 the first time a size is set
    }

    public bool IsOnGround()
    {
        return Physics2D.OverlapBox(transform.position, collider.size, 0, groundLayer);
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
    public void OnFuckingNormalJump()
    {
        if (IsOnGround())
            body.velocityY = jumpSpeed;
    }
    public void OnSwitchSize(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetSize(playerSize == PlayerSize.Small ? PlayerSize.Big : PlayerSize.Small);
        }
    }

    public void OnSwitchFuckingNormalSize()
    {
        SetSize(playerSize == PlayerSize.Small ? PlayerSize.Big : PlayerSize.Small);
    }

    bool ObjectHasRightTag(GameObject component)
    {
        if (component.CompareTag("Killer"))
            return false;

        if (!component.CompareTag("Red") && !component.CompareTag("Blue"))
            return true;

        return component.CompareTag(playerColor == PlayerColor.Red ? "Red" : "Blue");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!ObjectHasRightTag(collider.gameObject))
            Die();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!ObjectHasRightTag(collision.gameObject))
            Die();
    }

    void SetSize(PlayerSize size)
    {
        if (playerSize == PlayerSize.Small && size == PlayerSize.Big) // yes, this IS stupid -robin
        {
            spriteRenderer.transform.position = new Vector2(spriteRenderer.transform.position.x, spriteRenderer.transform.position.y + 0.17f);
        }
        if (playerSize == PlayerSize.Big && size == PlayerSize.Small)
        {
            spriteRenderer.transform.position = new Vector2(spriteRenderer.transform.position.x, spriteRenderer.transform.position.y - 0.17f);
        }
        playerSize = size;
        float newSize = playerSize == PlayerSize.Small ? 1.0f : 1.4f;
        collider.size = new Vector3(newSize * 0.9f, newSize * 1.2f, 1);
        spriteRenderer.transform.localScale = new Vector3(newSize * 0.4635f, newSize * 0.4635f, 1);
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

    public void OnSwitchFuckingNormalColor()
    {
       SetColor(playerColor == PlayerColor.Red ? PlayerColor.Blue : PlayerColor.Red);
    }
}
