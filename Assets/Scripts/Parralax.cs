using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public float pEffect;

    private Rigidbody2D rb;
    private float pxStart;
    private float pyStart;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.parent?.parent?.parent?.GetComponent<Rigidbody2D>(); // workaround for menu
        pxStart = SpriteRenderer.transform.position.x;
        pyStart = SpriteRenderer.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if (rb != null)// workaround for menu
        { 
            SpriteRenderer.transform.position = new Vector2(pxStart + rb.transform.position.x * (1f - pEffect * 2f), pyStart + rb.transform.position.y * (1f - pEffect * 0.5f));
       }  
    }
}
