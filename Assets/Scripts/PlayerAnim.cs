using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator animator;
    private Animator animatorBowtie;
    private Animator animatorHat;
    private bool isGrounded;

    public LayerMask groundLayer;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D collider;

    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animatorBowtie = GameObject.Find("BowtieAnim").GetComponent<Animator>();
        animatorHat = GameObject.Find("HatAnim").GetComponent<Animator>();
        collider = transform.parent.GetComponent<BoxCollider2D>();
        isGrounded = false;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapBox(transform.parent.position, collider.size, 0, groundLayer);
        HandleAnimation();
    }

    private void HandleAnimation()
    {
        if (isGrounded)
        {
            if (rb.velocity.x != 0)
            {
                animator.SetTrigger("penguin_walk_do");
                animatorBowtie.SetTrigger("bowtie_walk_do");
                animatorHat.SetTrigger("bowtie_walk_do"); // change the trigger names for the hat if you're up for a useless task
            }
            else
            {
                animator.SetTrigger("penguin_idle_do");
                animatorBowtie.SetTrigger("bowtie_idle_do");
                animatorHat.SetTrigger("bowtie_walk_do");
            }
        }
        else
        {
            if (rb.velocity.y > 0f)
            {
                animator.SetTrigger("penguin_up_do");
                animatorBowtie.SetTrigger("bowtie_up_do");
                animatorHat.SetTrigger("bowtie_up_do");
            }
            else
            {
                animator.SetTrigger("penguin_down_do");
                animatorBowtie.SetTrigger("bowtie_down_do");
                animatorHat.SetTrigger("bowtie_down_do");
            }
        }
    }
}
